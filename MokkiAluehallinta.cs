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
using System.Linq;

namespace Group9_VillageNewbies
{
    public partial class MokkiAluehallinta : Form
    {
        List<AlueTieto> alueTiedot = new List<AlueTieto>();
        List<MokkiTieto> mokkiTiedot = new List<MokkiTieto>();
        List<Posti> postiTiedot = new List<Posti>();
        private bool btnAddAlueClicked = false;
        AlueTieto aluetieto2 = new AlueTieto();
        int iAlueIdTarkistus = 1;
        int iMokkiIdTarkistus = 1;
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
            /*foreach(MokkiTieto mokki in mokkiTiedot) //Tarkistetaan että mokki_id tulee kannasta
            {
                MessageBox.Show(mokki.Mokki_id);
            }*/
            ////////////////////////////////////////////////////////////////////////////////////
            foreach(AlueTieto al in alueTiedot)
            {
                iAlueIdTarkistus++;
            };
            foreach(MokkiTieto mok in mokkiTiedot)
            {
                iMokkiIdTarkistus++;
            }
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
                    Alue_id = row["alue_id"].ToString(),

                };
                alueTiedot.Add(alue);
               
            }
            alueTiedot.Sort((a, b) => string.Compare(a.Alue_id, b.Alue_id)); //Järjestetää listaan alue_id:n mukaisesti
        }
        private void PaivitaAlueLista()
        {
            listBoxAlue.Items.Clear(); // Tyhjennä listbox ennen uusien tietojen lisäämistä

            DatabaseRepository repository = new DatabaseRepository();
            List<Posti> postit = repository.HaeKaikkiPostit();
            int iTark = 1;
            foreach (var alue in alueTiedot)
            {
                
                string alueTieto = $"{alue.AlueNimi}" + "," + $"{alue.Alue_id}";
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
                    Mokki_id = row["mokki_id"].ToString(),
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
                string mok_id = $"{mokki.Mokki_id}";
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
        private void LisaaComboBoxinAlueet()
        {
            alueTiedot.Sort((a, b) => string.Compare(a.Alue_id, b.Alue_id));
            comboBoxAlue.Items.Add("Valitse mökkille tarkoitettu alue");
            foreach (AlueTieto alueTieto in alueTiedot)
            {
                comboBoxAlue.Items.Add(alueTieto.AlueNimi);
            }
        }
        private void PaivitaComboBox()
        {
            comboBoxAlue.Items.Clear();
            foreach (AlueTieto alueTieto in alueTiedot)
            {
                if(alueTieto.Alue_id == aluetieto2.Alue_id)
                {
                    foreach (AlueTieto alueInfo in alueTiedot)
                    {
                        
                        comboBoxAlue.Items.Add(alueInfo.AlueNimi);
                    }
                }
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
                AlueNimi = textBoxAlue.Text,
                Alue_id = iAlueIdTarkistus.ToString(),
               
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
            if (!string.IsNullOrEmpty(textBoxAlue.Text))
            {
                for (int i = 0; i < listBoxAlue.Items.Count; i++)
                {
                    string itemText = listBoxAlue.Items[i].ToString();
                    string[] parts = itemText.Split(',');
                    string alueid = parts[1].Trim();
                    string aluenimi = parts[0].Trim();
                    if (alueid == aluetieto2.Alue_id) //Tarkistetaan onko valittu alueid sama kuin listboxista aiemmin valittu alueid
                    {
                        if(aluenimi == textBoxAlue.Text) //Tarkistetaan onko valitulle aluetiedolle vaihdettu aluenimi vai ei
                        {
                            MessageBox.Show("Ei muutettavaa");
                        }
                        else
                        {
                            //Muutetaan aluetietokantaan
                            DatabaseRepository repository = new DatabaseRepository();
                            bool onnistui = repository.MuutaAlueTieto(new AlueTieto() { AlueNimi = textBoxAlue.Text, Alue_id = aluetieto2.Alue_id });
                            if (onnistui)
                            {
                                MessageBox.Show("Alue muutettu onnistuneesti.");

                            }
                            else
                            {
                                MessageBox.Show("Alueen muuttaminen epäonnistui.");
                            }
                            break; // Poistu silmukasta kun aluetieto on muutettu
                        } 
                    }
                }
                LataaAlueetKannasta();
                PaivitaAlueLista();
                PaivitaComboBox();
            }
            else
            {
                MessageBox.Show("Muokatakseni aluetietoja, valitse alue ensin listasta tekstikenttään ja vaihda sen nimeä");
            }
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
            txtBoxMokID.Clear();
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
                        uusiMokki.Mokki_id = iMokkiIdTarkistus.ToString();
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
                        uusiMokki.Mokki_id = iMokkiIdTarkistus.ToString();
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

        private void btnChangeMokki_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxMokID.Text))
            {
                foreach(MokkiTieto mokki in mokkiTiedot) //Tarkistetaan että mitä muutetaan
                {
                    if(mokki.Mokki_id == (txtBoxMokID.Text))
                    {
                        mokki.Alue = comboBoxAlue.SelectedIndex.ToString();
                        mokki.Postinro = txtBoxMokPostinro.Text;
                        mokki.Mokkinimi = txtBoxMokNimi.Text;
                        mokki.Katuosoite = txtBoxMokOsoite.Text;
                        mokki.Hinta = txtBoxMokHinta.Text;
                        mokki.Kuvaus = txtBoxMokKuvaus.Text;
                        mokki.Henkilomaara = txtBoxMokMaara.Text;
                        mokki.Varustelu = txtBoxMokVarust.Text;

                        DatabaseRepository repository = new DatabaseRepository();
                        repository.MuutaMokkiTieto(mokki);
                        /*
                        {
                            MessageBox.Show("Mökin tiedot muutettu onnistuneesti.");
                        }
                        else
                        {
                            MessageBox.Show("Mökin tietojen muuttaminen epäonnistui.");
                        }*/
                        //LataaMokitKannasta();
                        //PaivitaMokkiLista();

                        
                    }
                }
                LataaMokitKannasta();
                PaivitaMokkiLista();
            }
            else
            {
                MessageBox.Show("Muokataksesi mökkitietoja, valitse mökki ensin listasta tekstikenttään.");
            }
        }

        private void btnDeleteMokki_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxMokID.Text))
            {
                string poistettavaMokki = txtBoxMokID.Text;

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
                AlueTieto alueTieto2 = new AlueTieto();
                var tiedot = listBoxAlue.SelectedItem.ToString().Split(','); // Jakaa valitun kohteen sanallisesti
                string alue = tiedot[0]; // Alueen nimi
                textBoxAlue.Text = alue;

                for (int i = 0; i < alueTiedot.Count; i++)
                {
                    if (alue == alueTiedot[i].ToString())
                    {
                        alueTieto2 = alueTiedot[i];
                        break;
                    }
                }
                aluetieto2.Alue_id = alueTieto2.Alue_id;
                aluetieto2.AlueNimi = alueTieto2.AlueNimi;
                //MessageBox.Show("Alueen nimi: " + aluetieto2.AlueNimi + "\n" + "Alueen id: " + aluetieto2.Alue_id);
                


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
                        txtBoxMokID.Text = $"{mokki.Mokki_id}";
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
            if(comboBoxAlue.SelectedIndex == 0)
            {
                MessageBox.Show("Valitse alue");
            }

        }

        private void MokkiAluehallinta_Load(object sender, EventArgs e)
        {

        }
    }
}
