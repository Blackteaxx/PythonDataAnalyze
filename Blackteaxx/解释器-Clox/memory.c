//
// Created by 86139 on 2023-03-24.
//

#include <stdlib.h>

#include "memory.h"
#include "value.h"
#include "vm.h"
#include "object.h"

// 使用内置库函数
void *reallocate(void *pointer, size_t oldSize, size_t newSize) {
    if(newSize == 0) {
        free(pointer);
        return NULL;
    }

    void *result = realloc(pointer, newSize);

    if(result == NULL){ exit(1);}

    return result;
}

static void freeObject(Obj *object) {
    switch (object->type) {
        case OBJ_STRING: {
            ObjString *string = (ObjString *)object;
            FREE_ARRAY(char, string->chars, string->length);
            FREE(ObjString, object);
            break;
        }
        case OBJ_FUNCTION: {
            // 缺一个释放ObjString的东西
            ObjFunction *function = (ObjFunction *)object;
            freeChunk(&function->chunk);
            FREE(ObjFunction, object);
            break;
        }
    }
}

void freeObjects() {
    Obj *object = vm.objects;
    while (object != NULL) {
        Obj *next = object->next;
        freeObject(object);
        object = next;
    }
}