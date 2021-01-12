using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MessageForm01
{
    public static class SmsgClient
    {   
        public static void SendMsgAsync(string other_ip, int other_port, string text)
        {
            SendDele dele = SendMsg;
            dele.BeginInvoke(other_ip, other_port, text, null, null);

        }
        delegate void SendDele(string other_ip, int other_port, string text);
        public static void SendMsg(string other_ip, int other_port, string text)
        {

            try
            {
                //이걸 먼저 처리하고 연결한 뒤 바로 보내게 하는 게 나을 수 있어 아래는 주석으로 하고 위로 옮김 
                byte[] packet = new byte[1024];
                MemoryStream ms = new MemoryStream(packet);
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(text);
                bw.Close();
                ms.Close();
                //클라이언트라 연결만 하면 됨 리슨 없음
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(other_ip), other_port);
                sock.Connect(iep);
                //byte[] packet = new byte[1024];
                //MemoryStream ms = new MemoryStream(packet);
                //BinaryWriter bw = new BinaryWriter(ms);
                //bw.Write(text);
                //bw.Close();
                //ms.Close();
                sock.Send(packet);
                sock.Close();
            }
            catch (Exception)
            {
                //그냥 있는 상태 
            }
           
        }
    }
}