---
title: 全局变量
Author: Blackteaxx
Section: 玩具解释器
Description: 好吧，还没想好嘞
---

# Global

通过一个存放在 VM 结构体中的 globals 散列表来存储

```
struct vm {
    table globals;
    table strings;
}
```

定义时字节码为 OP_DEFINE_GLOBAL
GET 字节码定义为 OP_GET，将栈中 VAL_OBJ->散列表中的值
SET 字节码定义为 OP_SET，将散列表中的值转为栈中索引常量值

## Syntax

```
program        → declaration* EOF ;

declaration    → varDecl
               | statement ;

varDecl        → "var" IDENTIFIER ( "=" expression )? ";" ;

statement      → exprStmt
               | printStmt
```

compile 主程序从解析 declaration，递归下降。

varDecl -> 先写入 String，再解析=后的表达式（若无则赋值 NIL），最后写入 OP_DEFINE_GLOBAL && indexofString

此外，还解决了一个优先级的小问题

```
a * b = c + d
```

如果按照实现思路来，他会变成这样

```
a * (b = c + d)
```

因此，需要在 parsePrecedence 外围增加一个能否赋值的布尔值，以防 identifier 的 prefix 进行逆优先级的赋值操作

对常量个数有所限制，因为Chunk中存储的字节码最多只有255