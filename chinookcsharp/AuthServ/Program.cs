using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuthServ
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel hc = new HttpChannel(10800); //
            ChannelServices.RegisterChannel(hc, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(EHAAALib.EHAAA),
                "AAASVC"
                ,WellKnownObjectMode.Singleton); //접근하기 위한 네임 AAASVC
            Console.ReadKey();//그냥 종료되지 않기 위함  서버 

        }
    }
}
