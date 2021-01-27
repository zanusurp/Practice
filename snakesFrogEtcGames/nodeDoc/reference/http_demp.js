const http =require('http');

http.createServer((req,res)=>{
    //write response
    res.write('Hello world');
    res.end();
}).listen(5000, ()=> console.log('server Running on http://localhost:5000'));