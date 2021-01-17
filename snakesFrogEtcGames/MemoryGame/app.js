document.addEventListener('DOMContentLoaded',()=>{
    //cards
    const cardArray = [
        {
            name:'fries',
            img:'images/fries.png'
        },
        {
            name: 'cheeseburger',
            img: 'images/cheeseburger.png'
          },
          {
            name: 'ice-cream',
            img: 'images/ice-cream.png'
          },
          {
            name: 'pizza',
            img: 'images/pizza.png'
          },
          {
            name: 'milkshake',
            img: 'images/milkshake.png'
          },
          {
            name: 'hotdog',
            img: 'images/hotdog.png'
          },
          {
            name: 'fries',
            img: 'images/fries.png'
          },
          {
            name: 'cheeseburger',
            img: 'images/cheeseburger.png'
          },
          {
            name: 'ice-cream',
            img: 'images/ice-cream.png'
          },
          {
            name: 'pizza',
            img: 'images/pizza.png'
          },
          {
            name: 'milkshake',
            img: 'images/milkshake.png'
          },
          {
            name: 'hotdog',
            img: 'images/hotdog.png'
          }
    ];
    cardArray.sort(()=>0.5 - Math.random());

    const grid = document.querySelector('.grid'); //grid 잡
    const resultDisplay = document.querySelector('#result'); //점수판 잡
    let cardsChosen = [];
    let cardsChosenId = [];
    let cardsWon = [];

    //Board
    function createBoard(){
        for(let i = 0; i< cardArray.length; i++){
            const card = document.createElement('img');
            card.setAttribute('src','images/blank.png');
            card.setAttribute('data-id',i);
            card.addEventListener('click',flipCard); //카드 뒤집
            grid.appendChild(card); //위에서 잡은 그리드 안에 카드라는 img 놓음
        }
    }

    //매칭 체크
    function checkForMatch(){
      const cards = document.querySelectorAll('img');
      const optionOneId = cardsChosenId[0];
      const optionTwoId = cardsChosenId[1];

      if(optionOneId == optionTwoId){
        cards[optionOneId].setAttribute('src','images/blank.png');
        cards[optionTwoId].setAttribute('src','images/blank.png');
        alert('YOu have clicked the same image');
      }
      else if(cardsChosen[0] === cardsChosen[1]){
        alert('You found a match');
        cards[optionOneId].setAttribute('src','images/white.png');
        cards[optionTwoId].setAttribute('src','images/white.png');
        cards[optionOneId].removeEventListener('click', flipCard);
        cards[optionTwoId].removeEventListener('click', flipCard);
        cardsWon.push(cardsChosen);
      }else{
        cards[optionOneId].setAttribute('src','images/blank.png');
        cards[optionTwoId].setAttribute('src','images/blank.png');
        alert('Try Again');
      }
      //초기화
      cardsChosen = [];
      cardsChosenId =[];
      //점수판
      resultDisplay.textContent = cardsWon.length;
      if(cardsWon.length === cardArray.length/2){
        resultDisplay.textContent = 'Congratulation You Found them all';
      }

    }
    //플립 펑션
    function flipCard(){
      let cardId = this.getAttribute('data-id');
      cardsChosen.push(cardArray[cardId].name);
      cardsChosenId.push(cardId);
      this.setAttribute('src',cardArray[cardId].img);
      if(cardsChosen.length ===2){
        setTimeout(checkForMatch, 500);
      }
    }
    createBoard();
});