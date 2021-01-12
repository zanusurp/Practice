using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Step02_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sock = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );
            //인터페이스 결합 (옵션)
            //연결 : 누구한테 연결할 것인지 : 서버
            IPAddress addr = IPAddress.Parse("192.168.1.13");
            IPEndPoint iep = new IPEndPoint(addr, 10248); //아까 서버와 똑같이
            sock.Connect(iep);
            string str;
            string str2; // 잘못된 것을 위한 변수 packet2와 같이
            byte[] packet = new byte[1024];
            byte[] packet2 = new byte[1024]; //수신이 잘못돼쓴데 됐다고 받을 수 있으니 하나 더 만들어서 확인 하기 위한 수신메시지 용으로 사용 

            while (true)
            {
                Console.Write("전송할 메세지 : ");
                str = Console.ReadLine();
                MemoryStream ms = new MemoryStream(packet);
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(str);
                bw.Close();
                sock.Send(packet);
                if (str == "exit")
                {
                    break;
                }
                sock.Receive(packet2);
                MemoryStream ms2 = new MemoryStream(packet2);
                BinaryReader br = new BinaryReader(ms2);
                str2 = br.ReadString();
                Console.WriteLine("수신한 메세지 : {0}", str2);
                br.Close();
                ms2.Close();
            }
            sock.Close();//소켓 닫기
        }
    }
}
