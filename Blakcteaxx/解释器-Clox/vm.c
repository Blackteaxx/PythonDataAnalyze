//
// Created by 86139 on 2023-03-31.
//

#include <stdio.h>
#include <stdarg.h>
#include <string.h>
#include <math.h>
#include "vm.h"
#include "common.h"
#include "debug.h"
#include "compiler.h"
#include "memory.h"

//#define DEBUG_TRACE_EXECUTION 1

// 静态声明虚拟机
VM vm;

static void resetStack() {
    vm.stackTop = vm.stack;

    vm.frameCount = 0;
}

// 运行时错误
static void runtimeError(const char *format, ...) {
    va_list args;
    va_start(args, format);
    vfprintf(stderr, format, args);
    va_end(args);
    fputs("\n", stderr);

    // 堆栈跟踪
    for (int i = vm.frameCount - 1; i>=0; i--) {
        CallFrame *frame = &vm.frames[i];
        ObjFunction *function= frame->function;
        size_t instruction = frame->ip - function->chunk.code - 1;
        fprintf(stderr, "[line %d] in ",
                function->chunk.lines[instruction]);
        if (function->name == NULL) {
            fprintf(stderr, "script\n");
        } else {
            fprintf(stderr, "%s()\n", function->name->chars);
        }
    }

    // 解释器在每条指令之前都会向前推进
    CallFrame* frame = &vm.frames[vm.frameCount - 1];
    size_t instruction = frame->ip - frame->function->chunk.code - 1;
    int line = frame->function->chunk.lines[instruction];
    fprintf(stderr, "[line %d] in script\n", line);
    resetStack();
}

void initVM() {
    resetStack();
    vm.objects = NULL;
    initTable(&vm.strings);
    initTable(&vm.globals);
}

void freeVM() {
    freeTable(&vm.globals);
    freeTable(&vm.strings);
    freeObjects();
}

void push(Value value) {
    *(vm.stackTop) = value;
    vm.stackTop++;
}

Value pop() {
    vm.stackTop--;
    return *(vm.stackTop);
}

