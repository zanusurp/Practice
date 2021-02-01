const { UserInputError } = require('apollo-server');


const Post = require('../../models/Post');


module.exports = {
   
    Mutation:{
        createdComment: async (_, { postId, body },context) => {
            const user = checkAuth(context);
            if(body.trim() === ''){
                throw new UserInputError('Empty comment',{
                    errors:{
                        body : ' Comment ody must not empty'
                    } 
                });
            }
        }

    }
}