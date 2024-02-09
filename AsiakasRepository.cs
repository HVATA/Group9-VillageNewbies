using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;


namespace Group9_VillageNewbies
{
    public class AsiakasRepository
    {
        private string connectionString = "DSN=ODBC.localhost.vn;Uid=root;Pwd=root1;"; // Oikeat yhteystiedot

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
                catch (Exception ex)
                {
                    Console.WriteLine("Virhe tietokannassa: " + ex.Message);
                }
            }

            return asiakkaat;
        }
    }
}
