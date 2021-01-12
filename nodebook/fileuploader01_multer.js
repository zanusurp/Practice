var express = require('express');
var http = require('http');
var path = require('path');

var bodyParser = require('body-parser');
var cookieParser = require('cookie-parser');
var static = require('serve-static');
var errorHandler = require('errorhandler');
var expressSession  = require('express-session');

var multer = require('multer');
var fs = require('fs');

var cors = require('cors');//ajax 요청ㅅ 작업 다중 서버 지원

var app = express();
app.set('port', process.env.PORT || 3000);

app.use(bodyParser.urlencoded({extended: false}));
app.use(bodyParser.json());

app.use('/public',static(path.join(__dirname,'public')));
app.use('/uploads',static(path.join(__dirname,'uploads')));

app.use(cookieParser());

app.use(expressSession({
    secret:'my key',
    resave:true,
    saveUninitialized:true
}));

app.use(cors());

var storage = multer.diskStorage({
    destination: function(req,file, callback){
        callback(null,'uploads')
    },
    filename: function(req,file,callback){
        callback(null,file.originalname+Date.now())
    }
});

var uplaod = multer({
    storage: storage,
    limit:{
        files:10,
        fileSize:1024*1024*1024

    }
});

var router =express.Router();

router.route('/process/photo').post(upload.array('photo',1), function(req,res){
    console.log('process/photo 호출');
    try{
        var files = req.files;
        console.dir('#===== 업로드된 첫번쨰 파일 정보 ====#');
        console.dir(req.files[0]);
        console.dir('#======#');
        
        var originalname='',
        filename='',
        mimetype='',
        size=0;

        if(Array.isArray(files)){
            console.log('배열에 있는 파일 갯수  : %d',files.length);

            for(var index = 0 ; index < files.length;index++){
                originalname = files[index].originalname;
                filename = files[index].filename;
                mimetype = files[index].mimetype;
                size = files[index].size;
            }
        }else{
            console.log('파일 갯수 : 1');
            originalname = files[index].originalname;
                filename = files[index].filename;
                mimetype = files[index].mimetype;
                size = files[index].size;

        }
        console.log('ㅍ현재파일 정보 : '+ originalname + ', '+ filename + ' ,' + mimetype + ', '+size);

        res.writeHead(200,{'Content-Type':'text/html;charset=utf8'});
        res.write('<h3>파일 업로드 성공</h3>');
        res.write('<p>원본 파일 이름'+originalname+'->저장파일 명 : ' + filename + '</p>');
        res.write('밈 타입 : '+mimetype);
        res.write('파일 사이즈' + size);
        
    }catch{
        console.log(err.stack);
    }
});

app.use('/',router);

http.createServer('app').listen(3000,function(res,req){
    console.log('3000');
});