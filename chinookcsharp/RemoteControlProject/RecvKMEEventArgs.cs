using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlProject
{//키보드마우스이벤트 발생시 처리하기 위한 인자형식 
    public delegate void RecvKMEEventHandler(object sender, RecvKMEEventArgs e);
    public class RecvKMEEventArgs:EventArgs
    {
        public Meta Meta
        {
            get;
            private set;
        }
        public int Key
        {
            get
            {
                return Meta.Key;
            }
        }
        public Point Now
        {
            get
            {
                return Meta.Now;
            }
        }
        public MsgType MT
        {
            get
            {
                return Meta.MT;
            }
        }
        public RecvKMEEventArgs(Meta meta)
        {
            Meta = meta;
        }
    }
}
