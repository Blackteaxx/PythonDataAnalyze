//
// Created by 86139 on 2023-03-31.
//

#ifndef CLOX_VM_H
#define CLOX_VM_H

#include "chunk.h"
#include "table.h"
#include "object.h"

#define FRAMES_MAX 64
#define STACK_MAX (FRAMES_MAX * UINT8_COUNT)


// 调用帧——存储函数局部变量
typedef struct {
    ObjFunction *function;
    uint8_t *ip; // 将自己的ip（即指向chunk的哪里）存起来，调用函数返回后，vm回调到调用方CallFrame中的ip
    Value *slots;// 能够使用虚拟机的第一个栈槽
} CallFrame;

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

typedef enum {
    INTERPRET_OK,
    INTERPRET_COMPILE_ERROR,
    INTERPRET_RUNTIME_ERROR
} InterpretResult;

extern VM vm;

void initVM();
void freeVM();
InterpretResult interpret(const char *source);
void push(Value value);
Value pop();

#endif //CLOX_VM_H
