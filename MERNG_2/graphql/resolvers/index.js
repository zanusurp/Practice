const postsResolvers = require('./posts');
const userResolvers = require('./users');
const commentResolvers = require('./comments');

module.exports = {
    Post:{
        likeCount(parent){
            console.log(parent);
            return parent.likes.length;
        },
        commentCount: (parent) => parent.comments.length
    },
    Query:{
        ...postsResolvers.Query,
        ...userResolvers.Query
    },
    Mutation:{
        ...userResolvers.Mutation,
        ...postsResolvers.Mutation,
        ...commentResolvers.Mutation
    },
    Subscription:{
        ...postsResolvers.Subscription
    }
};