using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlProject
{
    public class Controller
    {
        static Controller singleton;
        public static Controller Singletone
        {
            get
            {
                return singleton;
            }
        }
        static Controller()
        {
            singleton = new Controller();
        }
        private Controller()
        {

        }
        ImageServer img_server = null; //화면 보이는 부분
        SendEventClient sec = null; //전송하는 부분
        //화면에 보여주는 수신한 이미지 정보
        public event RecvImageEventHandler RecvImageEventHandler = null;
        string host_ip; //원격제어하는 상대방 ip 주소 
        public SendEventClient SendEventClient
        {//
            get
            {
                return sec;
            }
        }
        public string MyIp
        {// 컨트롤러만 있으면 사용할 수 있도록 사용자 아이피 디폴트 전달해줌
            get
            {
                string host_name = Dns.GetHostName();
                IPHostEntry host_entry = Dns.GetHostEntry(host_name);

                foreach (IPAddress ipaddr in host_entry.AddressList)
                {
                    if(ipaddr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ipaddr.ToString();
                    }
                }
                return string.Empty;
            }
        }

        public void StartEventClient()
        {
            sec = new SendEventClient(host_ip, NetworkInfo.EventPort);
        }

        public void Start(string host_ip)
        {
            this.host_ip = host_ip; //상대방 아이피
            img_server = new ImageServer(MyIp, NetworkInfo.ImgPort);
            img_server.RecvImageEventHandler += Img_server_RecvImageEventHandler;
            SetupClient.Setup(host_ip, NetworkInfo.SetupPort); //상대방에게 요청

        }

        private void Img_server_RecvImageEventHandler(object sender, RecvImageEventArgs e)
        {
            if (RecvImageEventHandler != null)
            {
                RecvImageEventHandler(this, e); //bypass 
            }
        }
        public void Stop()
        {
            if(img_server != null)
            {
                img_server.Close();
                img_server = null;
            }
        }
    }
}
