const bcrypt = require('bcryptjs');
const jwt = require('jsonwebtoken');
const { UserInputError } = require('apollo-server');

const { validateRegisterInput,validateLoginInput } = require('../../util/validators');
const { SECRET_KEY } = require('../../config');
const User = require('../../models/User');

function generateToken(user){
    return jwt.sign(
    {
        id:user.id,
        email:user.email,
        username: user.username
    }, 
    SECRET_KEY,{ expiresIn:'1h'});
}



module.exports={
    Mutation:{
        async login(_,{ username, password }){
            const {errors, valid} = validateLoginInput(username, password);
            const user = await User.findOne({username });
            
            if(!user){
                errors.general = 'User Not Found';
                throw new UserInputError('User Not Found',{ errors });

            }
            const match = await bcrypt.compare(password, user.password);
            if(!match){
                errors.general = 'Wrong Credentials';
                throw new UserInputError('Wrong credentials',{ errors });
            }
            const token = generateToken(user);

            return{
                ...user._doc,
                id:user._id,
                token
            }
        },

        //register(parent, args, context, info) //1:최종인풋 2: 일반적으로 사용 3:4:
        async register(_,
             {registerInput: {username, email, password, confirmPassword},
            }//,
            // context,
             // info
             ){//1: 필요 없기에 _ 2: 유저의 4개 항목
        // Validate user data
        const{ valid, errors } = validateRegisterInput(
            username,
            email,
            password,
            confirmPassword
        );
        if(!valid){
            throw new UserInputError('Erros',{errors});
            
        }
        //TODO: Make suer user doesnt already exist
            const user = await User.findOne({username});
            if(user){
                throw new UserInputError('username is taken',{
                    errors:{
                        username:' this username is taken'
                    }
                    
                });
            }
        //TODO: hash paswrod and create an auth token
            password = await bcrypt.hash(password, 12);

            const newUser = new User({
                email,
                username, 
                password,
                createdAt: new Date().toISOString()
            });
            const res  = await newUser.save();//저장

            const token = generateToken(res);

            return{
                ...res._doc,
                id:res._id,
                token
            }
        }
    }
}