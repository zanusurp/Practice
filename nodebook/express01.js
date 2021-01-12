var express=  require('express');
var http  = require('http');

var  app = express();
app.set('port',process.env.PORT || 3000);
http.createServer(app).listen(app.get('port'),function(){
    console.log('서버를 시작합니다.'+app.get('port'));
});