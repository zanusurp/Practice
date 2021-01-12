using RecvRCInfoEventLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace RemoteControlProject
{
    public class Remote
    {
        static Remote singleton;//유일
        public static Remote Singleton
        {
            get
            {
                return singleton;
            }
        }
        static Remote()
        {
            singleton = new Remote();
        }
            
        private Remote()
        {
            AutomationElement ae = AutomationElement.RootElement; //자동화 요소 데스크탑
            System.Windows.Rect rt = ae.Current.BoundingRectangle; // 데탑윈도우 사용능력 얻어옴
            Rect = new Rectangle((int)rt.Left, (int)rt.Top, (int)rt.Width, (int)rt.Height);
            SetupServer.RecvRCInfoEventHandler += SetupServer_RecvRCInfoEventHandler;
            SetupServer.Start(MyIp, NetworkInfo.SetupPort);

        }
        public string MyIp
        {
            get
            {
                return NetworkInfo.DefaultIP; 
            }
        }
        private void SetupServer_RecvRCInfoEventHandler(object sender, RecvRCInfoEventArgs e)
        {
            if (RecvRCInfoEventHandler != null)
            {
                RecvRCInfoEventHandler(this, e);
            }
        }

        public event RecvRCInfoEventHandler RecvRCInfoEventHandler = null; //원격 제어 요청 
        public event RecvKMEEventHandler RecvKMEEventHandler = null;//키보드 마우스 이벤트 수신
        RecvEventServer res = null;//위를 수신 위한 이벤트서버
        public Rectangle Rect//사각 영역 보내야됨 드로잉이고 어쎔블에서UI체크 다함 
        {
            get;
            private set;
        }
        public void RecvEventStart()
        {
            res = new RecvEventServer(MyIp, NetworkInfo.EventPort);
            res.RecvKMEEventHandler += Res_RecvKMEEventHandler;
        }

        private void Res_RecvKMEEventHandler(object sender, RecvKMEEventArgs e)
        {
            if(RecvKMEEventHandler != null)
            {
                RecvKMEEventHandler(this, e); //bypass
            }
            switch (e.MT)
            {
                case MsgType.MT_KDOWN:WrapNative.KeyDown(e.Key); break;
                case MsgType.MT_KEYUP:WrapNative.KeyUP(e.Key);break;
                case MsgType.MT_M_LEFTDOWN: WrapNative.LeftDown(); break;
                case MsgType.MT_M_LEFTUP: WrapNative.LeftUp(); break;
                case MsgType.MT_M_MOVE: WrapNative.Move(e.Now); break;

            }
        }
        public void Stop()
        {
            SetupServer.Close();
                if (res != null)
                {
                    res.Close();
                    res = null;
                }
            
        }
    }
}
