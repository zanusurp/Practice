using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteControlProject
{//이벤트 전송용 
    public enum MsgType
    {
        MT_KDOWN=1, MT_KEYUP, MT_M_LEFTDOWN,
        MT_M_LEFTUP,MT_M_RIGHTDOWN,MT_M_RIGHTUP,
        MT_M_MIDDLEDOWN,MT_M_MIDDLEUP,MT_M_MOVE
    }
    public class SendEventClient //라입러리로 만들거기에 퍼블릭
    { //9바이트를 보내는 건 마우스 무브 떄문임 그걸 따로 나누겠다면 나눠도 됨 
        IPEndPoint ep;//기억 시킴 
        public SendEventClient(string ip, int port)//서버 ip와 포트 
        {
            ep = new IPEndPoint(IPAddress.Parse(ip), port);
        }
        public void SendKeyDown(int key) //키 눌렸을 댸 
        {
            byte[] data = new byte[9];
            data[0] = (byte)MsgType.MT_KDOWN;
            Array.Copy(BitConverter.GetBytes(key),0, data, 1, 4);//기본식제공 내용,0은 이미 차지됨 1~4까지 채워달라 
            SendData(data);
        }

        private void SendData(byte[] data)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ep);//위에 생성한 서버주소 
            sock.Send(data);
            sock.Close();//원래 예외 처리 해 줌 
        }
        public void SendKeyUP(int key)
        {
            byte[] data = new byte[9];
            data[0] = (byte)MsgType.MT_KEYUP;
            Array.Copy(BitConverter.GetBytes(key), 0, data, 1, 4);//기본식제공 내용,0은 이미 차지됨 1~4까지 채워달라 
            SendData(data);
        }
        public void SendMouseDown(MouseButtons mouseButtons) //좌표가 필요 없음 
        {
            byte[] data = new byte[9];
            switch (mouseButtons)
            {
                case MouseButtons.Left: data[0] = (byte)MsgType.MT_M_LEFTDOWN; break;
                case MouseButtons.Right: data[0] = (byte)MsgType.MT_M_RIGHTDOWN; break;
                case MouseButtons.Middle: data[0] = (byte)MsgType.MT_M_MIDDLEDOWN; break;
            }
            SendData(data);
        }
        public void SendMouseUp(MouseButtons mouseButtons) //좌표가 필요 없음 
        {
            byte[] data = new byte[9];
            switch (mouseButtons)
            {
                case MouseButtons.Left: data[0] = (byte)MsgType.MT_M_LEFTUP; break;
                case MouseButtons.Right: data[0] = (byte)MsgType.MT_M_RIGHTUP; break;
                case MouseButtons.Middle: data[0] = (byte)MsgType.MT_M_MIDDLEUP; break;
            }
            SendData(data);
        }
        public void SendMouseMove(int x, int y)
        {
            byte[] data = new byte[9];
            data[0] = (byte)MsgType.MT_M_MOVE;
            Array.Copy(BitConverter.GetBytes(x), 0, data, 1, 4);
            Array.Copy(BitConverter.GetBytes(y), 0, data, 5, 4);//앞에 0~4까지 썼으므로)
            SendData(data);
        }
    }
}
