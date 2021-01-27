const http = require('http');
const path = require('path');
const fs = require('fs');

const server = http.createServer((req,res)=>{
    
    // if(req.url === '/'){
    //     fs.readFile(path.join(__dirname,'public','index.html'),(err,data) => {
    //         res.writeHead(200, {'Content-Type':'text/html'});
    //         res.end(data);
    //     });

    // }
    // if(req.url==='/about'){
    //     fs.readFile(path.join(__dirname,'public','about.html'),(err,content) =>{
    //         if(err) throw err;
    //         res.writeHead(200, {'Content-Type':'text/html'});
    //         res.end(content);
    //     });
    // }
    // if(req.url === '/api/users'){
    //     const users = [
    //         {name:'Bob Smith',age:40},
    //         {name:'Bob jong',age:20}
    //     ];
    //     res.writeHead(200, {'Content-Type':'application/json'});
    //     res.end(JSON.stringify(users));
    // }
    //buildPath
    let filePath = path.join(__dirname,'public',req.url === '/' ? 'index.html':req.url);
    console.log(filePath);
    //extension of file
    let extName = path.extname(filePath);
    //initial content Type
    let ContentType = 'text/html';
    //Check your ext and set content type
    switch(extName){
        case '.js':
            ContentType = 'text/javascript';
            break;
        case '.css':
            ContentType = 'text/css';
            break;
        case '.json':
            ContentType = 'application/json';
            break;
        case '.png':
            ContentType = 'image/png';
            break;
        case '.jpg':
            ContentType = 'image/jpg';
            break;
        
            
    }

    //ReadFile
    fs.readFile(filePath, (err, content) => {
        if(err){
            if(err.code =='ENOENT'){
                //page not found
                fs.readFile(path.join(__dirname, 'public','404.html'),(err,content)=>{
                    res.writeHead(200, {'Content-Type':'text/html'});
                    res.end(content,'utf8');
                });
            }else{
                //Some server error
                res.writeHead(500);
                res.end(`Server Error : ${err.code}`);
            }
        }else{//no error
            res.writeHead(200,{'Content-Type':'text/html'});
            res.end(content,'utf8');
        
        }   

    });
    
});
const PORT = process.env.PORT | 5000;

server.listen(PORT, () => console.log('server is running on host :'+PORT));

