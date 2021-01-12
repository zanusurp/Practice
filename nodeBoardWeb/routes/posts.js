var express = require('express');
var router = express.Router();
var Post = require('../models/Post'); //model import
var User = require('../models/User');
var util = require('../util'); //에러처리용

//index
router.get('/',async function(req,res){ //함수 안에선 await를쓰고 이걸 쓰는 함수엔 꼭 async
    //paging ------------------------------------------------------
    var page = Math.max(1, parseInt(req.query.page));
    var limit = Math.max(1, parseInt(req.query.limit));
    page = !isNaN(page)?page:1; //페이지 없으면 1
    limit = !isNaN(limit)?limit:10; // 리밋 없으면 10까지를 제한으로 

    var searchQuery = createSearchQuery(req.query);

    //await를 써야 순차적으로 나감 
    var skip = (page-1)*limit; //현재 1페이지의 경우 0이 됨 스킵 안한단 소리 
    var maxPage = 0;

    var posts = [];
    if(searchQuery){
        var count = await Post.countDocuments(searchQuery); // 총 갯수 
        maxPage = Math.ceil(count/limit); //한 페이지당 10개씩 올림으로 해서 맥스페이지 구함
        posts = await Post.find(searchQuery) //나열 하는데 아래 조건에 맞춰서 함 
        .populate('author') //User에서 갖고올 것 Post에 리퍼돼 있음
        .sort('-createdAt') //내림차
        .skip(skip)
        .limit(limit)
        .exec();
    }    
    res.render('posts/index',{ //랜더 시작
        posts:posts,
        currentPage:page,
        maxPage:maxPage,
        limit:limit,
        searchType:req.query.searchType,
        searchText:req.query.searchText
    });
    // Post.find({}) //기존 이렇게 나열 했던 것을 페이징 넣어야 하므로 지움
    // .populate('author')
    // .sort('-createdAt')
    // .exec(function(err,posts){
    //     if(err) return res.json(err);
    //     res.render('posts/index',{posts:posts});
    // });
});

//new
router.get('/new', util.isLoggedin,function(req,res){ //로그인 됐는지 확인하고 작성
    var post = req.flash('post')[0] || {};
    var errors  = req.flash('errors')[0] || {};
    res.render('posts/new', {post:post, errors:errors});
});

//create
router.post('/', util.isLoggedin , function(req,res){
    req.body.author = req.user._id;
    Post.create(req.body, function(err, post){
        if(err){
            req.flash('post', req.body);
            req.flash('errors',util.parseError(err));
            return res.redirect('/posts/new'+res.locals.getPostQueryString());
        }
        res.redirect('/posts'+res.locals.getPostQueryString(false,{page:1, searchText:''}));

    });
});

//show
router.get('/:id', function(req, res){
    Post.findOne({_id:req.params.id}) 
      .populate('author')             
      .exec(function(err, post){      
        if(err) return res.json(err);
        res.render('posts/show', {post:post});
      });
  });

//edit
router.get('/:id/edit', util.isLoggedin, checkPermission, function(req, res){
    var post = req.flash('post')[0];
    var errors = req.flash('errors')[0] || {};
    if(!post){
      Post.findOne({_id:req.params.id}, function(err, post){
          if(err) return res.json(err);
          res.render('posts/edit', { post:post, errors:errors });
        });
    }
    else {
      post._id = req.params.id;
      res.render('posts/edit', { post:post, errors:errors });
    }
  });

//update
router.put('/:id', util.isLoggedin, checkPermission,function(req,res){
    req.body.updatedAt = Date.now();
    Post.findOneAndUpdate({_id:req.params.id}, req.body, {runValidators:true}, function(err, post){
        if(err){
            req.flash('post',req.body);
            req.flash('errors',util.parseError(err));
            return res.redirect('/posts/'+req.params.id+'/edit'+res.locals.getPostQueryString());
        }
        res.redirect('/posts/'+req.params.id+res.locals.getPostQueryString());
    });
});

//destroy
router.delete('/:id', util.isLoggedin, checkPermission,function(req,res){
    Post.deleteOne({_id:req.params.id}, function(err){
        if(err) return res.json(err);
        res.redirect('/posts'+res.locals.getPostQueryString());
    });
});

//export router 
module.exports = router;

//퍼미션
function checkPermission(req,res, next){
    Post.findOne({_id:req.params.id}, function(err,post){
        if(err) return res.json(err);
        if(post.author != req.user.id) return util.noPermission(req,res);

        next();
    });
}
//서치 쿼리 
async function createSearchQuery(queries){ 
    var searchQuery = {};
    if(queries.searchType && queries.searchText && queries.searchText.length >= 3){
      var searchTypes = queries.searchType.toLowerCase().split(',');
      var postQueries = [];
      if(searchTypes.indexOf('author!')>=0){ 
        var user = await User.findOne({ username: queries.searchText }).exec();
        if(user) postQueries.push({author:user._id});
      }
      else if(searchTypes.indexOf('author')>=0){ 
        var users = await User.find({ username: { $regex: new RegExp(queries.searchText, 'i') } }).exec();
        var userIds = [];
        for(var user of users){
          userIds.push(user._id);
        }
        if(userIds.length>0) postQueries.push({author:{$in:userIds}});
      }
      //regex에 대한 몽고 내용
      //https://docs.mongodb.com/manual/reference/operator/query/regex/
      //$or에 대한 몽고 내용
      //https://docs.mongodb.com/manual/reference/operator/query/or/
      if(searchTypes.indexOf('title')>=0){
        postQueries.push({ title: { $regex: new RegExp(queries.searchText, 'i') } });
      }
      if(searchTypes.indexOf('body')>=0){
        postQueries.push({ body: { $regex: new RegExp(queries.searchText, 'i') } });
      }
      if(postQueries.length>0) searchQuery = {$or:postQueries}; 
      else searchQuery = null;
    }
    return searchQuery;
  }