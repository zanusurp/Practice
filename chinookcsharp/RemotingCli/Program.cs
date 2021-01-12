using GeneralLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace RemotingCli
{
    public class Program
    {//같은 General 참조 해야 함 
        static void Main(string[] args)
        {
            HttpChannel hc = new HttpChannel();
            ChannelServices.RegisterChannel(hc, false);
            General gen = Activator.GetObject(
                typeof(General),
                "http://192.168.1.13:10400/MyREmote") as General; //오브젝트 형식으로하여 메소드 사용
            string str = gen.ConvertIntToStr(2);
            Console.WriteLine("호출 결과 :{0}",str );
            Console.ReadLine();
            str = gen.ConvertIntToStr(3);
            Console.WriteLine("호출 결과 :{0}", str);
            Console.ReadLine();
            str = gen.ConvertIntToStr(5);
            Console.WriteLine("호출 결과 :{0}", str);
            Console.ReadLine();
            str = gen.ConvertIntToStr(9);
            Console.WriteLine("호출 결과 :{0}", str);
            Console.ReadLine();
            str = gen.ConvertIntToStr(7);
            Console.WriteLine("호출 결과 :{0}", str);
            Console.ReadLine();
        }
    }
}
