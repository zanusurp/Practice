using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MessageForm01
{//다른 사용자 접속 안내 서버 
    public class UserInfoCSServer
    {
        //헨들러 불러옴 
        public event UserInfoEventHandler UserInfoEventHandler = null;
        public string IPStr
        {
            get;
            set;
        }
        public int Port
        {
            get;
            set;
        }

        public UserInfoCSServer(string ipstr, int port)
        {
            IPStr= ipstr;
            Port= port;
        }
        Socket sock = null; // 어느 포트로 로딩 돼 있는지 확인하기 위함 
        public bool Start()
        {
            try
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipaddr = IPAddress.Parse(IPStr);
                IPEndPoint iep = new IPEndPoint(ipaddr, Port);
                bool check = true;
                while (check) //포트 정하기 부분
                {
                    try
                    {
                        sock.Bind(iep);
                        check = false;
                    }
                    catch 
                    {
                        Port += 2;
                        iep = new IPEndPoint(ipaddr, Port);
                    }
                }
                sock.Listen(5);
                AcceptLoopAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;// 실패시 서버 가동 못함
            }
        }
        delegate void AcceptDele();//스레드로 해도 됨 별다른 수동 추가건 없으므로
        private void AcceptLoopAsync()
        {
            AcceptDele dele = AcceptLoop;
            dele.BeginInvoke(null, null);
        }
        private void AcceptLoop()
        {
            Socket dosock;
            while (true)
            {
                dosock = sock.Accept();
                DoItAsync(dosock);
            }
        }
        //비동기 처리 
        delegate void DoitDele(Socket dosock);
        private void DoItAsync(Socket dosock)
        {
            DoitDele dele = Doit;
            dele.BeginInvoke(dosock, null, null);
        }
        private void Doit(Socket dosock)
        {
            byte[] packet = new byte[1024];
            dosock.Receive(packet);
            MemoryStream ms = new MemoryStream(packet);
            BinaryReader br = new BinaryReader(ms);  
            string id = br.ReadString();
            string ip = br.ReadString();
            int sport = br.ReadInt32();
            int fport = br.ReadInt32();
            br.Close();
            ms.Close();
            if (UserInfoEventHandler != null)
            {//유저인포를 아래와 같이 사용하게 된다.
                UserInfoEventHandler(this, new UserInfoEventArgs(id, ip, sport, fport));
            }
            dosock.Close();
        }
    }
}