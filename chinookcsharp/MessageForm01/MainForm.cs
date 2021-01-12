using FileReceivingServer;
using FileSendingClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageForm01
{
    public partial class MainForm : Form
    {
        string ID
        {
            get;
            set;
        }
        string PW
        {
            get;
            set;
        }
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(string id, string pw)
        {
            ID = id;
            PW = pw;
            InitializeComponent();
        }
        // 원래 본 호스트 사용자 아이피 포트 설정 부분 MySSet()으로감 
        //private void btn_my_set_Click(object sender, EventArgs e) 
        //{
        //    //서버 연결
        //    string ip = tbox_my_ip.Text;
        //    int port = 0;
        //    if(int.TryParse(tbox_my_port.Text, out port) == false)
        //    {
        //        MessageBox.Show("포트를 잘못 입력 했습니다.");
        //        return;
        //    }
        //    SmsgServer sms = new SmsgServer(ip, port);
        //    sms.SmsgRecvEventHanlder += SMS_SmsgRecvEventHanlder;
            
        //    if (sms.Start() == false) //연결 시작
        //    {
        //        MessageBox.Show("서버가동 실패 ");
        //    }
        //    else //성공시 설정 변경 불가능하게 하기 
        //    {
        //        tbox_my_ip.Enabled = tbox_my_port.Enabled = btn_my_set.Enabled = false;
        //    }

        //}
        //핸들 메세지를 받게됐을 떄 
        private void SMS_SmsgRecvEventHanlder(object sender, SmsgRecvEventArgs e)
        {
            AddMessage(string.Format("{0}:{1} -> {2}", e.IPstr, e.Port, e.Msg));
        }
        delegate void MyDele(string msg); //비동기 다른 스레드에서 실행할 수 있도록 해주기 위함
        private void AddMessage(string msg) //바로 위에 메세지 
        {
            if (lbox_msg.InvokeRequired)
            {
                MyDele dele = AddMessage; //이걸 다른데서 수행가능하기 위함
                object[] objs = new object[] { msg }; //전달 인자 형식
                lbox_msg.BeginInvoke(dele, objs); // 대리자, 인자 lbox 생성한 스레드가 에드메세지 수행하도록 전달 
            }
            else //또쓰는 문제가 없기
            {
                lbox_msg.Items.Add(msg);
            }
        }
        string other_ip;
        int other_port=10300;
        //버튼을 지웠기에 포트 잡아줄 이유 없어짐
        //private void btn_other_set_Click(object sender, EventArgs e)
        //{
        //    other_ip = tbox_other_ip.Text;
        //    if(int.TryParse(tbox_other_port.Text, out other_port)==false)
        //    {
        //        MessageBox.Show("포트 번호를 정수로 변환 할 수 없습니다.");
        //    }
        //}

        private void btn_send_Click(object sender, EventArgs e)
        {
            SmsgClient.SendMsgAsync(other_ip, other_port, tbox_msg.Text);
            lbox_msg.Items.Add(string.Format("{0}:{1} <- {2}",other_ip,other_port,tbox_msg.Text));
        }

        private void lbox_msg_DragEnter(object sender, DragEventArgs e)//대화창드래그엔터
        {
            e.Effect = DragDropEffects.All;
        }

        private void lbox_msg_DragDrop(object sender, DragEventArgs e) //대호창드래그드롭
        {
            FileSendingClientc fsc = new FileSendingClientc(other_ip,other_fport); //파일 클라이언트
            fsc.SendFileDataEventHandler += Fsc_SendFileDataEventHandler;
            string[] fs = e.Data.GetData(DataFormats.FileDrop) as string[]; //드래그한 파일 목록 얻어오는 작업 
            foreach (string f in fs)
            {
                fsc.SendAsync(f);
                string msg = string.Format("{0}:{1}에게 {2}파일 전송 시작", other_ip, other_fport);
                AddMessage(msg);
            }


        }

        private void Fsc_SendFileDataEventHandler(object sender, SendFileDataEventArgs e)
        {
            if(e.Remain == 0) //다 끝났을 떄 하나만 메세지로 보여준다 
            {
                string msg = string.Format("{0}파일 {1} byte남음 . . ", e.FileName, e.Remain);
                AddMessage(msg);
            }
        }
        //MyFSet()으로 이동 파일 포트 부분 
        //private void btn_my_fset_Click(object sender, EventArgs e)//내측 파일버튼
        //{
        //    string ip = tbox_my_ip.Text;
        //    int port = 0;
        //    if(int.TryParse(tbox_my_fport.Text,out port) == false)
        //    {
        //        MessageBox.Show("포트를 잘 못 입력 하셨습니다.");
        //        return;
        //    }
        //    FileRecvServ frs= new FileRecvServ(ip, port);
        //    frs.AcceptedEventHandler += Frs_AcceptedEventHandler;
        //    frs.CloseEventHandler += Frs_ClosedEventHandler;
        //    frs.FileDataRecvEventHandler += Frs_FileDataRecvEventHandler;
        //    frs.FileLengthRecvEventHandler += Frs_FileLengthRecvEventHandler;
        //    frs.RecvFileNameEventHandler += Frs_RecvFileNameEventHandler;

        //    if (frs.Start() == false)//실행 시켰을 경우
        //    {
        //        MessageBox.Show("파일 수신 서버 가동 실패 ");
        //    }
        //    else //연결 성공 했을 경우 설정 못 바꾸게 
        //    {
        //        tbox_my_ip.Enabled = tbox_my_fport.Enabled = false;
        //        btn_my_fset.Enabled = false;
        //    }
        //}
        //여러개를 수신할 수 있으므로 딕셔너리로 한다
        Dictionary<string, FileStream> fsdic = new Dictionary<string, FileStream>(); 
        private void Frs_RecvFileNameEventHandler(object sender, RecvFileNameEventArgs e)
        {
            string fname = e.FileName;
            int index = fname.LastIndexOf(@"\");
            if(index != -1)
            {
                fname = fname.Substring(index + 1);
            }
            FileStream fs = File.Create(fname); //전송하는 파일 이름
            fsdic[e.FileName] = fs;
        }

        private void Frs_FileLengthRecvEventHandler(object sender, FileLengthRecvEventArgs e)
        {
            string msg = string.Format("{0}:{1} 에서 {2},{3}byte 전송 시작", e.RemoteEndPoint.Address,e.RemoteEndPoint.Port,e.FileName,e.Length);
            AddMessage(msg); //response
        }

        private void Frs_FileDataRecvEventHandler(object sender, FileDataRecvEventArgs e)
        {
            FileStream fs = fsdic[e.FileName];
            fs.Write(e.Data, 0, e.Data.Length);
            if (e.RemainLenth == 0)
            {
                string msg = string.Format("{0}:{1}에서 파일 {2}전송 완료",e.RemoteEndPoint.Address,e.RemoteEndPoint.Port,e.FileName);
                AddMessage(msg);
                fs.Close();
            }
        }

        private void Frs_ClosedEventHandler(object sender, CloseEventArgs e)
        {
            string msg = string.Format("{0}:{1} 파일 전송을 마치고 연결 해제", e.IPStr, e.Port);
            AddMessage(msg);
        }

        private void Frs_AcceptedEventHandler(object sender, AcceptedEventArgs e)
        {
            string msg = string.Format("{0}:{1} 파일 전송을 위해 연결 ", e.IPStr, e.Port);
            AddMessage(msg);
        }
        int other_fport;
        //직접 입력하게 되면서 필요 없어짐 아래 fport
        //private void btn_other_fset_Click(object sender, EventArgs e) //상대측 파일버튼
        //{
        //    if(int.TryParse(tbox_other_fport.Text,out other_fport)==false)
        //    {
        //        MessageBox.Show("상대 포트 번호를 정수로 변환 할 수 없습니다");
        //    }
        //}
        EHAAALib.EHAAA Eaaa
        {
            get
            {
                return Activator.GetObject(
                    typeof(EHAAALib.EHAAA),
                    "http://192.168.1.13:10800/AAASVC")as EHAAALib.EHAAA;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Eaaa.KeepAlive(ID);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Eaaa.Logout(ID);
            timer1.Enabled = false;
            Close();

        }

        private void btn_withdraw_Click(object sender, EventArgs e)
        {
            Eaaa.WithDraw(ID, PW);
            timer1.Enabled = false;
            Close();
        }
        //사용자가 입력 안하고 그냥 하드 코드로 둠
        int sport = 10400;
        int fport = 10200;
        int bport = 10600;
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            MySSet(); //포트
            MyFSet(); //파일 포트
            //다른 유저가 로그인아웃 했을 떄 정보를 수신할 서버 필요. 클래스생성
            UserInfoCSServer ucbs = new UserInfoCSServer(DefAddress.ToString(),bport);
            //나머지 부분 
            //
            ucbs.UserInfoEventHandler += Ucbs_UserInfoEventHandler;
            if (ucbs.Start() == false)
            {
                MessageBox.Show("유저인포헨들프로그램이 잘 못 됐음");
            }
            bport = ucbs.Port;
            Eaaa.KeepAlive(ID, DefAddress.ToString(), sport, fport, bport);//처음 로그인 성공시 전달
        }

        private void Ucbs_UserInfoEventHandler(object sender, UserInfoEventArgs e)
        {
            if (e.FPort == 0)
            {
                UserInfoEventArgs ru = null;
                foreach(UserInfoEventArgs uiea in lbox_user.Items)
                {
                    if(uiea.ID == e.ID)
                    {
                        ru = uiea;
                        break;
                    }
                }
                if(ru != null)
                {
                    lbox_user.Items.Remove(e);//Fport 없다면 사실상 로그아웃 상태라 제거 
                }
                
            }
            else
            {
                lbox_user.Items.Add(e);
            }
        }

        IPAddress DefAddress //IP도 사용자가 입력하지 않게 하드로 둠
        {
            get
            {
                string hname = Dns.GetHostName();
                IPHostEntry ihe = Dns.GetHostEntry(hname); //Entry통해서 호스트네임 가져옴
                foreach (IPAddress ipaddr in ihe.AddressList)
                {
                    if(ipaddr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {//각각 IP 어드레스 
                        return ipaddr; //어드레스 페밀리가 많을 경우 제일 처음 발견하는 걸 보냄
                    }
                }
                return IPAddress.Any;
            }
        }
        private void MyFSet()
        {//원래 버튼 클릭 했을 떄 내 아이피 포트 설정 후 변경 못하게 하던 곳 
            //서버 연결
            
            SmsgServer sms = new SmsgServer(DefAddress.ToString(), sport);
            sms.SmsgRecvEventHanlder += SMS_SmsgRecvEventHanlder;

            if (sms.Start() == false) //연결 시작
            {
                MessageBox.Show("서버가동 실패 ");
            }
            else //성공시 설정 변경 불가능하게 하기 
            {
                //포트가 점유돼 있을 시 다른 번호로 변경해서 바인드 하는 것으로
                sport = sms.Port; //SmsRecv도 변경이 돼야 함 
            }
        }

        private void MySSet()
        {
            
            FileRecvServ frs = new FileRecvServ(DefAddress.ToString(), fport);
            frs.AcceptedEventHandler += Frs_AcceptedEventHandler;
            frs.CloseEventHandler += Frs_ClosedEventHandler;
            frs.FileDataRecvEventHandler += Frs_FileDataRecvEventHandler;
            frs.FileLengthRecvEventHandler += Frs_FileLengthRecvEventHandler;
            frs.RecvFileNameEventHandler += Frs_RecvFileNameEventHandler;

            if (frs.Start() == false)//실행 시켰을 경우
            {
                MessageBox.Show("파일 수신 서버 가동 실패 ");
            }
            else //연결 성공 했을 경우 설정 못 바꾸게 
            {
                fport = frs.Port;
            }
        }

        private void lbox_user_SelectedIndexChanged(object sender, EventArgs e)
        {//내가 전송하려는 상대방 구현이 됨 
            UserInfoEventArgs uie = lbox_user.SelectedItem as UserInfoEventArgs;
            other_ip = uie.IPStr;
            other_port = uie.SPort;
            other_fport = uie.FPort;
        }
    }
}
