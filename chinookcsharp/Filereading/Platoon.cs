using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filereading
{
    public class Platoon
    {
        public Platoon()
        {
            Marines = new List<Marine>();
            Firebats = new List<Firebat>();
        }
        public List<Marine> Marines { get; set; }
        public List<Firebat> Firebats { get; set; }
    }
}
