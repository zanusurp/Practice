using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Step02_Server_Defined_Class
{
    public delegate void ClosedEventHanlder(object sender, ClosedEventArgs e);
    public class ClosedEventArgs:EventArgs
    {
        
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
        public ClosedEventArgs(IPEndPoint remote_ep)
        {
            REmoteEP = remote_ep;

        }
    }
}
