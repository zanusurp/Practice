using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MessageForm01
{
    public class SmsgServer //전체를 아우르는 구간 서버 헨들러 불러옴
    {
        public event SmsgRecvEventHanlder SmsgRecvEventHanlder = null;
        public string IPStr
        {
            get;
            private set;
        }
        public int Port
        {
            get;
            private set;
        }

        public SmsgServer(string ipstr, int port) //서버 연결 
        {
            IPStr= ipstr;
            Port = port;
        }
        Socket sock;
        //연결 시작 
        public bool Start() 
        {
            try
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //소켓 타입 밑 스타일 형성 
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IPStr), Port);
                bool check = true;
                while (check)
                {
                    try
                    {
                        sock.Bind(iep);
                        check = false;//포트연결 잘 됐을시
                    }
                    catch (Exception)
                    {
                        Port += 2;//중복일시 +2해서 다음걸로 봄 원포트 번호는 메인폼에
                        iep = new IPEndPoint(IPAddress.Parse(IPStr), Port);
                    }
                }
                
                sock.Listen(5);
                //클라이언트와 연결하는 부분
                AcceptLoopAsync();
                return true;
            }
            catch (Exception)
            {
                return false ;
            }
            
        }
        delegate void AcceptDele(); //하단 루프와 같은 형식으로 취함 
        private void AcceptLoopAsync() // 비동기 하기 위해 
        {
            AcceptDele dele = AcceptLoop;
            dele.BeginInvoke(null, null); //이렇게 비동기 적으로 나타냄 (대리자 필수인듯)
        }
        private void AcceptLoop()
        {
            Socket dosock;
            while (true)
            {
                dosock = sock.Accept();
                Doit(dosock); //그냥 처리 
            }
        }
        //Doit은 show message부분이라 비동기로 하지 않고 그냥 처리함
        private void Doit(Socket dosock) //얘도 비동기 처리 해야 됨 
        {
            IPEndPoint remote = dosock.RemoteEndPoint as IPEndPoint; // 상대방 게 있어야핸들러
            byte[] packet = new byte[1024];
            dosock.Receive(packet);
            dosock.Close();
            MemoryStream ms = new MemoryStream(packet);
            BinaryReader br = new BinaryReader(ms);
            string msg = br.ReadString();
            br.Close();
            ms.Close();
            if(SmsgRecvEventHanlder != null)
            {
                SmsgRecvEventHanlder(this, new SmsgRecvEventArgs(remote, msg));
            }
        }
    }
}