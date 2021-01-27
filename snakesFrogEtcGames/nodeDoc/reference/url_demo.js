const url = require('url');
const myUrl = new URL('http://mywebsite.com/hello.html?id=100&status=active');

//serialize url
console.log(myUrl.href);
console.log(myUrl.toString());
//host (root domain)
console.log('host : '+myUrl.host);
console.log('host naem : '+myUrl.hostname);
//Path 
console.log(myUrl.pathname);
//SErial Query
console.log(myUrl.search);

//params.object
console.log(myUrl.searchParams);
//loop thorugh params
myUrl.searchParams.forEach((value, name) => console.log(`${name} : ${value}`));
