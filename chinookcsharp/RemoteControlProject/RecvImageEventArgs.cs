using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlProject
{//이미지 헨들러 수신에 대한 이벤트 헨들러 
    public delegate void RecvImageEventHandler(object sender, RecvImageEventArgs e);
    public class RecvImageEventArgs:EventArgs
    {
        public IPEndPoint IPEndPoint
        {//누가 보낸 것인가
            get;
            private set;
        }
        public IPAddress IPAddress
        {//아이피만 필요할 경우
            get
            {
                return IPEndPoint.Address;
            }
        }
        public string IPAddressStr
        {//좀 더 필요할 경우
            get
            {
                return IPAddress.ToString();
            }
        }
        public int Port
        {
            get
            {
                return IPEndPoint.Port;

            }
        }
        public Image Image
        {
            get;
            private set;
        }
        public Size size
        {//파일 사이즈
            get
            {
                return Image.Size;
            }
        }
        public int Width
        {
            get
            {
                return Image.Width;
            }
        }
        public int Height
        {
            get
            {
                return Image.Height;
            }
        }
        public RecvImageEventArgs(IPEndPoint ep , Image image)
        {
            IPEndPoint = ep;
            Image = image;
        }
        public override string ToString()
        {
            return string.Format("IP:{0} width:{1} Height : {2}", IPAddressStr, Width,Height);
        }
    }
}
