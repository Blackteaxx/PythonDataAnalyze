//
// Created by 86139 on 2023-03-24.
//

#include <stdio.h>
#include <string.h>

#include "memory.h"
#include "value.h"
#include "object.h"
#include "table.h"

bool valuesEqual(Value a, Value b) {
    if (a.type != b.type) {
        return false;
    }
    switch (a.type) {
        case VAL_BOOL:
            return AS_BOOL(a) == AS_BOOL(b);
        case VAL_NUMBER:
            return AS_NUMBER(a) == AS_NUMBER(b);
        case VAL_NIL:
            return true;
        case VAL_OBJ: {
            return AS_OBJ(a) == AS_OBJ(b);
        }
        default: return false; // unreachable
    }
}


void initValueArray(ValueArray* array) {
    array->count = 0;
    array->capacity = 0;
    array->values = NULL;
}

int writeValueArray(ValueArray* array, Value value) {
    // 查找是否已经含有常量
    if (array->count != 0) {
        switch (value.type) {
            case VAL_NUMBER: {
                for (int i = 0; i < array->count; i++) {
                    if (array->values[i].type == VAL_NUMBER &&
                        value.as.number == array->values[i].as.number) {
                        return i + 1;
                    }
                }
                break;
            }
            case VAL_BOOL:{
                for (int i = 0; i < array->count; i++) {
                    if (array->values[i].type == VAL_BOOL && value.as.boolean == array->values[i].as.boolean) {
                        return i + 1;
                    }
                }
                break;
            }

            case VAL_NIL:{
                for (int i = 0; i < array->count; i++) {
                    if (array->values[i].type == VAL_NIL) {
                        return i + 1;
                    }
                }
                break;
            }

            case VAL_OBJ:{
                switch (value.as.obj->type) {
                    case OBJ_STRING:{
                        for (int i = 0; i < array->count; i++) {
                            if (array->values[i].type == VAL_OBJ && AS_STRING(array->values[i]) == AS_STRING(value)) {
                                return i + 1;
                            }
                        }
                    }

                }
                break;
            }
        }
    }

    if (array->capacity < array->count + 1) {
        int oldCapacity = array->capacity;
        array->capacity = GROW_CAPACITY(oldCapacity);
        array->values = GROW_ARRAY(Value, array->values,
                                   oldCapacity, array->capacity);
    }

    array->values[array->count] = value;
    array->count++;
    return array->count;
}

void freeValueArray(ValueArray* array) {
    FREE_ARRAY(Value, array->values, array->capacity);
    initValueArray(array);
}

void printValue(Value value) {
    switch (value.type) {
        case VAL_BOOL: {
            printf(AS_BOOL(value)?"true":"false");
            break;
        }
        case VAL_NIL: {
            printf("nil");
            break;
        }
        case VAL_NUMBER: {
            printf("%g", AS_NUMBER(value));
            break;
        }
        case VAL_OBJ: {
            printObject(value);
            break;
        }
    }
}
