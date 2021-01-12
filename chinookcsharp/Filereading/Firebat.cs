using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filereading
{
    public class Firebat
    {
        public Firebat(int no)
        {
            No = no;
            HP = 60;
        }

        public int HP { get; set; }
        public int No { get; set; }
    }
}
