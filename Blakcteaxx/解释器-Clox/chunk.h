//
// Created by 86139 on 2023-03-24.
//
// chunk指代字节码序列
// 代替树，是一个密集的单字节序列，能够在缓存中快速操作

#ifndef CLOX_CHUNK_H
#define CLOX_CHUNK_H

#include "common.h"
#include "value.h"

// 操作码，控制我们要处理的指令类型——加减等
// 字节码允许有操作数，以二进制数据形式存储在指令流的操作码之后
typedef  enum {
    OP_CALL,
    OP_CONSTANT,     // 产生特定常数
    // 专用指令节省指令和常量表中的一个项
    OP_NIL,
    OP_TRUE,
    OP_FALSE,
    OP_POP,
    OP_JUMP_IF_FALSE,
    OP_JUMP,
    OP_LOOP,
    OP_GET_LOCAL,
    OP_SET_LOCAL,
    OP_SET_GLOBAL,
    OP_GET_GLOBAL,
    OP_DEFINE_GLOBAL,
    OP_EQUAL,
    OP_GREATER,
    OP_LESS,
    OP_ADD,
    OP_SUBTRACT,
    OP_MULTIPLY,
    OP_DIVIDE,
    OP_NOT,
    OP_NEGATE,       // 负号
    OP_PRINT,
    OP_RETURN,      // 返回指令
} OpCode;

// 动态字节数组的简单包装
// capacity and count
// 如果有新元素进入，若count < capacity ，则count自增，然后进入
// 若 count >= capacity , 则resize
typedef struct {
    int capacity;
    int count;

    uint8_t *code;     // 存储操作码和操作数

    int *lines; // 存储行号，与code平行

    ValueArray constants;     // 存储常量值
} Chunk;

void initChunk(Chunk *chunk);
void freeChunk(Chunk *chunk);
void writeChunk(Chunk *chunk, uint8_t byte, int line);

int addConstant(Chunk* chunk, Value value);



#endif //CLOX_CHUNK_H
