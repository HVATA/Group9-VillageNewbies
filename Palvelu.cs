using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Group9_VillageNewbies
    {
    internal class Palvelu
        {
        public string Palvelu_id { get; set; }
        public string Nimi { get; set; }
        public string Kuvaus { get; set; }
        public string Hinta { get; set; }
        public string Alv { get; set; }

        public Palvelu ( string palvelu_id, string nimi, string kuvaus, string hinta, string alv )
            {
            Palvelu_id = palvelu_id;
            Nimi = nimi;
            Kuvaus = kuvaus;
            Hinta = hinta;
            Alv = alv;
            }

        public static List<Palvelu> HaeKaikkiPalvelut ()
            {
            List<Palvelu> palvelut = new List<Palvelu>();
            DatabaseRepository repository = new DatabaseRepository();
            DataTable palveluTable = repository.ExecuteQuery("SELECT * FROM palvelu");

            foreach (DataRow row in palveluTable.Rows)
                {
                Palvelu palvelu = new Palvelu(
                    row["palvelu_id"].ToString(),
                    row["nimi"].ToString(),
                    row["kuvaus"].ToString(),
                    row["hinta"].ToString(),
                    row["alv"].ToString()
                );

                palvelut.Add(palvelu);
                }

            return palvelut;
            }
        }
    }