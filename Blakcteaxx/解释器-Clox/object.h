//
// Created by 86139 on 2023-04-09.
//

#ifndef CLOX_OBJECT_H
#define CLOX_OBJECT_H

#include "common.h"
#include "value.h"
#include "chunk.h"

#define OBJ_TYPE(value)        (AS_OBJ(value)->type)
#define IS_STRING(value)       isObjType(value, OBJ_STRING)
#define IS_FUNCTION(value)     isObjType(value, OBJ_FUNCTION)
#define AS_STRING(value)       ((ObjString*)AS_OBJ(value))
#define AS_CSTRING(value)      (((ObjString*)AS_OBJ(value))->chars)
#define AS_FUNCTION(value)     ((ObjFunction*)AS_OBJ(value))

typedef enum {
    OBJ_STRING,
    OBJ_FUNCTION
} ObjType;


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

ObjFunction *newFunction();
ObjString *takeString(char *chars, int length);
ObjString *copyString(const char *chars, int length);
void printObject(Value value);

static inline bool isObjType(Value value, ObjType type) {
    return IS_OBJ(value) && AS_OBJ(value)->type == type;
}



#endif //CLOX_OBJECT_H
