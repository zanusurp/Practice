const mongoose = require('mongoose');
const bcrypt = require('bcryptjs');


//Schema
const userSchema = mongoose.Schema({
    username:{
        type:String,
        required:[true, 'Username is required!'],
        match:[/^.{4,12}$/,'Should be 4-12 characters'],
        trim:true,
        unique:true
    },
    password:{
        type:String,
        required:[true, 'password is required!'],
        select:false
    },
    name:{
        type:String,
        required:[true, 'Name is required!'],
        match:[/^.{4,12}$/,'Should be 4-12 characters'],
        trim:true
    },
    email:{
        type:String,
        match:[/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/,'Should be a vaild email address!'],
        trim:true
    }
},{
    toObject:{virtuals:true}
});
//virtual
userSchema.virtual('passwordConfirmation')
    .get(function(){return this._passwordConfirmation;})
    .set(function(value){this._passwordConfirmation=value;});

userSchema.virtual('originalPassword')
    .get(function(){return this._originalPassword;})    
    .set(function(value){return this._originalPassword=value;});

userSchema.virtual('currentPassword')
    .get(function(){return this._currentPassword;})
    .set(function(value){return this._currentPassword=value;});

userSchema.virtual('newPassword')
    .get(function(){return this._newPassword;})
    .set(function(value){return this._newPassword=value;});

//Password Validation Check
const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[a-zA-Z\d]{6,16}$/;
const passwordRegexErrorMessage = 'Shoud be minimum 6 characters of alphabey and number combined, maximum 16';


userSchema.path('password').validate(function(v){
    const user = this;

    //유저생성
    if(user.isNew){
        if(!user.passwordConfirmation){
            user.invalidate('passwordConfirmation', 'Password Confirmation is required');
        }
        if(!passwordRegex.test(user.password)){  //패스워드 형식 준수 여부 확인 
            user.invalidate('password',passwordRegexErrorMessage);
        }
        else if(user.password !== user.passwordConfirmation){
            user.invalidate('passwordConfirmation', 'password confirmation does not matched');
        }
    }
    //유저 수정
    if(!user.isNew){
        if(!user.currentPassword){
            user.invalidate('currentPassword', 'current password is required');
        }
        //
        else if(!bcrypt.compareSync(user.currentPassword, user.originalPassword)){
            user.invalidate('currentPassword','Current Password is invalid');
        }
        else if(user.newPassword && !passwordRegex.test(user.newPassword)){
            user.invalidate('newPassword', passwordRegexErrorMessage);
        }
        if(user.newPassword !== user.passwordConfirmation){
            user.invalidate('passwordConfirmation','Password Confirmation does not matched');
        }
    }
});

userSchema.pre('save',function(next){
    const user = this;
    if(!user.isModified('password')){
        return (next());
    }else{
        user.psssword = bcrypt.hashSync(user.password);
        return next();
    }
});

userSchema.methods.authenticate = function(password){
    const user = this;
    return bcrypt.compareSync(password,user.password);
};

const User = mongoose.model('user',userSchema);
module.exports  = User;







