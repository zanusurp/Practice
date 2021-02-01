const { gql } = require('apollo-server');

module.exports = gql`
    type Post{
        id: ID!
        body:String!
        createdAt:String!
        username:String!
        comments:[Comment]! #안쪽에 적으면 무조건 1개 있어야 되는 것으로 됨
        likes:[Like]!
        likeCount: Int!
        conmmentCOunt:Int!
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
    type Query{ #포스트 목록 
        #sayHi : String! #!은 필수
        getPosts: [Post]
        getPost(postID:ID!):Post
    }
    type Mutation { #여기명령으로 상위 등록된 디비 실행함
    register(registerInput: RegisterInput): User!
    login(username: String!, password: String!): User!
    createPost(body: String!): Post!
    deletePost(postId: ID!): String!
    createComment(postId: String!, body: String!): Post!
    deleteComment(postId: ID!, commentId: ID!): Post!
    likePost(postId: ID!): Post!
    }
    type Subscription {
        newPost: Post!
    }
`;