using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlProject
{
    public static class NetworkInfo //네트워크 포트 미리 서정용
    {
        public static short ImgPort
        {//이미지 용 포트 
            get
            {
                return 20004;
            }
        }
        public static short SetupPort
        {
            get
            {
                return 20002;
            }
        }
        public static short EventPort
        {//이벤트 수신용 포트
            get
            {
                return 20010;
            }
        }
        public static string DefaultIP
        {//아이피 설정용
            get
            {
                string host_name = Dns.GetHostName(); //내컴퓨터 호스트 이름 얻어오기
                IPHostEntry host_entry = Dns.GetHostEntry(host_name); //내컴에관한 아이피등 얻어옴
                foreach (IPAddress ipaddr in host_entry.AddressList)
                {
                    if(ipaddr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ipaddr.ToString(); //이렇게 아이피 얻어오기 
                    }
                }
                return "127.0.0.1"; //호스트로 얻어오지 못하면 그냥 자기자신으로
            }
            
        }
    }
}
