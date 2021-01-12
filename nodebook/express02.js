var express = require('express');
var http  = require('http');
var app = express();

app.use(function(req,res,next){
    console.log('0번째 미들웨어 요청 처리');
    res.send({name:'소녀시대',age:20});
    next();
});
app.use(function(req,res,next){
    console.log('첫번째 미들 웨어을 요청 처리함');
    req.user= 'mike';
    next();
});
app.use(function(req,res,next){
    console.log('두 번쨰 미들 웨어에서 요청을 처리함');
    res.writeHead('200',{'Content-Type':'text/html;charset=utf8'});
    res.end('<h1>'+req.user+'서버에서 응답한 결과</h1>');

});
http.createServer(app).listen(3000,function(){
    console.log('서버가 3000포트에서 시작됨 ')
});