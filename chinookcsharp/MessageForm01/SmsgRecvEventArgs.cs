using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MessageForm01
{
    //delegate 대리인 제일 밑에 것 함수만 표현하기 위함 
    public delegate void SmsgRecvEventHanlder(object sender, SmsgRecvEventArgs e);
    public class SmsgRecvEventArgs : EventArgs
    {
        public IPEndPoint RemoteEndPoint//연결
        {
            get;
            private set;
        }
        public string Msg//메세지
        {
            get;
            private set;
        }
        public string IPstr //ip주소
        {
            get
            {
                return RemoteEndPoint.Address.ToString();
            }
            
        }
        public int Port //port
        {
            get
            {
                return RemoteEndPoint.Port;
            }
        }
        public SmsgRecvEventArgs(IPEndPoint remote, string msg)
        {
            RemoteEndPoint = remote;
            Msg = msg;
        }

    }
}
