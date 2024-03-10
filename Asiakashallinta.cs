using Group9_VillageNewbies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Group9_VillageNewbies

{
    public partial class Asiakashallinta : Form
    {
        List<AsiakasTieto> asiakasTiedot = new List<AsiakasTieto>();

        public Asiakashallinta()

        {
            InitializeComponent(); // Alusta komponentit
            LataaPaikkakunnat(); // Lataa paikkakunnat ComboBoxiin
            LataaAsiakkaatTietokannasta(); // Lataa asiakastiedot tietokannasta
            PaivitaAsiakasLista(); // Päivitä listboxin tiedot
            dataGridView1.DataSource = asiakasTiedot; // Aseta asiakasTiedot lista DataSourceksi
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        // Metodi, joka päivittää ListBoxin asiakastiedot tietokannasta
        private void PaivitaAsiakasLista()
        {
            listBox1.Items.Clear(); // Tyhjennä listbox ennen uusien tietojen lisäämistä

            // Käydään läpi asiakasTiedot-lista ja lisätään jokainen asiakas ListBoxiin
            foreach (var asiakas in asiakasTiedot)
            {
                // Muodosta merkkijono, jossa on asiakkaan tiedot ja lisää se ListBoxiin
                string asiakasTieto = $"{asiakas.Etunimi} {asiakas.Sukunimi}, {asiakas.Lahiosoite}, {asiakas.Postinro} {asiakas.Toimipaikka}, {asiakas.Puhelinnro}, {asiakas.Email}";
                listBox1.Items.Add(asiakasTieto);
            }
        }


        private void LataaAsiakkaatTietokannasta()
        {
            DatabaseRepository repository = new DatabaseRepository();
            asiakasTiedot.Clear(); // Tyhjennä lista varmuuden vuoksi
            DataTable asiakkaatTable = repository.ExecuteQuery(@"SELECT a.etunimi, a.sukunimi, a.lahiosoite, a.postinro, p.toimipaikka, a.puhelinnro, a.email FROM asiakas a JOIN posti p ON a.postinro = p.postinro");

            foreach (DataRow row in asiakkaatTable.Rows)
            {
                AsiakasTieto asiakas = new AsiakasTieto()
                {
                    // Aseta tiedot row:sta
                    Etunimi = row["etunimi"].ToString(),
                    Sukunimi = row["sukunimi"].ToString(),
                    Lahiosoite = row["lahiosoite"].ToString(),
                    Postinro = row["postinro"].ToString(),
                    Toimipaikka = row["toimipaikka"].ToString(),
                    Puhelinnro = row["puhelinnro"].ToString(),
                    Email = row["email"].ToString(),

                };
                asiakasTiedot.Add(asiakas);
            }
        }

        private void LataaAsiakkaatDataGridViewiin()
        {
            // Oletetaan, että dataGridView1 on DataGridView-komponenttisi nimi
            dataGridView1.AutoGenerateColumns = true; // Luo sarakkeet automaattisesti
            dataGridView1.DataSource = null; // Tyhjennä vanhat tiedot
            dataGridView1.DataSource = asiakasTiedot; // Aseta asiakasTiedot lista DataSourceksi
            //tekstiä dataGridView1:n otsikkoriviin
            dataGridView1.Columns[0].HeaderText = "Etunimi";
            dataGridView1.Columns[1].HeaderText = "Sukunimi";
            dataGridView1.Columns[2].HeaderText = "Lähiosoite";
            //lisää tekstiä dataGridView1:n kenttiin
            dataGridView1.Columns[0].DataPropertyName = "Etunimi";
            dataGridView1.Columns[1].DataPropertyName = "Sukunimi";
            dataGridView1.Columns[2].DataPropertyName = "Lahiosoite";
        }


        // Metodi joka suoritetaan kun käyttäjä valitsee jonkun asiakkaan ListBoxista
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var tiedot = listBox1.SelectedItem.ToString().Split(',');
                if (tiedot.Length >= 5) // Varmista, että kaikki kentät ovat läsnä
                {
                    // Erota nimet (oletetaan, että ne ovat ensimmäisessä kentässä ja erotettu pilkuilla)
                    var nimet = tiedot[0].Trim().Split(' ');
                    if (nimet.Length > 2)
                    {
                        textBox1.Text = string.Join(" ", nimet.Take(nimet.Length - 1)); // Etunimet
                        textBox2.Text = nimet.Last(); // Sukunimi
                    }
                    else if (nimet.Length == 2)
                    {
                        textBox1.Text = nimet[0]; // Etunimi
                        textBox2.Text = nimet[1]; // Sukunimi
                    }

                    textBox3.Text = tiedot[1].Trim(); // Osoite (sisältää talonumeron)

                    // Erota postinumero ja paikkakunta (oletetaan, että ne ovat kolmannessa kentässä)
                    var postiJaPaikka = tiedot[2].Trim().Split(' ');
                    if (postiJaPaikka.Length >= 2)
                    {
                        textBox4.Text = postiJaPaikka[0]; // Postinumero
                        //textBox5.Text = string.Join(" ", postiJaPaikka.Skip(1)); // Paikkakunta
                    }

                    textBox6.Text = tiedot[3].Trim(); // Puhelinnumero
                    textBox7.Text = tiedot[4].Trim(); // Sähköpostiosoite

                    // Aseta ComboBoxin valinta vastaamaan paikkakuntaa
                    string paikkakuntaValinta = tiedot[2].Trim().Split(' ').Last(); // Oletetaan, että paikkakunta on viimeinen elementti tässä osassa

                    // Käy läpi kaikki ComboBoxin itemit ja vertaa niitä paikkakuntaan
                    foreach (var item in comboBoxPostinumero.Items)
                    {
                        Posti posti = (Posti)item;
                        if (posti.Toimipaikka == paikkakuntaValinta)
                        {
                            comboBoxPostinumero.SelectedItem = item;
                            break; // Lopeta silmukka kun oikea item löytyy
                        }
                    }
                }
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex != -1)
            //{
            //    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            //}
            textBox1.Text = "POISTETTU!";
        }

        private void btnSortBySurname_Click(object sender, EventArgs e)
        {
            // Lajittele asiakasTiedot lista sukunimen perusteella
            asiakasTiedot.Sort((a, b) => a.Sukunimi.CompareTo(b.Sukunimi));
            PaivitaAsiakasLista(); // Päivitä ListBox
        }

        private void btnSortByCity_Click(object sender, EventArgs e)
        {
            // Lajittele asiakasTiedot lista paikkakunnan perusteella
            asiakasTiedot.Sort((a, b) => a.Toimipaikka.CompareTo(b.Toimipaikka));
            PaivitaAsiakasLista(); // Päivitä ListBox
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Asiakas uusiAsiakas = new Asiakas()
            {
                Postinro = textBox4.Text,
                Etunimi = textBox1.Text,
                Sukunimi = textBox2.Text,
                Lahiosoite = textBox3.Text,
                Email = textBox7.Text,
                Puhelinnro = textBox6.Text
            };

            DatabaseRepository repository = new DatabaseRepository();
            bool onnistui = repository.LisaaAsiakas(uusiAsiakas);
            if (onnistui)
            {
                MessageBox.Show("Asiakas lisätty onnistuneesti.");
            }
            else
            {
                MessageBox.Show("Asiakkaan lisäys epäonnistui.");
            }
            PaivitaAsiakasLista(); // Päivitä listboxin tiedot lisäyksen jälkeen
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Päivitetty!";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Tyhjennä kaikki tekstikentät
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            //textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            // Aseta ComboBoxin valinta tyhjäksi
            comboBoxPostinumero.SelectedItem = null;
        }

        private void Asiakashallinta_Load(object sender, EventArgs e)
        {
            LataaPaikkakunnat();
        }

        //Hakee postinumerot ja paikkakunnat tietokannasta ja lisää ne ComboBoxiin
        private void LataaPaikkakunnat()
        {
            DatabaseRepository repository = new DatabaseRepository();
            var postit = repository.HaeKaikkiPostit();
            comboBoxPostinumero.Items.Clear(); // Tyhjennä lista ennen uusien tietojen lisäämistä
            foreach (var posti in postit)
            {
                //comboBoxPostinumero.Items.Add(new { Text = posti.Toimipaikka, Value = posti.Postinro });
                comboBoxPostinumero.Items.Add(posti);
            }

            comboBoxPostinumero.DisplayMember = "Toimipaikka";
            comboBoxPostinumero.ValueMember = "Portinumero";
            comboBoxPostinumero.Items.Add("Lisää paikkakunta..."); // Lisää loppuun uusi paikkakunta -valinta
        }

        private void comboBoxPostinumero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPostinumero.SelectedItem != null)
            {
                var valittuItem = comboBoxPostinumero.SelectedItem;

                // Tarkista, onko valittu "Lisää paikkakunta..."
                if (valittuItem.ToString() == "Lisää paikkakunta...")
                {
                    // Tässä kohtaa voit esimerkiksi avata uuden lomakkeen paikkakunnan lisäämiseksi
                    AvaaLisaaPaikkakuntaLomake();
                    //textBox1.Text = "Metodi tulossa!";
                }
                else
                {
                    // Käsitellään tapaus, kun valittu kohde on Posti-objekti
                    try
                    {
                        Posti valittuPosti = (Posti)valittuItem;
                        textBox4.Text = valittuPosti.Postinro; // Aseta valitun postinumeron arvo textBox4:ään
                    }
                    catch (InvalidCastException)
                    {
                        // Virheenkäsittely, jos valittua kohdetta ei voida muuntaa Posti-tyypiksi
                        MessageBox.Show("Valinta ei ole sopiva.");
                    }
                }
            }
        }

        private void AvaaLisaaPaikkakuntaLomake()
        {
            // Tässä voit avata lomakkeen uuden paikkakunnan lisäämiseksi
            // Esimerkiksi näin:
            LisaaPaikkakuntaForm lisaaPaikkakuntaForm = new LisaaPaikkakuntaForm();
            if (lisaaPaikkakuntaForm.ShowDialog() == DialogResult.OK)
            {
                // Jos lomake suljetaan OK-painikkeella, voit ladata paikkakunnat uudelleen
               LataaPaikkakunnat();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true; // Luo sarakkeet automaattisesti
            dataGridView1.DataSource = null; // Tyhjennä vanhat tiedot
            dataGridView1.DataSource = asiakasTiedot; // Aseta asiakasTiedot lista DataSourceksi
        }


    }
}
