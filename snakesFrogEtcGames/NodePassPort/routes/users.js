const express = require('express');
const router = express.Router();

//login page
router.get('/login',(req,res)=>{
    res.render('login');
});


//register page
router.get('/register',(req,res)=>{
    res.render('register');
});
///register handle
router.post('/register',(req,res)=>{
    //console.log(req.body);
    const {name, email, password, password2} = req.body;
    let errors = [];
    //check failed
    if(!name || !email || !password || !password2){
        errors.push({ msg : 'please fill in all fields'});
    }
    //check password math
    if(password !== password2){
        errors.push({ msg : 'Passwords do not match'});
    }

    //check pass length
    if(password.length < 6){
        errors.push({ msg : 'password must be at least6 characters'});
    }
    if(errors.length > 0){
        res.render('register',{
            errors,
            name,
            email,
            password,
            password2
        });
    }else{
        res.send('pass');
    }
});
module.exports = router;