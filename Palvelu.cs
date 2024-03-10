using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9_VillageNewbies
{
    internal class Palvelu
    {
        public string Palvelu_id { get; set; }
        public string Nimi { get; set; }
        public string Kuvaus { get; set; }
        public string Hinta { get; set; }
        public string Alv { get; set; }
        public string Saatavuus { get; set; }

        public Palvelu(string palvelu_id, string nimi, string kuvaus, string hinta, string alv, string saatavuus)
        {
            Palvelu_id = palvelu_id;
            Nimi = nimi;
            Kuvaus = kuvaus;
            Hinta = hinta;
            Alv = alv;
            Saatavuus = saatavuus;
        }
    }
}
