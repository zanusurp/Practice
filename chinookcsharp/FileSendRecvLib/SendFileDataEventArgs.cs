using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSendingClient
{
    public delegate void SendFileDataEventHandler(object sender, SendFileDataEventArgs e);
    public class SendFileDataEventArgs:EventArgs
    {
       
        public string FileName
        {
            get;
            private set;
        }
        public long Remain
        {
            get;
            private set;
        }
        public SendFileDataEventArgs(string fname, long remain)
        {
            FileName = fname;
            Remain = remain;
        }
    }
}
