using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RecvRCInfoEventLib
{
    /// <summary>
    /// 원격제어 요청 수신 이벤트 정의하기 위한 대리자
    /// </summary>
    /// <param name="sender">이벤트 통보 개체</param>
    /// <param name="e">이벤트 처리 인자 </param>
    public delegate void RecvRCInfoEventHandler(object sender, RecvRCInfoEventArgs e);
    /// <summary>
    /// 원격 제어 요청 수신 이벤트 인자 클래스
    /// </summary>
    public class RecvRCInfoEventArgs : EventArgs
    {
        /// <summary>
        /// ip단말 정보 가져오기
        /// </summary>
        public IPEndPoint IPEndPoint//누구한테 IP요청이 왔는가 
        {
            get;
            private set;
        }
        /// <summary>
        /// ip 주소 문자열 - 가져오기
        /// </summary>
        public string IPAddressStr
        {//ip
            get
            {
                return IPEndPoint.Address.ToString();
            }
        }
        /// <summary>
        /// 포트  - 가져오기
        /// </summary>
        public int Port
        {//port
            get
            {
                return IPEndPoint.Port;
            }
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="RemoteEndPoint"></param>
        public RecvRCInfoEventArgs(EndPoint RemoteEndPoint)//생성자 소켓 네트워크뭐가 오든
        {//
            IPEndPoint = RemoteEndPoint as IPEndPoint; //입맛에 맞춰 변경

        }
    }
}

