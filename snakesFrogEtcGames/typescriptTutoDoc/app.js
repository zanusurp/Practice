//typescript Academind
function add(n1, n2, showResult, phrase) {
    if (typeof n1 !== 'number' && typeof n2 !== 'number') {
        throw new Error('Incorrect Input ! ');
    }
    var result = n1 + n2; //밑에 그냥 뒀더니 앞에가 문자화 돼 버려서 52.9가 나옴
    if (showResult) {
        console.log(phrase + result);
    }
    else {
        return n1 + n2;
    }
}
var test; //값을 줘서 정한게 없다면 ㅇ렇게 정의는 해주는 게 좋음 
test = 2;
var number1 = 5; //이것이 노멀자바였다면 숫자로그냥 더했을 것
var number2 = 2.9;
var printResult = true;
var resultPhrase = 'result is : ';
add(number1, number2, printResult, resultPhrase);
//object : generic
var person = {
    name: 'Maxim',
    nickname: 'tajan',
    age: 30
};
//{} 이게 오브젝트 표현인데 안에 파라미터를 넣으면 각개 부를 수 있도록 바뀜
var person1 = {
    name: 'Maxim',
    nickname: 'tajan',
    age: 30,
    role: [2, 'podo']
};
//그냥 이렇게 하라함
var person2 = {
    name: 'max',
    age: 30,
    hobbies: ['Sports', 'Cooking'],
    role: [2, 'author'] //튜플
};
person2.role.push('admin');
//person2.role[1] = 10;
console.log(person);
console.log(person1.age);
console.log(person2.age);
//Array
console.log(person2.hobbies[1]);
var favoriteActivities;
favoriteActivities = ['Sports']; //스트링으로 배열 했기 때문에 이전처럼 아무거나 안들어감
var favoriteActivities1; //이건 아무거나 들어감 any타입
favoriteActivities1 = ['aa', 1, true, person];
for (var _i = 0, _a = person2.hobbies; _i < _a.length; _i++) { //foreach 같다 
    var hobby = _a[_i];
    console.log(hobby.toUpperCase());
    //console.log(hobby.map()); //error
}
//Enums 이넘
//const ADMIN = 0;
//const  READ_ONLY = 1;
//const AUTHOR = 2;
var Role;
(function (Role) {
    Role[Role["ADMIN"] = 0] = "ADMIN";
    Role[Role["READ_ONLY"] = 1] = "READ_ONLY";
    Role[Role["AUTHOR"] = 2] = "AUTHOR";
})(Role || (Role = {}));
var person3 = {
    name: 'mm',
    age: 20,
    hobbies: ['ss', 'dd'],
    role: Role.ADMIN //enum으로 쓸 예정 번호에 따른 역할 
};
if (person3.role === Role.ADMIN) {
    console.log('role is ADMIN');
}
//ANY TYPE 애니 타입  : 특정 한 게 없다 
//타입 여러개 가능하게 설정
function combine(input1, input2, resultConversion) {
    //const result = input1 + input2; //에러남
    var result;
    if (typeof input1 === 'number' && typeof input2 === 'number' || resultConversion === 'as-number') {
        result = +input1 + +input2; //앞에 플러스를 붙임으로서 문자도 숫자화 하는 것임 
    }
    else {
        result = input1.toString() + input2.toString();
    }
    return result;
    // if(resultConversion === 'as-number'){ //주석 먹이고 맨 위에 or로 넣으면 됨
    //     return parseFloat(result);
    // }else{
    //     return result.toString();
    // }
}
var conbinedAges = combine(30, 26, 'as-number');
console.log(conbinedAges);
var conbinedStringsAges = combine('30', '26', 'as-number');
console.log(conbinedStringsAges);
var conbimedNames = combine('Max', 'Anna', 'as-text');
console.log(conbimedNames);
