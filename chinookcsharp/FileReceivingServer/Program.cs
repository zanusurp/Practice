using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReceivingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            FileRecvServ fs = new FileRecvServ("192.168.1.13", 10340);
            fs.AcceptedEventHandler += FS_AcceptedEventHandler; // 연결
            fs.CloseEventHandler += FS_CloseEventHandler; // 닫기
            fs.RecvFileNameEventHandler += FS_RecvFileNameEventHandler; //파일이름 받기
            fs.FileLengthRecvEventHandler += FS_FileLengthRecvEventHandler; // 파일길이 받기
            fs.FileDataRecvEventHandler += FS_FileDataRecvEventHandler; //파일 데이터 받기 

            fs.Start(); // 서버 스타트
            Console.ReadKey();
        }

        static long length; //남은 길이 정의
        static FileStream fs;

        private static void FS_FileDataRecvEventHandler(object sender, FileDataRecvEventArgs e)
        {
            Console.WriteLine("{0}:{1}에서 {2} 남은길이:{3} 시작", e.RemoteEndPoint.Address, e.RemoteEndPoint.Port, e.FileName, e.RemainLenth);
            fs.Write(e.Data, 0, e.Data.Length);
            if (e.RemainLenth == 0)
            {
                fs.Close(); //없으면종료
            }
        }

        private static void FS_FileLengthRecvEventHandler(object sender, FileLengthRecvEventArgs e)
        {
            Console.WriteLine("{0}:{1}에서 {2} 길이:{3} 시작", e.RemoteEndPoint.Address, e.RemoteEndPoint.Port, e.FileName,e.Length);
            length = e.Length;
        }

        private static void FS_RecvFileNameEventHandler(object sender, RecvFileNameEventArgs e)
        {
            Console.WriteLine("{0}:{1}에서 {2} 전송 시작", e.RemoteEndPoint.Address, e.RemoteEndPoint.Port, e.FileName);
            fs = File.Create(e.FileName);
        }

        private static void FS_CloseEventHandler(object sender, CloseEventArgs e)
        {
            Console.WriteLine("{0}:{1}와 연결 해제",e.IPStr, e.Port);
        }

        private static void FS_AcceptedEventHandler(object sender, AcceptedEventArgs e)
        {
            Console.WriteLine("{0}:{1} 와 연결 ",e.IPStr, e.Port);
        }
    }
}
