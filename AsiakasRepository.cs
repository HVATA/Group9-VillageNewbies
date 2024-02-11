using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using System.Diagnostics;
using Group9_VillageNewbies;
using System.Windows.Forms;



namespace Group9_VillageNewbies
{
    public class AsiakasRepository
    {
        private string connectionString = "DSN=Village Newbies;Uid=root;Pwd=root1;";

        public List<Asiakas> HaeAsiakkaat()
        {
            List<Asiakas> asiakkaat = new List<Asiakas>();
            string query = "SELECT asiakas_id, postinro, etunimi, sukunimi, lahiosoite, email, puhelinnro FROM asiakas";

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                OdbcCommand command = new OdbcCommand(query, connection);

                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Yhteys avattu");
                        Debug.WriteLine("Yhteys avattu onnistuneesti. Tietokannan versio: " + connection.ServerVersion);

                        MessageBox.Show("Tietokannan versio: " + connection.ServerVersion);
                        using (OdbcDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Asiakas asiakas = new Asiakas()
                                {
                                    AsiakasId = reader.GetInt32(reader.GetOrdinal("asiakas_id")),
                                    Postinro = reader.GetString(reader.GetOrdinal("postinro")),
                                    Etunimi = reader.GetString(reader.GetOrdinal("etunimi")),
                                    Sukunimi = reader.GetString(reader.GetOrdinal("sukunimi")),
                                    Lahiosoite = reader.GetString(reader.GetOrdinal("lahiosoite")),
                                    Email = reader.GetString(reader.GetOrdinal("email")),
                                    Puhelinnro = reader.GetString(reader.GetOrdinal("puhelinnro"))
                                };
                                asiakkaat.Add(asiakas);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Yhteys ei ole auki");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Virhe tietokannassa: " + ex.Message);
                }
            }

            return asiakkaat;
        }
    }
}
