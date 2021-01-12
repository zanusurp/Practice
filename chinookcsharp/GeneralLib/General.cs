using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLib
{//서버와 클라 둘 다 쓰임
    public class General : MarshalByRefObject //리모트 채널 프록시 자동
    {
        public string ConvertIntToStr(int num)
        {
            Console.WriteLine("ConvertIntToStr 메소드 수행 (전달 받은 인자는 : {0})",num);
            switch (num)
            {
                case 0: return "영";
                case 1: return "일";
                case 2: return "이";
                case 3: return "삼";
                case 4: return "사";
                case 5: return "오";
                case 6: return "육";
                case 7: return "칠";
                case 8: return "팔";
                case 9: return "구";
                default: return "모르는 수";
            }
        }
    }
}
