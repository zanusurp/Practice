//index.js
const kk = require('./kk');
const express = require('express');
const mongoose = require('mongoose');
const bodyParser = require('body-parser');
const methodOverride = require('method-override');
const app = express();

//DB setting 
mongoose.set('useNewUrlParser', true);
mongoose.set('useFindAndModify', false);
mongoose.set('useCreateIndex', true);
mongoose.set('useUnifiedTopology', true);
mongoose.connect(kk.mong);

const db = mongoose.connection;
db.once('open', function(){
    console.log('DB connected');
});
db.on('error',function(err){
    console.log('DB ERROR', err);
});

//other setting 
app.set('view engine', 'ejs');
app.use(express.static(__dirname+'/public'));
console.log('정적데이터 위치 : '+__dirname+'/public'); //확인용
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended:true}));
app.use(methodOverride('_method'));

//routes
app.use('/', require('./routes/home'));
app.use('/posts', require('./routes/posts'));
app.use('/users', require('./routes/users'));

//port setting
const port = process.env.PORT || 3000;
app.listen(port, function(){
    console.log(`server on ! http://localhost :${port}`);
});











