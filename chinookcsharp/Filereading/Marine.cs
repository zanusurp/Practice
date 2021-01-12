using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filereading
{
    public class Marine
    {
        public Marine(int no)
        {
            No = no;
            HP = 50;
        }
        public int HP { get; set; }
        public int No { get; set; }
    }
}
