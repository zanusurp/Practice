using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteControlProject
{
    public partial class RemoteClientForm : Form
    {
        bool check; //이미지 수신 여부
        Size csize;
        SendEventClient EventSC//발생한 이벤트 전송
        {
            get
            {
                return Controller.Singletone.SendEventClient;
            }
        }
        
        public RemoteClientForm()
        {
           
            InitializeComponent();
        }

        private void RemoteClientForm_Load(object sender, EventArgs e)
        {
            Controller.Singletone.RecvImageEventHandler += Singleton_RecvImageEventHandler;
        }

        private void Singleton_RecvImageEventHandler(object sender, RecvImageEventArgs e)
        {
            if (check == false)
            {
                Controller.Singletone.StartEventClient();
                check = true;
                csize = e.Image.Size;
            }
            pbox_remote.Image = e.Image;
        }

        private void RemoteClientForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (check == true)
            {
                EventSC.SendKeyUP(e.KeyValue);
            }
        }

        private void RemoteClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (check == true)
            {
                EventSC.SendKeyDown(e.KeyValue);
            }
        }

        private void pbox_remote_MouseDown(object sender, MouseEventArgs e)
        {
            if (check == true)
            {
                Text = e.Location.ToString();
                EventSC.SendMouseDown(e.Button);
            }
        }

        private void pbox_remote_MouseMove(object sender, MouseEventArgs e)
        {
            if (check == true)
            {

                Point pt = ConvertPoint(e.X, e.Y); //서로 해상도가 다르기 때문에 메소드 만듦
                Text = e.Location.ToString();
                EventSC.SendMouseMove(pt.X,pt.Y); //마우스 무브는 현재 포인터
            }
        }

        private Point ConvertPoint(int x, int y)
        {//해상도 맞춰야 함 
            int nx = csize.Width * x / pbox_remote.Width;
            int ny = csize.Width * y / pbox_remote.Height;
            return new Point(nx, ny);
        }

        private void pbox_remote_MouseUp(object sender, MouseEventArgs e)
        {
            if (check == true)
            {
                Text = e.Location.ToString();
                EventSC.SendMouseUp(e.Button);
            }
        }
    }
}
