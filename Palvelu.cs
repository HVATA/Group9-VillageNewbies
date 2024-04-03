using System;
using System.Collections.Generic;
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
        public string AlueNimi { get; set; }

        public Palvelu ( string palvelu_id, string nimi, string kuvaus, string hinta, string alv, int alueId )
            {
            Palvelu_id = palvelu_id;
            Nimi = nimi;
            Kuvaus = kuvaus;
            Hinta = hinta;
            Alv = alv;
            AlueId = alueId;
            }
        public Palvelu ( string nimi, string kuvaus, string hinta, string alueNimi )
            {
            Nimi = nimi;
            Kuvaus = kuvaus;
            Hinta = hinta;
            AlueNimi = alueNimi;
            }

        public static List<Palvelu> HaeKaikkiPalveluTiedot ()
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
        }
    }
