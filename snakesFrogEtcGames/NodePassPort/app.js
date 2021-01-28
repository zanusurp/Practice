const express = require('express');
const expressLayouts = require('express-ejs-layouts');
const mongoose = require('mongoose');

const app = express();
//Dbconfig
const db = require('./config/keys').MongoURI;
//connecto mongo
mongoose.connect(db,{useNewUrlParser:true})
.then(()=>console.log('Mongo Connected'))
.catch(err => console.log(err));





//ejs 
app.use(expressLayouts);
app.set('view engine','ejs');//set ejs as view
//body parser
app.use(express.urlencoded({extended:false}));
//router
app.use('/',require('./routes/index'));
app.use('/users',require('./routes/users'));

const PORT = process.env.PORT || 5000;

app.listen(PORT, console.log(`Server started on ${PORT}`));
