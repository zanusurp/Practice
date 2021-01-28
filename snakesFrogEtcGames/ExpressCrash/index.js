//https://www.youtube.com/watch?v=L72fhGm1tfE
const express = require('express');
const path = require('path');
const exphds = require('express-handlebars');//
const members = require('./Members')
const app = express();

//handlebars
app.engine('handlebars',exphds({defaultLayout:'main'}));
app.set('view engine','handlebars');

const logger = require('./middleware/logger');

//Init middleware
app.use(logger);
//
//Body Parser Middleware
app.use(express.json());
app.use(express.urlencoded({extended:false}))

//Hompage router 
app.get('/',(req,res)=>{
    res.render(`index`,{
        title : 'Member App',
        members
    });
});

//set static folder
app.use(express.static(path.join(__dirname,'public')));

// app.get('/', (req, res) => {
//     // res.send('<h1>Hello test</h1>');
//     res.sendFile(path.join(__dirname,'public','index.html'));
// });

//members api
app.use('/api/members', require('./routes/api/members'));


const PORT = process.env.PORT || 5000; //일단 환경변수는 없지만 이렇게도 쓴다는 거 
app.listen(PORT, () => console.log(`Server Started on PORT : ${PORT}`));

