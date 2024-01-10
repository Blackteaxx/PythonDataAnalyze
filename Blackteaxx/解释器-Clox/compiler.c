//
// Created by 86139 on 2023-04-01.
//

#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <strings.h>
#include "common.h"
#include "compiler.h"
#include "scanner.h"

#ifdef DEBUG_PRINT_CODE
#include "debug.h"
#endif

typedef struct {
    Token previous;
    Token current;
    bool hadError;
    bool panicMode;
} Parser;

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

// 函数指针
typedef void (*ParseFn)(bool canAssign);

typedef struct {
    ParseFn prefix;
    ParseFn infix;
    Precedence precedence;
} ParseRule;

typedef struct {
    Token name;
    int depth;
} Local;

typedef enum {
    TYPE_FUNCTION,
    TYPE_SCRIPT
} FunctionType;

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

Parser parser;
Compiler *current = NULL;

static Chunk *currentChunk() {
    // 对Chunk进行封装，返回顶层Function的Chunk
    return &(current->function->chunk);
}

static void errorAt(Token *token, const char *message) {
    if (parser.panicMode) return;

    fprintf(stderr, "[line %d] Error", token->line);

    if (token->type == TOKEN_EOF) {
        fprintf(stderr, "at end");
    } else if (token->type == TOKEN_ERROR) {
        // nothing
    } else {
        fprintf(stderr, "at '%.*s'", token->length, token->start);
    }

    fprintf(stderr, ": %s\n", message);
    parser.hadError = true;
    parser.panicMode = true;
}


static void error(const char *message) {
    errorAt(&parser.previous, message);
}

static void errorAtCurrent(const char *message) {
    errorAt(&parser.current, message);
}

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

// 读取下一个标识，验证标识是否具有预期的类型
static void consume(TokenType type, const char *message) {
    if (parser.current.type == type) {
        advance();
        return;
    }

    errorAtCurrent(message);
}

static bool check(TokenType type) {
    return parser.current.type == type;
}

static bool match(TokenType type) {
    if(!check(type)) {
        return false;
    }
    advance();
    return true;
}

// 向块中追加一个字节
static void emitByte(uint8_t byte) {
    writeChunk(currentChunk(), byte, parser.previous.line);
}

// 写入一个操作符和操作数
static void emitBytes (uint8_t byte1, uint8_t byte2) {
    emitByte(byte1);
    emitByte(byte2);
}

static int emitJump(uint8_t instruction) {
    emitByte(instruction);
    emitByte(0xff);
    emitByte(0xff);
    return currentChunk()->count - 2;
}

static void emitLoop(int loopStart) {
    emitByte(OP_LOOP);

    int offset = currentChunk()->count - loopStart + 2;
    if (offset > UINT16_MAX) error("Loop body too large.");

    emitByte((offset >> 8) & 0xff);
    emitByte(offset & 0xff);
}

static void emitReturn() {
    // 隐式返回NIL
    emitByte(OP_NIL);
    emitByte(OP_RETURN);
}

static uint8_t makeConstant (Value value) {
    int constant = addConstant(currentChunk(), value);

    if (constant > 255) {
        error("Too many constants in one chunk.");
        return 0;
    }

    return (uint8_t)constant;
}

static void emitConstant(Value value) {
    emitBytes(OP_CONSTANT, makeConstant(value));
}

static void patchJump(int offset) {
    // -2 是因为offset所在与后一个是操作数，
    // 而jump则代表读取完后两个存放jump的操作数然后跳转的偏移量
    int jump = currentChunk()->count - offset - 2;

    if (jump > UINT16_MAX) {
        error("Too much code to jump over.");
    }

    // 分别存放高八位和低八位
    currentChunk()->code[offset] = (jump >> 8) & 0xff;
    currentChunk()->code[offset + 1] = jump & 0xff;
}

