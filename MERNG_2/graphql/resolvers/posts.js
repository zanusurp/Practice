const { UserInputError,AuthenticationError } = require('apollo-server');

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
            context.pubsub.publish('NEW_POST',{ //하단 subscribe
                newPost: post
            })
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
        },
        //
        async likePost(_,{ postId }, context){
            const { username } = checkAuth(context);
            
            const post = await Post.findById(postId);
            if(post){
                if(post.likes.find(like => like.username === username)){
                    //Post already likes, unlike it
                    post.likes = post.likes.filter(like => like.username !== username); // 이렇게 하는 것으로 좋아요 취소
                    
                }else{
                    //not liked, so change it like 
                    post.likes.push({
                        username,
                        createdAt: new Date().toISOString()
                    });
                }
                await post.save();
                return post;
            }else throw new UserInputError('Post not Found');

            
        }
    },
    //새로운 글이 나오면 알리는 표시 같은 것 
    Subscription:{
        newPost:{
            subscribe:(_,__,{ pubsub }) => pubsub.asyncIterator('NEW_POST')//파라미터 필요 없는건 _ __로 막음
        }
    }
};