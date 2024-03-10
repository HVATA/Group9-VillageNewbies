using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9_VillageNewbies
{
    internal class Posti
    {
        public string Postinro { get; set; }
        public string Toimipaikka { get; set; }

        public Posti(string postinro, string toimipaikka)
        {
            Postinro = postinro;
            Toimipaikka = toimipaikka;
        }
    }
}
