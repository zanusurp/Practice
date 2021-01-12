using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace FileSendingClient
{
    public class FileSendingClientc
    {
        const int MAX_PACK_SIZE = 1024; //최대 파일 크기 
        public event SendFileDataEventHandler SendFileDataEventHandler = null;
        public string IPstr
        {
            get;
            private set;
        }
        public int Port
        {
            get;
            private set;
        }

        public FileSendingClientc(string ip, int port)
        {
            IPstr = ip;
            Port = port;
        }
        //파일 전송 역시 비동기 
        delegate void SendDele(string fname);
        public  void SendAsync(string fname)
        {
            SendDele dele = Send;
            dele.BeginInvoke(fname, null, null);// 비동기로 send 실행 
        }
        public void Send(string fname)
        {
            //전송 실제 실행 부분
            if (File.Exists(fname) == false)
            {
                return;
            }
            //파일을 전송 해야 되기 떔누에 소켓 생성
            Socket sock = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IPstr), Port);
            sock.Connect(iep);

            byte[] packet = new byte[MAX_PACK_SIZE];
            MemoryStream ms = new MemoryStream(packet);
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write(fname);
            bw.Close();
            ms.Close();
            sock.Send(packet);

            FileStream fs = File.OpenRead(fname);
            ms = new MemoryStream(packet);
            bw = new BinaryWriter(ms);
            bw.Write(fs.Length);//파일 길이 
            sock.Send(packet, 0, 8, SocketFlags.None); //이벤트 처리가 아니니non으로 
            long remain = fs.Length; //파일 크기 보여주기 위해 만듦
            int sl;
            while (remain >= MAX_PACK_SIZE)
            {
                fs.Read(packet, 0, MAX_PACK_SIZE);
                sl = sock.Send(packet);
                while (sl < MAX_PACK_SIZE)
                {
                    //맥스 사이즈보다 작다면 덜 보낸 것 
                    sl += sock.Send(packet, sl, MAX_PACK_SIZE - sl, SocketFlags.None);
                }
                //아직 파일이 남아있을 시 아래를 진행하게 됨 
                if(SendFileDataEventHandler != null)
                {
                    SendFileDataEventHandler(this, new SendFileDataEventArgs(fname, remain));
                }
                remain -= MAX_PACK_SIZE;
            }
            fs.Read(packet, 0, (int)remain);
            sl = sock.Send(packet);
            while (sl < remain)
            {
                //맥스 사이즈보다 작다면 덜 보낸 것 
                sl += sock.Send(packet, sl, (int)remain - sl, SocketFlags.None);
            }
            remain = 0;
            if (SendFileDataEventHandler != null)
            {
                SendFileDataEventHandler(this, new SendFileDataEventArgs(fname, remain));
            }
            fs.Close();
            sock.Close();
        }
    }
}