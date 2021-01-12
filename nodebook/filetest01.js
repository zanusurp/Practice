//page 117
var logger = require('./winstonTest');
var fs = require('fs');
fs.readFile('./filetest01.txt','utf8',function(err, data){
    if(err){
        console.log(err);
    }
    console.log(data);
});
//도기식은 변수로 해서 ㅂㄹ러야 되는 듯 

fs.writeFile('./filetest01Write.txt','helloworld',function(err){
    if(err){
        console.log(err);
    };
    console.log('데이터 자성 환료');
});

fs.open('./filetest01Write.txt','w',function(err,fd){
    if(err) throw err;

    var buff = new Buffer('안녕 \n');
    fs.write(fd,buff,0,buff.length,null,function(err,written,buffer){
        if(err) throw err;

        console.log(err,written,buffer);

        fs.close(fd,function(){
            console.log('파일 열고 데이터 쓰고 파일 닫기 종료');
        });
    });

});

logger.debug();