static void initCompiler(Compiler *compiler,
                         FunctionType type) {
    // linked, 自底向上链接
    compiler->enclosing = current;

    // local
    compiler->localCount = 0;
    compiler->scopeDepth = 0;

    // function
    compiler->function = newFunction();
    compiler->type = type;

    // 更变current
    current = compiler;

    // 填入函数名
    if (current->type != TYPE_SCRIPT) {
        current->function->name = copyString(parser.previous.start,
                                             parser.previous.length);
    }

    // 要求局部变量栈槽0供内部使用
    Local *local = &(current->locals[current->localCount++]);
    local->depth = 0;
    local->name.start = "";
    local->name.length = 0;
}

static ObjFunction *endCompiler() {
    emitReturn();
    ObjFunction *function = current->function;
#ifdef DEBUG_PRINT_CODE
    if (!parser.hadError) {
        disassembleChunk(currentChunk(), "code");
#endif
    current = current->enclosing;
    return function;
}

// 开始代码块
static void beginScope() {
    current->scopeDepth++;
}

// 结束代码块
static void endScope() {
    current->scopeDepth--;

    // 删去底层作用域的局部变量
    while (current->localCount > 0 &&
            current->locals[current->localCount - 1].depth > current->scopeDepth) {
        emitByte(OP_POP);
        current->localCount--;
    }
}

static void expression();
static ParseRule *getRule(TokenType type);
static void parsePrecedence(Precedence precedence);
static uint8_t identifierConstant(Token *name);
static void declaration();
static void and_(bool canAssign);
static void or_(bool canAssign);
static uint8_t argumentList();

// 中缀解析
static void binary(bool canAssign) {
    TokenType operatorType = parser.previous.type;
    ParseRule *rule = getRule(operatorType);
    // 因为二元操作符是左结合的
    parsePrecedence((Precedence)(rule->precedence + 1));

    switch (operatorType) {
        case TOKEN_BANG_EQUAL: {
            emitBytes(OP_EQUAL, OP_NOT);
            break;
        }
        case TOKEN_EQUAL_EQUAL: {
            emitByte(OP_EQUAL);
            break;
        }
        case TOKEN_GREATER: {
            emitByte(OP_GREATER);
            break;
        }
        case TOKEN_GREATER_EQUAL: {
            emitBytes(OP_LESS, OP_NOT);
            break;
        }
        case TOKEN_LESS: {
            emitByte(OP_LESS);
            break;
        }
        case TOKEN_LESS_EQUAL: {
            emitBytes(OP_GREATER, OP_NOT);
            break;
        }
        case TOKEN_PLUS: {
            emitByte(OP_ADD);
            break;
        }
        case TOKEN_MINUS: {
            emitByte(OP_SUBTRACT);
            break;
        }
        case TOKEN_STAR: {
            emitByte(OP_MULTIPLY);
            break;
        }
        case TOKEN_SLASH: {
            emitByte(OP_DIVIDE);
            break;
        }
        default: return;
    }
}

// 函数调用



static void call(bool canAssign) {
    uint8_t argCount = argumentList();
    emitBytes(OP_CALL, argCount);
}

static void literal(bool canAssign) {
    switch (parser.previous.type) {
        case TOKEN_FALSE:  {
            emitByte(OP_FALSE);
            break;
        }
        case TOKEN_TRUE:  {
            emitByte(OP_TRUE);
            break;
        }
        case TOKEN_NIL:  {
            emitByte(OP_NIL);
            break;
        }
        default: return; // unreachable
    }
}

// 分组解析
static void grouping(bool canAssign) {
    // 递归调用expression来编译括号内的表达式
    expression();
    consume(TOKEN_RIGHT_PAREN, "Except ')' after expression.");
}

static void number(bool canAssign) {
    double value = strtod(parser.previous.start, NULL);
    emitConstant(NUMBER_VAL(value));
}

static void string(bool canAssign) {
    // +1 -2 去除双引号

    emitConstant(OBJ_VAL(copyString(parser.previous.start + 1,
                                    parser.previous.length - 2)));
}

static bool identifierEqual(Token *a, Token *b);

// 解析是局部变量还是全局变量
static int resolveLocal(Compiler *compiler, Token *name) {
    //  如果是局部变量则返回在栈中的位置

    for (int i = compiler->localCount - 1; i >= 0; i--) {

        if (compiler->locals[i].depth == -1) {
            error("Can not read local variable in its"
                  "own initializer");
        }

        Local *local = &compiler->locals[i];
        if (identifierEqual(name, &local->name)) {
            return i;
        }
    }

    return -1;
}

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

// 标识符前缀运算
static void variable(bool canAssign) {
    namedVariable(parser.previous, canAssign);
}

static void unary(bool canAssign) {
    TokenType operateorType = parser.previous.type;

    // 编译操作数
    parsePrecedence(PREC_UNARY);

    // 写入操作码
    switch (operateorType) {
        case TOKEN_MINUS: {
            emitByte(OP_NEGATE);
            break;
        }
        case TOKEN_BANG: {
            emitByte(OP_NOT);
            break;
        }
        default: return;
    }
}

ParseRule rules[] = {
        [TOKEN_LEFT_PAREN]    = {grouping, call,   PREC_CALL},
        [TOKEN_RIGHT_PAREN]   = {NULL,     NULL,   PREC_NONE},
        [TOKEN_LEFT_BRACE]    = {NULL,     NULL,   PREC_NONE},
        [TOKEN_RIGHT_BRACE]   = {NULL,     NULL,   PREC_NONE},
        [TOKEN_COMMA]         = {NULL,     NULL,   PREC_NONE},
        [TOKEN_DOT]           = {NULL,     NULL,   PREC_NONE},
        [TOKEN_MINUS]         = {unary,    binary, PREC_TERM},
        [TOKEN_PLUS]          = {NULL,     binary, PREC_TERM},
        [TOKEN_SEMICOLON]     = {NULL,     NULL,   PREC_NONE},
        [TOKEN_SLASH]         = {NULL,     binary, PREC_FACTOR},
        [TOKEN_STAR]          = {NULL,     binary, PREC_FACTOR},
        [TOKEN_BANG]          = {unary,    NULL,   PREC_NONE},
        [TOKEN_BANG_EQUAL]    = {NULL,     binary, PREC_EQUALITY},
        [TOKEN_EQUAL]         = {NULL,     NULL,   PREC_NONE},
        [TOKEN_EQUAL_EQUAL]   = {NULL,     binary, PREC_EQUALITY},
        [TOKEN_GREATER]       = {NULL,     binary, PREC_COMPARISON},
        [TOKEN_GREATER_EQUAL] = {NULL,     binary, PREC_COMPARISON},
        [TOKEN_LESS]          = {NULL,     binary, PREC_COMPARISON},
        [TOKEN_LESS_EQUAL]    = {NULL,     binary, PREC_COMPARISON},
        [TOKEN_IDENTIFIER]    = {variable, NULL,   PREC_NONE},
        [TOKEN_STRING]        = {string,   NULL,   PREC_NONE},
        [TOKEN_NUMBER]        = {number,   NULL,   PREC_NONE},
        [TOKEN_AND]           = {NULL,     and_,   PREC_AND},
        [TOKEN_CLASS]         = {NULL,     NULL,   PREC_NONE},
        [TOKEN_ELSE]          = {NULL,     NULL,   PREC_NONE},
        [TOKEN_FALSE]         = {literal,  NULL,   PREC_NONE},
        [TOKEN_FOR]           = {NULL,     NULL,   PREC_NONE},
        [TOKEN_FUN]           = {NULL,     NULL,   PREC_NONE},
        [TOKEN_IF]            = {NULL,     NULL,   PREC_NONE},
        [TOKEN_NIL]           = {literal,  NULL,   PREC_NONE},
        [TOKEN_OR]            = {NULL,     or_,    PREC_OR},
        [TOKEN_PRINT]         = {NULL,     NULL,   PREC_NONE},
        [TOKEN_RETURN]        = {NULL,     NULL,   PREC_NONE},
        [TOKEN_SUPER]         = {NULL,     NULL,   PREC_NONE},
        [TOKEN_THIS]          = {NULL,     NULL,   PREC_NONE},
        [TOKEN_TRUE]          = {literal,  NULL,   PREC_NONE},
        [TOKEN_VAR]           = {NULL,     NULL,   PREC_NONE},
        [TOKEN_WHILE]         = {NULL,     NULL,   PREC_NONE},
        [TOKEN_ERROR]         = {NULL,     NULL,   PREC_NONE},
        [TOKEN_EOF]           = {NULL,     NULL,   PREC_NONE},
};



// 解析优先级较高的子串
// 所有解析函数的协调者
static void parsePrecedence(Precedence precedence) {
    // 遇到的第一个字符总是前缀表达式
    advance();
    ParseFn prefixRule = getRule(parser.previous.type)->prefix;
    if (prefixRule == NULL) {
        error("Expect expression.");
        return;
    }

    bool canAssign = precedence <= PREC_ASSIGNMENT;
    prefixRule(canAssign);

    while (precedence <= getRule(parser.current.type)->precedence) {
        advance();
        ParseFn infixRule = getRule(parser.previous.type)->infix;
        infixRule(canAssign);
    }

    if (canAssign && match(TOKEN_EQUAL)) {
        error("Invalid assignment target.");
    }

}

// 将标识符作为字符串加到常量表中, 返回索引
static uint8_t identifierConstant(Token *name) {
    return makeConstant(OBJ_VAL(copyString(name->start,
                                           name->length)));
}

// 比较两个标识符是否相同
static bool identifierEqual(Token *a, Token *b) {
    if (a->length != b->length) {
        return false;
    }

    return memcmp(a->start, b->start, a->length) == 0;
}



// 添加局部变量
static void addLocal(Token name) {
    if (current->localCount == UINT8_COUNT) {
        error("Too many local variables in function.");
        return;
    }

    Local *local = &current->locals[current->localCount++];
    local->name = name;
    local->depth = current->scopeDepth;
    local->depth = -1;
}

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


    addLocal(*name);
}

