//
// Created by 86139 on 2023-03-24.
//

#ifndef CLOX_MEMORY_H
#define CLOX_MEMORY_H

#include "common.h"
#include "object.h"
#include "vm.h"

#define ALLOCATE(type, count) \
    (type *)reallocate(NULL, 0, sizeof(type) * count)
#define FREE(type, pointer) \
    reallocate(pointer, sizeof(type), 0)

#define GROW_CAPACITY(capacity) ((capacity)<8 ? 8: (capacity) * 2)

// 宏本身获取pointer的类型
#define GROW_ARRAY(type, pointer, oldCapacity, newCapacity) \
(type *)reallocate(pointer, sizeof(type) * (oldCapacity), sizeof(type) * (newCapacity))

#define FREE_ARRAY(type, pointer, oldCapacity) \
reallocate(pointer, sizeof(type) * oldCapacity, 0)


void *reallocate(void *pointer, size_t oldSize, size_t newSize);
void freeObjects();

#endif //CLOX_MEMORY_H
