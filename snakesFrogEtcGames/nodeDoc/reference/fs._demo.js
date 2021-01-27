const fs = require('fs');
const path = require('path');

//create folder
// fs.mkdir(path.join(__dirname,'/test'),{},function(err){
//     if(err) throw err;
//     console.log('folder created...');
// });

//create and write files
fs.writeFile(path.join(__dirname,'/test','hello.text'),'Hello World!',err =>{
    if(err) throw err;
    console.log('file is written');
});

fs.writeFile(path.join(__dirname,'/test','hello.text'),'I Love Node js !',err =>{
    if(err) throw err;
    console.log('file is written');
});//overwritten

fs.appendFile(path.join(__dirname,'/test','hello.text'),'Hello Again', err => {
    if(err) throw err;
    console.log('file is appended ');
});

//read file
fs.readFile(path.join(__dirname, '/test','hello.text'),'utf8', (err, data)=>{
    if(err) throw err;
    console.log(data);
});

//rename file
fs.rename(path.join(__dirname,'/test','hello.text'),path.join(__dirname,'/test','helloword.txt'), err=>{
    if(err) throw err;
    console.log('renamed');
});




