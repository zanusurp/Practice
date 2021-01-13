$(document).ready(function(){
    function get2digits (num){ //2자리 만들기 
        return ('0' + num).slice(-2);
    }
    function getDate(dateObj){ //달과 일수 2자리 만들기 함수 재사용
        if(dateObj instanceof Date)
        return dateObj.getFullYear()+'-'+get2digits(dateObj.getMonth()+1)+'-'+get2digits(dateObj.getDate());
    }

    function getTime(dateObj){ //시간 만들기 2자리 만들기 함수 재사용
        if(dateObj instanceof Date)
        return get2digits(dateObj.getHours())+ ':'+get2digits(dateObj.getMinutes())+':'+get2digits(dateObj.getSeconds());
    }

    function convertDate(){ //날짜 Date로 변경
        $('[data-date]').each(function(index, element){
            var dateString = $(element).data('date');
            if(dateString){
                var date = new Date(dateString);
                $(element).html(getDate(date));

            }
        });
    }
    function convertDateTime(){ // 날짜 시간 Date로 변경
        $('[data-date-time]').each(function(index,element){
            var dateString = $(element).data('date-time');
            if(dateString){
                var date = new Date(dateString);
                $(element).html(getDate(date)+ ' ' +getTime(date));
            }
        });
    }
    //exec
    convertDate();
    convertDateTime();
});

$(function(){
    var search = window.location.search; //서치 하는 것 찾음
    var params = {};
  
    if(search){ 
      $.each(search.slice(1).split('&'),function(index,param){
        var index = param.indexOf('=');
        if(index>0){
          var key = param.slice(0,index);
          var value = param.slice(index+1);
  
          if(!params[key]) params[key] = value;
        }
      });
    }
  
    if(params.searchText && params.searchText.length>=3){ 
      $('[data-search-highlight]').each(function(index,element){
        var $element = $(element);
        var searchHighlight = $element.data('search-highlight');
        var index = params.searchType.indexOf(searchHighlight);
  
        if(index>=0){
          var decodedSearchText = params.searchText.replace(/\+/g, ' '); //띄어쓰기가 있는 경우 +가 되니 이걸로 빈칸 만들어줌
          decodedSearchText = decodeURI(decodedSearchText);
          
          var regex = new RegExp(`(${decodedSearchText})`,'ig'); 
          $element.html($element.html().replace(regex,'<span class="highlighted">$1</span>'));
        }
      });
    }
  });