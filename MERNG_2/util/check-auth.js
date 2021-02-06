const { AuthenticationError } = require('apollo-server');
const jwt = require('jsonwebtoken');
const { SECRET_KEY } = require('../config');

//아무나 글 쓰면 안되니까 로그인된 사용자인지 확인
module.exports = (context) => {
    //context = { ... headers }
    const authHeader = context.req.headers.authorization;
    if(authHeader){
        //token bearer ....
        const token = authHeader.split('Bearer ')[1];
        if(token){ 
            try{
                const user = jwt.verify(token, SECRET_KEY);
                return user;
            }catch(err){
                throw new AuthenticationError('Invalid/Expired token');
            }
        }
        //토큰 없다면
        throw new Error('Athentication token must be \'Bearer [token] ');
    }
    //인증헤더가 없다면 
    throw new Error('Athentication header  must be provided ');
}