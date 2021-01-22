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

//object
const person = {
    name:'Maxim',
    nickname:'tajan',
    age: 30
};
console.log(person.nickname);
