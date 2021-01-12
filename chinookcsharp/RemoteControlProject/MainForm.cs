using RecvRCInfoEventLib;
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
    public partial class MainForm : Form
    {
        string sip; //상대방 아이피
        int sport;
        RemoteClientForm rcf = null; //원격 요청시 
        VirtualCursorForm vcf = null; //가상 커서도 필요 

        public MainForm()
        {
           
            InitializeComponent();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
           if(tbox_ip.Text == NetworkInfo.DefaultIP)
            {//같은 호스트 사용 할 수 없도록 
                MessageBox.Show("같은 호스트를 원격 제어할 수 없음 ");
                tbox_ip.Text = string.Empty;
                return;
            }
            string host_ip = tbox_ip.Text;
            Rectangle rect = Remote.Singleton.Rect;
            Controller.Singletone.Start(host_ip);

            rcf.ClientSize = new Size(rect.Width-40,rect.Height-80);
            rcf.Show();
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Hide();//실제 내 화면 사라짐 , 노티파이 실행됨
            Remote.Singleton.RecvEventStart();
            timer_send_imag.Stop();//주기적으로 타이머 통해 이미지 전송 
            vcf.Show();//가상 커서 시각화 
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Text += ":" + NetworkInfo.DefaultIP; //자신의 디폴트 아이피
            vcf = new VirtualCursorForm();
            rcf = new RemoteClientForm();
            //원격 제어 요청이 왔을 시 처리 
            Remote.Singleton.RecvRCInfoEventHandler += Singleton_RecvRCInfoEventHandler;
        }

        delegate void Remote_Dele(object sender, RecvRCInfoEventArgs e);
        private void Singleton_RecvRCInfoEventHandler(object sender, RecvRCInfoEventArgs e)
        {
            if (this.InvokeRequired)//크로스 스레드 처리
            {
                object[] objs = new object[2] { sender, e };
                this.Invoke(new Remote_Dele(Singleton_RecvRCInfoEventHandler), objs);
            }
            else
            {
                tbox_controller_ip.Text = e.IPAddressStr;//요청자 아이피
                sip = e.IPAddressStr;
                sport = e.Port;
                btn_ok.Enabled = true;
            }
        }

        private void timer_send_imag_Tick(object sender, EventArgs e)
        {
            Rectangle rect = Remote.Singleton.Rect;
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            Size size2 = new Size(rect.Width, rect.Height);
            graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), size2);
            graphics.Dispose();
            try
            {
                ImageClient ic = new ImageClient();
                ic.Connect(sip, NetworkInfo.ImgPort);//이미지 포트 
                ic.SendImageAsync(bitmap, null); //비동기 실행
            }
            catch 
            {
                timer_send_imag.Stop();
                MessageBox.Show("서버에 문제가 있는 것 같아요 ");
                this.Close();
            }
        }

        private void noti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //하이드 시켰던 날 보이기 
            this.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {//종료 
            Remote.Singleton.Stop();
            Controller.Singletone.Stop();
            Application.Exit();

        }
    }
}
