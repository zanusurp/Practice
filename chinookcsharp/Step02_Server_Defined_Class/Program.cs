using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step02_Server_Defined_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            EchoServer es = new EchoServer("192.168.1.13",10248);
            es.RecievedMsgEventHanlder += ES_RecievedMsgEventHandler;
            es.AcceptedEventHandler += ES_AcceptedEventHandler;
            es.ClosedEventHanlder += ES_ClosedEventHanlder;
            if (es.Start() == false)
            {
                Console.WriteLine("서버 가동 실패");
                return;
            }
            Console.ReadKey(); //연결됐을 떄 키를 읽는다.
        }

        private static void ES_ClosedEventHanlder(object sender, ClosedEventArgs e)
        {
            Console.WriteLine("{0}:{1}에서 연결을 닫음",e.IPStr,e.Port);
        }

        private static void ES_AcceptedEventHandler(object sender, AcceptedEventArgs e)
        {
            Console.WriteLine("{0}:{1}에서 연결을 했음", e.IPStr, e.Port);
        }

        private static void ES_RecievedMsgEventHandler(object sender, RecievedMsgEventArgs e)
        {
            Console.WriteLine("{0}:{1} - > {2}", e.IPStr, e.Port,e.Msg);
        }
    }

    
}
