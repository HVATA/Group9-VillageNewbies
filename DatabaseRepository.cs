﻿using System;
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
        public bool LisaaVarauksenPalvelu(Varauksen_palvelut varPal)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO varauksen_palvelut (varaus_id, palvelu_id, lkm) VALUES (?, ?, ?)";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("varaus_id", varPal.Varaus_id);
                        command.Parameters.AddWithValue("palvelu_id", varPal.Palvelu_id);
                        command.Parameters.AddWithValue("lkm", varPal.Lkm);

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
        public void MuutaVarauksenPalvelut(Varauksen_palvelut varpa)
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
                UPDATE varauksen_palvelut
                SET
                    palvelu_id = ?,
                    lkm = ?
                WHERE varaus_id = ?";

                        // Lisää parametrit ODBC:n tapaan käyttäen kysymysmerkkejä ja sijoittamalla arvot järjestyksessä
                        command.Parameters.Add(new OdbcParameter("palvelu_id", varpa.Palvelu_id));
                        command.Parameters.Add(new OdbcParameter("lkm", varpa.Lkm));
                        command.Parameters.Add(new OdbcParameter("varaus_id", varpa.Varaus_id));

                        command.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Virhe tietokantaa muutettaessa: {ex.Message}");
                }
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
        public bool PoistaVarauksenPalvelu(Varauksen_palvelut varauspal)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    string query = "DELETE FROM varauksen_palvelut WHERE varaus_id = ? AND palvelu_id = ? AND lkm = ?";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("varaus_id", varauspal.Varaus_id);
                        command.Parameters.AddWithValue("palvelu_id", varauspal.Palvelu_id);
                        command.Parameters.AddWithValue("lkm", varauspal.Lkm);
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



        public void UpdateInvoicePaymentStatus(int invoiceId, bool isPaid)
        {
            string query = $"UPDATE lasku SET maksettu = {isPaid} WHERE lasku_id = {invoiceId}";
            ExecuteNonQuery(query);
        }

        public DataTable GetReservationDetails()
        {
            string query = @"
        SELECT 
            v.varaus_id, 
            CONCAT(a.etunimi, ' ', a.sukunimi) AS asiakas_nimi,
            m.mokkinimi, 
            v.varattu_pvm, 
            v.vahvistus_pvm, 
            v.varattu_alkupvm, 
            v.varattu_loppupvm
        FROM 
            varaus v
        JOIN 
            asiakas a ON v.asiakas_id = a.asiakas_id
        JOIN 
            mokki m ON v.mokki_mokki_id = m.mokki_id
        ORDER BY 
            v.varattu_pvm ASC;";

            return ExecuteQuery(query);
        }

        public DataTable HaePalvelutAlueittain()
        {
            string query = @"
        public DataTable GetReservationDetails()
        {
            string query = @""
        SELECT 
            v.varaus_id, 
            CONCAT(a.etunimi, ' ', a.sukunimi) AS asiakas_nimi,
            m.mokkinimi, 
            v.varattu_pvm, 
            v.vahvistus_pvm, 
            v.varattu_alkupvm, 
            v.varattu_loppupvm
        FROM 
            varaus v
        JOIN 
            asiakas a ON v.asiakas_id = a.asiakas_id
        JOIN 
            mokki m ON v.mokki_mokki_id = m.mokki_id
        ORDER BY 
            v.varattu_pvm ASC;"";

            return ExecuteQuery(query);
        }";

            return ExecuteQuery(query);
        }



        public void PoistaLasku(int varausid)
        {
            string query = $"DELETE FROM lasku WHERE lasku_id = {varausid}";
            ExecuteNonQuery(query);
        }
        public bool PoistaLasku2(Lasku lasku)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    string query = "DELETE FROM lasku WHERE lasku_id = ?";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("lasku_id", lasku.LaskuId);
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

        public void PaivitaLasku(int varausId, double summa, double alv)
        {
            string query = $"UPDATE lasku SET summa = {summa}, alv = {alv} WHERE varaus_id = {varausId}";
            ExecuteNonQuery(query);
        }

        public void LisaaUusiLasku(int varausId, int asiakasId, double summa, double alv)
        {
            string query = $"INSERT INTO lasku (varaus_id, asiakas_id, summa, alv) VALUES ({varausId}, {asiakasId}, {summa}, {alv})";
            ExecuteNonQuery(query);
        }


        public DataTable HaePalvelutAlueeltaJaAjalta(int alueId, DateTime aloitusPvm, DateTime lopetusPvm)
        {
            DataTable dataTable = new DataTable();
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                // Muodosta SQL-kysely käyttäen parametreja
                string query = @"
            SELECT 
                a.nimi AS AlueNimi,
                m.mokkinimi AS MokkiNimi,
                p.nimi AS PalveluNimi,
                vp.lkm AS PalvelunMaara,
                v.varattu_alkupvm,
                v.varattu_loppupvm
            FROM varaus v
            JOIN mokki m ON v.mokki_mokki_id = m.mokki_id
            JOIN alue a ON m.alue_id = a.alue_id
            JOIN varauksen_palvelut vp ON v.varaus_id = vp.varaus_id
            JOIN palvelu p ON vp.palvelu_id = p.palvelu_id
            WHERE 
                a.alue_id = ?
                AND v.varattu_alkupvm >= ?
                AND v.varattu_loppupvm <= ?
            ORDER BY v.varattu_alkupvm, p.nimi;";

                using (OdbcCommand command = new OdbcCommand(query, connection))
                {
                    // Aseta SQL-kyselyn parametrit
                    command.Parameters.AddWithValue("alue_id", alueId);
                    command.Parameters.AddWithValue("varattu_alkupvm", aloitusPvm.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("varattu_loppupvm", lopetusPvm.ToString("yyyy-MM-dd"));

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
            }
            return dataTable;
        }









    }


}