static Value peek(int distance) {
    return vm.stackTop[-1 - distance];
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

static bool isFalsey(Value value) {
    return IS_NIL(value) || (IS_BOOL(value) && !(AS_BOOL(value)));
}

static void concatenate() {
    ObjString *b = AS_STRING(pop());
    ObjString *a = AS_STRING(pop());

    int length = a->length + b->length;
    char *chars = ALLOCATE(char, length + 1);

    memcpy(chars, a->chars, a->length);
    memcpy(chars + a->length, b->chars, b->length);

    chars[length] = '\0';

    ObjString *result = takeString(chars, length);
    push(OBJ_VAL(result));
}

static void repeatString() {
    double b = AS_NUMBER(pop());
    ObjString *a = AS_STRING(pop());

    if (fabs( (int)(b) - b) > 1e-10) {
        runtimeError(
                "Operands must be an interger and a string.");
    } else {
        int length = a->length * (int)b + 1;
        char *chars = ALLOCATE(char, length);

        for (int i = 0; i < b; i++) {
            memcpy(chars + a->length * i, a->chars, a->length);
        }

        chars[length] = '\0';

        ObjString *result = takeString(chars, length);
        push(OBJ_VAL(result));
    }

}

static InterpretResult run() {

    // 最顶层函数调用栈帧
    CallFrame *frame = &vm.frames[vm.frameCount - 1];
#define READ_BYTE() (*(frame->ip++))
#define READ_CONSTANT() (frame->function->chunk.constants.values[READ_BYTE()])
#define READ_STRING() AS_STRING(READ_CONSTANT())
// 一些位运算
#define READ_SHORT() \
    (frame->ip += 2, \
    (uint16_t)((frame->ip[-2] << 8) | frame->ip[-1]))

#define BINARY_OP(valueType, op) do { \
    if (!IS_NUMBER(peek(0)) || !IS_NUMBER(peek(1))) { \
        runtimeError("Operands must be numbers."); \
        return INTERPRET_RUNTIME_ERROR; \
    }                  \
    double b = AS_NUMBER(pop()); \
    double a = AS_NUMBER(pop()); \
    push(valueType(a op b)); \
    }while(false)


    // 不断读取当前字节码
    for(;;) {
        
#ifdef DEBUG_TRACE_EXECUTION
        // 每次循环打印状态
        printf("Start LOG:\n");
        printf("             ");
        for(Value *slot = vm.stack; slot < vm.stackTop; slot++) {
            printf("[ ");
            printValue(*slot);
            printf(" ]");
        }
        printf("\n");

        disassembleInstruction(&frame->function->chunk,
                               (int)(frame->ip - frame->function->chunk.code));
        printf("END LOG\n");
#endif

        uint8_t instruction;
        switch (instruction = READ_BYTE()) {
            case OP_CALL: {
                int argCount = READ_BYTE();
                if (!callValue(peek(argCount), argCount)) {
                    return INTERPRET_RUNTIME_ERROR;
                }
                frame = &vm.frames[vm.frameCount - 1];
                break;
            }
            case OP_CONSTANT: {
                // 存入常量
                Value constant = READ_CONSTANT();
                push(constant);
#ifdef DEBUG_TRACE_EXECUTION
                printValue(constant);
                printf("\n");
#endif
                break;
            }
            case OP_NIL: {
                push(NIL_VAL);
                break;
            }
            case OP_TRUE: {
                push(BOOL_VAL(true));
                break;
            }
            case OP_FALSE: {
                push(BOOL_VAL(false));
                break;
            }
            case OP_POP: {
                pop();
                break;
            }
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
            case OP_LOOP: {
                uint16_t offset = READ_SHORT();
                frame->ip = frame->ip - offset;
                break;
            }
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
            case OP_DEFINE_GLOBAL: {
                ObjString *name = READ_STRING();
                tableSet(&vm.globals, name, peek(0));
                pop();
                break;
            }
            case OP_EQUAL: {
                Value b = pop();
                Value a = pop();
                push(BOOL_VAL(valuesEqual(a, b)));
                break;
            }
            case OP_GREATER: {
                BINARY_OP(BOOL_VAL, >);
                break;
            }
            case OP_LESS: {
                BINARY_OP(BOOL_VAL, <);
                break;
            }
            case OP_ADD: {
                if (IS_STRING(peek(0)) && IS_STRING(peek(1))) {
                    concatenate();
                } else if (IS_NUMBER(peek(0)) && IS_NUMBER(peek(1))) {
                    double b = AS_NUMBER(pop());
                    double a = AS_NUMBER(pop());
                    push(NUMBER_VAL(a + b));
                } else {
                    runtimeError(
                            "Operands must be two numbers or two strings.");
                    return INTERPRET_RUNTIME_ERROR;
                }
                break;
            }
            case OP_SUBTRACT: {
                BINARY_OP(NUMBER_VAL, -);
                break;
            }
            case OP_MULTIPLY: {
                if (IS_NUMBER(peek(0)) && IS_STRING(peek(1))) {
                    repeatString();
                } else {
                    BINARY_OP(NUMBER_VAL, *);
                }
                break;
            }
            case OP_DIVIDE: {
                BINARY_OP(NUMBER_VAL, /);
                break;
            }
            case OP_NOT: {
                push(BOOL_VAL(isFalsey(pop())));
                break;
            }
            case OP_NEGATE: {
                // 取负
                if (!IS_NUMBER(peek(0))) {
                    runtimeError("Operand must be a number.");
                    return INTERPRET_RUNTIME_ERROR;
                }
                push(NUMBER_VAL(-AS_NUMBER(pop())));
                break;
            }
            case OP_PRINT: {
                printValue(pop());
                printf("\n");
                break;
            }
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
        }
    }
#undef READ_BYTE
#undef READ_CONSTANT
#undef READ_STRING
#undef READ_SHORT
#undef BINARY_OP
}

InterpretResult interpret(const char *source) {
    ObjFunction *function = compile(source);
    if (function == NULL) {
        return INTERPRET_COMPILE_ERROR;
    }

    // 存储被调用的函数
    push(OBJ_VAL(function));

    // 初始化栈帧
    CallFrame *frame = &vm.frames[vm.frameCount++];
    frame->function = function;
    frame->ip = function->chunk.code;
    frame->slots = vm.stack;

    InterpretResult result = run();

    return result;
}