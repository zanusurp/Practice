#include <stdio.h>
#include <stdlib.h>
#include<locale.h> //언어 위한 



void main() {
	////10
	//printf("%d\n",10);
	//printf("%d\n", 010);
	//printf("%d\n", 0x10);
	////8
	//printf("%o\n", 10);
	//printf("%o\n", 010);
	//printf("%o\n", 0x10);
	////16
	//printf("%#x\n", 10);
	//printf("%#x\n", 010);
	//printf("%#x\n", 0x10); //#붙이면 16진수 표시 해줌 
	//system("pause");//시스템 멈춤
	

	//데이터 용량 범위
	printf("%d, %d\n",sizeof('a'),sizeof(23));
	printf("char:%d, %d~ %d\n",sizeof(char),(char)0x80,0x7F);//0x8000, 0111 1111
	printf("short:%d, %d~ %d\n", sizeof(short), (short)0x8000, 0x7FFF);
	printf("int:%d, %d~ %d\n", sizeof(int), 0x80000000, 0x7FFFFFFF);
	printf("long:%d\n", sizeof(long));
	printf("long long:%d, %lld~%lld\n", sizeof(long long), 0x8000000000000000, 0x7FFFFFFFFFFFFFFF);
	
	printf("%c : %d %#x\n", '0','0','0');
	printf("%c : %d %#x\n", 'A', 'A', 'A');
	printf("%c : %d %#x\n", 'a', 'a', 'a');

	//한글 쓰는 법 
	char ch = 'ㄱ';
	printf("%c\n", ch);

	wchar_t ch1 = L'ㄱ';
	setlocale(LC_ALL,"KOREAN");
	wprintf(L"%c\n",ch1);
	putwchar(L'홍');
	putwchar(L'\n');
	_putws(L"홍길동");

	//대칭 암호화 : 들어간 데이터와 나온 데이터가 같은 것 // pd 와 data 같은 값
	int pd = 0x12345678;
	int key = 0x2345873a;
	int sec = pd ^ key;
	int data = sec ^ key;
	printf("평문 : %#x \n",pd);
	printf("키 : %#x\n", key);
	printf("암호문 : %#x\n", sec); //암호문:0x3171D142
	printf("복호문 : %#x\n", data); //복호문:0x12345678

	//마스크 통해서 특정 수 2진화
	int num;
	printf("정수 : ");
	scanf_s("%d", &num);
	printf("%#x\n", num);
	unsigned int cnum = 0x80000000;
	int check = 0;
	int cnt = 0;
	while (cnum) {
		if (cnum & num) {
			printf("1");
			check = 1;
		}
		else {
			if (check == 1) {
				printf("0");
			}
		}
		cnt++;
		cnum = cnum / 2;
		if ((cnt % 4 == 0) && (check == 1)) {
			printf(" ");
		}
	}
	printf("\n");
}