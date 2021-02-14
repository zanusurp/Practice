//home route

const express  = require('express');
const router = express.Router();
const passport = require('../config/passport');


//Home
router.get('/', function(req, res){
    res.render('home/welcome');
  });
  router.get('/about', function(req, res){
    res.render('home/about');
  });

//login
router.get('/login', function(req,res){
    let username = req.flash('username')[0];
    let errors = req.flash('errors')[0] || {};
    res.render('home/login', {
        username:username,
        errors:errors
    })
});

//post login
router.post('/login',
    function(req,res,next){
        let errors = {};
        let isValid = true;

        if(!req.body.username){
            isValid = false;
            errors.username = 'Username is required';
        }
        if(!req.body.password){
            isValid=false;
            errors.password = 'Password is required';
        }
        if(isValid){
            next();
        }
        else{
            req.flash('errors',errors);
            res.redirect('/login');
        }
    },
    passport.authenticate('local-login',{ //로긴 성패 후 
        successRedirect:'/posts',
        failureRedirect:'/login'
    })
);
module.exports = router;