const postsResolvers = require('./posts');
const userResolvers = require('./users');
const commentResolvers = require('./comments');

module.exports = {
    Post:{
        likeCount(parent){ //정식   //약식 likeCount:(parent) => parent.likes.length;
            console.log(parent);
            return parent.likes.length;
        },

        commentCount: (parent) => parent.comments.length //약식
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