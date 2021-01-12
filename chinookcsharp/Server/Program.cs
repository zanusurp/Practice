using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = null;
            try
            {
                //소켓 생성 ip4 tcp 
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //인터페이스와 결합
                IPAddress addr = IPAddress.Parse("192.168.1.13");
                IPEndPoint iep = new IPEndPoint(addr, 10040); //앞은 아이피 뒤는 포트
                socket.Bind(iep);
                //백로그 큐  크기 설정
                socket.Listen(5);
                Socket docket;
                //AcceptLoop
                while (true)
                {
                    //Do it
                    docket = socket.Accept();
                    DoitAsync(docket);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //socket 닫기 
                socket.Close();
            }


        }
        delegate void DoitDele(Socket sock);
        private static void DoitAsync(Socket sock)
        {
            //다수와 가능하기 위해 비동기
            DoitDele dele = Doit;
            dele.BeginInvoke(sock, null, null); // 비동기로 수행 하거라


        }
        private static void Doit(Socket docket)
        {
            try
            {
                //그냥 두면 하나랑만 계속 연결하게 됨
                byte[] packet = new byte[1024];
                //누구로 부터 받았는지 확인 하기 위함1
                IPEndPoint iep = docket.RemoteEndPoint as IPEndPoint; //아이피 끝을 보여주는 것으로 
                while (true)
                {
                    docket.Receive(packet);
                    MemoryStream ms = new MemoryStream(packet); //메모리로 변환을 해야 함
                    BinaryReader br = new BinaryReader(ms); //스트림 개체면 뭐든 읽어옴 
                    string msg = br.ReadString();  //해당 하는 것 불러옴 
                    //누구로 부터 받았는지 확인 하기 위함2
                    br.Close(); //쓴 거 차례로 꺼준다.
                    ms.Close();
                    Console.WriteLine("{0}:{1} -> {2}", iep.Address, iep.Port, msg);

                    if (msg == "exit") //exit라는 메세지를 ㅏㅂㄷ았을 경우
                    {
                        break;
                    }
                    docket.Send(packet);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                docket.Close();
            }
        }
    }
}
