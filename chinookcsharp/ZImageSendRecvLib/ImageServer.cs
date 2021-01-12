using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlProject
{//이미지 서버 수신 
    public class ImageServer
    {
        Socket lis_sock;
        public event RecvImageEventHandler RecvImageEventHandler = null;//이미지헨들러
        public ImageServer(string ip, int port)
        {
            lis_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            lis_sock.Bind(ep);
            lis_sock.Listen(5);

            lis_sock.BeginAccept(DoAccept, null); //비동기
            
        }
        void DoAccept(IAsyncResult result) //비동기
        {
            if(lis_sock == null) //없을 떄 오면 그냥 끊는다
            {
                return;
            }
            try
            {//클라이언트에 연결 요청이 왔기 떄문 
                Socket dosock = lis_sock.EndAccept(result);
                Receive(dosock);
                lis_sock.BeginAccept(DoAccept, null); //이걸 다시 넣어서 듣기로 
            }
            catch (Exception)
            {
                Close(); //문제 발생시
            }
        }

        public void Close()
        {
            if(lis_sock != null)
            {
                lis_sock.Close();
                lis_sock = null; //완전 닫는다
            }
        }

        private void Receive(Socket dosock)
        {
            byte[] lbuf = new byte[4]; //길이
            dosock.Receive(lbuf); //배열로 받도록 돼 있음 

            int len = BitConverter.ToInt32(lbuf,0); //0부터 4바이트씩
            byte[] buffer = new byte[len];
            int trans = 0;
            
            while (trans < len)
            {//버퍼, 시작위치, 크기, 
                trans += dosock.Receive(buffer, trans, len - trans, SocketFlags.None);
            }
            if(RecvImageEventHandler != null)
            {
                IPEndPoint ep = dosock.RemoteEndPoint as IPEndPoint; //상대방
                RecvImageEventArgs e = new RecvImageEventArgs(ep, ConvertBitMap(buffer));
                RecvImageEventHandler(this, e);
            }
        }
        public Bitmap ConvertBitMap(byte[] data) 
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0,(int)data.Length);
            Bitmap bitmap = new Bitmap(ms);
            return bitmap;

        }
    }
}
