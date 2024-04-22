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
    }
}
