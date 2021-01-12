using RemoteControlProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualCursorForm
{
    public partial class VirtualCursorForm : Form
    {
        public VirtualCursorForm()
        {
            InitializeComponent();
        }

        private void VirtualCursorForm_Load(object sender, EventArgs e)
        {
            Size = new Size(10, 10);//이게 잘 안먹힐 경우 대비
            Remote.Singleton.RecvKMEEventHandler += Singleton_RecvKMEEventHandler;
        }
        delegate void ChangeLocationDele(Point now, MsgType mt);
        void ChangeLocation(Point now, MsgType mt)
        {
            if(mt == MsgType.MT_M_MOVE)
            {
                Location = new Point(now.X + 3, now.Y + 3); //가상 커서 폼 위치 약간 옮김
            }
        }
        private void Singleton_RecvKMEEventHandler(object sender, RecvKMEEventArgs e)
        {
            if (this.InvokeRequired) //현재 작업하고 있는 것이 폼 스레드와 같은 건지 확인
            {//만일 트루라면 폼 생성했던 스레드와 작업 하는 것과 다를 다는것 
                object[] objs = new object[] { e.Now, e.MT };
                this.Invoke(new ChangeLocationDele(ChangeLocation),objs);//모든 UI에는 인보크있음 이 폼을 실행하고 있는 스레드가 해당 메소드를 호출하도록
            }
            else
            {
                ChangeLocation(e.Now, e.MT);
            }
        }
    }
}
