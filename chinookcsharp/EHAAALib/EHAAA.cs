using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading; //timer
using System.Threading.Tasks;

namespace EHAAALib
{   //사용자 객체
    class UserInfo //사용자 정보 
    {
        internal string ID
        {
            get;
            private set;
        }
        internal DateTime LastKA //나 살아있다는 용도 keep alive
        {
            get;
            set;
        }
        internal string IPStr
        {
            get;
            set;
        }
        internal int Sport //서버 연결
        {
            get;
            set;
        }
        internal int FPort //파일
        {
            get;
            set;
        }
        internal int BPort // 사용자정보 포트
        {
            get;
            set;
        }

        public UserInfo(string id, string ip, int sport, int fPort, int bPort)
        {
            ID = id;
            IPStr = ip;
            Sport = sport;
            FPort = fPort;
            BPort = bPort;
        }
    }
    //
    public class EHAAA:MarshalByRefObject //리모트 
    {
        const string sfname = "member.xsl";
        const string dfname = "member.xml";
        DataTable mtb = new DataTable("회원"); //ADO으로 데이터 파일 이용 할 예정 디비는 안씀
        //파일 연결 돼 있는 것은 뭐고, 다른 친구 등 들어올 떄 알려줄 lib 
        Dictionary<string, UserInfo> ui_dic = new Dictionary<string, UserInfo>();
        Timer timer = null;  //킵얼라이브 시간 필요
        public EHAAA()
        {
            Initialize();
        }
        ~EHAAA()
        {//소멸자에선 데이터 저장 
            mtb.WriteXml(dfname);
        }
        private void Initialize()
        {//데이터 로딩하는 작업
            timer = new Timer(CheckKeepAlive);
            timer.Change(0, 3000); //3초 얼라이브 줌
            if (File.Exists(sfname))//파일 존재 여부 확인
            {
                mtb.ReadXmlSchema(sfname);//팡리 구조를 읽어와달라
                if (File.Exists(dfname)) //데이터 읽어달라
                {
                    mtb.ReadXml(dfname);
                }
            }
            else
            {
                DesignMTB(); //스키마 없다면 테이블 디자인 
            }
        }

        //회원 테이블 업승ㄹ 시 디자인 
        private void DesignMTB()
        {
            DataColumn dc_id = new DataColumn("id", typeof(string));
            dc_id.Unique = true;
            dc_id.AllowDBNull = false;
            mtb.Columns.Add(dc_id);

            DataColumn dc_pw = new DataColumn("pw", typeof(string));//여긴 암호화 없이 함
            dc_pw.AllowDBNull = false;
            mtb.Columns.Add(dc_pw);

            DataColumn[] pkeys = new DataColumn[] { dc_id };
            mtb.PrimaryKey = pkeys; //프라이머리 키로 
            mtb.WriteXmlSchema(sfname); //스키마 파이 ㄹ정의 

        }

        private void CheckKeepAlive(object state)
        {
            Console.Write("."); //확인 마다 점 찍기로 함 
            List<string> dlist = new List<string>();
            foreach (KeyValuePair<string,UserInfo> ui in ui_dic)
            {
                TimeSpan ts = DateTime.Now - ui.Value.LastKA; //지금 시간과 킵얼라이브 확인
                //3초 주기로 하는데 3번(9초) 줬는데도 도착 않았다면 삭제유저 목록으로 강제 추가 
                if (ts.TotalSeconds > 9) 
                {
                    dlist.Add(ui.Key);
                }
            }
            foreach (string id in dlist)
            {
                ui_dic.Remove(id); //삭제 한 후 삭제 리스트에 제거
                Logout2(id);
            }
        }

