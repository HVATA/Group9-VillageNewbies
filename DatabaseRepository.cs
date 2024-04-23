using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

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
        public int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                OdbcCommand command = new OdbcCommand(query, connection);
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
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
            return rowsAffected;
        }

        public List<Posti> HaeKaikkiPostit()
        {
            List<Posti> postit = new List<Posti>();
            // Päivitetty kysely, joka hakee kaikki postinumerot, jotka ovat asiakkaiden käytössä,
            // ja jättää pois ne, jotka ovat vain mökkien käytössä
            string query = @"SELECT DISTINCT p.postinro, p.toimipaikka
                            FROM posti p
                            WHERE EXISTS (
                                SELECT 1 FROM asiakas a WHERE a.postinro = p.postinro
                            )
                            OR NOT EXISTS (
                                -- Valitse postinumerot, joita käytetään vain mökeissä, eli ne joita ei käytetä asiakkailla
                                SELECT 1 FROM mokki m WHERE m.postinro = p.postinro AND NOT EXISTS (
                                    SELECT 1 FROM asiakas a2 WHERE a2.postinro = m.postinro
                                )
                            )
                            ORDER BY p.toimipaikka ASC;";

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


        public List<Posti> HaeKaikkiPostit2()
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

        public List<Posti> HaeKaikkiPostit1()
        {
            List<Posti> postit = new List<Posti>();
            // Päivitetty kysely, joka hakee vain asiakkaiden käyttämiä postinumeroita, jotka eivät ole mökkien käytössä
            string query = @"
        SELECT p.postinro, p.toimipaikka 
        FROM posti p
        WHERE p.postinro IN (
            SELECT DISTINCT a.postinro 
            FROM asiakas a
        ) AND p.postinro NOT IN (
            SELECT DISTINCT m.postinro 
            FROM mokki m
        )
        ORDER BY p.toimipaikka ASC";

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


        public bool LisaaPosti(Posti posti)
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
        public bool PoistaPosti(Posti posti) //Ei toiminut ainakaan alue-hallinnassa
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
        public bool LisaaAsiakas(Asiakas asiakas)
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
        // Metodi asiakkaan tietojen poistamiseksi
        public bool PoistaAsiakas(int asiakasId)
        {
            using (var connection = new OdbcConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "DELETE FROM asiakas WHERE asiakas_id = ?";
                    using (var command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", asiakasId);
                        int affectedRows = command.ExecuteNonQuery();
                        return affectedRows > 0; // Palautetaan true jos poisto onnistui
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Virhe tietokannassa: " + ex.Message);
                    return false;
                }
            }
        }

        public bool LisaaAlue(AlueTieto alue)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO alue (alue_id, nimi) VALUES (?, ?)";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("alue_id", alue.Alue_id);
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
        public bool PoistaAlue(AlueTieto alue)
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
        public bool LisaaMokki(MokkiTieto mokki)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    string query = "INSERT INTO mokki (mokki_id, alue_id, postinro, mokkinimi, katuosoite, hinta, kuvaus, henkilomaara, varustelu) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("mokki_id", mokki.Mokki_id);
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
        public bool LisaaVaraus(Varaus varaus)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    string query = "INSERT INTO varaus " +
                                   "(varaus_id, asiakas_id, mokki_mokki_id, varattu_pvm, vahvistus_pvm, varattu_alkupvm, varattu_loppupvm) " +
                                   "VALUES (?, ?, ?, ?, ?, ?, ?)";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("varaus_id", varaus.Varaus_id);
                        command.Parameters.AddWithValue("asiakas_id", varaus.Asiakas_id);
                        command.Parameters.AddWithValue("mokki_mokki_id", varaus.Mokki_Mokki_id);
                        command.Parameters.AddWithValue("varattu_pvm", varaus.Varattu_pvm);
                        command.Parameters.AddWithValue("vahvistus_pvm", varaus.Vahvistu_pvm);
                        command.Parameters.AddWithValue("varattu_alkupvm", varaus.Varattu_alkupvm);
                        command.Parameters.AddWithValue("varattu_loppupvm", varaus.Varattu_loppupvm);
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
        public void MuutaVaraus(Varaus varaus)
        {
            using (var connection = new OdbcConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new OdbcCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"
                UPDATE varaus
                SET
                    asiakas_id = ?,
                    mokki_mokki_id = ?,
                    varattu_pvm = ?,
                    vahvistus_pvm = ?,
                    varattu_alkupvm = ?,
                    varattu_loppupvm = ?
                WHERE varaus_id = ?";

                        // Lisää parametrit ODBC:n tapaan käyttäen kysymysmerkkejä ja sijoittamalla arvot järjestyksessä
                        command.Parameters.Add(new OdbcParameter("asiakas_id", varaus.Asiakas_id));
                        command.Parameters.Add(new OdbcParameter("mokki_mokki_id", varaus.Mokki_Mokki_id));
                        command.Parameters.Add(new OdbcParameter("varattu_pvm", varaus.Varattu_pvm));
                        command.Parameters.Add(new OdbcParameter("vahvistus_pvm", varaus.Vahvistu_pvm));
                        command.Parameters.Add(new OdbcParameter("varattu_alkupvm", varaus.Varattu_alkupvm));
                        command.Parameters.Add(new OdbcParameter("varattu_loppupvm", varaus.Varattu_loppupvm));
                        command.Parameters.Add(new OdbcParameter("varaus_id", varaus.Varaus_id));

                        command.ExecuteNonQuery();
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Virhe tietokantaa muutettaessa: {ex.Message}");
                }
            }
        }
        public bool PoistaVaraus(Varaus varaus)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    string query = "DELETE FROM varaus WHERE varaus_id = ?";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("varaus_id", varaus.Varaus_id);
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
        public bool PoistaMokki(MokkiTieto mokki)
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
        public bool MuutaAlueTieto(AlueTieto alueTieto)
        {
            using (var connection = new OdbcConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new OdbcCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"
                        UPDATE alue
                        SET
                            nimi = ?
                        WHERE alue_id = ?";

                        // Lisää parametrit ODBC:n tapaan käyttäen kysymysmerkkejä ja sijoittamalla arvot järjestyksessä
                        command.Parameters.Add(new OdbcParameter("nimi", alueTieto.AlueNimi));
                        command.Parameters.Add(new OdbcParameter("alue_id", alueTieto.Alue_id));

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Virhe päivitettäessä aluetietoja: {ex.Message}");
                    return false;
                }
            }
        }
        public void MuutaMokkiTieto(MokkiTieto mokkiTieto)
        {
            using (var connection = new OdbcConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new OdbcCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"
                        UPDATE mokki
                        SET
                            alue_id = ?,
                            postinro = ?,
                            mokkinimi = ?,
                            katuosoite = ?,
                            hinta = ?,
                            kuvaus = ?,
                            henkilomaara = ?,
                            varustelu = ?
                        WHERE mokki_id = ?";

                        // Lisää parametrit ODBC:n tapaan käyttäen kysymysmerkkejä ja sijoittamalla arvot järjestyksessä
                        command.Parameters.Add(new OdbcParameter("alue_id", mokkiTieto.Alue));
                        command.Parameters.Add(new OdbcParameter("postinro", mokkiTieto.Postinro));
                        command.Parameters.Add(new OdbcParameter("mokkinimi", mokkiTieto.Mokkinimi));
                        command.Parameters.Add(new OdbcParameter("katuosoite", mokkiTieto.Katuosoite));
                        command.Parameters.Add(new OdbcParameter("hinta", mokkiTieto.Hinta));
                        command.Parameters.Add(new OdbcParameter("kuvaus", mokkiTieto.Kuvaus));
                        command.Parameters.Add(new OdbcParameter("henkilomaara", mokkiTieto.Henkilomaara));
                        command.Parameters.Add(new OdbcParameter("varustelu", mokkiTieto.Varustelu));
                        command.Parameters.Add(new OdbcParameter("mokki_id", mokkiTieto.Mokki_id));

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Virhe tietokantaa muutettaessa: {ex.Message}");
                }
            }
        }

        public bool MuutaAsiakkaanTiedot(AsiakasTieto muokattuAsiakas)
        {
            using (var connection = new OdbcConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new OdbcCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"
                    UPDATE asiakas
                    SET
                        etunimi = ?,
                        sukunimi = ?,
                        lahiosoite = ?,
                        postinro = ?,
                        puhelinnro = ?,
                        email = ?
                    WHERE asiakas_id = ?";

                        // Lisää parametrit ODBC:n tapaan käyttäen kysymysmerkkejä ja sijoittamalla arvot järjestyksessä
                        command.Parameters.Add(new OdbcParameter("etunimi", muokattuAsiakas.Etunimi));
                        command.Parameters.Add(new OdbcParameter("sukunimi", muokattuAsiakas.Sukunimi));
                        command.Parameters.Add(new OdbcParameter("lahiosoite", muokattuAsiakas.Lahiosoite));
                        command.Parameters.Add(new OdbcParameter("postinro", muokattuAsiakas.Postinro));
                        command.Parameters.Add(new OdbcParameter("puhelinnro", muokattuAsiakas.Puhelinnro));
                        command.Parameters.Add(new OdbcParameter("email", muokattuAsiakas.Email));
                        command.Parameters.Add(new OdbcParameter("asiakas_id", muokattuAsiakas.AsiakasId));

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Virhe päivitettäessä asiakkaan tietoja: {ex.Message}");
                    return false;
                }
            }
        }

        public DataTable GetInvoicesWithDetails2()
        {
            string query = @"
        SELECT 
            l.lasku_id, l.varaus_id, a.etunimi, a.sukunimi, m.mokkinimi, m.katuosoite, l.summa, l.alv, l.erapvm, l.maksettu
        FROM 
            vn.lasku l
        JOIN 
            vn.varaus v ON l.varaus_id = v.varaus_id
        JOIN 
            vn.asiakas a ON v.asiakas_id = a.asiakas_id
        JOIN 
            vn.mokki m ON v.mokki_mokki_id = m.mokki_id
        ORDER BY 
            l.lasku_id";
            return ExecuteQuery(query);
        }

        public DataTable GetInvoicesWithDetails()
        {
            string query = @"
            SELECT 
                l.lasku_id, 
                l.varaus_id, 
                a.etunimi, 
                a.sukunimi, 
                a.lahiosoite AS katuosoite, 
                a.postinro AS postinumero, 
                p.toimipaikka AS paikkakunta,
                a.email AS sahkoposti, 
                a.puhelinnro AS puhelinnumero,
                m.mokkinimi, 
                m.katuosoite AS mokin_katuosoite, 
                l.summa, 
                l.alv, 
                l.erapvm, 
                l.maksettu
            FROM 
                vn.lasku l
            JOIN 
                vn.varaus v ON l.varaus_id = v.varaus_id
            JOIN 
                vn.asiakas a ON v.asiakas_id = a.asiakas_id
            JOIN 
                vn.posti p ON a.postinro = p.postinro
            JOIN 
                vn.mokki m ON v.mokki_mokki_id = m.mokki_id
            ORDER BY 
                l.lasku_id;";
            return ExecuteQuery(query);
        }

        public DataTable GetUnpaidInvoices()
        {
            string query = @"
        SELECT 
            l.lasku_id, l.varaus_id, a.etunimi, a.sukunimi, m.mokkinimi, m.katuosoite, l.summa, l.alv, l.erapvm, l.maksettu
        FROM 
            vn.lasku l
        JOIN 
            vn.varaus v ON l.varaus_id = v.varaus_id
        JOIN 
            vn.asiakas a ON v.asiakas_id = a.asiakas_id
        JOIN 
            vn.mokki m ON v.mokki_mokki_id = m.mokki_id
        WHERE 
            l.maksettu = FALSE
        ORDER BY 
            l.lasku_id";
            return ExecuteQuery(query);
        }

        public DataTable GetPaidInvoices()
        {
            string query = @"
        SELECT 
            l.lasku_id, l.varaus_id, a.etunimi, a.sukunimi, m.mokkinimi, m.katuosoite, l.summa, l.alv, l.erapvm, l.maksettu
        FROM 
            vn.lasku l
        JOIN 
            vn.varaus v ON l.varaus_id = v.varaus_id
        JOIN 
            vn.asiakas a ON v.asiakas_id = a.asiakas_id
        JOIN 
            vn.mokki m ON v.mokki_mokki_id = m.mokki_id
        WHERE 
            l.maksettu = TRUE
        ORDER BY 
            l.lasku_id";
            return ExecuteQuery(query);
        }

        public DataTable GetOverdueUnpaidInvoices2()
        {
            string query = @"
        SELECT 
            l.lasku_id, l.varaus_id, a.etunimi, a.sukunimi, m.mokkinimi, m.katuosoite, l.summa, l.alv, l.erapvm, l.maksettu
        FROM 
            vn.lasku l
        JOIN 
            vn.varaus v ON l.varaus_id = v.varaus_id
        JOIN 
            vn.asiakas a ON v.asiakas_id = a.asiakas_id
        JOIN 
            vn.mokki m ON v.mokki_mokki_id = m.mokki_id
        WHERE 
            l.maksettu = FALSE AND l.erapvm < CURDATE()
        ORDER BY 
            l.lasku_id";
            return ExecuteQuery(query);
        }

        public DataTable GetOverdueUnpaidInvoices()
        {
            // Tämä kysely hakee kaikki maksamattomat laskut, joiden eräpäivä on mennyt umpeen suhteessa nykyiseen päivämäärään.
            string query = @"
    SELECT 
        l.lasku_id, 
        l.varaus_id, 
        a.etunimi, 
        a.sukunimi, 
        m.mokkinimi, 
        m.katuosoite, 
        l.summa, 
        l.alv, 
        l.erapvm, 
        l.maksettu
    FROM 
        vn.lasku l
    JOIN 
        vn.varaus v ON l.varaus_id = v.varaus_id
    JOIN 
        vn.asiakas a ON v.asiakas_id = a.asiakas_id
    JOIN 
        vn.mokki m ON v.mokki_mokki_id = m.mokki_id
    WHERE 
        l.maksettu = FALSE AND 
        l.erapvm < CURDATE()
    ORDER BY 
        l.lasku_id";
            return ExecuteQuery(query);
        }



        public void UpdateInvoicePaymentStatus2(int invoiceId, bool isPaid)
        {
            string query = "UPDATE vn.lasku SET maksettu = @isPaid WHERE lasku_id = @invoiceId;";
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                OdbcCommand command = new OdbcCommand(query, connection);
                command.Parameters.AddWithValue("@isPaid", isPaid);
                command.Parameters.AddWithValue("@invoiceId", invoiceId);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Virhe päivitettäessä laskun maksutilaa: " + ex.Message);
                }
            }
        }

        public void UpdateInvoicePaymentStatus(int invoiceId, bool isPaid)
        {
            string query = $"UPDATE lasku SET maksettu = {isPaid} WHERE lasku_id = {invoiceId}";
            ExecuteNonQuery(query);
        }



    }


}
