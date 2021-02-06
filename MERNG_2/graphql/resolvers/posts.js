const { AuthenticationError } = require('apollo-server');

const Post = require('../../models/Post');
const checkAuth = require('../../util/check-auth');


module.exports = {
    Query:{
        //sayHi : () => 'Hello worldasdasd' 
        async getPosts(){
            try{
                const posts = await Post.find().sort({ createdAt:-1 });
                return posts;
            }
            catch(err){
                throw new Error(err);
            }
        },
        async getPost(_,{ postId }){
            try{
                const post = await Post.findById(postId);
                if(post){
                    return post;

                }else{
                    throw new Error('Post not found');
                }
            }catch(err){
                throw new Error(err);
            }
        }
    },
    Mutation:{
        async createPost(_,{ body }, context){//최상단 index js에서 req 오브젝트를context로 보내어 req 제어가능
            const user = checkAuth(context);
            console.log(user); 
            const newPost = new Post({
                body,
                user:user.id,
                username:user.username, //모델에서 확인
                createdAt:new Date().toISOString()
            });
            const post = newPost.save();
            return post;
        },
        async deletePost(_,{ postId }, context){
            const user = checkAuth(context);
            
            try{
                const post = await Post.findById(postId);
                if(user.username === post.username){
                    await post.delete();
                    return 'post Deleted successfully';
                }else{
                    throw new AuthenticationError('Action not allowed');
                }
            }catch(err){
                throw new Error(err);
            }
        }
    }
};