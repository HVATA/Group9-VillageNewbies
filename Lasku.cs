using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9_VillageNewbies
{
    public class Lasku
    {
        public int LaskuId { get; set; }
        public int AsiakasId { get; set; }
        public int VarausId { get; set; }
        public DateTime LaskunPvm { get; set; }
        public DateTime Erapvm { get; set; }
        public double Summa { get; set; }
        public double Alv { get; set; }
        public bool Maksettu { get; set; }
        public string FilePath { get; set; }
        public string Postinro { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Lahiosoite { get; set; }
        public string Email { get; set; }
        public string Puhelinnro { get; set; }
        public string Mokkinimi { get; set; }

    }
}
