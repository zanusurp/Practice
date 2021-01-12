using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlProject
{//요청
    public static class SetupClient //정적으로함
    {
        public static event EventHandler ConnectedEventHandler = null;//허락한 정보 정상적
        public static event EventHandler ConnectFailedEventHandler = null;//비정상일시
        static Socket sock;
        public static void Setup(string ip, int port) //서버측 아피와 포트 
        {
            IPAddress ipaddr = IPAddress.Parse(ip); //위에 받은 것 ip화
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//v4, 신뢰성 있는 방식(보장;파일전송등), tcp;송수신자3헨드쉨
            //sock.Connect(ep); //동기식,비동기로 하지 않다면 연결안될시 시스템 멈춤
            sock.BeginConnect(ep, DoConnect, null);//비동기,3번째는 static sock있으므로nun

        }
        static void DoConnect(IAsyncResult result)
        {
            AsyncResult ar = result as AsyncResult;
            try
            {
                sock.EndConnect(result);//시스템 정상 종결
                if(ConnectedEventHandler != null)//비동기 정상연결인지 확인 
                {
                    ConnectedEventHandler(null, new EventArgs());//이벤트 발생 호출 
                }
            }
            catch (Exception)
            {
                //연결이 되지 않았을 시에 
                if(ConnectFailedEventHandler != null)
                {
                    ConnectFailedEventHandler(null, new EventArgs());
                }
            }
            sock.Close();
        }
        
    }
}
