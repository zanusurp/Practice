const { ApolloServer } = require('apollo-server');
const gql = require('graphql-tag');
const mongoose = require('mongoose');

const typeDefs = require('./graphql/typeDefs');
const resolvers = require('./graphql/resolvers');
const { MONGODB } = require('./config');



const server = new ApolloServer({
    typeDefs,
    resolvers
});
const Port = process.env.PORT || 5000;
mongoose.connect(MONGODB,{useNewUrlParser: true}).then(()=>{
    console.log('Mongodb Connected')
    return server.listen({port:Port})
}).then(res => {
    console.log(`server running at ${res.url}`);
});