        private void Logout2(string id)
        {
            try//로그아웃 중 오류날 걸 대비 
            {
                //클라가 강제 로그아웃 됐다는 걸 알려주야
                foreach (UserInfo ui in ui_dic.Values)
                {
                    string oip = ui.IPStr; //아이피 주소
                    int obport = ui.BPort; //다른 유저 수신하기 위한 백포트 
                                           //로긴 로그아웃할 떄 알려주는 것
                    SendUserInfoAsync(oip, obport, id, "", 0, 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public void Logout(string id) //정상 로그 아웃 
        {
            if (ui_dic.ContainsKey(id) == false)
            {
                return;
            }
            ui_dic.Remove(id);
            Logout2(id); //정상 로그인 시 제대로 됐단 의미에서 이렇게 넘어가줌
        }
        public bool Join(string id, string pw) //로그인
        {
            try
            {
                DataRow dr = mtb.NewRow();
                dr["id"] = id;
                dr["pw"] = pw;
                mtb.Rows.Add(dr);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
        
        public void WithDraw(string id, string pw) //탈퇴
        {
            if (ui_dic.ContainsKey(id))
            {
                DataRow dr = mtb.Rows.Find(id);
                if(dr == null)
                {
                    return;
                }
                if (dr["pw"].ToString() == pw)
                {
                    mtb.Rows.Remove(dr);
                    Logout(id);
                }
            }
        }
        public int Login(string id, string pw)
        {
            try
            {
                DataRow dr = mtb.Rows.Find(id);
                if (dr == null) //회원 존재 안할 시 
                {
                    return 1;//미가입 
                }
                if (ui_dic.ContainsKey(id) == false)
                {
                    if (dr["pw"].ToString() == pw)
                    {
                        return 0; //로긴 성공 
                    }
                    return 3; //아이디는 있으나 비밀번호 틀림
                }
                return 2; //이미 로그인 중 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 3; //예외 발생 
            }
        } 
        public void KeepAlive(string id) //살아있는 상태 전달하기로 함
        {// 처음 이후 두번째부터는 이렇게 
            try
            {
                if (ui_dic.ContainsKey(id))
                {
                    ui_dic[id].LastKA = DateTime.Now;
                }
            }
            catch (Exception e)
            {

            }
        }
        public void KeepAlive(string id, string ipstr, int sport, int fport, int bport)
        {//처음 보낼 때
            Console.WriteLine("{0}의 첫번째 keepalive , {1},{2}", id, ipstr, bport);
            try
            {
                UserInfo ui = new UserInfo(id, ipstr, sport, fport, bport); //개겣형성
                foreach (UserInfo oui in ui_dic.Values)
                {
                    Console.WriteLine("Other{0}", oui.ID); //로그인한 유저들한테 새로운로긴 알림
                    string oip = oui.IPStr;
                    int osport = oui.Sport;
                    int ofport = oui.FPort;
                    int obport = oui.BPort;
                    SendUserInfoAsync(oip, obport, id, ipstr, sport, fport);//이미 있는 사람에게 전달
                    SendUserInfoAsync(ipstr, bport, oui.ID, oip, osport, ofport);//새로 
                }
                ui_dic[id] = ui;
                ui.LastKA = DateTime.Now;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //비동기 실행
        delegate void SUIDele(string oip, int obport, string id, string ipstr, int sport, int fport); //대리자
        private void SendUserInfoAsync(string oip, int obport, string id, string ipstr, int sport, int fport)//비동기
        {
            SUIDele dele = SendUserInfo;
            dele.BeginInvoke(oip, obport, id, ipstr, sport, fport, null, null);//콜벡 상태는 널
        }
        private void SendUserInfo(string oip, int obport, string id, string ipstr, int sport, int fport)//동기
        {//상대에게 전달하는 코드 
            try
            {
                Socket sock = new Socket(
                    AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(oip),obport);
                sock.Connect(iep);
                byte[] packet = new byte[1024];
                MemoryStream ms = new MemoryStream(packet);
                BinaryWriter bw = new BinaryWriter(ms); //
                bw.Write(id);
                bw.Write(ipstr);
                bw.Write(sport);
                bw.Write(fport);
                bw.Close();
                ms.Close();
                sock.Send(packet);
                sock.Close();

            }
            catch (Exception)
            {//로그작성

                
            }
        }
    }
}
