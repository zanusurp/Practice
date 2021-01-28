const express = require('express');
const uuid = require('uuid');
const router = express.Router();
const members = require('../../Members'); //테스트용 

//Get All memebrs
router.get('/', (req,res)=>{
    res.json(members);
});
//get Single Memebr
router.get('/:id', (req,res)=>{
    //res.send(req.params.id); //포스트로 테스트 해보면 그냥 숫자만 나오게 됨
    const found = members.some(member => member.id === parseInt(req.params.id));
    if(found){
        res.json(members.filter(member => member.id === parseInt(req.params.id)));//맴버 아이디는 숫자라 숫자에 맞춰야함 파람은 문자임
    }else{
        res.status(400).json({ msg: `The ID no ${req.params.id}Member not  found` });
    }
    
});
//Create Memebr
router.post('/', (req,res)=>{
    //res.send(req.body); //이렇게하면 보여줌
    const newMember = {
        id : uuid.v4(),
        name : req.body.name,
        email : req.body.email,
        status : 'active'
    };
    if(!newMember.name || ! newMember.email){
        return res.status(400).json({msg:'Please fill name and  email'});;
    }
    members.push(newMember);
    res.json(members);
    //res.redirect('/')
});

//update Member
router.put('/:id', (req,res)=>{
    //res.send(req.params.id); //포스트로 테스트 해보면 그냥 숫자만 나오게 됨
    const found = members.some(member => member.id === parseInt(req.params.id));
    if(found){
        const updMember = req.body;
        members.forEach(member => {
            if(member.id === parseInt(req.params.id)){
                member.name = updMember.name ? updMember.name : member.name;
                member.email = updMember.email ? updMember.email : member.email;

                res.json({msg : 'MEmebr was updated', member});
            }
        });
    }else{
        res.status(400).json({ msg: `The ID no ${req.params.id}Member not  found` });
    }
    
});
//delete Member
router.delete('/:id', (req,res)=>{
    //res.send(req.params.id); //포스트로 테스트 해보면 그냥 숫자만 나오게 됨
    const found = members.some(member => member.id === parseInt(req.params.id));
    if(found){
        res.json({msg : 'Member deleted', members: members.filter(member => member.id !== parseInt(req.params.id))});//이건 그냥 제거한 채 뽑아낸건데 ㅡ ㅡ 
    }else{
        res.status(400).json({ msg: `The ID no ${req.params.id}Member not  found` });
    }
    
});


module.exports = router;