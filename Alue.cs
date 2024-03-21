using System;
using System.Collections.Generic;
using System.Data;
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

        public static List<Alue> HaeKaikkiAlueet ()
            {
            List<Alue> alueet = new List<Alue>();
            DatabaseRepository repository = new DatabaseRepository();
            DataTable alueetTable = repository.ExecuteQuery("SELECT * FROM alue");

            foreach (DataRow row in alueetTable.Rows)
                {
                Alue alue = new Alue
                    {
                    AlueId = Convert.ToInt32(row["alue_id"]),
                    Nimi = row["nimi"].ToString()
                    };
                alueet.Add(alue);
                }

            return alueet;
            }
        }
    }