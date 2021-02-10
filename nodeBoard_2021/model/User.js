const mongoose = require('mongoose');

//Schema
const userSchema = mongoose.Schema({
    username:{type:String, required:[true, 'Username is required!'], unique:true},
    password:{type:String, required:[true, 'password is required!'], select:false},
    name:{type:String, required:[true, 'Name is required!']},
    email:{type:String}
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

userSchema.path('password').validate(function(v){
    const user = this;

    //유저생성
    if(user.isNew){
        if(!user.passwordConfirmation){
            user.invalidate('passwordConfirmation', 'Password Confirmation is required');
        }
        if(user.password !== user.passwordConfirmation){
            user.invalidate('passwordConfirmation', 'password confirmation does not matched');
        }
    }
    //유저 수정
    if(!user.isNew){
        if(!user.currentPassword){
            user.invalidate('currentPassword', 'current password is required');
        }
        else if(user.currentPassword != user.originalPassword){
            user.invalidate('currentPassword', 'current password is invalid');
        }
        if(user.newPassword !== user.passwordConfirmation){
            user.invalidate('passwordConfirmation','Password Confirmation does not matched');
        }
    }
});

const User = mongoose.model('user',userSchema);
module.exports  = User;







