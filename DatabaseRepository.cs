using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Group9_VillageNewbies
    {
    internal class DatabaseRepository
        {

        private string connectionString = "DSN=Village Newbies;Uid=root;Pwd=root1;";

        public DataTable ExecuteQuery ( string query )
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
                catch (OdbcException odbcEx)
                    {
                    Console.WriteLine("ODBC Virhe tietokannassa: " + odbcEx.Message);
                    }
                catch (Exception ex)
                    {
                    Console.WriteLine("Yleinen virhe tietokannassa: " + ex.Message);
                    }
                finally
                    {
                    if (connection.State == ConnectionState.Open)
                        {
                        connection.Close();
                        }
                    }
                }
            return dataTable;
            }

        public List<Posti> HaeKaikkiPostit ()
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
        public bool LisaaPosti ( Posti posti )
            {
            try
                {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                    {
                    string query = "INSERT INTO posti (postinro, toimipaikka) VALUES (?, ?)";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                        {
                        command.Parameters.AddWithValue("postinro", posti.Postinro);
                        command.Parameters.AddWithValue("toimipaikka", posti.Toimipaikka);

                        connection.Open();
                        command.ExecuteNonQuery();
                        }
                    }
                return true;
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Virhe tietokantaan lisättäessä: {ex.Message}");
                return false;
                }
            }
        public bool PoistaPosti ( Posti posti ) //Ei toiminut ainakaan alue-hallinnassa
            {
            try
                {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                    {
                    connection.Open();

                    string query = "DELETE FROM posti WHERE postinro = ? AND toimipaikka = ?";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                        {
                        command.Parameters.AddWithValue("postinro", posti.Postinro);
                        command.Parameters.AddWithValue("toimipaikka", posti.Toimipaikka);
                        command.ExecuteNonQuery();
                        }


                    }
                return true;
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Virhe tietokannassa: {ex.Message}");
                return false;
                }
            }


        // Metodi uuden asiakkaan tietojen lisäämiseksi
        public bool LisaaAsiakas ( Asiakas asiakas )
            {
            try
                {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                    {
                    string query = "INSERT INTO asiakas (postinro, etunimi, sukunimi, lahiosoite, email, puhelinnro) VALUES (?, ?, ?, ?, ?, ?)";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                        {
                        command.Parameters.AddWithValue("postinro", asiakas.Postinro);
                        command.Parameters.AddWithValue("etunimi", asiakas.Etunimi);
                        command.Parameters.AddWithValue("sukunimi", asiakas.Sukunimi);
                        command.Parameters.AddWithValue("lahiosoite", asiakas.Lahiosoite);
                        command.Parameters.AddWithValue("email", asiakas.Email);
                        command.Parameters.AddWithValue("puhelinnro", asiakas.Puhelinnro);

                        connection.Open();
                        command.ExecuteNonQuery();
                        }
                    }
                return true;
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Virhe tietokantaan lisättäessä: {ex.Message}");
                return false;
                }
            }
        public bool LisaaAlue ( AlueTieto alue )
            {
            try
                {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                    {
                    connection.Open();

                    string query = "INSERT INTO alue (nimi) VALUES (?)";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                        {
                        command.Parameters.AddWithValue("nimi", alue.AlueNimi);
                        command.ExecuteNonQuery();
                        }
                    /* Kommenteissa kun ylemäpää löytyy LisaaPosti-funktio
                     * 
                    string query2 = "INSERT INTO posti (postinro, toimipaikka) VALUES (?, ?)";
                    using (OdbcCommand command = new OdbcCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("postinro", posti.Postinro);
                        command.Parameters.AddWithValue("toimipaikka", posti.Toimipaikka);
                        command.ExecuteNonQuery();
                    }*/
                    }
                return true;
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Virhe tietokantaan lisättäessä: {ex.Message}");
                return false;
                }
            }
        public bool PoistaAlue ( AlueTieto alue )
            {
            try
                {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                    {
                    connection.Open();

                    string query = "DELETE FROM alue WHERE nimi = ?";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                        {
                        command.Parameters.AddWithValue("nimi", alue.AlueNimi);
                        command.ExecuteNonQuery();
                        }
                    }
                return true;
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Virhe tietokannassa: {ex.Message}");
                return false;
                }
            }
        public bool LisaaMokki ( MokkiTieto mokki )
            {
            try
                {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                    {
                    string query = "INSERT INTO mokki (alue_id, postinro, mokkinimi, katuosoite, hinta, kuvaus, henkilomaara, varustelu) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                        {
                        command.Parameters.AddWithValue("alue_id", mokki.Alue);
                        command.Parameters.AddWithValue("postinro", mokki.Postinro);
                        command.Parameters.AddWithValue("mokkinimi", mokki.Mokkinimi);
                        command.Parameters.AddWithValue("katuosoite", mokki.Katuosoite);
                        command.Parameters.AddWithValue("hinta", mokki.Hinta);
                        command.Parameters.AddWithValue("kuvaus", mokki.Kuvaus);
                        command.Parameters.AddWithValue("henkilomaara", mokki.Henkilomaara);
                        command.Parameters.AddWithValue("varustelu", mokki.Varustelu);
                        connection.Open();
                        command.ExecuteNonQuery();
                        }
                    }
                return true;
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Virhe tietokantaan lisättäessä: {ex.Message}");
                return false;
                }
            }
        public bool PoistaMokki ( MokkiTieto mokki )
            {
            try
                {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                    {
                    string query = "DELETE FROM mokki WHERE mokkinimi = ?";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                        {
                        command.Parameters.AddWithValue("mokkinimi", mokki.Mokkinimi);
                        connection.Open();
                        command.ExecuteNonQuery();
                        }
                    }
                return true;
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Virhe tietokannasta poistaessa: {ex.Message}");
                return false;
                }
            }



        }
    }
