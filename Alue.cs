using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9_VillageNewbies
{
    internal class Alue
    {

        public int AlueId { get; set; }
        public string Nimi { get; set; }

        public override string ToString ()
            {
            return Nimi;
        }
    }
}
