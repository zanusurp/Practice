const os = require('os');
//platform
console.log(os.platform());
//cpu arch X64
console.log(os.arch());
//cpu core info
console.log(os.cpus());

//free memory 
console.log(os.freemem()); //rest
console.log(os.totalmem());//entire

//home directory
console.log(os.homedir());
//uptime 
console.log(os.uptime()/3600);



