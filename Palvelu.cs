using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Group9_VillageNewbies
    {
    public class Palvelu
        {
        public string Palvelu_id { get; set; }
        public string Nimi { get; set; }
        public string Kuvaus { get; set; }
        public string Hinta { get; set; }
        public string Alv { get; set; }
        public int AlueId { get; set; }

        public Palvelu ( string palvelu_id, string nimi, string kuvaus, string hinta, string alv, int alueId )
            {
            Palvelu_id = palvelu_id;
            Nimi = nimi;
            Kuvaus = kuvaus;
            Hinta = hinta;
            Alv = alv;
            AlueId = alueId;
            }

        public PalveluTiedot ProjisoiPalveluTiedoiksi ()
            {
            return new PalveluTiedot(Nimi, Kuvaus, Hinta, "");
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
                    row["alv"].ToString(),
                    Convert.ToInt32(row["alue_id"])
                );

                palvelut.Add(palvelu);
                }

            return palvelut;
            }

        public static List<PalveluTiedot> HaeKaikkiPalveluTiedot ()
            {
            List<Palvelu> kaikkiPalvelut = HaeKaikkiPalvelut();
            List<PalveluTiedot> palveluTiedot = new List<PalveluTiedot>();

            foreach (var palvelu in kaikkiPalvelut)
                {
                palveluTiedot.Add(palvelu.ProjisoiPalveluTiedoiksi());
                }

            return palveluTiedot;
            }

        public static List<PalveluTiedot> HaeAlueenPalveluTiedot ( int alueId )
            {
            List<Palvelu> kaikkiPalvelut = HaeKaikkiPalvelut();
            List<PalveluTiedot> alueenPalveluTiedot = new List<PalveluTiedot>();

            foreach (var palvelu in kaikkiPalvelut)
                {
                if (palvelu.AlueId == alueId)
                    {
                    alueenPalveluTiedot.Add(palvelu.ProjisoiPalveluTiedoiksi());
                    }
                }

            return alueenPalveluTiedot;
            }
        }
    }
