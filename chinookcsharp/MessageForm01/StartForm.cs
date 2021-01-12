using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageForm01
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }
        //가입
        private void btn_join_Click(object sender, EventArgs e)
        {
            if (Eaaa.Join(tbox_id.Text, tbox_pw.Text))
            {
                MessageBox.Show("가입을 축하하니다.");
            }
            else
            {
                MessageBox.Show("가입 실패입니다");
            }
        }
        EHAAALib.EHAAA Eaaa
        {
            get
            {
                return Activator.GetObject(
                    typeof(EHAAALib.EHAAA), "http://192.168.1.13:10800/AAASVC") as EHAAALib.EHAAA;
            }
        }
        //로긴
        private void btn_login_Click(object sender, EventArgs e)
        {
            int re = Eaaa.Login(tbox_id.Text, tbox_pw.Text);
            if (re == 0)
            {
                MainForm mf = new MainForm(tbox_id.Text, tbox_pw.Text);
                mf.FormClosed += Mf_FormClosed; //메인 폼 닫혔을 떄 스타트폼 보이게 
                this.Visible = false; //메인 폼이 보이게 되면 스타트 폼을 안 보이게
                mf.ShowDialog();
            }
            else
            {
                MessageBox.Show(string.Format("로그인 실패 - {0}",re));
            }
        }

        private void Mf_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true; 
        }
    }
}
