const { ApolloServer } = require('apollo-server'); //graphql 열기위한 서버
const mongoose = require('mongoose');

const typeDefs = require('./graphql/typeDefs');
const resolvers = require('./graphql/resolvers');
const { MONGODB } = require('./config');

//const pubsub = new PubSub();

const PORT = process.env.PORT || 5000;

const server = new ApolloServer({
    typeDefs,
    resolvers,
    context: ({ req }) =>  ({ req, pubsub })
});

//mongoose
mongoose.connect(MONGODB, { useNewUrlParser:true })
    .then(()=>{
        console.log('MongoDB Connected');
        return server.listen({port:PORT});
    })
    .then((res)=>{
        console.log(`server running at + ${res.url}`);
    })


