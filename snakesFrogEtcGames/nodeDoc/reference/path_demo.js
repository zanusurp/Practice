const path = require('path');

//base file naem
console.log('filename : '+__filename);
console.log(path.basename("base naem : " +__filename));
//Director yname 
console.log(path.dirname("basenaem dir: "+__filename));

//file extension 
console.log(path.extname('path extname  :'+__filename));
console.log(path.parse('par name :  '+__filename));

//concreteness path
console.log(path.join(''+__dirname, 'test','hello.html'));
