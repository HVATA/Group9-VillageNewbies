using System.Collections.Generic;
using System.Data;

namespace Group9_VillageNewbies
    {
    public class PalveluTiedot
        {
        public string Nimi { get; set; }
        public string Kuvaus { get; set; }
        public string Hinta { get; set; }
        public string AlueNimi { get; set; } // Alueen nimi

        public PalveluTiedot ( string nimi, string kuvaus, string hinta, string alueNimi )
            {
            Nimi = nimi;
            Kuvaus = kuvaus;
            Hinta = hinta;
            AlueNimi = alueNimi;
            }

        public static List<PalveluTiedot> HaePalveluTiedot ()
            {
            List<PalveluTiedot> palveluTiedot = new List<PalveluTiedot>();

            // Luodaan uusi DatabaseRepository-olio
            DatabaseRepository repository = new DatabaseRepository();

            // Suoritetaan kysely palvelutietojen hakemiseksi
            DataTable results = repository.ExecuteQuery("SELECT p.nimi AS PalvelunNimi, p.kuvaus AS PalvelunKuvaus, p.hinta AS PalvelunHinta, a.nimi AS AlueenNimi " +
                                                        "FROM palvelu p " +
                                                        "INNER JOIN alue a ON p.alue_id = a.alue_id");

            // Käydään läpi jokainen tulosrivi ja lisätään PalveluTiedot-listaan
            foreach (DataRow row in results.Rows)
                {
                palveluTiedot.Add(new PalveluTiedot(
                    row["PalvelunNimi"].ToString(),
                    row["PalvelunKuvaus"].ToString(),
                    row["PalvelunHinta"].ToString(),
                    row["AlueenNimi"].ToString()
                ));
                }

            return palveluTiedot;
            }
        public static List<PalveluTiedot> HaeAlueenPalveluTiedot ( int alue_id )
            {

            List<PalveluTiedot> alueenPalveluTiedot = new List<PalveluTiedot>();
            DatabaseRepository repository = new DatabaseRepository();
            DataTable results = repository.ExecuteQuery("SELECT p.nimi AS PalvelunNimi, p.kuvaus AS PalvelunKuvaus, p.hinta AS PalvelunHinta, a.nimi AS AlueenNimi " +
                                                        "FROM palvelu p " +
                                                        "INNER JOIN alue a ON p.alue_id = a.alue_id " +
                                                        "WHERE a.alue_id = " + alue_id);
            foreach (DataRow row in results.Rows)
                {
                alueenPalveluTiedot.Add(new PalveluTiedot(
                    row["PalvelunNimi"].ToString(),
                    row["PalvelunKuvaus"].ToString(),
                    row["PalvelunHinta"].ToString(),
                    row["AlueenNimi"].ToString()
                    ));
                }
            return alueenPalveluTiedot;
            }
        }
    }