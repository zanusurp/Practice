const { gql } = require('apollo-server');

module.exports = gql`
    type Post{
        id: ID!
        body:String!
        createdAt:String!
        username:String!
        comments:[Comment]! #안에 !하면 최소 하나 있어라 이거임 그건 아니기 떄문에 밖에
        likes:[Like]! #
        likeCount:Int!
        commentCount: Int!

    }
    type Comment{
        id:ID!
        createdAt:String!
        username:String!
        body:String!
    }
    type Like{
        id:ID!
        createdAt:String!
        username:String!
    }
    type User{
        id:ID!
        email:String!
        token:String!
        username:String!
        createdAt:String!
    }
    input RegisterInput{
        username:String!
        password:String!
        confirmPassword:String!
        email:String!
    }
    type Query{
        #sayHi : String! 
        getPosts:[Post]
        getPost(postId:ID!):Post
        getUsers:[User]
    }
    type Mutation{
        register(registerInput: RegisterInput):User!
        login(username:String!, password:String!): User!
        createPost(body:String!):Post!
        deletePost(postId:ID!):String!
        createComment(postId:String!,body:String!):Post!
        deleteComment(postId:ID!, commentId:ID!):Post!
        likePost(postId:ID!):Post!
        
    }
    type Subscription{
        newPost: Post! #새로운 게 나오면 사람들이 알게 함 
    }
`;