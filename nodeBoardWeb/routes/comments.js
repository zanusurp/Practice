var express = require('express');
var router = express.Router();
var Comment = require('../models/Comment');
var Post = require('../models/Post');
var util = require('../util');

//create
router.post('/', util.isLoggedin, checkPostId, function(req,res){
    var post = res.locals.post;
    req.body.author = req.user._id;
    req.body.post = post._id;

    Comment.create(req.body, function(err, comment){
        if(err){
            req.flash('commentForm', {_id:null, form:req.body});
            req.flash('commentError', {_id:null, errors:util.parseError(err)});
        }
        return res.redirect('/posts/'+post._id+res.locals.getPostQueryString());
    });
});
//댓글 수정 
router.put('/:id', util.isLoggedin, checkPermission, checkPostId, function(req,res){
    var post = res.locals.post;
    req.body.updatedAt = Date.now();
    Comment.findOneAndUpdate({_id:req.params.id}, req.body, {runValidators:true}, function(err, comment){
        if(err){
            req.flash('commentForm',{_id:req.params.id, form:req.body});
            req.flash('commentError',{_id:req.params.id, errors:util.parseError(err)});
        }
        return res.redirect('/posts/'+post._id+res.locals.getPostQueryString());
    });
});

//삭제
router.delete('/:id', util.isLoggedin, checkPermission, checkPostId, function(req,res){
    var post = res.locals.post;

    Comment.findOneAndDelete({_id:req.params.id}, function(err, comment){
        if(err) return res.json(err);
        //수정된 코멘트 저장
        comment.isDeleted = true;
        comment.save(function(err, comment){
            if(err) return res.json(err);
            return res.redirect('/posts/'+post._id+res.locals.getPostQueryString());
        });
    });
});

//모듈 내보내기
module.exports = router;


//허가
function checkPermission(req, res, next){
    Comment.findOne({_id:req.params.id}, function(err, comment){
        if(err) return res.json(err);
        if(comment.author != req.user.id) return util.noPermission(req,res);

        next();
    });
}

//포스트 번호 체크 
function checkPostId(req,res, next){
    Post.findOne({_id:req.query.postId}, function(err,post){
        if(err) return res.json(err);

        res.locals.post = post;
        next();
    });
}