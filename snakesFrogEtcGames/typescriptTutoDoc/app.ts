//typescript Academind
function add(n1:number,n2:number,showResult:boolean, phrase:string){
    if(typeof n1 !== 'number' && typeof n2 !=='number'){
        throw new Error('Incorrect Input ! ');
    }
    const result = n1 + n2; //밑에 그냥 뒀더니 앞에가 문자화 돼 버려서 52.9가 나옴
    if(showResult){
        console.log(phrase + result);
    }else{
        return n1+n2;
    }
}
let test:number; //값을 줘서 정한게 없다면 ㅇ렇게 정의는 해주는 게 좋음 
test = 2;
const number1 = 5; //이것이 노멀자바였다면 숫자로그냥 더했을 것
const number2 = 2.9;
const printResult = true;
const resultPhrase = 'result is : ';
add(number1,number2, printResult, resultPhrase);

//object : generic
const person :object= {
    name:'Maxim',
    nickname:'tajan',
    age: 30
};
//{} 이게 오브젝트 표현인데 안에 파라미터를 넣으면 각개 부를 수 있도록 바뀜
const person1 :{
    name:string;
    nickname:string;
    age:number;
    role:[number,string]; //튜플 //Tuple 튜플 
}= {
    name:'Maxim',
    nickname:'tajan',
    age: 30,
    role:[2,'podo']
};
//그냥 이렇게 하라함
const person2 = {
    name:'max',
    age:30,
    hobbies:['Sports','Cooking'],
    role:[2,'author'] //튜플
};
person2.role.push('admin');
//person2.role[1] = 10;


console.log(person);
console.log(person1.age);
console.log(person2.age);
//Array
console.log(person2.hobbies[1]);

let favoriteActivities:string[];
favoriteActivities = ['Sports']; //스트링으로 배열 했기 때문에 이전처럼 아무거나 안들어감
let favoriteActivities1:any[]; //이건 아무거나 들어감 any타입
favoriteActivities1 = ['aa',1, true, person];

for (const hobby of person2.hobbies){ //foreach 같다 
    console.log(hobby.toUpperCase());
    //console.log(hobby.map()); //error
}

//Enums 이넘
//const ADMIN = 0;
//const  READ_ONLY = 1;
//const AUTHOR = 2;

enum Role{
    ADMIN, 
    READ_ONLY,
    AUTHOR
}

const person3 = {
    name: 'mm',
    age:20,
    hobbies:['ss','dd'],
    role:Role.ADMIN //enum으로 쓸 예정 번호에 따른 역할 
}
if(person3.role===Role.ADMIN){
    console.log('role is ADMIN');
}
//ANY TYPE 애니 타입  : 특정 한 게 없다 
//타입 여러개 가능하게 설정
type Combinable = number | string; //number | string대신 쓰게 됨
type TextOrNumber = 'as-number' | 'as-text';
function combine ( input1:Combinable, input2: Combinable, resultConversion:TextOrNumber){ //2가지 가능케 함
    //const result = input1 + input2; //에러남
    let result;
    if(typeof input1 ==='number' && typeof input2 ==='number' || resultConversion ==='as-number'){
        result = +input1 +  +input2; //앞에 플러스를 붙임으로서 문자도 숫자화 하는 것임 
    }else{
        result = input1.toString() + input2.toString();
    }
    return result;
    // if(resultConversion === 'as-number'){ //주석 먹이고 맨 위에 or로 넣으면 됨
    //     return parseFloat(result);
    // }else{
    //     return result.toString();
    // }
    
}
const conbinedAges = combine(30, 26,'as-number');
console.log(conbinedAges);

const conbinedStringsAges = combine('30', '26','as-number');
console.log(conbinedStringsAges);

const conbimedNames = combine('Max','Anna','as-text');
console.log(conbimedNames);

//void
function add2(n1:number, n2:number){
    return n1 + n2;
}
function printREsult(num:Number):void{ //  return 들어가면 타입을 undefined으로 가능
    console.log('Result : '+ num); //보이드 이기에 리턴할 이유가 없다 
}
printREsult(add2(5,12));
let combineValues;
combineValues =add2; //함수를넣어버릴 수있따 
console.log(combineValues(2,3));

let combineValues2 : Function; //함수만 들어가도록 명시

let combineValues3 : () => number; //함수화
//위 add2를 쓰고 싶다면
let combineValues4 : (a:number, b:number) => number;
combineValues4 = add2;
console.log(combineValues4(2,3));

function addAndHandle(n1:number, n2:number, cb:(num:number) => void){ //마지막 함수화
    const result = n1 + n2;
    cb(result);
}
addAndHandle(10,20, (result)=>{
    console.log(result);
    return result;
});

//unknown type 언노운 타입
let userInput: unknown; //언노운 타입  any와 비슷해 보이지만 다름
let userName1: string;
userInput = 5;
userInput = 'max';
//userName1 = userInput; //안됨 근데 unknow이 아닌 any면 됨
if( typeof userInput ==='string') {//규정을 명확하게 할 수 있음 
    userName1 = userInput;
}

//never type  네버 타입
function generateError(message:string, code:number):never{//never를 보냄
    throw {message:message , errorCode:code};
}

const result2 = generateError('An Error occurred',500);
console.log(result2); //이렇게 해서 타입을 보면uncaught