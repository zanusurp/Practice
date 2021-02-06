const Post = require('../../models/Post');
const checkAuth = require('../../util/check-auth');
const { UserInputError,AuthenticationError } = require('apollo-server');
module.exports = {
    Mutation:{
        createComment: async (_, { postId, body}, context)=>{
            const { username } = checkAuth(context);
            if(body.trim() === ''){
                throw new UserInputError('Empty Comment', {
                    errors:{
                        body: 'comment body must not empty'
                    }
                });
            }
            const post = await Post.findById(postId);//가장 앞에 배치 unshift
            if(post){
                post.comments.unshift({
                    body,
                    username,
                    createdAt:new Date().toISOString()
                });
                await post.save();
                return post;
            }else throw new UserInputError('Post not Found');
        },
        async deleteComment(_, {postId, commentId},context){
            const { username } = checkAuth(context);

            const post = await Post.findById(postId);

            if(post){
                const commentIndex = post.comments.findIndex( c => c.id === commentId);
                if(post.comments[commentIndex].username === username){
                    post.comments.splice(commentIndex, 1);
                    await post.save();
                    return post;
                }else{
                    throw new AuthenticationError('Action not allowed'); //그냥 사용자 아니면 버튼 안보이면 그만이긴 함
                }

            }else{
                throw new UserInputError('Post not Found');
            }
        }
    }
}