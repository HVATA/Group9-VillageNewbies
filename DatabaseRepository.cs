using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9_VillageNewbies
{
    internal class DatabaseRepository
    {

        private string connectionString = "DSN=Village Newbies;Uid=root;Pwd=root1;";

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                OdbcCommand command = new OdbcCommand(query, connection);
                try
                {
                    connection.Open();
                    using (OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Virhe tietokannassa: " + ex.Message);
                }
            }
            return dataTable;
        }

        public List<Posti> HaeKaikkiPostit()
        {
            List<Posti> postit = new List<Posti>();
            string query = "SELECT postinro, toimipaikka FROM posti ORDER BY toimipaikka ASC";

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
                            string postinro = reader["postinro"].ToString();
                            string toimipaikka = reader["toimipaikka"].ToString();

                            postit.Add(new Posti(postinro, toimipaikka));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Virhe tietokannassa: " + ex.Message);
                    // Käsittele virhe tarvittaessa
                }
            }
            return postit;
        }



    }
}
