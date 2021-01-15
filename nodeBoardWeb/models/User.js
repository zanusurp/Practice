//model User
var mongoose = require('mongoose');
var bcrypt = require('bcryptjs'); //hash 비밀번호 
//schema
var userSchema = mongoose.Schema({
    username:{
        type:String,
        require:[true,'Username is required!'],
        match:[/^.{4,12}$/,'Should be 4-12 Characters'],
        trim:true, //공백제거
        unique:true
    },
    password:{
        type:String,
        require:[true,'Password is required!'],
        select:false
    },
    name:{
        type:String,
        require:[true,'Name is Required'],
        match:[/^.{4,12}$/,'Should be 4-12 Characters'],
        trim:true //공백제거
    },
    email:{
        type:String,
        match:[/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/,'Should be a valid email Address'],
        trim:true
    }
},{
    toObject:{virtual : true}
});

//virtual get set
userSchema.virtual('passwordConfirmation')
    .get(function(){return this._passwordConfirmation;})
    .set(function(value){this._passwordConfirmation = value;});
userSchema.virtual('originalPassword')
    .get(function(){return this._originamPassword;})      
    .set(function(value){return this._originamPassword = value;});
userSchema.virtual('currentPassword')    
    .get(function(){return this._currentPassword;})
    .set(function(value){return this._currentPassword = value;});
userSchema.virtual('newPassword')    
    .get(function(){return this._newPassword;})
    .set(function(value){return this._newPassword = value;});

//password validation
var passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,16}$/;//패스워드 정규식
var passwordRegexErrorMessage = 'Should be minimum 8 Characters of alphabet and number combination!';
userSchema.path('password').validate(function(v){
    var user = this;

    //create user
    if(user.isNew){
        if(!user.passwordConfirmation){
            user.invalidate('passwordConfirmation', 'Password Confirmation is required');
        }
        if(!passwordRegex.test(user.password)){
            user.invalidate('password', passwordRegexErrorMessage);
        }
        else if(user.password !== user.passwordConfirmation){
            user.invalidate('passwordConfirmation', 'Password Confirmation does not matched');
        }
    }

    //update User
    if(!user.isNew){
        if(!user.currentPassword){
            user.invalidate('currentPassword','Current Password is requried!');
        }
        else if(!bcrypt.compareSync(user.currentPassword, user.originalPassword)){
            user.invalidate('currentPassword', 'Current Password is invalid');
        }
        if(user.newPassword && !passwordRegex.test(user.newPassword)){
            user.invalidate('newPassword',passwordRegexErrorMessage);
        }
        if(user.newPassword !== user.passwordConfirmation){
            user.invalidate('passwordConfirmation','Password Confirmation does not matched!')
        }
    }
});
//hash password
userSchema.pre('save', function(next){
   var user = this;
   if(!user.isModified('password')){
       return next();
   }
   else{
       user.password = bcrypt.hashSync(user.password);
       return next();
   }
});

// model methods
userSchema.methods.authenticate = function (password) {
    var user = this;
    return bcrypt.compareSync(password,user.password);
  };
  
  // model & export
  var User = mongoose.model('user',userSchema);
  module.exports = User;