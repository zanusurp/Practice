using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileReceivingServer
{
    public delegate void FileDataRecvEventHandler(object sender, FileDataRecvEventArgs e);
    public class FileDataRecvEventArgs : EventArgs
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
        public long RemainLenth
        {
            get;
            private set;
        }
        public byte[] Data
        {
            get;
            private set;
        }
        public FileDataRecvEventArgs(string fname, IPEndPoint rep,  long rlen, byte[] data)
        {
            RemoteEndPoint = rep;
            FileName = fname;
            Data = data;
            
            RemainLenth = rlen;
        }


    }
}
