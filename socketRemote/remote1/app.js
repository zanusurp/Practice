const express  = require('express');
const app = express();

const post = process.env.PORT || 9900;
const io = require('socket.io');

io.listen(app.listen(port));

app.use(express.static(__dirname+'/public'));

const secret = 'Rem';

const presentation = io.on('connection', function(socket){
    socket.on('load', function(data){
        socket.emit('access',{
            access:(data.key === secret?'granted':'denied')
        });
    });

    socket.on('slide-changed',function(data){
        if(data.key === secret){
            presentation.emit('navigate',{
                hash:data.hash
            });
        }
    });
});
console.log(`runnong on http:// localhost:${post} `);