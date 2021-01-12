using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlProject
{
    public class ImageClient
    {
        Socket sock; 
        public void Connect(string ip, int port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //이미지가 꺠저도 된다면 UDP
            IPAddress ipaddr = IPAddress.Parse(ip); //ip화
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            sock.Connect(ep);
            
        }
        public bool SendImage(Image img)// 일단 동기식으로 작성(차후 비동기로)
        {//선형 방식으로 기록 전달
            if (sock == null)
            {
                return false;
            }
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            byte[] data = ms.GetBuffer();
            try
            {
                int trans = 0;//얼만큼 보냈는지 기억용
                byte[] lbuf = BitConverter.GetBytes(data.Length);//이미지길이
                sock.Send(lbuf); //전송할 이미지 길이 선전송
                while (trans < data.Length) //데이터 
                {
                    //sock.Send(data, SocketFlags.None);//이래버리면 다 가간힌다고함
                    //data.length-trans 하여 남은 데이터마다 계속 보내도록 
                    trans += sock.Send(data,trans,data.Length-trans,SocketFlags.None); 
                }
                sock.Close();
                sock=null; //리턴이미지 못하게 아예 닫음 
                return true;
            }
            catch (Exception)
            {
                return false; //안되면 어떻게 할 것인가 알아서 할 것 
            }
                
        }
        
        public void SendImageAsync(Image img, AsyncCallback callback)//완료됐다면 callback
        {//비동기 
            SendImageDele dele = SendImage;
            dele.BeginInvoke(img, callback, this); //완료후 콜백, 나자신 전달
        }
        public void Close()
        {
            if(sock != null)
            {
                sock.Close();
                sock = null;
            }
        }
    }
    public delegate bool SendImageDele(Image img);
}
