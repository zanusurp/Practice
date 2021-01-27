function addnum(a,b){
    console.log("named");
    console.log(a+b);
}
var anon = function(a,b){
    console.log('anonymous funciton initiated'+(a+b));
    
}

anon(2,4);
setTimeout(anon(100,100), 3000);
setTimeout(function(){console.log("anonymous after 3 secs"+(10+20));},3000);

//using constructors
var cons = new Function("a","b","console.log('in constructor function!');return a+b;");
cons(2,3);

//self invoking function
(function(a,b){
    console.log("in self invoking function :  "+ (a+b));
    return a+b;
}(2,6));

//object
var person = new Object();
person.name = "sasa";
person.age = 10;

var animal = {};
animal.name = "tiger";
animal.age = 222;

console.log(person);


function Person(){
    this.name = "aaa";
    this.age = 111;
}
var p  =new Person();
console.log(p);


//window
function windowOp(){
    var newWindow = window.open("http://google.com","newWindow","height=400, width=200");
    newWindow.moveTo(150,200);
    newWindow.close();
}

//alert('Screen width : ' + screen.width+"\n" + "SCreen color delpth" +screen.colorDepth);

document.write("<br> "+navigator.appCodeName);
document.write("<br> "+navigator.appName);
document.write("<br> "+navigator.oscpu);
document.write("<br> "+navigator.platform);

document.write("<br>" + location.href);
document.write("<br>" + location.host);
document.write("<br>" + location.protocol);

var ppp = document.getElementsByTagName('p');

//Even

// function paraClicked(){
//     document.getElementById('abc').setAttribute("style","color:yellow")
// }
// document.getElementById('abc').addEventListener("click", paraClicked);


//Form validations

$(document).ready(function(){
    $('#title').css('color','red');
});