// 解析变量
static uint8_t parseVariable(const char *errormessage) {
    consume(TOKEN_IDENTIFIER, errormessage);
    // 声明变量
    declareVariable();

    // 局部变量
    if (current->scopeDepth > 0) { return 0;}
    return identifierConstant(&parser.previous);
}

// 初始化
static void markInitialized() {
    if (current->scopeDepth == 0) {
        return;
    }
    current->locals[current->localCount - 1].depth =
            current->scopeDepth;
}

// 写入chunk
static void defineVariable(uint8_t global) {
    // 局部变量
    if (current->scopeDepth > 0) {
        // 初始化
        markInitialized();
        return;
    }

    emitBytes(OP_DEFINE_GLOBAL, global);
}

static uint8_t argumentList() {
    uint8_t argCount = 0;
    if (!check(TOKEN_RIGHT_PAREN)) {
        do {
            expression();
            argCount++;
        } while(match(TOKEN_COMMA));
    }

    consume(TOKEN_RIGHT_PAREN, "Expect ')' after arguments.");
    return argCount;
}

static void and_(bool canAssign) {
    // leftexp（若为假，留在栈顶，跳转） + jump + pop + rightexp(若左为真，此值留在栈顶)
    int endJump = emitJump(OP_JUMP_IF_FALSE);

    emitByte(OP_POP);
    parsePrecedence(PREC_AND);

    patchJump(endJump);
}

