//> Chunks of Bytecode debug-c
#include <stdio.h>

#include "debug.h"
//> Closures debug-include-object
#include "object.h"
//< Closures debug-include-object
//> debug-include-value
#include "value.h"
//< debug-include-value

void disassembleChunk(Chunk* chunk, const char* name) {
    printf("== %s ==\n", name);

    for (int offset = 0; offset < chunk->count;) {
        offset = disassembleInstruction(chunk, offset);
    }
}
//> constant-instruction
static int constantInstruction(const char* name, Chunk* chunk,
                               int offset) {
    uint8_t constant = chunk->code[offset + 1];
    printf("%-16s %4d '", name, constant);
    printValue(chunk->constants.values[constant]);
    printf("'\n");
//> return-after-operand
    return offset + 2;
//< return-after-operand
}
//< constant-instruction
//> Methods and Initializers invoke-instruction
static int invokeInstruction(const char* name, Chunk* chunk,
                             int offset) {
    uint8_t constant = chunk->code[offset + 1];
    uint8_t argCount = chunk->code[offset + 2];
    printf("%-16s (%d args) %4d '", name, argCount, constant);
    printValue(chunk->constants.values[constant]);
    printf("'\n");
    return offset + 3;
}
//< Methods and Initializers invoke-instruction
//> simple-instruction
static int simpleInstruction(const char* name, int offset) {
    printf("%s\n", name);
    return offset + 1;
}
//< simple-instruction
//> Local Variables byte-instruction
static int byteInstruction(const char* name, Chunk* chunk,
                           int offset) {
    uint8_t slot = chunk->code[offset + 1];
    printf("%-16s %4d\n", name, slot);
    return offset + 2; // [debug]
}
//< Local Variables byte-instruction
//> Jumping Back and Forth jump-instruction
static int jumpInstruction(const char* name, int sign,
                           Chunk* chunk, int offset) {
    uint16_t jump = (uint16_t)(chunk->code[offset + 1] << 8);
    jump |= chunk->code[offset + 2];
    printf("%-16s %4d -> %d\n", name, offset,
           offset + 3 + sign * jump);
    return offset + 3;
}
//< Jumping Back and Forth jump-instruction
//> disassemble-instruction
int disassembleInstruction(Chunk* chunk, int offset) {
    printf("%04d ", offset);
//> show-location
    if (offset > 0 &&
        chunk->lines[offset] == chunk->lines[offset - 1]) {
        printf("   | ");
    } else {
        printf("%4d ", chunk->lines[offset]);
    }
//< show-location

    uint8_t instruction = chunk->code[offset];
    switch (instruction) {
//> disassemble-constant
        case OP_CONSTANT:
            return constantInstruction("OP_CONSTANT", chunk, offset);
//< disassemble-constant
//> Types of Values disassemble-literals
        case OP_NIL:
            return simpleInstruction("OP_NIL", offset);
        case OP_TRUE:
            return simpleInstruction("OP_TRUE", offset);
        case OP_FALSE:
            return simpleInstruction("OP_FALSE", offset);
//< Types of Values disassemble-literals
//> Global Variables disassemble-pop
        case OP_POP:
            return simpleInstruction("OP_POP", offset);
//< Global Variables disassemble-pop
//> Local Variables disassemble-local
        case OP_GET_LOCAL:
            return byteInstruction("OP_GET_LOCAL", chunk, offset);
        case OP_SET_LOCAL:
            return byteInstruction("OP_SET_LOCAL", chunk, offset);
//< Local Variables disassemble-local
//> Global Variables disassemble-get-global
        case OP_GET_GLOBAL:
            return constantInstruction("OP_GET_GLOBAL", chunk, offset);
//< Global Variables disassemble-get-global
//> Global Variables disassemble-define-global
        case OP_DEFINE_GLOBAL:
            return constantInstruction("OP_DEFINE_GLOBAL", chunk,
                                       offset);
//< Global Variables disassemble-define-global
//> Global Variables disassemble-set-global
        case OP_SET_GLOBAL:
            return constantInstruction("OP_SET_GLOBAL", chunk, offset);
//< Superclasses disassemble-get-super
//> Types of Values disassemble-comparison
        case OP_EQUAL:
            return simpleInstruction("OP_EQUAL", offset);
        case OP_GREATER:
            return simpleInstruction("OP_GREATER", offset);
        case OP_LESS:
            return simpleInstruction("OP_LESS", offset);
//< Types of Values disassemble-comparison
//> A Virtual Machine disassemble-binary
        case OP_ADD:
            return simpleInstruction("OP_ADD", offset);
        case OP_SUBTRACT:
            return simpleInstruction("OP_SUBTRACT", offset);
        case OP_MULTIPLY:
            return simpleInstruction("OP_MULTIPLY", offset);
        case OP_DIVIDE:
            return simpleInstruction("OP_DIVIDE", offset);
//> Types of Values disassemble-not
        case OP_NOT:
            return simpleInstruction("OP_NOT", offset);
//< Types of Values disassemble-not
//< A Virtual Machine disassemble-binary
//> A Virtual Machine disassemble-negate
        case OP_NEGATE:
            return simpleInstruction("OP_NEGATE", offset);
//< A Virtual Machine disassemble-negate
//> Global Variables disassemble-print
        case OP_PRINT:
            return simpleInstruction("OP_PRINT", offset);
//< Global Variables disassemble-print
//> Jumping Back and Forth disassemble-jump
        case OP_JUMP:
            return jumpInstruction("OP_JUMP", 1, chunk, offset);
        case OP_JUMP_IF_FALSE:
            return jumpInstruction("OP_JUMP_IF_FALSE", 1, chunk, offset);
//< Jumping Back and Forth disassemble-jump
//> Jumping Back and Forth disassemble-loop
        case OP_LOOP:
            return jumpInstruction("OP_LOOP", -1, chunk, offset);
//< Jumping Back and Forth disassemble-loop
//> Calls and Functions disassemble-call
        case OP_CALL:
            return byteInstruction("OP_CALL", chunk, offset);
        case OP_RETURN:
            return simpleInstruction("OP_RETURN", offset);
        default:
            printf("Unknown opcode %d\n", instruction);
            return offset + 1;
    }
}
//< disassemble-instruction