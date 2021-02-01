const { AuthenticationError } = require('apollo-server');
const jwt = require('jsonwebtoken');
const { SECRET_KEY } = require('../config');


module.exports = (context) =>{
    //context = {... headers}
    const authHeader = context.req.headers.authorization;
    console.log("인증 머리  :"+authHeader);
    if(authHeader){
        //Beaer..
        const token = authHeader.split('Bearer')[1];
        console.log("토큰 : "+token);
        if(token){
            try{
                const user = jwt.verify(token, SECRET_KEY);
                return user;
            }
            catch(err){
                throw new AuthenticationError('Invaild/Expired token');
            }
        }
        throw new Error('Authentication token must be \'Bearer [token] ');
    }
    throw new Error('Authorization header must be provided');
};