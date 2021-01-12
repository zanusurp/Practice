//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace RemoteControlProject//새프로젝트에서 라이브러리로 만듦
//{//원격제어할 떄 누가 하는지 전달하는 역할 
//    public delegate void RecvRCInfoEventHandler(object sender, RecvRCInfoEventArgs e);
//    public class RecvRCInfoEventArgs:EventArgs
//    {
//        public IPEndPoint IPEndPoint//누구한테 IP요청이 왔는가 
//        {
//            get;
//            private set;
//        }
//        public string APAddressStr
//        {//ip
//            get
//            {
//                return IPEndPoint.Address.ToString();
//            }
            
//        }
//        public int Port
//        {//port
//            get
//            {
//                return IPEndPoint.Port;
//            }
//        }
//        public RecvRCInfoEventArgs(EndPoint RemoteEndPoint)//생성자 소켓 네트워크뭐가 오든
//        {//
//            IPEndPoint = RemoteEndPoint as IPEndPoint; //입맛에 맞춰 변경
            
//        }
//    }
//}
