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