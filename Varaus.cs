using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9_VillageNewbies
{
    internal class Varaus
    {
        public int Varaus_id { get; set; }
        public int Asiakas_id { get; set; }
        public int Mokki_Mokki_id { get; set; }
        public DateTime Varattu_pvm { get; set; }
        public DateTime Vahvistu_pvm { get; set; }
        public DateTime Varattu_alkupvm { get; set; }
        public DateTime Varattu_loppupvm { get; set; }

        public Varaus(int varaus_id, int asiakas_id, int mokki_mokki_id, DateTime varattu_pvm, DateTime vahvistu_pvm, DateTime varattu_alkupvm, DateTime varattu_loppupvm)
        {
            Varaus_id = varaus_id;
            Asiakas_id = asiakas_id;
            Mokki_Mokki_id = mokki_mokki_id;
            Varattu_pvm = varattu_pvm;
            Vahvistu_pvm = vahvistu_pvm;
            Varattu_alkupvm = varattu_alkupvm;
            Varattu_loppupvm = varattu_loppupvm;
        }
    }



}
