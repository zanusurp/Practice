//공식 문서 사이트 
//https://nodejs.org/dist/latest-v14.x/docs/api/synopsis.html
const http = require('http');
const hostname = '127.0.0.1';
const port = 3000;

const server = http.createServer((req, res) => {
    res.statusCode = 200;
    res.setHeader('Content-Type', 'text/plain');
    res.end('Hello, World node ');
});

server.listen(port, hostname, ()=> {
    console.log('server running at local ${hostname} : ${port}');
});