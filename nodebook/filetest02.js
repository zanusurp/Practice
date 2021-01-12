var output = '안녕1';
var buffer1 = new Buffer(10);
var len  = buffer1.write(output,'utf8');
console.log('첫번 째 버퍼의 문자열 : %s',buffer1.toString());

var buffer2 = new Buffer('안녕2 !','utf8');
console.log('두번쨰 버퍼의 문자열 : %s',buffer2.toString());

console.log('버퍼 객체 타입 확인 : %s',Buffer.isBuffer(buffer1));

var byteLen  = Buffer.byteLength(output);
var str1 =  buffer1.toString('utf8',0,byteLen);
var str2 = buffer2.toString('utf8');

buffer1.copy(buffer2,0,0,len);
console.log('두번쨰 버퍼에 복사하 ㄴ후의 문자열 : %s',buffer2.toString('utf8'));

var buffer3 = Buffer.concat([buffer1,buffer2]);
console.log('두개 합 친 후 의 모습 : %s',buffer3.toString('utf8'));