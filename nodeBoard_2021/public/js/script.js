$(function(){
    function get2digits(num){
        return('0'+num).slice(-2);
    }
    function getDate(dateObj){
        if(dateObj instanceof Date){
            return dateObj.getFullYear()+'-' + get2digits(dateObj.getMonth()+1)+'-'+get2digits(dateObj.getDate());
        }
            
    }
    function getTime(dateObj){
        if(dateObj instanceof Date){
            return get2digits(dateObj.getHours())+':'+get2digits(dateObj.getMinutes())+':'+get2digits(dateObj.getSeconds());
        }
    }
    function convertDate(){//날짜만
        $('[data-date]').each(function(index,element){
            const dateString = $(element).data('date');
            if(dateString){
                const date = new Date(dateString);
                $(element).html(getDate(date));
            }
        });
    }
    //날짜와 시간
    function convertDateTime(){ //var 가 아닌 const를 쓰는 이유는 var의 타입과 /scope 문제 때문 해서 안되면 도로 바꾸기로 그럴리는 없지만
        $('[data-date-time').each(function(index, element){
            const dateString = $(element).data('date-time');
            if(dateString){
                const date = new Date(dateString);
                $(element).html(getDate(date)+' '+ getTime(date));
            }
        });
    }

    convertDate();
    convertDateTime();
});
$(function(){
    var search = window.location.search;
    var params = {};

    if(search){
        $.each(search.slice(1).split('&'), function(index, param){
            var index  = param.indexOf('=');
            if(index>0){
                var key = param.slice(0, index);
                var value = param.slice(index+1);

                if(!params[key]) params[key] = value;
            }
        });
    }
    if(params.searchText && params.searchtText.length>=3){
        $('[data-search-highlight]').each(function(index, element){
            var $element = $(element);
            var searchHighLight = $element.data('search-highlight');
            var index = params.searchType.indexOf(searchHighLight);

            if(index>=0){
                var decodedSearchText = params.searchText.replace(/\+/g,' ');
                decodedSearchText = decodeURI(decodedSearchText);

                var regex = new RegExp(`(${decodedSearchText})`, 'ig');
                $element.html($element.html().replace(regex,'<span class="highlighted">$1</span>'));
            }
        });
    }
});