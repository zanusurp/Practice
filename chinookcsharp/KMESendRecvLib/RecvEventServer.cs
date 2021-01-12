using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlProject
{//이벤트 수신 
    public class RecvEventServer
    {
        Socket lis_sock;
        public event RecvKMEEventHandler RecvKMEEventHandler = null;
        public RecvEventServer(string ip, int port)
        {//하나로 합쳐 만들지 않는 이유는 아이파와 포트가 여러개 있는 환경일수도있으므로
            lis_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            lis_sock.Bind(ep);
            lis_sock.Listen(5);
            lis_sock.BeginAccept(DoAccept, null);//비동기
            
        }

        private void DoAccept(IAsyncResult result)
        {
           if(lis_sock != null)
            {
                Socket dosock = lis_sock.EndAccept(result); //ACcept가 연결 됨
                lis_sock.BeginAccept(DoAccept, null); //또 오면 또 하는 것 
                Receive(dosock);//바등기 것을 처리 
            }
        }

        private void Receive(Socket dosock)//9바이트 받은 것 처리
        {
            byte[] buffer = new byte[9];
            int n = dosock.Receive(buffer);
            if(RecvKMEEventHandler != null){

                RecvKMEEventArgs e = new RecvKMEEventArgs(new Meta(buffer));
                RecvKMEEventHandler(this, e);
            }
            dosock.Close();
        }
        public void Close()
        {
            if(lis_sock != null)
            {
                lis_sock.Close();
                lis_sock = null;
            }
        }
    }
}
