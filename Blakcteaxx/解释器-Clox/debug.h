//
// Created by 86139 on 2023-03-24.
//

#ifndef CLOX_DEBUG_H
#define CLOX_DEBUG_H

#include "chunk.h"

void disassembleChunk(Chunk *chunk, const char *name);
int disassembleInstruction(Chunk* chunk, int offset);



#endif //CLOX_DEBUG_H
