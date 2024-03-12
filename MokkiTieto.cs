using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9_VillageNewbies
{
    public class MokkiTieto
    {
        public string Postinro {  get; set; }
        public string Mokkinimi { get; set; }
        public string Katuosoite { get; set; }
        public string Hinta { get; set; }
        public string Kuvaus { get; set; }
        public string Henkilomaara { get; set; }
        public string Varustelu { get; set; }
        public string Alue { get; set; }

        public override string ToString()
        {
            // Palauta merkkijono, joka näytetään ListBoxissa
            return $"{Mokkinimi}";
        }


    }
}
