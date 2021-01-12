var express = require('express');
var http = require('http');
//var path = require('path');
var bodyParser = require('body-parser');
///var static = require('serve-static');

var expressErrorHanlder = require('express-error-handler');

var app = express();
var router = express.Router();
var cookieParser = require('cookie-parser');
var expressSession= require('express-session');

app.use(cookieParser());
app.use(expressSession(){
    secret:'my key',
    resave:true,
    saveUninitialized:true
});


var errorHandler = expressErrorHanlder({
    static:{
        '404': './public/404.html'
    }
});

//app.use(expressErrorHanlder.httpError(404));
//app.use(errorHandler);

app.set('port',process.env.PORT || 3000);

app.use(bodyParser.urlencoded({extended : false}));

app.use(bodyParser.json());

app.use(express.static(__dirname+'/public'));
//app.use('/public',static(path.join(__dirname,'public')));

app.use(function(req,res,next){
    console.log('첫번쨰 미들웨어에서 요청 처리함');
    var paramId = req.body.id || req.query.id;
    var paramPassword = req.body.password || req.query.password;

    res.writeHead(200,{'Content-Type':'text/html;charset=utf8'});
    res.write('<h1><Express서버에서 응답한 결과 입니다./h1>');
    res.write('<div><p>Param id : '+paramId+'</p></div>');
    res.write('<div><p>Param password : '+paramPassword+'</p></div>');
    res.end();
});

router.route('/process/product').get(function(req,res){
    console.log('process/product 호출됨');
    if(req.session.user){
        res.redirect('/public/product.html');

    }else{
        res.redirect('/public/login2.html');
    }
});
app.use('/',router);

http.createServer(app).listen(3000,function(){
    console.log('3000 local server running ');
});