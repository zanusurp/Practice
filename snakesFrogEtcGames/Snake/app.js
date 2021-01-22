document.addEventListener('DOMContentLoaded', ()=>{
    const squares = document.querySelectorAll('.grid div');
    const scoreDisply = document.querySelector('span');
    const StartBtn = document.querySelector('.start');
    
    
    console.log('전체필드  : '+squares);
    
    const width = 10;
    let currentIndex = 0; //그리드 첫번째 박스
    let appleIndex = 0; //첫번째 사과
    let currentSnake = [2,1,0]; //현재 뱀
    let direction = 1; //속도
    let score = 0; //현 점수
    let speed = 0.9;//속도
    let intervalTime = 0;
    let interval =0;

    //시작/재시작
    function startGame(){
        //초기화
        currentSnake.forEach(index=> squares[index].classList.remove('snake'));
        squares[appleIndex].classList.remove('apple');
        clearInterval(interval);
        score=0; 
        randomApple(); //사과 셋
        direction=1;//속도1
        
        //기본 세팅
        scoreDisply.innerText = score;
        intervalTime = 1000;
        currentSnake=[2,1,0];
        currentIndex = 0;
        currentSnake.forEach(index => squares[index].classList.add('snake'));
        intervalTime = setInterval(moveOutcomes, intervalTime );//1초당움직임

    } 

    function moveOutcomes(){
        if(
            (currentSnake[0]+width >= (width*width) && direction === width) || //바닥에 박았을 떄  control학인 
            (currentSnake[0] % width === width -1 && direction === 1 ) || //뱀이 오른쪽 벽에 박았을 떄
            (currentSnake[0] % width === 0 && direction === -1) || //뱀이 왼쪽 벽을 박았을 떄 
            (currentSnake[0] - width <0 && direction === -width) || //뱀이  천정을 박았을 떄 control 확인
            squares[currentSnake[0] + direction].classList.contains('snake') //뱀이 적용 된 div 부분
        ){
            return clearInterval(interval); //박았을 떄 멈추게 됨 
        }
        //움직임
        const tail = currentSnake.pop();//끝자락 날라감
        squares[tail].classList.remove('snake'); //끝자라 스네이크 지움
        currentSnake.unshift(currentSnake[0] + direction); // 방향 쪽에 하나 추가

        //사과 먹은 후 
        if(squares[currentSnake[0]].classList.contains('apple')){
            squares[currentSnake[0]].classList.remove('apple'); //스네이크 머리가 현재 타일에 도달시 사과 클래스 없앰
            squares[tail].classList.add('snake');
            currentSnake.push(tail);//추가
            randomApple(); //랜덤 생성
            score++;
            scoreDisply.textContent = score;
            clearInterval(interval);
            intervalTime = intervalTime * speed; //간격 줄여서 속도빠르게 바꿈 
            interval = setInterval(moveOutcomes, intervalTime);
        }
        squares[currentSnake[0]].classList.add('snake');
    }
    //애플 생성
    function randomApple(){
        do{
            appleIndex = Math.floor(Math.random() * squares.length); //스퀘어 내부에 생기도록 함 
        }while(squares[appleIndex].classList.contains('snake'));
        squares[appleIndex].classList.add('apple');
    }
    //조정
    function control(e){
        squares[currentIndex].classList.remove('snake');
        if(e.keyCode === 39){
            direction =1; //오른쪽 클릭시 오른쪽
        }else if(e.keyCode === 38){
            direction = -width; //위쪽 눌렀을 시 10칸 이동 (10*10 이기에)
        }else if(e.keyCode === 37){
            direction = -1; //왼쪽
        }else if(e.keyCode ===40){
            direction = +width; //아래로
        }     
    }
    document.addEventListener('keyup', control);
    StartBtn.addEventListener('click',startGame);
});