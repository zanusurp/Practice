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










