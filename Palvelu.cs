using System;
using System.Collections.Generic;
using System.Data;

namespace Group9_VillageNewbies
    {
    public class Palvelu
        {
        public int Palvelu_id { get; set; }
        public string Nimi { get; set; }
        public string Kuvaus { get; set; }
        public string Hinta { get; set; }
        public int Alv { get; set; }
        public int AlueId { get; set; }
        public string AlueNimi { get; set; }

        public Palvelu ( int palvelu_id, string nimi, string kuvaus, string hinta, int alv, int alueId, string alueNimi )
            {
            Palvelu_id = palvelu_id;
            Nimi = nimi;
            Kuvaus = kuvaus;
            Hinta = hinta;
            Alv = alv;
            AlueId = alueId;
            AlueNimi = alueNimi;
            }
        public Palvelu ( string nimi, string kuvaus, string hinta, string alueNimi, int alv)
            {
            Nimi = nimi;
            Kuvaus = kuvaus;
            Hinta = hinta;
            AlueNimi = alueNimi;
            Alv = alv;
            }
        public Palvelu ( string nimi, string kuvaus, string hinta, string alueNimi )
            {
            Nimi = nimi;
            Kuvaus = kuvaus;
            Hinta = hinta;
            AlueNimi = alueNimi;
            }
        public Palvelu()
        {
           
        }
        public static List<Palvelu> HaeKaikkiPalveluTiedot ()
            {
            List<Palvelu> palvelut = new List<Palvelu>();
            DatabaseRepository repository = new DatabaseRepository();
            DataTable palveluTable = repository.ExecuteQuery("SELECT p.palvelu_id, p.nimi, p.kuvaus, p.hinta, p.alv, p.alue_id, a.nimi AS alueen_nimi " +
                                                            "FROM palvelu p " +
                                                            "INNER JOIN alue a ON p.alue_id = a.alue_id");

            foreach (DataRow row in palveluTable.Rows)
                {
                Palvelu palvelu = new Palvelu(
                    Convert.ToInt32(row["palvelu_id"]),
                    row["nimi"].ToString(),
                    row["kuvaus"].ToString(),
                    row["hinta"].ToString(),
                    Convert.ToInt32(row["alv"]),
                    Convert.ToInt32(row["alue_id"]),
                    row["alueen_nimi"].ToString()
                );

                palvelut.Add(palvelu);
                }

            return palvelut;
            }


        public static List<Palvelu> HaeKaikkiPalvelut ()
            {
            List<Palvelu> palvelut = new List<Palvelu>();
            DatabaseRepository repository = new DatabaseRepository();
            DataTable palveluTable = repository.ExecuteQuery("SELECT p.nimi AS PalvelunNimi, p.kuvaus AS PalvelunKuvaus, p.hinta AS PalvelunHinta, a.nimi AS AlueenNimi " +
                                                        "FROM palvelu p " +
                                                        "INNER JOIN alue a ON p.alue_id = a.alue_id");

            foreach (DataRow row in palveluTable.Rows)
                {
                Palvelu palvelu = new Palvelu(
                    row["PalvelunNimi"].ToString(),
                    row["PalvelunKuvaus"].ToString(),
                    row["PalvelunHinta"].ToString(),
                    row["AlueenNimi"].ToString()
                );
                palvelut.Add(palvelu);
                }

            return palvelut;
          }


        public static List<Palvelu> HaeAlueenPalvelut ( int alueId )
            {
            List<Palvelu> alueenpalvelut = new List<Palvelu>();
            DatabaseRepository repository = new DatabaseRepository();
            DataTable results = repository.ExecuteQuery("SELECT p.nimi AS PalvelunNimi, p.kuvaus AS PalvelunKuvaus, p.hinta AS PalvelunHinta, a.nimi AS AlueenNimi " +
                                                        "FROM palvelu p " +
                                                        "INNER JOIN alue a ON p.alue_id = a.alue_id " +
                                                        "WHERE a.alue_id = " + alueId);
            foreach (DataRow row in results.Rows)
                {
                alueenpalvelut.Add(new Palvelu(
                    row["PalvelunNimi"].ToString(),
                    row["PalvelunKuvaus"].ToString(),
                    row["PalvelunHinta"].ToString(),
                    row["AlueenNimi"].ToString()
                ));
                }
            return alueenpalvelut;
            }
        public static bool PoistaPalvelu ( string palveluId )
            {
            // Alustetaan poiston onnistuminen false-arvolla
            bool poistoOnnistui = false;

            try
                {
                DatabaseRepository repository = new DatabaseRepository();

                // Luo SQL-kysely poistamista varten
                string query = "DELETE FROM palvelu WHERE palvelu_id = '" + palveluId + "'";

                // Suorita poistokysely tietokantaan
                repository.ExecuteNonQuery(query);

                // Aseta poiston onnistuminen true-arvoksi
                poistoOnnistui = true;
                }
            catch (Exception ex)
                {
                // Tulosta virheilmoitus poikkeuksen käsittelyä varten
                Console.WriteLine("Virhe poistettaessa palvelua: " + ex.Message);
                }

            // Palauta poiston onnistuminen
            return poistoOnnistui;
            }
        public static bool LisaaPalvelu ( string nimi, string kuvaus, string hinta, int alv, int alueId )
            {
            bool lisaysOnnistui = false;
            // lisää int tyyppi joka on random numero 1-5 välillä
            Random rnd = new Random();
            int tyyppi = rnd.Next(1, 5);

            try
                {
                DatabaseRepository repository = new DatabaseRepository();
                string query = "INSERT INTO palvelu (nimi, tyyppi, kuvaus, hinta, alv, alue_id) VALUES ('" + nimi + "', '" + tyyppi + "', '" + kuvaus + "', '" + hinta + "', " + alv + ", " + alueId + ")";
                repository.ExecuteNonQuery(query);
                lisaysOnnistui = true;
                }
            catch (Exception ex)
                {
                Console.WriteLine("Virhe lisättäessä palvelua: " + ex.Message);
                }
            return lisaysOnnistui;
            }

        public static bool MuokkaaPalvelu ( string palveluId, string nimi, string kuvaus, string hinta, int alv, int alueId )
            {
            bool muokkausOnnistui = false;
            try
                {
                DatabaseRepository repository = new DatabaseRepository();
                string query = "UPDATE palvelu SET nimi='" + nimi + "', kuvaus='" + kuvaus + "', hinta='" + hinta + "', alv=" + alv + ", alue_id=" + alueId + " WHERE palvelu_id='" + palveluId + "'";
                repository.ExecuteNonQuery(query);
                muokkausOnnistui = true;
                }
            catch (Exception ex)
                {
                Console.WriteLine("Virhe muokattaessa palvelua: " + ex.Message);
                }
            return muokkausOnnistui;
            }

        public static int HaeAlueIdNimenPerusteella ( string alueenNimi )
            {
            int alueId = -1; // Alueen id, joka palautetaan (-1 jos aluetta ei löydy)

            try
                {
                DatabaseRepository repository = new DatabaseRepository();
                string query = "SELECT alue_id FROM alue WHERE nimi = '" + alueenNimi + "'";
                DataTable result = repository.ExecuteQuery(query);

                if (result.Rows.Count > 0)
                    {
                    DataRow row = result.Rows[0];
                    alueId = Convert.ToInt32(row["alue_id"]);
                    }
                else
                    {
                    Console.WriteLine("Aluetta ei löytynyt nimen perusteella.");
                    }
                }
            catch (Exception ex)
                {
                Console.WriteLine("Virhe haettaessa alueen id:tä nimen perusteella: " + ex.Message);
                }

            return alueId;
            }

        }
    }
