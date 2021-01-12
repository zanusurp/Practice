using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileReceivingServer
{
    public delegate void RecvFileNameEventHandler(object sender, RecvFileNameEventArgs e);
    public class RecvFileNameEventArgs : EventArgs
    {
       
        public IPEndPoint RemoteEndPoint
        {
            get;
            private set;
        }
        public string FileName
        {
            get;
            private set;
        }
        //public string IPStr
        //{
        //    get
        //    {
        //        return RemoteEndPoint.Address.ToString();
        //    }
        //}
        //public int Port
        //{
        //    get
        //    {
        //        return RemoteEndPoint.Port;
        //    }
        //}
        public RecvFileNameEventArgs(string fname, IPEndPoint rep)
        {
            FileName = fname;
            RemoteEndPoint = rep;
        }
    }
}

