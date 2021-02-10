//Model Post.js
const mongoose = require('mongoose');

//schema
const postSchema = mongoose.Schema({
    title:{type:String, require:true},
    body:{type:String, require:true},
    createdAt:{type:Date, default:Date.now},
    updatedAt:{type:Date}
});

// export
const Post = mongoose.model('post',postSchema);
module.exports = Post;