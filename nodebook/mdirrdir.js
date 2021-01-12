var fs = require('fs');
fs.mkdir('./docs',0666,function(err){
    if(err) throw err;
    console.log('새 디렉토리 만듦');

    fs.rmdir('./docs',function(err){
        if(err) throw err;
        console.log('디렉토리 삭제 ');
    });
});
