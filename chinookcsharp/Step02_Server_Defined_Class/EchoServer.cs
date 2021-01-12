using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Step02_Server_Defined_Class
{
    public class EchoServer
    {
        public event AcceptedEventHandler AcceptedEventHandler = null;
        public event ClosedEventHanlder ClosedEventHanlder = null;
        public event RecievedMsgEventHanlder RecievedMsgEventHanlder = null;
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

        public EchoServer(string ipstr, int port)
        {
            
            IPStr = ipstr;
            Port= port;
        }
        //소켓 맴버로 
        Socket socket=null;
        public bool Start()
        {
            try
            {
                //소켓 생성 ip4 tcp 
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //인터페이스와 결합
                IPAddress addr = IPAddress.Parse(IPStr);
                IPEndPoint iep = new IPEndPoint(addr, Port); //앞은 아이피 뒤는 포트
                socket.Bind(iep);
                //백로그 큐  크기 설정
                socket.Listen(5);

                //AcceptLoop
                AcceptLoopAsyn(socket); //기존 while부분 대체 비동기로 연결 해야 하기 떄문 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            //finally 여기선 스톱해선 안됨 bool로 진행되는 부분임
            //{
            //    //socket 닫기 
            //    socket.Close();
            //}
        }
        public void Close()
        {
            if (socket != null)
            {
                try
                {
                    socket.Close();
                }
                catch
                {

                }
            }
        }
        delegate void AcceptDele();
        private void AcceptLoopAsyn(Socket docket)
        {
            AcceptDele dele = AcceptLoop;
            dele.BeginInvoke(null, null);
        }
        void AcceptLoop()
        {
            Socket dosock = null;
            while (true)
            {
                dosock = socket.Accept();
                DoitAsync(dosock);
            }
        }
        //상단 DOit 대리자로 사용
        delegate void DoitDele(Socket dosock);
        private void DoitAsync(Socket dosock)
        {
            //다수와 가능하기 위해 비동기
            DoitDele dele = Doit;
            dele.BeginInvoke(dosock, null, null); // 비동기로 수행 하거라


        }
        //여기서 이벤트 헨들러가 사용된다.
        private void Doit(Socket dosock)
        {
            IPEndPoint remote_ep = dosock.RemoteEndPoint as IPEndPoint;
           if(AcceptedEventHandler != null)
            {
                AcceptedEventHandler(this, new AcceptedEventArgs(remote_ep));
            }
            try
            {
                //그냥 두면 하나랑만 계속 연결하게 됨
                byte[] packet = new byte[1024];
                while (true)
                {
                    dosock.Receive(packet);
                    MemoryStream ms = new MemoryStream(packet); //메모리로 변환을 해야 함
                    BinaryReader br = new BinaryReader(ms); //스트림 개체면 뭐든 읽어옴 
                    string msg = br.ReadString();  //해당 하는 것 불러옴 
                    //누구로 부터 받았는지 확인 하기 위함2
                    br.Close(); //쓴 거 차례로 꺼준다.
                    ms.Close();
                    if (RecievedMsgEventHanlder != null)
                    {
                        RecievedMsgEventHanlder(this, new RecievedMsgEventArgs(remote_ep, msg));
                    }
                    //종료는 없앰 클라에서 끊기면 예외 발생하게 둠 
                    dosock.Send(packet);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dosock.Close();
                if (ClosedEventHanlder != null)
                {
                    ClosedEventHanlder(this, new ClosedEventArgs(remote_ep));
                }
            }
        }
    }
}
   