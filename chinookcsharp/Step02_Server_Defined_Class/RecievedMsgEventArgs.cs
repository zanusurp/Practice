﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Step02_Server_Defined_Class
{
    public delegate void RecievedMsgEventHanlder(object sender, RecievedMsgEventArgs e);
    public class RecievedMsgEventArgs:EventArgs
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
        public string Msg
        {
            get;
            private set;
        }
        public RecievedMsgEventArgs(IPEndPoint remote_ep, string msg)
        {
            REmoteEP = remote_ep;
            Msg = msg;

        }
    }
}
