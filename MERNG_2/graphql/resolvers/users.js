const bcrypt = require('bcryptjs');
const jwt = require('jsonwebtoken');
const { UserInputError } = require('apollo-server');

const { validateRegisterInput,validateLoginInput } = require('../../util/validators');
const { SECRET_KEY } = require('../../config');
const User = require('../../models/User');

function generateToken(user){
    return jwt.sign({
        id:user.id,
        email:user.email,
        username:user.username
    }, SECRET_KEY,{ expiresIn:'1h' } );
}


//
module.exports = {
    Query:{
        async getUsers(){
            try{
                const users = await User.find();
                return users;
            }
            catch(err){
                throw new Error(err);
            }
        }
    },
    Mutation:{
        async login(_, {username, password}){
            const  { errors, valid } = validateLoginInput(username, password);
            const user = await User.findOne({username});

            if(!user){
                errors.general = 'User not found';
                throw new UserInputError('User not found', { errors });
            }
            
            const match = await bcrypt.compare(password, user.password);
            if(!match){ //암호 안 ㅁ자음
                errors.general = 'Wrong Credential';
                throw new UserInputError('Wrong Credential', { errors });
            }

            const token = generateToken(user);
            return {
                ...user.doc,
                id:user._id,
                token

            };

        },
        //register(parent, args, context, info)
        async register(_,
            {registerInput: {username, email,password,confirmPassword}}
            ){
                // Validate user data
                const { valid,errors } = validateRegisterInput(username, email,password,confirmPassword);
                if(!valid){
                    throw new UserInputError('Errors', {errors});
                }
                // Make sure user doesnt already exist
                const user = User.findOne({ username });
                if(user){
                    throw new UserInputError('Username is taken',{
                        errors:{
                            username: 'This username is taken'
                        }
                    });
                }
                //hash password and creat an auth token
                password = await bcrypt.hash(password, 12);

                const newUser = User({
                    email,
                    username,
                    password,
                    createdAt:new Date().toISOString()
                });
                const res = await newUser.save();

                const token = generateToken(res); //secret key암호로 넣어주고 
                return {
                    ...res.doc,
                    id:res._id,
                    token

                };
            }
    }
}