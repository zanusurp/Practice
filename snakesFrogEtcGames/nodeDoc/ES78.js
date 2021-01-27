//string.prototype.padStart/padEnd
const string = '12345';
console.log(string.padStart(10, '.'));
console.log(string.padEnd(10, '.'));
//Object.Values
const object = {
    name:'John',
    age: 20,
    favoriteBooks:['HarryPotter','DoppelSoeldner']
}
console.log(Object.values(object)); //shows object in linear type

//Object.entries
console.log(Object.entries(object)); //shows object in  tree type
//Async function

//Exponentiation 멱법이란: 거듭제곱을 하여 나오는 값을 말함
console.log(Math.pow(2,4));
console.log(2**4);
//Trailing Commas
const anotherObject = {
    first : 1,
    second : 2,
    third : 3 //
};

console.log(anotherObject);

const array = [1,,3]; //this one shows properly 
const array1 = [1,2,3,]; // I don't know why mine didn't work like lecture's terminal but it must show <one time> at the end of statement 
console.log(array);
console.log(array1);
//arrow function
const add = (a,b)=> console.log(a+b);
add(2,3);

const array2 = [1,2,3];
array2.map((number)=>{  //map자체는 기존 배열에 값의 변형을 주기 위한 것임 
    console.log('arraow'+number);
});
array2.forEach(function(element){
    console.log(element);
});

const greeting = (name) =>{
    const hey = 'Hello, ' + name + '!';
    const templateString = `HEllo , ${name}`; //What the hell it's what I've been lookingfor serveral times before. totally sma efuctin fo escaping statement 

    console.log(templateString);
}
greeting('Josh');
const [first, second, third] = array;
console.log(first, third);

const object1 = {
    channelName:'Javascript Mster',
    views : 15000
}
console.log(object1.channelName);
const {channelName, views} = object1;
console.log(channelName);

//rest operater
const add1 = (a,b,c) =>console.log([a,b,c].reduce((a,b)=> a+b, 0)); //c가 없다면 두번쨰로 있다면 첫번째로 그런 것임 
const add2 = (...numbers) => console.log(numbers.reduce((a,b)=>a+b,0)); //상관 없어짐 ...라는 것으로 몇개가 들어가든 무상관
add1(1,2,3);
add2(1,2,3,5,5,7,3,32,4,2);

//spread operator
const array4 = [1,2,3];
console.log(array4[0], array4[1],array4[2]);
console.log(...array4); //

