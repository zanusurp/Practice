//route users
const express = require('express');
const router = express.Router();
const User = require('../model/User');

//유저 목록
router.get('/', function(req,res){
    User.find({})
        .sort({username:1})
        .exec(function(err,users){
            if(err) return res.json(err);
            res.render('users/index', {users:users});
        });
});
//유저 생성파넬 이동
router.get('/new',function(req,res){
    res.render('users/new');
});
//생성
router.post('/', function(req,res){
    User.create(req.body, function(err, user){
        if(err) return res.json(err);
        res.redirect('/users');
    });
});

//보이기
router.get('/:username', function(req,res){
    User.findOne({username:req.params.username}, function(err,user){
        if(err) return res.json(err);
        res.render('users/show',{user:user});
    });
});

//사용자 수정파넬 이동
router.get('/:username/edit', function(req,res){
    User.findOne({username:req.params.username}, function(err, user){
        if(err) return res.json(err);
        res.render('users/edit', {user:user});
    });
});

//사용자 업뎃
router.put('/:username',function(req,res,next){
    User.findOne({username:req.params.username})
        .select('password')
        .exec(function(err, user){
            if(err) return res.json(err);

            user.originalPassword = user.password;
            user.password = req.body.newPassword? req.body.newPassword : user.password;
            for(var p in req.body){
                user[p] = req.body[p];
            }

            user.save(function(err, user){
                if(err) return res.json(err);
                res.redirect('/users/'+user.username);
            }); 
        });
});
//삭제
router.delete('/:username', function(req,res){
    User.deleteOne({username:req.params.username}, function(err){
        if(err) return res.json(err);
        res.redirect('/users');
    });
}); 

module.exports = router;