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
        private bool btnAddAlueClicked = false;
        private bool btnDeleteAlueClicked = false;
        public MokkiAluehallinta()
        {
            InitializeComponent();
            LataaAlueetKannasta();
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
        private void PaivitaAlueLista()//Lisätää haetut alueet listaan
        {
            listBoxAlue.Items.Clear(); // Tyhjennä listbox ennen uusien tietojen lisäämistä

            // Käydään läpi alueTiedot-lista ja alue ListBoxiin
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
            DataTable mokkiTable = repository.ExecuteQuery(@"SELECT * FROM mokki");

            foreach (DataRow row in mokkiTable.Rows)
            {
                MokkiTieto mokki = new MokkiTieto()
                {
                    // Aseta tiedot row:sta
                    Alue = row["alue_id"].ToString() ,
                    Postinro = row["postinro"].ToString() ,
                    Mokkinimi = row["mokkinimi"].ToString() ,
                    Katuosoite = row["katuosoite"].ToString() ,
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
            btnAddAlueClicked = true;
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
            btnDeleteAlueClicked = true;
            if (!string.IsNullOrEmpty(textBoxAlue.Text))
            {
                string poistettavaAlue = textBoxAlue.Text;

                // Käydään läpi ListBoxin elementit indeksien avulla
                for (int i = 0; i < listBoxAlue.Items.Count; i++)
                {
                    string alue = listBoxAlue.Items[i].ToString();
                    if (alue == poistettavaAlue)
                    {
                        // Poista elementti ListBoxista
                        listBoxAlue.Items.RemoveAt(i);

                        // Poista alue myös tietokannasta
                        DatabaseRepository repository = new DatabaseRepository();
                        bool onnistui = repository.PoistaAlue(new AlueTieto() { AlueNimi = poistettavaAlue });
                        if (onnistui)
                        {
                            MessageBox.Show("Alue poistettu onnistuneesti.");
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
                    if (alue == poistettavaAlue)
                    {
                        // Poista elementti ListBoxista
                        comboBoxAlue.Items.RemoveAt(i);

                        // Poista alue myös tietokannasta
                        DatabaseRepository repository = new DatabaseRepository();
                        bool onnistui = repository.PoistaAlue(new AlueTieto() { AlueNimi = poistettavaAlue });
                        if (onnistui)
                        {
                            MessageBox.Show("Alue poistettu onnistuneesti.");
                        }
                        else
                        {
                            MessageBox.Show("Alueen poistaminen epäonnistui.");
                        }
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

        private void btnClearMokki_Click(object sender, EventArgs e)
        {

        }

        private void btnAddMokki_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeMokki_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteMokki_Click(object sender, EventArgs e)
        {

        }

        private void btnPalveluihin_Click(object sender, EventArgs e)
        {
            Palveluhallinta pavela = new Palveluhallinta();
            pavela.ShowDialog();
        }

        private void listBoxAlue_SelectedIndexChanged(object sender, EventArgs e)//asetetaan listboxista tieto textboxiin.
        {
            if (listBoxAlue.SelectedIndex != -1)
            {
                var tiedot = listBoxAlue.SelectedItem.ToString();
                textBoxAlue.Text = tiedot;
            }
        }

        private void listBoxMokki_SelectedIndexChanged(object sender, EventArgs e)//Valitaan mitkä tiedot tuodaan lomakkeelle
        {
            var tieto = listBoxMokki.SelectedItem.ToString();
            if (listBoxMokki.SelectedIndex != -1)
            {
                if (tieto == "Rukan Mökki") //RUKAN MÖKKI
                { 
                    foreach(var mokki in mokkiTiedot)
                    {
                        if(mokki.Mokkinimi == "Rukan Mökki")
                        {
                            comboBoxAlue.Text = $"{mokki.Alue}";
                            txtBoxMokPostinro.Text = $"{mokki.Postinro}";
                            txtBoxMokNimi.Text = $"{mokki.Mokkinimi}";
                            txtBoxMokOsoite.Text = $"{mokki.Katuosoite}";
                            txtBoxMokHinta.Text = $"{mokki.Hinta}";
                            txtBoxMokKuvaus.Text = $"{mokki.Kuvaus}";
                            txtBoxMokMaara.Text = $"{mokki.Henkilomaara}";
                            txtBoxMokVarust.Text = $"{mokki.Varustelu}";
                        }
                    }
                }
                else if (tieto =="Tahkon Tupa") //TAHKON TUPA
                {
                    foreach (var mokki in mokkiTiedot)
                    {
                        if (mokki.Mokkinimi == "Tahkon Tupa")
                        {
                            comboBoxAlue.Text = $"{mokki.Alue}";
                            txtBoxMokPostinro.Text = $"{mokki.Postinro}";
                            txtBoxMokNimi.Text = $"{mokki.Mokkinimi}";
                            txtBoxMokOsoite.Text = $"{mokki.Katuosoite}";
                            txtBoxMokHinta.Text = $"{mokki.Hinta}";
                            txtBoxMokKuvaus.Text = $"{mokki.Kuvaus}";
                            txtBoxMokMaara.Text = $"{mokki.Henkilomaara}";
                            txtBoxMokVarust.Text = $"{mokki.Varustelu}";
                        }
                    }
                }
                else if (tieto == "Ylläksen Yöpuu")//YLLÄKSEN YÖPUU
                {
                    foreach (var mokki in mokkiTiedot)
                    {
                        if (mokki.Mokkinimi == "Ylläksen Yöpuu")
                        {
                            comboBoxAlue.Text = $"{mokki.Alue}";
                            txtBoxMokPostinro.Text = $"{mokki.Postinro}";
                            txtBoxMokNimi.Text = $"{mokki.Mokkinimi}";
                            txtBoxMokOsoite.Text = $"{mokki.Katuosoite}";
                            txtBoxMokHinta.Text = $"{mokki.Hinta}";
                            txtBoxMokKuvaus.Text = $"{mokki.Kuvaus}";
                            txtBoxMokMaara.Text = $"{mokki.Henkilomaara}";
                            txtBoxMokVarust.Text = $"{mokki.Varustelu}";
                        }
                    }
                }
                else if (tieto == "Saariselän Sviitti")//SAARISELÄN SVIITTI
                {
                    foreach (var mokki in mokkiTiedot)
                    {
                        if (mokki.Mokkinimi == "Saariselän Sviitti")
                        {
                            comboBoxAlue.Text = $"{mokki.Alue}";
                            txtBoxMokPostinro.Text = $"{mokki.Postinro}";
                            txtBoxMokNimi.Text = $"{mokki.Mokkinimi}";
                            txtBoxMokOsoite.Text = $"{mokki.Katuosoite}";
                            txtBoxMokHinta.Text = $"{mokki.Hinta}";
                            txtBoxMokKuvaus.Text = $"{mokki.Kuvaus}";
                            txtBoxMokMaara.Text = $"{mokki.Henkilomaara}";
                            txtBoxMokVarust.Text = $"{mokki.Varustelu}";
                        }
                    }
                }
                else if (tieto == "Levin Lumo")//LEVIN LUMO
                {
                    foreach (var mokki in mokkiTiedot)
                    {
                        if (mokki.Mokkinimi == "Levin Lumo")
                        {
                            comboBoxAlue.Text = $"{mokki.Alue}";
                            txtBoxMokPostinro.Text = $"{mokki.Postinro}";
                            txtBoxMokNimi.Text = $"{mokki.Mokkinimi}";
                            txtBoxMokOsoite.Text = $"{mokki.Katuosoite}";
                            txtBoxMokHinta.Text = $"{mokki.Hinta}";
                            txtBoxMokKuvaus.Text = $"{mokki.Kuvaus}";
                            txtBoxMokMaara.Text = $"{mokki.Henkilomaara}";
                            txtBoxMokVarust.Text = $"{mokki.Varustelu}";
                        }
                    }
                }
                else if (tieto == "Pyhän Piilo")//PYHÄN PIILO
                {
                    foreach (var mokki in mokkiTiedot)
                    {
                        if (mokki.Mokkinimi == "Pyhän Piilo")
                        {
                            comboBoxAlue.Text = $"{mokki.Alue}";
                            txtBoxMokPostinro.Text = $"{mokki.Postinro}";
                            txtBoxMokNimi.Text = $"{mokki.Mokkinimi}";
                            txtBoxMokOsoite.Text = $"{mokki.Katuosoite}";
                            txtBoxMokHinta.Text = $"{mokki.Hinta}";
                            txtBoxMokKuvaus.Text = $"{mokki.Kuvaus}";
                            txtBoxMokMaara.Text = $"{mokki.Henkilomaara}";
                            txtBoxMokVarust.Text = $"{mokki.Varustelu}";
                        }
                    }

                }
                else if (tieto == "Himos Huvila")//HIMOS HUVILA
                {
                    foreach (var mokki in mokkiTiedot)
                    {
                        if (mokki.Mokkinimi == "Himos Huvila")
                        {
                            comboBoxAlue.Text = $"{mokki.Alue}";
                            txtBoxMokPostinro.Text = $"{mokki.Postinro}";
                            txtBoxMokNimi.Text = $"{mokki.Mokkinimi}";
                            txtBoxMokOsoite.Text = $"{mokki.Katuosoite}";
                            txtBoxMokHinta.Text = $"{mokki.Hinta}";
                            txtBoxMokKuvaus.Text = $"{mokki.Kuvaus}";
                            txtBoxMokMaara.Text = $"{mokki.Henkilomaara}";
                            txtBoxMokVarust.Text = $"{mokki.Varustelu}";
                        }
                    }
                }
                else if (tieto == "Sallan Salaisuus")//SALLAN SALAISUUS
                {
                    foreach (var mokki in mokkiTiedot)
                    {
                        if (mokki.Mokkinimi == "Sallan Salaisuus")
                        {
                            comboBoxAlue.Text = $"{mokki.Alue}";
                            txtBoxMokPostinro.Text = $"{mokki.Postinro}";
                            txtBoxMokNimi.Text = $"{mokki.Mokkinimi}";
                            txtBoxMokOsoite.Text = $"{mokki.Katuosoite}";
                            txtBoxMokHinta.Text = $"{mokki.Hinta}";
                            txtBoxMokKuvaus.Text = $"{mokki.Kuvaus}";
                            txtBoxMokMaara.Text = $"{mokki.Henkilomaara}";
                            txtBoxMokVarust.Text = $"{mokki.Varustelu}";
                        }
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
                if(alue.AlueNimi == textBoxAlue.Text && btnAddAlueClicked)
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
