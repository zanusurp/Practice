using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileReceivingServer
{
    public delegate void CloseEventHandler(object sender, CloseEventArgs e);
    public class CloseEventArgs :EventArgs
    {
        
        public IPEndPoint RemoteEndPoint
        {
            get;
            private set;
        }
        public string IPStr
        {
            get
            {
                return RemoteEndPoint.Address.ToString();
            }
        }
        public int Port
        {
            get
            {
                return RemoteEndPoint.Port;
            }
        }
        public CloseEventArgs(IPEndPoint rep)
        {
            RemoteEndPoint = rep;
        }
    }
}
