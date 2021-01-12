using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSendingClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("서버 IP: ");
            string ip = Console.ReadLine();
            int port = 10340;
            Console.Write("포트번호 : {0}", port);

            FileSendingClientc fsc = new FileSendingClientc(ip, port);
            fsc.SendFileDataEventHandler += Fsc_SendFileDataEventHandler;

            Console.Write("전송할 파일 명:  ");
            string fname = Console.ReadLine();
            fsc.SendAsync(fname);

            Console.ReadKey(); // 붕 뜨지 않게 리드 키로 종료 
        }

        private static void Fsc_SendFileDataEventHandler(object sender, SendFileDataEventArgs e)
        {
            Console.WriteLine("{0}파일 {1} bytes남았음.",e.FileName,e.Remain);
        }
    }
}
