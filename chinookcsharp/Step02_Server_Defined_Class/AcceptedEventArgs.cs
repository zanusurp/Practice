using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Step02_Server_Defined_Class
{
    public delegate void AcceptedEventHandler(object sender, AcceptedEventArgs e);
    public class AcceptedEventArgs:EventArgs
    {
        //대리자로 이벤트 반응해 주는 것 만듦 
        
        public IPEndPoint REmoteEP
        {
            get;
            private set;
        }
        public string IPStr
        {
            get
            {
                return REmoteEP.Address.ToString(); 
            }
        }
        public int Port
        {
            get
            {
                return REmoteEP.Port;
            }
        }
        public AcceptedEventArgs(IPEndPoint remote_ep)
        {
            REmoteEP = remote_ep;

        }
    }
}
