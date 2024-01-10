---
Title: 从0到1的解释器文档
Description: 看上去摸不着头脑，听起来简单，做起来困难的一个项目
Author: Blackteaxx
---

# 简易 Interpreter

| 学号      | 姓名 |
| --------- | ---- |
| 211820073 | 胡涂 |

[参考资料：Crafting Interpreters](http://www.craftinginterpreters.com/)

你要是一只脑子很小的熊，当你想事情的时候，你会发现，有时在你心里看起来很像回事的事情，当它展示出来，让别人看着它的时候，就完全不同了。（A. A.米尔恩，《小熊维尼》）

# 1. 项目功能

通过阅读参考资料，构建了一个简单的解释器，支持全局、局部变量，控制流语句与函数调用，值类型有 bool、nil、num 和 string。

总体实现思路为三个模块：词法分析、编译器、虚拟机，词法分析用于解析字符串预定义 TOKEN，编译器用于分析上下文并填入指令，虚拟机用于运行指令。

![20230518000600](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518000600.png)

最终效果如下：

![20230519115921](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230519115921.png)

# 2. 项目结构与实现思路

## 1. 代码存储结构-Chunk

就像汇编一样，存储指令集并能够进行执行。

并且 Chunk 中不应该只有 op，还应该有操作数，典型就是 OP_CONSTANT，获取一个常量值，那么我们就需要一个结构来存储常量。（ValueArray）
![20230517205843](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230517205843.png)

由于代码长度不固定，因此使用动态数据对 code 进行存储，结构体如下：

```
typedef struct {
    int capacity;
    int count;

    uint8_t *code;     // 存储操作码和操作数

    int *lines; // 存储行号，与code平行

    ValueArray constants;     // 存储常量值
} Chunk;
```

---

### 1.1 Value 池

Value 结构体：

值有很多种，bool、num、nil、string，于是需要一个结构体来保存 value 类型和 value 值，用联合体保存不同值是个不错的选择

Obj 是后续实现字符串与函数对象时使用的结构体。就跟在后面讲吧。

依旧是动态数组，支持 init、free、write

```
typedef struct {
    ValueType type;
    union {
        bool boolean;
        double number;
        Obj *obj; // 当Value类型是obj时，指向Obj
    } as;
} Value;

// 常量池
typedef struct {
    int capacity;
    int count;
    Value *values;
} ValueArray;
```

### 1.2 Object 结构体

由于 struct 中的元素在内存空间中是连续且按照声明顺序排布的，所以以下结构体能够通过 ObjString \*obj，的方式来实现继承。

![20230518084547](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518084547.png)

有点过度设计了，不过扩展性不错，未来可期。

```
struct Obj {
    ObjType type;
    struct Obj *next; // 链表实现GC
};

typedef struct {
    Obj obj;
    int arity; // 所需要的参数数量
    Chunk chunk;
    struct ObjString *name; // 函数名
} ObjFunction;

struct ObjString {
    Obj obj;
    int length;
    char *chars;
    uint32_t hash;
};
```

### 1.4 String 和 HashTable（Global）

string 结构体需要额外维护一个字符数组，方便释放

```
// 中间生成字符串，拥有字符的所有权，不用创建副本
ObjString *takeString(char *chars, int length);
// 源字符串中字符串，需要创建副本
ObjString *copyString(const char *chars, int length);
```

而语言中有大量的函数调用和根据标识符查询变量值，需要一个结构来存储以便查找（因为 ValueArray 只是常量池，不支持修改）

使用开放地址法解决冲突，使用负载因子（0.75）判断是否需要增长数组，使用墓碑法解决删除破坏线性查找的缺点。

所以选择哈希表存储变量，结构体如下：

```
typedef struct {
    ObjString *key;
    Value value;
} Entry;

typedef struct {
    int count;
    int capacity;
    Entry *entries;
} Table;
```

hashtable 核心函数，findEntry

```
static Entry *findEntry(Entry *entries, int capacity,
                        ObjString *key) {
    uint32_t index = key->hash % capacity;
    for(;;) {
        Entry *entry = &entries[index];
        if (entry->key == NULL) {
            if (IS_NIL(entry->value)){
                // empty
                return tombstone!=NULL ? tomestone : NULL;
            } else {
                tomestone = entry;
            }
        } else if (entry->key == key) // equal，地址相同{
            return entry;
        }
        // index+
        index++;
    }
}
```

哈希函数采用的是 FNV-1a，为了防止多次求取哈希值，选择在 copyString 和 takeString 产生 ObjString 的时候就计算出字符串哈希值并保存。

哈希需要满足产出的值均匀分布，以最大的可能性防止冲突。

```
static uint32_t hashString(const char* key, int length) {
  uint32_t hash = 2166136261u;
  for (int i = 0; i < length; i++) {
    hash ^= (uint8_t)key[i];
    hash *= 16777619;
  }
  return hash;
}
```

#### 插入

根据 findEntry 返回的 entry，判断值是否为 NIL，如果是就说明插入新的条目。如果不是（同时 key 不为 NULL），就说明要替换条目的值

#### 查找

findEntry 返回的 entry 如果是 key!=NULL,就返回，否则 false

#### 墓碑

有 tableDelete 函数，将删除的条目置为墓碑（key=NULL，value=true）

同时，墓碑也计算在大小中，同时插入时，优先插入墓碑

#### 动态

在插入之前，需要判断是否达到负载因子.

```
if (table->count + 1 > table->capacity * LOAD_FACTOR) {
    int capacity = table->capacity == 0? 8:table->capacity*2;
    adjustCapacity(table, capacity);
}
```

然后在此处延迟处理墓碑，并且将每个条目入新表

```
static void adjustCapacity(Table *table, int capacity) {
Entry *entries = alloc(entry, capacity);

    init entries;

    table->count = 0;

    // iter table
    for (int i = 0; i < table->count; i++) {
        // ignore tombstone
        if (table->entries[i].key != NULL) {
            Entry *dest = findEntry(entries, capacity, table->entries[i].key);
            dest->key = able->entries[i].key;
            dest->value = able->entries[i].value;
        }
    }

    FREE(table->entries, entry, table->capacity);

    // reset entries
    table->entries = entries;

}
```

#### 遗留的部分——字符串驻留

将所有的字符串记录放在一个 Table 中，同时 takeString 和 copyString 加入新的字符串的时候，会在 Table 中查找有没有 chars 相同的 ObjString.(实现方法就是放在 VM 结构体的 strings 哈希表中)

最后，copyString 和 takeString 的实现

值得注意的是，比较字符串是否相同，先比较 hash，再比较 length，最后 memcmp

```
ObjString *takeString(char *chars, int length) {
    uint32_t hash = hashString(chars, length);
    ObjString *interned = (ObjString *) tableFindString(&vm.strings, chars, length,
                                                        hash);
    if (interned != NULL) {
        FREE_ARRAY(char, chars, length + 1);
        return interned;
    }
    return allocateString(chars, length, hash);
}

ObjString *copyString(const char *chars, int length) {
    uint32_t hash = hashString(chars, length);
    ObjString* interned = tableFindString(&vm.strings, chars, length,
                                          hash);
    if (interned != NULL) return interned;
    char *heapChars = ALLOCATE(char, length + 1);
    memcpy(heapChars, chars, length);
    heapChars[length] = '\0';
    return allocateString(heapChars, length, hash);
}
```

### 1.5 动态数组

实现动态：

```
void writeChunk(Chunk *chunk, uint8_t byte, int line) {
    if (chunk->capacity <= chunk->count) {
        int oldCapacity = chunk->capacity;
        chunk->capacity = GROW_CAPACITY(oldCapacity);

        // realloc，这里这么麻烦是因为要垃圾回收
        chunk->code = GROW_ARRAY(uint8_t, chunk->code,
                                 oldCapacity, chunk->capacity);
        chunk->lines = GROW_ARRAY(int, chunk->lines,
                                  oldCapacity, chunk->capacity);
    }

    chunk->code[chunk->count] = byte;
    chunk->lines[chunk->count] = line;
    chunk->count++;
}
```

## 2. 后端-VM

VM 在程序进入时就要定义，用来保存全部状态

---

由于需要支持函数，因此 VM 中的指令存放在函数中

---

VM 中的 stack，代表着解释过程中存在的一些中间结果，例如

```
print 3 - 2;
```

3-2 的结果需要保存，以供后续输出

而后序遍历满足堆栈语义（也就是后缀表达式的求值可以用堆栈实现）

stack 是有大小限制的，因为 value 数组的索引受 chunk 的数据类型限制，即为 uint8_t,最高为 255

至于 frame，留到函数

---

VM 需要跟踪很多状态，chunk 就是一个，结构体如下

```
typedef struct {
    // 通过栈帧得到函数字节码块，并且有堆栈语义
    CallFrame frames[FRAMES_MAX];
    int frameCount;

    // optional
    // uint8_t *ip;// 指令指针

    // 数组实现栈，固定长度的原因是chunk中常量值索引最多255
    Value stack[STACK_MAX];
    Value *stackTop; // 运用指针比偏移量更快，初始值为0

    Table globals;
    Table strings; // 字符串驻留
    Obj *objects; // 链表头
} VM;
```

VM 主要负责解释(interpret)字节码中的指令

主要的函数是 run(),根据读取到的字节码类型分别进行操作(switch case)

## 3. 前端-Scanner

Scanner 的任务就是分析字符串并把字符串中的一些字符标记为预先定义好的 Token

可以用状态机（等价于正则），但是 clox 实现采用遍历字符串的方法，较为简单易懂。

start 指向 Token 首，current 指向当前字符，直到满足/异常停止，重新扫描时，start=current

文件以 TOKEN_EOF 结尾

Scanner 功能如下：

```
print 1 + 2;

1 31 'print'
| 21 '1'
|  7 '+'
| 21 '2'
|  8 ';'
2 39 ''
```

Scanner 结构体如下

```
typedef struct {
  const char* start;
  const char* current;
  int line;
} Scanner;
```

主要函数 scanToken

```
Token scanToken() {
    skipWhitespace();

    scanner.start = scanner.current;

    if(isAtEnd()) { return makeToken(TOKEN_EOF); }

    // 根据下一字符判断进入那个入口
    char c = advance();

    // 标识符
    if(isAlpha(c)) {
        return identifier();
    }

    // 字面量
    if(isDigit(c)) {
        return number();
    }

    switch (c) {
        // 单字符
        case '(': return makeToken(TOKEN_LEFT_PAREN);
        case ')': return makeToken(TOKEN_RIGHT_PAREN);
        case '{': return makeToken(TOKEN_LEFT_BRACE);
        case '}': return makeToken(TOKEN_RIGHT_BRACE);
        case ';': return makeToken(TOKEN_SEMICOLON);
        case ',': return makeToken(TOKEN_COMMA);
        case '.': return makeToken(TOKEN_DOT);
        case '-': return makeToken(TOKEN_MINUS);
        case '+': return makeToken(TOKEN_PLUS);
        case '*': return makeToken(TOKEN_STAR);
        case '/': return makeToken(TOKEN_SLASH);

        // 2字符
        case '!':
            return makeToken(
                    match('=') ? TOKEN_BANG_EQUAL : TOKEN_BANG);
        case '=':
            return makeToken(
                    match('=') ? TOKEN_EQUAL_EQUAL : TOKEN_EQUAL);
        case '<':
            return makeToken(
                    match('=') ? TOKEN_LESS_EQUAL : TOKEN_LESS);
        case '>':
            return makeToken(
                    match('=') ? TOKEN_GREATER_EQUAL : TOKEN_GREATER);

        // 字面量
        case '"': return string();

    }

    return errorToken("Unexpected character. ");

}
```

此模块在技术上没有什么难度，值得说的也就是如何区分关键字和标识符。

也就相当于枚举然后暴力匹配了..

```
static TokenType identifierType() {
    switch (scanner.start[0]) {
        case 'a': return checkKeyword(1, 2, "nd", TOKEN_AND);
        case 'c': return checkKeyword(1, 4, "lass", TOKEN_CLASS);
        case 'e': return checkKeyword(1, 3, "lse", TOKEN_ELSE);
        case 'f': {
            if (scanner.current - scanner.start > 1) {
                switch (scanner.start[1]) {
                    case 'a': return checkKeyword(2, 3, "lse", TOKEN_FALSE);
                    case 'o': return checkKeyword(2, 1, "r", TOKEN_FOR);
                    case 'u': return checkKeyword(2, 1, "n", TOKEN_FUN);
                }
            }
        }
        case 'i': return checkKeyword(1, 1, "f", TOKEN_IF);
        case 'n': return checkKeyword(1, 2, "il", TOKEN_NIL);
        case 'o': return checkKeyword(1, 1, "r", TOKEN_OR);
        case 'p': return checkKeyword(1, 4, "rint", TOKEN_PRINT);
        case 'r': return checkKeyword(1, 5, "eturn", TOKEN_RETURN);
        case 's': return checkKeyword(1, 4, "uper", TOKEN_SUPER);
        case 't': {
            if (scanner.current - scanner.start > 1) {
                switch (scanner.start[1]) {
                    case 'h': return checkKeyword(2, 2, "is", TOKEN_THIS);
                    case 'r': return checkKeyword(2, 2, "ue", TOKEN_TRUE);
                }
            }
        }

        case 'v': return checkKeyword(1, 2, "ar", TOKEN_VAR);
        case 'w': return checkKeyword(1, 4, "hile", TOKEN_WHILE);
    }


    return TOKEN_IDENTIFIER;
}

```

## 4. 编译-Compiler

最主要的部分，将 TOKEN 转化为 ByteCode 以供 VM 执行。

解析表达式采用 Vaughan Pratt 的“自顶向下算符优先解析”，比较方便的处理了优先级以及结合性。

此处分为解析 TOKEN 和生成 ByteCode 两个部分。

---

解析的核心在于 Parser 结构体：

```
typedef struct {
    Token previous;
    Token current;
    bool hadError;
    bool panicMode;
} Parser;
```

核心函数在于 advance
值得一提的是，parser 的 previous 和 current 的使用很让人迷惑

```
// 解析标识函数
static void advance() {
    // 获取旧标识
    parser.previous = parser.current;

    for (;;) {
        parser.current = scanToken();

        // 不断循环直到到达一个没有错误的标识或者到达终点
        if (parser.current.type != TOKEN_ERROR) { break; }
        errorAtCurrent(parser.current.start);
    }
}
```

解析报告异常模块就不多讲了，放进去显得臃肿。

---

生成代码，需要得到 chunk，然后将 TOKEN 与 OP 对应起来。

这里的 chunk 在后期属于每一个函数都要有单独的 chunk，所以获取当前 chunk 要封装成一个函数。

写入常数有 emitConstant 函数

遇见小括号：
递归解析表达式

```
static void grouping() {
  expression();
  consume(TOKEN_RIGHT_PAREN, "Expect ')' after expression.");
}
```

遇见前缀（一元）表达式：

```
static void unary() {
  TokenType operatorType = parser.previous.type;

  // Compile the operand.
  parsePrecedence(PREC_UNARY);

  // Emit the operator instruction.
  switch (operatorType) {
      emitByte(OP)
  }
}
```

遇见二元表达式:

```
static void binary() {
  TokenType operatorType = parser.previous.type;
  // 函数指针
  ParseRule* rule = getRule(operatorType);
  parsePrecedence((Precedence)(rule->precedence + 1));

  switch (operatorType) {
    emitByte(OP)
  }
}

```

解析二元表达式的时候，就遇见了优先级和结合性的问题，这里就用到了 Pratt

算符优先级如下：

```
typedef enum {
    PREC_NONE,
    PREC_ASSIGNMENT,  // =
    PREC_OR,          // or
    PREC_AND,         // and
    PREC_EQUALITY,    // == !=
    PREC_COMPARISON,  // < > <= >=
    PREC_TERM,        // + -
    PREC_FACTOR,      // * /
    PREC_UNARY,       // ! -
    PREC_CALL,        // . ()
    PREC_PRIMARY
} Precedence;
```

```
static void expression () {
    // 从最低级开始
    parsePrecedence(PREC_ASSIGNMENT);
}
```

### Pratt 算法

Pratt Parser 主要函数伪代码

```
def parsePrecedence(Precedence precedence) {
    advance();
    ParseFn prefixRule = getRule(parser.previous.type)->prefix;
    prefixRule();

    while(precedence <= rules[curToken.type].precedence) {
        advance();
        ParseFn infixRule = getRule(parser.previous.type)->infix;
        infixRule();
    }
}
```

值得注意的是，常量也算作前缀词素

虽然看着很吓人，有迭代和递归。
但是实际上对于表达式，他的实际作用仅仅相当于将中缀表达式变换为后缀表达式,只是多了一个前缀符号的处理(negate/constant)

**一个非常简单的例子**

```
(-1 + 2) * 3
- Advance()

- parsePrecedence('=')
    - Advance()
    - prefixFn('(') // grouping
        - parsePrecedence('=')
            - Advance()
            - prefixFn('-')
                - parsePrecedence('-')
                    - Advance()
                    - prefixFn('1')
                    - return(because '-' > '+')
                - return
            - Advance()
            - infixFn('+')
                - parsePrecedence('+' + 1)
                    - Advance()
                    - prefixFn('2')
                    - return(because '+' + 1 > ')')
                - return
            - return
        - return
    - Advance()
    - infixFn('*')
        - parsePrecedence('*' + 1)
            - infixFn('3')
            - return(because Token_EOF)
        - return
    - return
```

## 5. 语法的实现

### 5.1 Syntax

```
declaration    → funDecl
               | varDecl
               | statement ;

funDecl        → "fun" function ;
varDecl        → "var" IDENTIFIER ( "=" expression )? ";" ;

statement      → exprStmt
               | forStmt
               | ifStmt
               | printStmt
               | returnStmt
               | whileStmt
               | block ;

exprStmt       → expression ";" ;
forStmt        → "for" "(" ( varDecl | exprStmt | ";" )
                           expression? ";"
                           expression? ")" statement ;
ifStmt         → "if" "(" expression ")" statement
                 ( "else" statement )? ;
printStmt      → "print" expression ";" ;
returnStmt     → "return" expression? ";" ;
whileStmt      → "while" "(" expression ")" statement ;
block          → "{" declaration* "}" ;

```

### 5.2 逻辑运算符

==，!=，<，>，<=和>=

!=、<=和>=可以转化为== !、> !、< !

### 5.3 全局变量

![20230518164139](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518164139.png)

思路很简单，在 VM 中设置一个 HashTable，将名称与变量值存进去，要用就查，要放就插。

PS:所有的操作数都有一个堆栈效应，而表达式的堆栈效应是 1，最终会在 vm 中的 stack 留下一个值，所有语句的堆栈效应都是 0，因为不会留下任何值。所以 expressionStat 最后要添加一个 OP_POP

具体实现就是：compiler 在编译为标识符变量，向常量表中加入 ObjString，然后解析初始化值，最后利用 OP_DEFINE_GLOBAL 使得 vm 直到开始解析全局变量

#### 定义

```
static void varDeclaration() {
    // 写入字节码，global为索引
    uint8_t global = parseVariable("Expect variable name.");

    // 看看是否初始化
    if (match(TOKEN_EQUAL)) {
        expression();
    } else {
        emitByte(OP_NIL);
    }

    // 结尾要有分号
    consume(TOKEN_SEMICOLON, "Expect ';' after variable"
                             "declaration.");


    // 写入OP_DEFINE_GLOBAL 与索引值
    defineVariable(global);
}
```

#### 读取和写入

还是依靠 Pratt 解析算法，将 identifier 的前缀解析规则定义为解析变量，具体思路就是获取 ObjString，然后来个 OP_GET_GLOBAL

```
static void namedVariable(Token name) {
  uint8_t arg = identifierConstant(&name);
  if (match(TOKEN_EQUAL)){
    expression();
    emitBytes(OP_SET_GLOBAL, arg)
  } else {
    emitBytes(OP_GET_GLOBAL, arg);
  }
}
```

后端很简单，简单放一下

```
            case OP_SET_GLOBAL: {
                ObjString *name = READ_STRING();
                if (tableSet(&vm.globals, name, peek(0))) {
                    tableDelete(&vm.globals, name);
                    runtimeError("Undefined variable '%s'", name->chars);
                    return INTERPRET_RUNTIME_ERROR;
                }
                break;
            }
            case OP_GET_GLOBAL: {
                ObjString *name = READ_STRING();
                Value value;
                if (!tableGet(&vm.globals, name, &value)) {
                    runtimeError("Undefined variable %s", name->chars);
                    return INTERPRET_RUNTIME_ERROR;
                }
                push(value);
                break;
            }
```

### 5.4 局部变量

![20230518164139](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518164139.png)

局部变量是最常用的，局部变量的缓慢会导致整体运行的缓慢，因此局部变量的实现采用了与全局变量完全不同的一种实现方式。

局部变量在代码块中有堆栈语义。因此，可以将局部变量存放在一个栈中，用偏移量取值。

所以，在 compiler 结构体中保存局部变量的状态:

```
typedef struct {
  Token name;
  int depth;
} Local;

typedef struct {
  Local locals[UINT8_COUNT];
  int localCount;
  int scopeDepth;
} Compiler;
```

局部变量是在 block 中产生的，也就是说，遇见 block 中的'{'，就要将 Compiler 中的 scopeDepth++。

而除了在 block 中，其余上下文与全局变量没有差异，所以需要在 varDeclaration 中的 parseVariable 和 defineVariable 和解析标识符的 variable 三个函数做修改.

```
// 定义局部变量
static void declareVariable() {
    if (current->scopeDepth == 0) {
        return;
    }

    Token *name = &parser.previous;

    for (int i = current->localCount - 1; i > 0 ; i--) {
        // 同作用域比较是否有标识符相同
        Local *local = &current->locals[i];
        if (local->depth != -1 && local->depth < current->scopeDepth) {
            break;
        }

        if (identifierEqual(name, &local->name)) {
            error("Already a variable with this name in this scope.");
        }
    }

    addLocal(*name);// 向compiler加入局部变量状态
}

static uint8_t parseVariable(const char *errormessage) {
    consume(TOKEN_IDENTIFIER, errormessage);
    // 填入局部变量
    declareVariable();

    // 局部变量
    if (current->scopeDepth > 0) { return 0;}// 这边会返回一个假的索引，defineVariable函数也不会投入这个index值
    return identifierConstant(&parser.previous);
}
```

为什么会不用生成索引，甚至连字节码都不用生成呢？见下例

![20230518165107](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518165107.png)

最后值在 VM stack 中留下的位置就是 Compiler 中 locals 栈槽的索引

同时，在块结束的时候，需要把同层局部变量全部 pop 出，即 endScope

```
static void endScope() {
    current->scopeDepth--;

    // 删去底层作用域的局部变量
    while (current->localCount > 0 &&
            current->locals[current->localCount - 1].depth > current->scopeDepth) {
        emitByte(OP_POP);
        current->localCount--;
    }
}
```

同时，在表达式中的局部变量识别也需要修改，具体就是全局变量提到过的 namedVariable 函数
resolveLocal 就是在局部变量 locals 数组中寻找 name 局部变量，找到就返回索引，找不到就返回-1.

```
// 标识符前缀运算
static void namedVariable(Token name, bool canAssign) {
    uint8_t getOp, setOp;

    // 解析局部变量
    int arg = resolveLocal(current, &name);

    if (arg != -1) {
        getOp = OP_GET_LOCAL;
        setOp = OP_SET_LOCAL;
    } else {
        arg = identifierConstant(&name);
        getOp = OP_GET_GLOBAL;
        setOp = OP_SET_GLOBAL;
    }

    if (canAssign && match(TOKEN_EQUAL)) {
        expression();
        emitBytes(setOp, (uint8_t)arg);
    } else{
        emitBytes(getOp, (uint8_t)arg);
    }
}
```

于是，根据相对索引取值就成了局部变量设计的核心，非常神奇，此处在后续函数栈帧有更神奇的应用。

后端不难写出如下代码：

```
            case OP_GET_LOCAL: {
                uint8_t slot = READ_BYTE();
                push(frame->slots[slot]);
                break;
            }
            case OP_SET_LOCAL: {
                uint8_t slot = READ_BYTE();
                frame->slots[slot] = peek(0);
                break;
            }
```

依旧提供这张图，更加清晰地展示栈索引是如何对应上的

![20230518165107](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518165107.png)

### 5.5 控制流语句

控制流语句的实现是使用类似于 goto 的跳转指令实现的，因为字节码是线性的，没法使用 AST 的方法。

并没有什么详细可说的原理，也没有解释健壮性，但是就是可以运行成功。

#### if

![20230518192213](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518192213.png)

先记录好要回填 jump 多少格的值在 chunk 中的索引，到指定位置再进行回填。

因为 if 和 else 只能进行一个语句，所以要设置两个跳转，分别对应 condition 真和假

```
condition + thenJump + | pop + statement + elseJump + | pop + (else)
     (+ statement)

```

```
static void ifStatement() {

    // 条件语句，条件值留在栈顶，留作JUMP条件
    consume(TOKEN_LEFT_PAREN, "Expect '(' after if.");
    expression();
    consume(TOKEN_RIGHT_PAREN, "Expect ')' after condition.");

    // 此操作符有操作数，操作数在判断完代码块后回填
    // 返回在chunk中的偏移量
    int thenJump = emitJump(OP_JUMP_IF_FALSE);
    emitByte(OP_POP);

    // 执行语句
    statement();

    // 条件为真的偏移量
    int elseJump = emitJump(OP_JUMP);

    patchJump(thenJump);
    // 让条件为假的偏移量在POP前面
    emitByte(OP_POP);

    // 匹配ELSE
    if (match(TOKEN_ELSE)) {
        statement();
    }

    // 写入偏移量，指令在then statement之后
    patchJump(elseJump);
}
```

后端也很简单，根据偏移量偏移 ip 就行

```
            case OP_JUMP_IF_FALSE: {
                uint16_t offset = READ_SHORT();
                if (isFalsey(peek(0))) {
                    frame->ip = frame->ip + offset;
                }
                break;
            }
            case OP_JUMP: {
                uint16_t offset = READ_SHORT();
                frame->ip = frame->ip + offset;
                break;
            }
```

#### 逻辑运算符

![20230518192730](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518192730.png)

因为要支持短路运算，所以放到控制流语句里进行实现

值得注意的是，leftExp 若为假，则整个式子为假，只要左值。若为真，则要依靠右值，所以 pop 只有一个。

TOKEN_AND 的 中缀运算规则

```
leftExp + endJump + | pop + rightExp + | ...
```

```
static void and_(bool canAssign) {
  int endJump = emitJump(OP_JUMP_IF_FALSE);

  emitByte(OP_POP);
  parsePrecedence(PREC_AND);

  patchJump(endJump);
}
```

TOKEN_OR 也是类似处理，不做赘述。

#### while

![20230518193055](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518193055.png)

很简单，不做赘述

```
condition + exitJump + | pop + statement + loop(跳转至条件) + | pop
```

```
static void whileStatement() {
    int loopStart = currentChunk()->count;

    // 条件语句，条件值留在栈顶，留作JUMP条件
    consume(TOKEN_LEFT_PAREN, "Expect '(' after while.");
    expression();
    consume(TOKEN_RIGHT_PAREN, "Expect ')' after condition.");

    int exitJump = emitJump(OP_JUMP_IF_FALSE);
    emitByte(OP_POP);

    statement();

    // 循环向回跳，这个指令需要直到向前多远(到条件表达式之前)
    emitLoop(loopStart);

    patchJump(exitJump);
    emitByte(OP_POP);
}
```

#### for

for 循环较为复杂，有三个子句可以选择：

语法如下

```
"for" "(" ( varDecl | exprStmt | ";" )
        expression? ";"
        expression? ")" statement ;
```

仔细分析不难发现，varDecl 只需开头执行一遍，condition 与 whilecondition 类似，作为 loop 的开头，expression 作为迭代条件放于 statement 的后面，在运行之后进行 loop，因此我们可以画出如下流程。

![20230518193659](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518193659.png)

编译如下：

```
varDeclaration + condition + exitJump + | pop +
bodyJump(跳到statement) + loopexp + pop + loop(跳转至条件) +
statement + loop(跳转至loopexp) + |pop
```

```
// for
static void forStatement() {


    // 变量作用域受限在循环体中
    beginScope();

    consume(TOKEN_LEFT_PAREN, "Expect '(' after for.");

    // 解析初始化子句
    if (match(TOKEN_SEMICOLON)) {
        // 没有初始化
        ;
    } else if (match(TOKEN_VAR)) {
        varDeclaration();
    } else {
        expressionStatement();
    }

    int loopStart = currentChunk()->count;

    // 退出循环的条件子句
    int exitJump = -1;
    if (!match(TOKEN_SEMICOLON)) {
        expression();
        consume(TOKEN_SEMICOLON, "Expect ';' after loop condition.");

        exitJump = emitJump(OP_JUMP_IF_FALSE);
        emitByte(OP_POP);
    }

    // 增量子句
    if (!match(TOKEN_RIGHT_PAREN)) {
        int bodyJump = emitJump(OP_JUMP);
        int incrementStart = currentChunk()->count;

        // 增量子句
        expression();
        emitByte(OP_POP);
        consume(TOKEN_RIGHT_PAREN, "Expect ')' after loop condition.");

        emitLoop(loopStart);
        loopStart = incrementStart;
        patchJump(bodyJump);
    }

    statement();

    emitLoop(loopStart);
    // 修补退出子句
    if (exitJump != -1) {
        // 如果没有条件子句，就不需要退出，也不需要弹出表达式值
        patchJump(exitJump);
        emitByte(OP_POP);
    }

    endScope();
}
```

由于时间关系，没有考虑 switch-case 的实现。

### 5.6 函数

函数的主要实现思路就是，将每一个函数的字节码单独处理（Compiler），放到一个栈帧中，要调用的时候将字节码并入解释（VM）。

想法很简单，但是需要重构 Compiler 和 VM 的实现，以支持函数中的局部变量索引，同时支持返回值。

**首先是函数对象结构体：**
函数有它所属的独立 Chunk

```
typedef struct {
    Obj obj;
    int arity; // 所需要的参数数量
    Chunk chunk;
    struct ObjString *name; // 函数名
} ObjFunction;
```

**同时将代码的顶层也视为一层函数，封装在 Compiler 中：**

```
typedef struct Compiler{
    // 编译器栈链表
    struct Compiler *enclosing;

    // Local
    Local locals[UINT8_COUNT]; // 记录所有局部变量
    int localCount;
    int scopeDepth; // 编译的当前代码外围的代码块数量：0、1、2...
    // 并且用于跟踪哪个局部变量属于哪个块，便于弹出

    // 顶层Function
    ObjFunction *function;
    FunctionType type; //  说实话，没什么用，只在一两个地方有用
} Compiler;
```

在进行编译时，对 Compiler 进行 init，包装一个顶层 Function 给它，使它有一个可用的 chunk

在结束编译时，endCompiler 会返回一个 function 给 VM 进行解释。

#### 后端的实现思路

**Problem 1：**

如何解决局部变量的索引问题

解决思路：每一个函数内局部变量索引位置是一定的，因此绝对索引只依赖于 stack 栈槽到哪里了，即取决于 stack 的当前状态，基于此，可以采用栈帧的思路。

栈帧就是相对索引+绝对起始位置

![20230518200333](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518200333.png)

**Problem 2：**

如何返回值

虚拟机需要返回到调用函数的字节码块，并在调用之后立即恢复执行指令。因此，对于每个函数调用，在调用完成后，需要记录调用完成后需要跳回什么地方。这被称为返回地址，因为它是虚拟机在调用后返回的指令的地址。

这是调用函数的属性，不是被调用函数的属性。

**Summary**

因此对于每个被调用的函数，我们需要记录局部变量的开始位置，以及返回地址。这需要一个新的结构体来存储，被称为栈帧。

```
typedef struct {
    ObjFunction *function;
    uint8_t *ip; // function中的字节码
    Value *slots;// 能够使用虚拟机的第一个栈槽，并可以存储需要返回的地址
} CallFrame;
```

而存储函数调用的先后结构，并且要生成这样一个栈帧序列，考虑到函数调用的堆栈语义，用一个栈来存储栈帧。

最多支持调用 FRAMES_MAX(64)层函数

```
typedef struct {
    // 通过栈帧得到函数字节码块，并且有堆栈语义
    CallFrame frames[FRAMES_MAX];
    int frameCount;

    // 数组实现栈，固定长度的原因是chunk中常量值索引最多255
    Value stack[STACK_MAX];
    Value *stackTop; // 运用指针比偏移量更快，初始值为0

    Table globals;
    Table strings;
    Obj *objects; // 链表头
} VM;
```

后端的修改只需要改获取 ip 的每一行代码就可以了，不做赘述。注意：要在第一行先获取顶层 frame

#### 前端的解决思路

**声明**

还是一样的思路，编译函数有专门的入口函数，需要先解析函数名，然后再编译参数列表以及代码块。

总体效应相当于讲 function 作为值，name 作为键存储到 global 哈希表中了

```
static void funDeclaration() {
    uint8_t global = parseVariable("Expect function name");

    function(TYPE_FUNCTION);
    defineVariable(global);
}
```

由于要编译多个函数，所以需要很多 compiler，用一个链表进行存储（就是用链表实现栈了），endCompiler 时返回 Compiler 中的 function，并且使 current = current->next;

```
static void function(FunctionType type) {
    // 嵌套函数定义，使用Compiler栈
    Compiler compiler;
    initCompiler(&compiler, type);

    // parameters(is local)
    current->scopeDepth++;
    consume(TOKEN_LEFT_PAREN, "Expect '(' after function name.");
    if (!check(TOKEN_RIGHT_PAREN)) {
        do {
            // 解析参数列表
            current->function->arity++;
            uint8_t constant = parseVariable("Expect parameter name.");
            defineVariable(constant);
        } while (match(TOKEN_COMMA));
    }
    consume(TOKEN_RIGHT_PAREN, "Expect ')' after function parameters.");

    // block
    consume(TOKEN_LEFT_BRACE, "Expect '{' before function body.");
    block();

    ObjFunction *function = endCompiler();
    emitBytes(OP_CONSTANT, makeConstant(OBJ_VAL(function)));
}
```

**调用**

调用的语法依旧是 Pratt 算法实现，(作为中缀运算符，紧跟在函数声明的后面，并进行参数列表的解析

```
static void call(bool canAssign) {
  uint8_t argCount = argumentList();
  emitBytes(OP_CALL, argCount);
}
```

```
static uint8_t argumentList() {
  uint8_t argCount = 0;
  if (!check(TOKEN_RIGHT_PAREN)) {
    do {
      expression();
      argCount++;
    } while (match(TOKEN_COMMA));
  }
  consume(TOKEN_RIGHT_PAREN, "Expect ')' after arguments.");
  return argCount;
}
```

#### 前后端结合

有了函数调用的代码块之后，如何解决形参与实参结合的问题？
有如下例子

```
fun sum(a, b, c) {
  return a + b + c;
}

print 4 + sum(5, 6, 7);
```

(字节码第一位已经改成了供内部占用的槽)
![20230518204235](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518204235.png)

因此，很简单就能看出实现思路，就如上文所说的 frame 结构体中 ip 的作用一致。

case 如下

```
      case OP_CALL: {
        int argCount = READ_BYTE();
        if (!callValue(peek(argCount), argCount)) {
          return INTERPRET_RUNTIME_ERROR;
        }
        break;
      }

// callee 即为从globals找出的function对象
static bool callValue(Value callee, int argCount) {
    if (IS_OBJ(callee)) {
        switch (OBJ_TYPE(callee)) {
            case OBJ_FUNCTION:
                return call(AS_FUNCTION(callee), argCount);
            default:
                break; // Non-callable
        }
    }
    runtimeError("Can only call function!");
    return false;
}

// 处理函数调用
static bool call(ObjFunction *function, int argCount) {
    // 参数不匹配
    if (function->arity != argCount) {
        runtimeError("Expected %d arguments but got %d.",
                     function->arity, argCount);
        return false;
    }

    // 调用链超出大小
    if (vm.frameCount == FRAMES_MAX) {
        runtimeError("Stack overflow.");
        return false;
    }

    // 设置栈帧
    CallFrame *frame = &vm.frames[vm.frameCount++];
    frame->function = function;
    frame->ip = function->chunk.code;
    frame->slots = vm.stackTop - argCount - 1;// 从函数名开始
    return true;
}
```

frame 存储了一个指向被调用函数的指针，并将调用帧的 ip 指向函数字节码的开始处。最后，它设置 slots 指针，告诉调用帧它在栈上的窗口位置。这里的算法可以确保栈中已存在的实参与函数的形参是对齐的

后端读取局部变量就很简单了，把 SET 和 GET 对 stack 改成对 slots

```
            case OP_GET_LOCAL: {
                uint8_t slot = READ_BYTE();
                push(frame->slots[slot]);
                break;
            }
            case OP_SET_LOCAL: {
                uint8_t slot = READ_BYTE();
                frame->slots[slot] = peek(0);
                break;
            }
```

![20230518205014](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518205014.png)

**返回值**

```
            case OP_RETURN: {
                Value result = pop();
                vm.frameCount--;
                if (vm.frameCount == 0) {
                    pop();
                    return INTERPRET_OK;
                }

                // 覆盖栈顶
                vm.stackTop = frame->slots;
                push(result);
                frame = &vm.frames[vm.frameCount - 1];
                break;
            }
```

![20230518205241](https://cdn.jsdelivr.net/gh/Blackteaxx/Graph@master/img/20230518205241.png)


# 3. 总结

