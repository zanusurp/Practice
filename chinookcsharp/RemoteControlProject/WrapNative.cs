using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlProject
{
    [Flags]
    public enum KeyFlag
    {
        KE_DOWN = 0, KE__EXTENDEDKEY = 1, KE_UP = 2
    }
    [Flags]
    public enum MouseeFlag
    {
        ME_MOVE = 1, ME_LEFTDOWN = 2, ME_LEFTUP = 4, ME_RIGHTDOWN = 8,
        ME_RIGHTUP = 0x10, ME_MIDDLEDOWN = 0x20, ME_MIDDLEUP = 0x40, ME_WHEEL = 0x800,
        ME_ABSOULUTE = 8000
    }
    public static class WrapNative
    {
        [DllImport("user32.dll")]//유저32 gdi 터너 32 핵심 ms 
        static extern void keybd_event(byte vk, byte scan, int flags, int extra);
        [DllImport("user32.dll")]//extra는 사용하지 않은 부분 
        static extern void mouse_event(int flag, int dx, int dy, int buttons, int extra);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point point);//info에 있는 것도 xy 얻는 ref
        [DllImport("user32.dll")]
        static extern int SetCursorPos(int x, int y);// win 32 4byte = int 
        
        //ㅅ용자용 매핑
        public static void KeyDown(int keycode)
        {
            keybd_event((byte)keycode, 0, (int)KeyFlag.KE_DOWN, 0);

        }
        public static void KeyUP(int keycode)
        {
            keybd_event((byte)keycode, 0, (int)KeyFlag.KE_UP, 0);
        }
        public static void Move(int x,int y)
        {
            SetCursorPos(x, y);
        }
        public static void Move(Point pt) //위에거나 이거나 
        {
            SetCursorPos(pt.X, pt.Y);
        }
        public static void LeftDown()//마우스 왼쪽 버튼 
        {
            mouse_event((int)MouseeFlag.ME_LEFTDOWN,0,0,0,0);
        }
        public static void LeftUp()
        {
            mouse_event((int)MouseeFlag.ME_LEFTUP, 0, 0, 0, 0);
        }
        public static void RightDown()//마우스 왼쪽 버튼 
        {
            mouse_event((int)MouseeFlag.ME_RIGHTDOWN, 0, 0, 0, 0);
        }
        public static void RightUp()
        {
            mouse_event((int)MouseeFlag.ME_RIGHTUP, 0, 0, 0, 0);
        }
    }
}
