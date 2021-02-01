const { ApolloServer } = require('apollo-server'); //calculate
const mongoose = require('mongoose');



const typeDefs = require('./graphql/typeDefs');
const resolvers = require('./graphql/resolvers');
const { MONGODB } = require('./config');



const server = new ApolloServer({
    typeDefs,
    resolvers
});

//mongoose
mongoose.connect(MONGODB, { useNewUrlParser:true })
    .then(()=>{
        console.log('MongoDB Connected');
        return server.listen({port:5000});
    })
    .then((res)=>{
        console.log(`server running at + ${res.url}`);
    })


