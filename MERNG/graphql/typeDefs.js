const { gql } = require('apollo-server');

module.exports = gql`
    type Post{
        id: ID!
        body:String!
        createdAt:String!
        username:String!
        comments:[Comment]! #안쪽에 적으면 무조건 1개 있어야 되는 것으로 됨
        likes:[Like]!
    }
    type Comment{
        id: ID!
        createdAt: String!
        username: String!
        body:String!

    }
    type Like{
        id:ID!
        createdAt:String!
        username: String!
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
        #sayHi : String! #!은 필수
        getPosts: [Post]
        getPost(postID:ID!):Post
    }
    type Mutation{ #change database
        register(registerInput:RegisterInput): User!
        login(username:String!, password: String!):User!
        createPost(body:String!):Post!
        deletePost(postId:ID!):String!
        createComment(postId:String!, body:String!): Post!
        deleteComment(postId:String!, comemntId:ID!): Post!
        likePost(postId:ID!): Post!
    }
`