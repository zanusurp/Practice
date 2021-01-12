var http = require('http');
var fs = require('fs');
var server = http.createServer();

server.on('request', function(req,res){
    console.log('클라이언트 요청이 들어왔습니다');

    //이미지
    var filename = 'house.png';
    fs.readFile(filename, function(err, data){
        res.writeHead(200,{"Content-Type":"image/png"});
        res.write(data);
        res.end();
    });
    //스트림으로도 가능 단점은 헤더 부분을 설정하기 불가
    var infile = fs.createReadStream(filename, {flags:'r'});
    infile.pipe(res);
    
});


