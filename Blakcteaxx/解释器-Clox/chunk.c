//
// Created by 86139 on 2023-03-24.
//

#include <stdlib.h>

#include "chunk.h"
#include "memory.h"

void initChunk(Chunk *chunk) {
    chunk->capacity = 0;
    chunk->count = 0;
    chunk->code = NULL;
    chunk->lines = NULL;

    initValueArray(&chunk->constants);
}

void freeChunk(Chunk *chunk) {
    FREE_ARRAY(uint8_t, chunk->code, chunk->capacity);
    FREE_ARRAY(int, chunk->lines, chunk->capacity);
    freeValueArray(&chunk->constants);
    initChunk(chunk);
}


// 其中低级别的内存操作在另一个模块进行
void writeChunk(Chunk *chunk, uint8_t byte, int line) {
    if (chunk->capacity <= chunk->count) {
        int oldCapacity = chunk->capacity;
        chunk->capacity = GROW_CAPACITY(oldCapacity);
        chunk->code = GROW_ARRAY(uint8_t, chunk->code,
                                 oldCapacity, chunk->capacity);
        chunk->lines = GROW_ARRAY(int, chunk->lines,
                                  oldCapacity, chunk->capacity);
    }

    chunk->code[chunk->count] = byte;
    chunk->lines[chunk->count] = line;
    chunk->count++;
}


int addConstant(Chunk* chunk, Value value) {
    return writeValueArray(&chunk->constants, value) - 1;
//    return chunk->constants.count - 1;
}