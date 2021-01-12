#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <time.h>
#include <string.h>


const int MAX_SIZE = 1000;

#define N 624
#define M 397
#define MATRIX_A 0x9908b0dfUL 
#define UPPER_MASK 0x80000000UL 
#define LOWER_MASK 0x7fffffffUL 

static unsigned long mt[N];
static int mti = N + 1;

void init_genrand(unsigned long s)
{
    mt[0] = s & 0xffffffffUL;
    for (mti = 1; mti < N; mti++) {
        mt[mti] =
            (1812433253UL * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + mti);
        mt[mti] &= 0xffffffffUL;
    }
}

void init_by_array(unsigned long init_key[], int key_length)
{
    int i, j, k;
    init_genrand(19650218UL);
    i = 1; j = 0;
    k = (N > key_length ? N : key_length);
    for (; k; k--) {
        mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525UL))
            + init_key[j] + j;
        mt[i] &= 0xffffffffUL;
        i++; j++;
        if (i >= N) { mt[0] = mt[N - 1]; i = 1; }
        if (j >= key_length) j = 0;
    }
    for (k = N - 1; k; k--) {
        mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1566083941UL))
            - i;
        mt[i] &= 0xffffffffUL;
        i++;
        if (i >= N) { mt[0] = mt[N - 1]; i = 1; }
    }

    mt[0] = 0x80000000UL;
}


unsigned long genrand_int32(void)
{
    unsigned long y;
    static unsigned long mag01[2] = { 0x0UL, MATRIX_A };

    if (mti >= N) {
        int kk;

        if (mti == N + 1)
            init_genrand(5489UL);

        for (kk = 0; kk < N - M; kk++) {
            y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
            mt[kk] = mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1UL];
        }
        for (; kk < N - 1; kk++) {
            y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
            mt[kk] = mt[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1UL];
        }
        y = (mt[N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
        mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1UL];

        mti = 0;
    }

    y = mt[mti++];

    y ^= (y >> 11);
    y ^= (y << 7) & 0x9d2c5680UL;
    y ^= (y << 15) & 0xefc60000UL;
    y ^= (y >> 18);

    return y;
}

long genrand_int31(void)
{
    return (long)(genrand_int32() >> 1);
}

double genrand_real1(void)
{
    return genrand_int32() * (1.0 / 4294967295.0);
}

double genrand_real2(void)
{
    return genrand_int32() * (1.0 / 4294967296.0);
}

double genrand_real3(void)
{
    return (((double)genrand_int32()) + 0.5) * (1.0 / 4294967296.0);
}

double genrand_res53(void)
{
    unsigned long a = genrand_int32() >> 5, b = genrand_int32() >> 6;
    return(a * 67108864.0 + b) * (1.0 / 9007199254740992.0);
}

void process(char* target_name, char* output_file, unsigned long iv_key) {
    init_genrand(iv_key);
    char target_file[100] = "C:\\JAVA\\";
    strcat(target_file, target_name);
    char output[100] = "C:\\JAVA\\";
    strcat(output, output_file);
    FILE* in = fopen(target_file, "r");
    FILE* out = fopen(output, "w");
    int c = fgetc(in);
    while (!feof(in)) {
        int i = genrand_int32() >> 24;
        fprintf(out, "%c", c ^ i);
        c = fgetc(in);
    }
    fclose(in);
    fclose(out);
}

int main(void)
{
    int mode = 1;
    char target_name[100];
    char output_file[100];
    char key[100];
    unsigned long iv_key = 0;
    clock_t timestamp1;
    clock_t timestamp2;
    while (mode != 0) {
        iv_key = 0;
        printf("진행 : 1, 종료 : 0\n");
        scanf("%d", &mode);

        if (mode == 0) return 0;
        else {
            printf("대상 파일명(확장자 포함) : ");
            scanf("%s", target_name);
            printf("저장 파일명(확장자 포함) : ");
            scanf("%s", output_file);
            printf("키 : ");
            scanf("%s", key);
            timestamp1 = clock();

            for (int i = 0; i < strlen(key); i++) {
                iv_key += (int)key[i];
            }

            process(target_name, output_file, iv_key);
        }
        timestamp2 = clock();
        int min = (timestamp2 - timestamp1) / 1000;
        int sec = (timestamp2 - timestamp1) % 1000;
        printf("StreamCipher -key[%s] -in[%s] -out[%s] -소요시간[%02d분%03d초]\n\n", key, target_name, output_file, min, sec);
    }

    system("pause");
}