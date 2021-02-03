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
            
            if (!valid) {
                throw new UserInputError('Errors', { errors });
              }
            const user = await User.findOne({ username });
            console.log(user.username);
            if(!user){
                errors.general = 'User not found';
                throw new UserInputError('User not found', { errors });
            }
            
            console.log('방금 작성한 비밀번호 : '+password);
            console.log('사용자에 저장된 비밀번호 : '+user.password);
            // console.log((user.password).length);
            // var salt = bcrypt.genSaltSync(12);
            // var hash = bcrypt.hash(password,salt);
            // console.log((await hash).toString());
            var hash2 = bcrypt.hash(password,12);
            console.log((await hash2).toString());
            // //console.log('사용자 젖아된 비밀번호 해석: '+bcrypt.hashSync(user.password,"some very secret key"));
            const match = await bcrypt.compare(password,user.password);
            
            console.log('비밀번호와 매칭이 되는가'+match);
            if(!match){ //암호 확읹
                errors.general = 'Wrong Credential';
                throw new UserInputError('Wrong Credential', { errors });
            }

            const token = generateToken(user);
            return {
                ...user._doc,
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
                const user = await User.findOne({ username });
                
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
                    ...res._doc,
                    id:res._id,
                    token

                };
            }
    }
}