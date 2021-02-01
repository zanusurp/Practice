const { gql } = require('apollo-server');

module.exports = gql`
    type Post{
        id: ID!
        body:String!
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
        #sayHi : String! #!은 필수
        getPosts: [Post]
    }
    type Mutation{ #change database
        register(registerInput:RegisterInput): User!
        login(username:String!, password: String!):User!
    }
`