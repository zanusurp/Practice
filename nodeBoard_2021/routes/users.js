//route users
const express = require('express');
const router = express.Router();
const User = require('../model/User');
const util  =require('../util');

//유저 목록 어드민용
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
    const user = req.flash('user')[0] || {}; //플래시 사용하여 임시 저장
    const errors = req.flash('errros')[0] || {};
    res.render('users/new', {user:user, errors:errors}); //뿌림
});
//생성
router.post('/', function(req,res){
    User.create(req.body, function(err, user){
        if(err){
            req.flash('user',req.body);
            req.flash('errors',util.parseError(err));
            return res.redirect('/usesr/new');
        }
        res.redirect('/users');
    });
});

//보이기
router.get('/:username',util.isLoggedin,checkPermission, function(req,res){
    User.findOne({username:req.params.username}, function(err,user){
        if(err) return res.json(err);
        res.render('users/show',{user:user});
    });
});

//사용자 수정파넬 이동
router.get('/:username/edit',util.isLoggedin,checkPermission, function(req,res){
    const user = req.flash('user')[0];
    const errors = req.flash('errors')[0] || {};
    if(!user){
        User.findOne({username:req.params.username}, function(err,user){
            if(err) return res.json(err);
            res.render('users/edit', {username:req.params.username, user:user, errors:errors});
        });
    }else{
        res.render('users/edit',{username:req.params.username, user:user, errors: errors});
    }

    User.findOne({username:req.params.username}, function(err, user){
        if(err) return res.json(err);
        res.render('users/edit', {user:user});
    });
});

//사용자 업뎃
router.put('/:username',util.isLoggedin,checkPermission,function(req,res,next){
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
                if(err){
                    req.flash('user',req.body);
                    req.flash('errors',util.parseError(err));
                    return res.redirect('/users/'+req.params.username+'/edit');
                }
                res.redirect('/users/'+user.username);
            }); 
        });
});
//삭제 어드민용
router.delete('/:username', function(req,res){
    User.deleteOne({username:req.params.username}, function(err){
        if(err) return res.json(err);
        res.redirect('/users');
    });
}); 

module.exports = router;

function checkPermission(req, res, next){
    User.findOne({username:req.params.username}, function(err, user){
     if(err) return res.json(err);
     if(user.id != req.user.id) return util.noPermission(req, res);
   
     next();
    });
   }