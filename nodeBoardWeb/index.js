//index basic
var express = require('express');
var mongoose = require('mongoose');
var bodyParser = require('body-parser');
var methodOverride = require('method-override');
var flash = require('connect-flash');
var session = require('express-session');
var passport = require('./config/passport');
var util = require('./util'); //page 관련된 것 부르기 위함 
var app = express();

//DB setting
mongoose.set('useNewUrlParser',true);
mongoose.set('useFindAndModify',true);
mongoose.set('useCreateIndex',true);
mongoose.set('useUnifiedTopology',true);
mongoose.connect('mongodb+srv://sys:Tltmxpa@2019@webcluster1.trkdg.mongodb.net/<dbname>?retryWrites=true&w=majority');
var db =  mongoose.connection;
db.once('open', function(){
    console.log('DB connected');
});
db.on('error',function(err){
    console.log('DB error 내용 : '+ err);
});

//other setting
app.set('view engine','ejs'); //ejs 확장자
app.use(express.static(__dirname+'/public')); //고정
app.use(bodyParser.json()); //json
app.use(bodyParser.urlencoded({extended:true}));
app.use(methodOverride('_method'));
app.use(flash()); //req로 사용 가능, 배열로 저장됨
app.use(session({secret:'Mysecret', resave:true, saveUninitialized:true}));//세션 암호화, 저장

//passport
app.use(passport.initialize());
app.use(passport.session());

//custom Middlewares
app.use(function(req,res,next){
    res.locals.isAuthenticated = req.isAuthenticated();
    res.locals.currentUser = req.user;
    next();
  });

//routes
app.use('/',require('./routes/home')); // home , about
app.use('/posts',util.getPostQueryString,require('./routes/posts')); // posts paging 옵션 추가
app.use('/users', require('./routes/users')); //users
app.use('/comments', util.getPostQueryString, require('./routes/comments'));

//port set
var port = 3000;
app.listen(port,function(){
    console.log(port+' 포트에 서버 웹 노드 실행 ');
});





