using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RemoteControlProject
{//키보드 마우스 메시지 등 전달 역할 
    //enum KeyFlag
    //{
        
    //}
    //enum MouseFlag
    //{

    //}
    //enum MsgType SendEventClient에서 생성함
    //{

    //}
    public class Meta
    {
        public MsgType MT
        {
            get;
            private set;

        }
        public int Key //키
        {
            get;
            private set;
        }
        public Point Now//현재 좌표 
        {
            get;
            private set;
        }
        public Meta(byte[] data) //9바이트
        {
            MT = (MsgType)data[0]; //메세지 타입
            switch (MT)
            {
                case MsgType.MT_KDOWN:
                case MsgType.MT_KEYUP:
                    MakingKey(data); break;
               
                case MsgType.MT_M_MOVE:
                    MakingPoint(data); break; //이때는 포인트위치

                default:
                    break;
            }
        }

        private void MakingPoint(byte[] data)//시프트 시키는 이유 찾을 것 
        {
            Point now = new Point(0, 0);
            now.X = (data[4] << 24) +( data[3] << 16) + (data[2] << 8) + data[1];
            now.Y = (data[8] << 24) + (data[7] << 16 )+ (data[6] << 8) + data[5];

            Now = now;
        }

        private void MakingKey(byte[] data) //시프트 시키는 이유 찾을 것 
        {
            Key = (data[4] << 24) + (data[3] << 16) + (data[2] << 8) + data[1];
        }
    }
}
