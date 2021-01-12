using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileReceivingServer
{
    public delegate void FileLengthRecvEventHandler(object sender, FileLengthRecvEventArgs e);
    public class FileLengthRecvEventArgs : EventArgs
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
        public long Length
        {
            get;
            private set;
        }
        public FileLengthRecvEventArgs(string fname, IPEndPoint rep, long length)
        {
            FileName = fname;
            RemoteEndPoint = rep;
            Length = length;
        }
    }
}
