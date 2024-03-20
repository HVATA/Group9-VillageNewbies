using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Group9_VillageNewbies
{
    public partial class MokkiAluehallinta : Form
    {
        List<AlueTieto> alueTiedot = new List<AlueTieto>();
        List<MokkiTieto> mokkiTiedot = new List<MokkiTieto>();
        List<Posti> postiTiedot = new List<Posti>();
        private bool btnAddAlueClicked = false;
        public MokkiAluehallinta()
        {
            InitializeComponent();
            LataaAlueetKannasta();
            DatabaseRepository repository = new DatabaseRepository();
            postiTiedot = repository.HaeKaikkiPostit();
            PaivitaAlueLista();
            LataaMokitKannasta();
            PaivitaMokkiLista();
            LisaaComboBoxinAlueet();
        }
        private void LataaAlueetKannasta()//Haetaan alueet kannasta
        {

            alueTiedot.Clear(); // Tyhjennä lista varmuuden vuoksi
            DatabaseRepository repository = new DatabaseRepository();
            DataTable alueTable = repository.ExecuteQuery(@"SELECT * FROM alue");

            foreach (DataRow row in alueTable.Rows)
            {
                AlueTieto alue = new AlueTieto()
                {
                    // Aseta tiedot row:sta
                    AlueNimi = row["nimi"].ToString(),

                };
                alueTiedot.Add(alue);
            }
        }
        /*
        private void PoistaAlueListasta()
        {
            foreach (AlueTieto alueTieto in alueTiedot)
            {
                if(alueTieto.AlueNimi == textBoxAlue.Text)
                {
                    alueTiedot.Remove(alueTieto);
                }
            }
        }*/
        private void PaivitaAlueLista()
        {
            listBoxAlue.Items.Clear(); // Tyhjennä listbox ennen uusien tietojen lisäämistä

            DatabaseRepository repository = new DatabaseRepository();
            List<Posti> postit = repository.HaeKaikkiPostit();

            foreach (var alue in alueTiedot)
            {

                string alueTieto = $"{alue.AlueNimi}";
                listBoxAlue.Items.Add(alueTieto);

            }
        }
        private void LataaMokitKannasta()//Haetaan alueet kannasta
        {

            mokkiTiedot.Clear(); // Tyhjennä lista varmuuden vuoksi
            DatabaseRepository repository = new DatabaseRepository();
            DataTable mokkiTable = repository.ExecuteQuery(@"SELECT mokki.*, alue.nimi AS alueen_nimi
                                                                FROM mokki
                                                            JOIN alue ON mokki.alue_id = alue.alue_id");

            foreach (DataRow row in mokkiTable.Rows)
            {
                MokkiTieto mokki = new MokkiTieto()
                {
                    // Aseta tiedot row:sta
                    Alue = row["alueen_nimi"].ToString(),
                    Postinro = row["postinro"].ToString(),
                    Mokkinimi = row["mokkinimi"].ToString(),
                    Katuosoite = row["katuosoite"].ToString(),
                    Hinta = row["hinta"].ToString(),
                    Kuvaus = row["kuvaus"].ToString(),
                    Henkilomaara = row["henkilomaara"].ToString(),
                    Varustelu = row["varustelu"].ToString()

                };
                mokkiTiedot.Add(mokki);
            }
        }
        private void PaivitaMokkiLista()//Lisätää haetut alueet listaan
        {
            listBoxMokki.Items.Clear(); // Tyhjennä listbox ennen uusien tietojen lisäämistä

            // Käydään läpi asiakasTiedot-lista ja lisätään jokainen asiakas ListBoxiin
            foreach (var mokki in mokkiTiedot)
            {
                // Muodosta merkkijono, jossa on asiakkaan tiedot ja lisää se ListBoxiin
                string mok_alue = $"{mokki.Alue}";
                string mok_postinro = $"{mokki.Postinro}";
                string mok_mokkinimi = $"{mokki.Mokkinimi}";
                string mok_katuosoite = $"{mokki.Katuosoite}";
                string mok_hinta = $"{mokki.Hinta}";
                string mok_kuvaus = $"{mokki.Kuvaus}";
                string mok_henkilomaara = $"{mokki.Henkilomaara}";
                string mok_varustelu = $"{mokki.Varustelu}";
                listBoxMokki.Items.Add(mokki);
            }
        }

        private void btnClearAlue_Click(object sender, EventArgs e)
        {
            // Tyhjennä kaikki tekstikentät
            textBoxAlue.Clear();
        }

        private void btnAddAlue_Click(object sender, EventArgs e)
        {
            btnAddAlueClicked = true; //apuvälineenä aluecomboxiin tiedon välityksessä
            AlueTieto uusiAlue = new AlueTieto()
            {
                AlueNimi = textBoxAlue.Text
            };

            DatabaseRepository repository = new DatabaseRepository();
            bool onnistui = repository.LisaaAlue(uusiAlue);
            if (onnistui)
            {
                MessageBox.Show("Alue lisätty onnistuneesti.");
            }
            else
            {
                MessageBox.Show("Alueen lisäys epäonnistui.");
            }
            LataaAlueetKannasta();
            PaivitaAlueLista(); // Päivitä listboxin tiedot lisäyksen jälkeen
            LisaaUusiAlueComboBoxiin();
        }

        private void btnChangeAlue_Click(object sender, EventArgs e)//jää pohtimaan
        {

        }

        private void BtnDeleteAlue_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxAlue.Text))
            {
                string poistettavaAlue = textBoxAlue.Text;

                // Käydään läpi ListBoxin elementit indeksien avulla
                for (int i = 0; i < listBoxAlue.Items.Count; i++)
                {
                    string alue = listBoxAlue.Items[i].ToString();
                    if (alue == poistettavaAlue)
                    {

                        // Poista alue myös tietokannasta
                        DatabaseRepository repository = new DatabaseRepository();
                        bool onnistui = repository.PoistaAlue(new AlueTieto() { AlueNimi = textBoxAlue.Text }); //&& repository.PoistaPosti(new Posti(textBoxPostinro.ToString(), textBoxAlue.ToString()));//
                        if (onnistui)
                        {
                            MessageBox.Show("Alue poistettu onnistuneesti.");
                            // Poista elementti ListBoxista
                            listBoxAlue.Items.RemoveAt(i);
                            comboBoxAlue.Items.RemoveAt(i);
                        }
                        else
                        {
                            MessageBox.Show("Alueen poistaminen epäonnistui.");
                        }
                        break; // Poistu silmukasta kun alue on poistettu


                    }
                }
                for (int i = 0; i < comboBoxAlue.Items.Count; i++)
                {
                    string alue = comboBoxAlue.Items[i].ToString();
                    if (alue == textBoxAlue.Text)
                    {
                        // Poista elementti ListBoxista


                        // Poista alue myös tietokannasta
                        DatabaseRepository repository = new DatabaseRepository();
                        bool onnistui = repository.PoistaAlue(new AlueTieto() { AlueNimi = textBoxAlue.Text });
                        break; // Poistu silmukasta kun alue on poistettu
                    }
                }

                // Päivitä ListBoxin näyttö
                textBoxAlue.Clear();
                LataaAlueetKannasta();
                PaivitaAlueLista();

            }
            else
            {
                MessageBox.Show("Kirjoita alue, joka haluat poistaa.");
            }
        }

        private void btnClearMokki_Click(object sender, EventArgs e)//tyhjentää mökkitietojen kentät
        {
            txtBoxMokHinta.Clear();
            txtBoxMokKuvaus.Clear();
            txtBoxMokMaara.Clear();
            txtBoxMokNimi.Clear();
            txtBoxMokOsoite.Clear();
            txtBoxMokPostinro.Clear();
            txtBoxMokVarust.Clear();
        }

        private void btnAddMokki_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach(Posti posti in postiTiedot)
            {
                if(i < 1)
                {
                    if (posti.Postinro == txtBoxMokPostinro.Text)
                    {
                        MokkiTieto uusiMokki = new MokkiTieto();
                        uusiMokki.Postinro = txtBoxMokPostinro.Text;
                        uusiMokki.Mokkinimi = txtBoxMokNimi.Text;
                        uusiMokki.Katuosoite = txtBoxMokOsoite.Text;
                        uusiMokki.Alue = comboBoxAlue.SelectedIndex.ToString();
                        uusiMokki.Varustelu = txtBoxMokVarust.Text;
                        uusiMokki.Kuvaus = txtBoxMokKuvaus.Text;
                        uusiMokki.Hinta = txtBoxMokHinta.Text;
                        uusiMokki.Henkilomaara = txtBoxMokMaara.Text;

                        DatabaseRepository repository = new DatabaseRepository();
                        bool onnistui = repository.LisaaMokki(uusiMokki);
                        if (onnistui)
                        {
                            MessageBox.Show("Mökki lisätty onnistuneesti.");
                        }
                        else
                        {
                            MessageBox.Show("Mökin lisäys epäonnistui.");
                        }
                        LataaMokitKannasta();
                        PaivitaMokkiLista();
                        i++;
                    }
                    else
                    {
                        Posti uusiPosti = new Posti();
                        uusiPosti.Postinro = txtBoxMokPostinro.Text;
                        uusiPosti.Toimipaikka = comboBoxAlue.Text;
                        DatabaseRepository repository = new DatabaseRepository();
                        repository.LisaaPosti(uusiPosti);

                        MokkiTieto uusiMokki = new MokkiTieto();
                        uusiMokki.Postinro = txtBoxMokPostinro.Text;
                        uusiMokki.Mokkinimi = txtBoxMokNimi.Text;
                        uusiMokki.Katuosoite = txtBoxMokOsoite.Text;
                        uusiMokki.Alue = comboBoxAlue.SelectedIndex.ToString();
                        uusiMokki.Varustelu = txtBoxMokVarust.Text;
                        uusiMokki.Kuvaus = txtBoxMokKuvaus.Text;
                        uusiMokki.Hinta = txtBoxMokHinta.Text;
                        uusiMokki.Henkilomaara = txtBoxMokMaara.Text;

                        bool onnistui = repository.LisaaMokki(uusiMokki);
                        if (onnistui)
                        {
                            MessageBox.Show("Mökki lisätty onnistuneesti.");
                        }
                        else
                        {
                            MessageBox.Show("Mökin lisäys epäonnistui.");
                        }
                        LataaMokitKannasta();
                        PaivitaMokkiLista();
                        i++;
                    }
                }
                
            }
            
        }

        private void btnChangeMokki_Click(object sender, EventArgs e)//en tiiä tarviiko sinänsä
        {

        }

        private void btnDeleteMokki_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxMokNimi.Text))
            {
                string poistettavaMokki = txtBoxMokNimi.Text;

                // Poista alue myös tietokannasta
                DatabaseRepository repository = new DatabaseRepository();
                bool onnistui = repository.PoistaMokki(new MokkiTieto() { Mokkinimi = poistettavaMokki });

                // Tulosta viesti riippuen siitä, onnistuiko poistaminen
                if (onnistui)
                {
                    MessageBox.Show("Mökki poistettu onnistuneesti.");
                }
                else
                {
                    MessageBox.Show("Mökin poistaminen epäonnistui.");
                }

                // Päivitä ListBoxin näyttö
                LataaMokitKannasta();
                PaivitaMokkiLista();
            }
            else
            {
                MessageBox.Show("Kirjoita alue, joka haluat poistaa.");
            }
        }

        private void btnPalveluihin_Click(object sender, EventArgs e)
        {
            Palveluhallinta pavela = new Palveluhallinta();
            pavela.ShowDialog();
        }

        private void listBoxAlue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAlue.SelectedIndex != -1)
            {
                var tiedot = listBoxAlue.SelectedItem.ToString().Split(','); // Jakaa valitun kohteen sanallisesti
                string alue = tiedot[0]; // Alueen nimi
                string postinro = tiedot[1]; // Postinumero

                textBoxAlue.Text = alue;
            }
        }

        private void listBoxMokki_SelectedIndexChanged(object sender, EventArgs e)//Valitaan mitkä tiedot tuodaan lomakkeelle
        {

            var selectedMokki = listBoxMokki.SelectedItem.ToString();

            if (listBoxMokki.SelectedIndex != -1)
            {
                foreach (var mokki in mokkiTiedot)
                {
                    if (mokki.Mokkinimi == selectedMokki)
                    {
                        comboBoxAlue.Text = $"{mokki.Alue}";
                        txtBoxMokPostinro.Text = $"{mokki.Postinro}";
                        txtBoxMokNimi.Text = $"{mokki.Mokkinimi}";
                        txtBoxMokOsoite.Text = $"{mokki.Katuosoite}";
                        txtBoxMokHinta.Text = $"{mokki.Hinta}";
                        txtBoxMokKuvaus.Text = $"{mokki.Kuvaus}";
                        txtBoxMokMaara.Text = $"{mokki.Henkilomaara}";
                        txtBoxMokVarust.Text = $"{mokki.Varustelu}";

                        // Kun löydetään haluttu mökki, poistutaan foreach-silmukasta
                        break;
                    }
                }
            }
        }
        private void LisaaComboBoxinAlueet()
        {
            foreach (AlueTieto alueTieto in alueTiedot)
            {
                comboBoxAlue.Items.Add(alueTieto.AlueNimi);
            }
        }
        private void LisaaUusiAlueComboBoxiin()
        {

            foreach (var alue in alueTiedot)
            {
                if (alue.AlueNimi == textBoxAlue.Text && btnAddAlueClicked)
                {
                    string alueTieto = $"{alue.AlueNimi}";
                    comboBoxAlue.Items.Add(alueTieto);
                }
            }
        }
        private void comboBoxAlue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
