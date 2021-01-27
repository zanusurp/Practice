const EventEmitter = require('events');
//create Class
class MyEmitter extends EventEmitter{

}

//Init Obejct
const myEmitter = new MyEmitter();
//Event Listener
myEmitter.on('event', () => console.log('Event fired!'));
//Init Event
myEmitter.emit('event');
myEmitter.emit('event');
myEmitter.emit('event');
myEmitter.emit('event');
myEmitter.emit('event');
