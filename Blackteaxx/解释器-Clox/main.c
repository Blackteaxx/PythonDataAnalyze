#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "common.h"
#include "chunk.h"
#include "debug.h"
#include "vm.h"

// 处理多行输入
static void repl() {
    char line[2048];
    for (;;) {
        if(!fgets(line, sizeof(line), stdin)) {
            printf("\n");
            break;
        }

        interpret(line);
    }
}

// 处理文件
static char *readFile(const char *path) {
    FILE *file = fopen(path, "rb");

    // 无法打开文件
    if (file == NULL) {
        fprintf(stderr, "Could not open file \"%s\".\n", path);
        exit(74);
    }

    // 寻找文件长度,返回字节树
    fseek(file, 0L, SEEK_END);
    size_t fileSize = ftell(file);
    rewind(file);

    char *buffer = (char *)malloc(fileSize + 1);

    // 没有足够的空间
    if (buffer == NULL) {
        fprintf(stderr, "Not enough memory to read \"%s\"", path);
        exit(74);
    }

    size_t bytesRead = fread(buffer, sizeof(char), fileSize, file);

    // 读取失败
    if (bytesRead < fileSize) {
        fprintf(stderr, "Could not open file \"%s\".\n", path);
        exit(74);
    }


    buffer[fileSize] = '\0';

    fclose(file);
    return buffer;

}

static void runFile(const char *path) {
    char *source = (char *) readFile(path);
    InterpretResult result = interpret(source);
    free(source);

    if (result == INTERPRET_COMPILE_ERROR) { exit(65); }
    if (result == INTERPRET_RUNTIME_ERROR) { exit(70); }
}

int main(int argc, const char *argv[]) {
    initVM();

    if (argc == 1) {
        repl();
    } else if (argc == 2) {
        runFile(argv[1]);
    } else {
        fprintf(stderr, "Usage: clox [path]\n");
        exit(64);
    }

    freeVM();
    return 0;
}
