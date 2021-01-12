using GeneralLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace RemotingServ
{
    public class Program
    {
        static void Main(string[] args)
        {// 리모트 TCP:바이너리포멧 HTTP:SOAP포맷 사용 
            HttpChannel hc = new HttpChannel(10400);
            ChannelServices.RegisterChannel(hc, false); //뒤는 보안인데 신경 안쓰고 작성
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(General),
                "MyRemote",
                WellKnownObjectMode.Singleton);//singleton과 singlecall 하나/ 계속 생성
            Console.ReadKey(); //이게 없으면 서비스 하자마자 끝남
        }
    }
}
