using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FileReceivingServer
{
    //File 받는 서버에서 연결 닫기 받기 길이 등 헨들러 보냄 
    public class FileRecvServ
    {
        const int MAX_PACK_SIZE = 1024;
        public event AcceptedEventHandler AcceptedEventHandler = null;
        public event CloseEventHandler CloseEventHandler = null;
        public event RecvFileNameEventHandler RecvFileNameEventHandler = null;
        public event FileLengthRecvEventHandler FileLengthRecvEventHandler = null;
        public event FileDataRecvEventHandler FileDataRecvEventHandler = null;
        
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


        public FileRecvServ(string ip, int port)
        {
            IPStr = ip;
            Port = port;
        }

        Socket sock;
        public bool Start()
        {
            //연결실패 경우 대비
            try
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipaddr = IPAddress.Parse(IPStr);
                IPEndPoint iep = new IPEndPoint(ipaddr, Port);
                sock.Bind(iep);

                sock.Listen(5);
                AcceptLoopAsync(); //비동 기 연결 
            }
            catch (Exception)
            { 
                return false; //연결 실패했다
            }
            return true; //연결 성공했다 
        }
        delegate void AccpetDele();//비동기 하기 위한 대기라
        private void AcceptLoopAsync()
        {
            AccpetDele dele = AcceptLoop;
            dele.BeginInvoke(null, null); //비동기 호출 
        }
        private void AcceptLoop()
        {
            while (true)
            {
                Socket dosock = sock.Accept();
                DoitAsync(dosock);
            }
        }
        Thread thread; //이번엔 스레드로 비동기 처리 
        private void DoitAsync(object dosock) 
        {
            ParameterizedThreadStart pts = Doit; //파라미터가 있는 경우 사용  하단 doit 본문
            thread = new Thread(pts);
            thread.Start(dosock); // 변수 사용
            
        }

        private void Doit(object osock)
        {
            // 연결 
            Socket dosock = osock as Socket;
            IPEndPoint rep = dosock.RemoteEndPoint as IPEndPoint;
            if(AcceptedEventHandler != null)
            {
                AcceptedEventHandler(this, new AcceptedEventArgs(rep));
            }
            //파일 이름
            string fname = RecvFileName(dosock);
            if(RecvFileNameEventHandler != null)
            {
                RecvFileNameEventHandler(this, new RecvFileNameEventArgs(fname, rep));
            }
            //파일 길이 
            long length = RecvFileLength(dosock);
            if(FileLengthRecvEventHandler != null)
            {
                FileLengthRecvEventHandler(this, new FileLengthRecvEventArgs(fname, rep, length));
            }
            RecvFile(dosock, fname, length);
            dosock.Close();
            if (CloseEventHandler != null)
            {
                CloseEventHandler(this, new CloseEventArgs(rep));
            }
        }

        private void RecvFile(Socket dosock, string fname, long length)
        {
            IPEndPoint rep = dosock.RemoteEndPoint as IPEndPoint;
            byte[] packet = new byte[MAX_PACK_SIZE];
            while (length>=MAX_PACK_SIZE)
            {
                int rlen = dosock.Receive(packet);
                if(FileDataRecvEventHandler != null)
                {
                    byte[] pd2 = new byte[rlen];
                    MemoryStream ms = new MemoryStream(pd2);
                    ms.Write(packet, 0, rlen); //해당 길이 만큼
                    FileDataRecvEventHandler(this, new FileDataRecvEventArgs(fname, rep, length, pd2));
                }
                length -= rlen; 
            }
            dosock.Receive(packet, (int)length, SocketFlags.None); //남은 길이 해줌 
            if (FileDataRecvEventHandler != null)
            {
                byte[] pd2 = new byte[length];
                MemoryStream ms = new MemoryStream(pd2);
                ms.Write(packet, 0, (int)length); //해당 길이 만큼
                FileDataRecvEventHandler(this, new FileDataRecvEventArgs(fname, rep, 0, pd2)); //남은 길이 0 
            }
            
        }

        private long RecvFileLength(Socket dosock)
        {
            byte[] packet = new byte[8];
            dosock.Receive(packet);
            MemoryStream ms = new MemoryStream(packet);
            BinaryReader br = new BinaryReader(ms);
            long length = br.ReadInt64();
            br.Close();
            ms.Close();
            return length;
        }

        private string RecvFileName(Socket dosock)
        {
            byte[] packet = new byte[MAX_PACK_SIZE];
            dosock.Receive(packet);
            MemoryStream ms = new MemoryStream(packet);
            BinaryReader br = new BinaryReader(ms);
            string fname = br.ReadString();
            br.Close();
            ms.Close();
            return fname;
        }
    }
}