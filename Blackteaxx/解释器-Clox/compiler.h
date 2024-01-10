//
// Created by 86139 on 2023-04-01.
//

#ifndef CLOX_COMPILER_H
#define CLOX_COMPILER_H

#include "vm.h"
#include "object.h"

ObjFunction *compile(const char *source);

#endif //CLOX_COMPILER_H
