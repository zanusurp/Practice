using RecvRCInfoEventLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlProject
{// 요청 수신 
    public static class SetupServer
    {
        static Socket lis_sock; //리슨 소켓
        //누가 요청했는지 확인 헨들러
        static public event RecvRCInfoEventHandler RecvRCInfoEventHandler = null;
        static string ip; //셋업 가능하기 위한 아이피
        static int port; // 셋업 가능하기 위한 포트 지정 
        public static void Start(string ip, int port) //서버 가동
        {
            SetupServer.ip = ip;
            SetupServer.port = port;
            SocketBooting();
        }

        private static void SocketBooting()
        {
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            lis_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            lis_sock.Bind(ep); //해당 소켓을 우리가 지정한 ep와 바인드
            lis_sock.Listen(1); //해당 소켓으로 리슨 한명만 수락
            lis_sock.BeginAccept(DoAccept, null);//비동기 
        }
        static void DoAccept(IAsyncResult result) //상대 연결 요청 온 상황
        {
            if(lis_sock == null) //연결 문제 발생시 
            {
                return; //바로 종료 , 파기
            }
            try
            {
                Socket sock = lis_sock.EndAccept(result);//
                DoIt(sock);
                lis_sock.BeginAccept(DoAccept, null); //또요청 올 시,쓰레디 없이 무한반복
            }
            catch (Exception)
            {
                Close();// 문제 발생시닫음
            }
        }

        public static void Close()
        {
            if(lis_sock != null)
            {
                lis_sock.Close();
                lis_sock = null; //닫혔는데 안 닫혔을 수도 있으니 확인 
            }
        }

        private static void DoIt(Socket dosock) //연결 실질 작업
        {
            if(RecvRCInfoEventHandler != null)
            {//local은 나 remoteendpoint는 상대
                RecvRCInfoEventArgs e = new RecvRCInfoEventArgs(dosock.RemoteEndPoint);
                RecvRCInfoEventHandler(null, e);
            }
            dosock.Close();
        }
    }
}
