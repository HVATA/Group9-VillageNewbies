using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Group9_VillageNewbies
{
    public class AlueTieto
    {
        public string AlueNimi { get; set; }
        public string Alue_id { get; set; } 

        public override string ToString()
        {
            // Palauta merkkijono, joka näytetään ListBoxissa
            return $"{AlueNimi}";
        }
    }
}