static void or_(bool canAssign) {
    // leftexp + elseJump + endJump + pop + rightexp
    int elseJump = emitJump(OP_JUMP_IF_FALSE);
    int endJump = emitJump(OP_JUMP);

    patchJump(elseJump);
    emitByte(OP_POP);

    parsePrecedence(PREC_OR);
    patchJump(endJump);
}

static ParseRule *getRule(TokenType type) {
    return &rules[type];
}

static void expression () {
    // 从最低级开始
    parsePrecedence(PREC_ASSIGNMENT);
}

static void block() {
    while (!check(TOKEN_RIGHT_BRACE) && !check(TOKEN_EOF)) {
        declaration();
    }

    consume(TOKEN_RIGHT_BRACE, "Expect '}' after block.");
}

// === FunctionDeclaration ===

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

static void funDeclaration() {
    uint8_t global = parseVariable("Expect function name");
    // 由于递归，函数在声明时就可定义被初始化
    markInitialized();
    function(TYPE_FUNCTION);
    defineVariable(global);
}

static void varDeclaration() {
    uint8_t global = parseVariable("Expect variable name.");

    if (match(TOKEN_EQUAL)) {
        expression();
    } else {
        emitByte(OP_NIL);
    }

    consume(TOKEN_SEMICOLON, "Expect ';' after variable"
                             "declaration.");

    defineVariable(global);
}

static void expressionStatement() {
    // 保持堆栈0效应，表达式之后要弹出剩余值
    expression();
    consume(TOKEN_SEMICOLON, "Expect ';'"
                             "after value.");
    emitByte(OP_POP);
}

// print(1+2) currentat (
static void printStatement() {
    expression();
    consume(TOKEN_SEMICOLON, "Expect ';'"
                             "after value.");
    emitByte(OP_PRINT);
}

// return value
// return; -> NIL, OP_RETURN
static void returnStatement() {
    // 解决 顶层 return 的问题
    if (current->type == TYPE_SCRIPT) {
        error("Can't return from top-level code.");
    }

    if (match(TOKEN_SEMICOLON)) {
        emitReturn();
    } else {
        expression();
        consume(TOKEN_SEMICOLON, "Expect ';' after return value.");
        emitByte(OP_RETURN);
    }
}

static void synchronize() {
    parser.panicMode = false;

    // 寻找语句边界的前驱或者是后继
    while (parser.current.type != TOKEN_EOF) {
        if (parser.previous.type == TOKEN_SEMICOLON) {
            return;
        }
        switch (parser.current.type) {
            case TOKEN_CLASS:
            case TOKEN_FUN:
            case TOKEN_VAR:
            case TOKEN_FOR:
            case TOKEN_IF:
            case TOKEN_WHILE:
            case TOKEN_PRINT:
            case TOKEN_RETURN:
                return;

            default:
                ;
        }
        advance();
    }


}

static void statement();

static void ifStatement() {
    // condition + thenJump + | pop + statement + | elseJump + pop + (else)
    // + statement +

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

static void whileStatement() {
    // condition + exitJump + | pop + statement + loop(跳转至条件) + | pop
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

// for
static void forStatement() {
    // varDeclaration + condition + exitJump + | pop + bodyJump(跳到statement) + loopexp + pop + loop(跳转至条件) +
    // statement + loop(跳转至loopexp) + |pop

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

// 前端入口
static void declaration() {
    if (match(TOKEN_FUN)) {
        funDeclaration();
    } else if (match(TOKEN_VAR)) {
        varDeclaration();
    } else{
        statement();
    }
    // 恐慌模式同步
    if (parser.panicMode) {
        synchronize();
    }
}

// Statement
static void statement() {
    if (match(TOKEN_PRINT)) {
        printStatement();
    } else if (match(TOKEN_IF)) {
        ifStatement();
    } else if (match(TOKEN_WHILE)) {
        whileStatement();
    } else if (match(TOKEN_FOR)) {
        forStatement();
    } else if (match(TOKEN_LEFT_BRACE)) {
        beginScope();
        block();
        endScope();
    } else if (match(TOKEN_RETURN)) {
        returnStatement();
    }
    else {
        expressionStatement();
    }
}

ObjFunction *compile(const char *source) {
    // Scanner
    initScanner(source);

    Compiler compiler;
    initCompiler(&compiler, TYPE_SCRIPT);

    // 恐慌模式与错误同步
    parser.hadError = false;
    parser.panicMode = false;

    // 启动Scanner
    advance();

    // 一直读到文件末尾
    while(!match(TOKEN_EOF)) {
        declaration();
    }

    // 从编译器中获取函数对象
    ObjFunction *function = endCompiler();
    return parser.hadError?NULL:function;
}