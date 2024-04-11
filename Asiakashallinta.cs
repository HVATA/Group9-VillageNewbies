using Group9_VillageNewbies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Group9_VillageNewbies

{
    public partial class Asiakashallinta : Form
    {
        List<AsiakasTieto> asiakasTiedot = new List<AsiakasTieto>();
        private BindingSource bindingSource = new BindingSource();

        public Asiakashallinta()

        {
            InitializeComponent(); // Alusta komponentit
            LataaPaikkakunnat(); // Lataa paikkakunnat ComboBoxiin
            LataaAsiakkaatTietokannasta(); // Lataa asiakastiedot tietokannasta
            //PaivitaAsiakasLista(); // Päivitä listboxin tiedot
            dataGridView1.DataSource = asiakasTiedot; // Aseta asiakasTiedot lista DataSourceksi
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete; // Kytke dataGridView1_DataBindingComplete tapahtumakäsittelijä DataBindingComplete-tapahtumaan

            // Kytke Asiakashallinta_Load tapahtumakäsittelijä Load-tapahtumaan
            this.Load += new System.EventHandler(this.Asiakashallinta_Load);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
       


        private void LataaAsiakkaatTietokannasta()
        {
            DatabaseRepository repository = new DatabaseRepository();
            asiakasTiedot.Clear(); // Tyhjennä lista varmuuden vuoksi
            DataTable asiakkaatTable = repository.ExecuteQuery(@"SELECT a.asiakas_id, a.etunimi, a.sukunimi, a.lahiosoite, a.postinro, p.toimipaikka, a.puhelinnro, a.email FROM asiakas a JOIN posti p ON a.postinro = p.postinro");

            foreach (DataRow row in asiakkaatTable.Rows)
            {
                AsiakasTieto asiakas = new AsiakasTieto()
                {
                    // Aseta tiedot row:sta
                    AsiakasId = row["asiakas_id"] != DBNull.Value ? Convert.ToInt32(row["asiakas_id"]) : 0,
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

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            // Tarkista, että DataGridView:ssä on valittu rivi
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Ota ensimmäisen valitun solun rivin indeksi
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                // Ota DataGridView:n rivi, joka vastaa valittua riviä
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

                // Ota valitun rivin asiakasId. Oletetaan, että AsiakasId on ensimmäinen sarake.
                int asiakasId = Convert.ToInt32(selectedRow.Cells["AsiakasId"].Value); // muokkaa "AsiakasId" vastaamaan oikeaa sarakenimeä

                DatabaseRepository repository = new DatabaseRepository();
                bool onnistui = repository.PoistaAsiakas(asiakasId);

                if (onnistui)
                {
                    MessageBox.Show("Asiakas poistettu onnistuneesti.");
                    // Päivitä DataGridView uusilla tiedoilla tietokannasta
                    LataaAsiakkaatDataGridViewiin();
                    TyhjennaTekstikentat(); // Tyhjennä tekstikentät poiston jälkeen


                }
                else
                {
                    MessageBox.Show("Asiakkaan poisto epäonnistui.");
                }
            }
            else
            {
                MessageBox.Show("Valitse poistettava asiakas.");
            }
        }


        private void btnSortBySurname_Click(object sender, EventArgs e)
        {
            
        // Lajittele asiakasTiedot lista sukunimen perusteella
        asiakasTiedot.Sort((a, b) => a.Sukunimi.CompareTo(b.Sukunimi));
            //PaivitaAsiakasLista(); // Päivitä ListBox
            //järjestä Gridview
            bindingSource.Sort = "Sukunimi ASC";
            dataGridView1.Refresh();
        }

        private void btnSortByCity_Click(object sender, EventArgs e)
        {
            // Lajittele asiakasTiedot lista paikkakunnan perusteella
            asiakasTiedot.Sort((a, b) => a.Toimipaikka.CompareTo(b.Toimipaikka));
            //PaivitaAsiakasLista(); // Päivitä ListBox
            bindingSource.Sort = "Toimipaikka ASC";
            dataGridView1.Refresh();
        }


private void btnAdd_Click(object sender, EventArgs e)
{
    // Sähköpostin muodon tarkistus
    string emailPattern = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
    if (!Regex.IsMatch(textBox7.Text, emailPattern))
    {
        MessageBox.Show("Sähköpostiosoite ei ole kelvollisessa muodossa.");
        return; // Keskeytä lisäys jos sähköposti on virheellinen
    }

    // Puhelinnumeron muodon tarkistus
    string phonePattern = @"^(\+358|0)\d{2,3}-?\d{5,7}$";
    if (!Regex.IsMatch(textBox6.Text, phonePattern))
    {
        MessageBox.Show("Puhelinnumero ei ole kelvollisessa muodossa.");
        return; // Keskeytä lisäys jos puhelinnumero on virheellinen
    }

    // Luo uusi asiakasobjekti
    Asiakas uusiAsiakas = new Asiakas()
    {
        Postinro = textBox4.Text,
        Etunimi = textBox1.Text,
        Sukunimi = textBox2.Text,
        Lahiosoite = textBox3.Text,
        Email = textBox7.Text,
        Puhelinnro = textBox6.Text
    };

    // Yritä lisätä asiakas tietokantaan
    DatabaseRepository repository = new DatabaseRepository();
    bool onnistui = repository.LisaaAsiakas(uusiAsiakas);
    if (onnistui)
    {
        MessageBox.Show("Asiakas lisätty onnistuneesti.");
        LataaAsiakkaatDataGridViewiin(); // Päivitä DataGridView uusilla tiedoilla
    }
    else
    {
        MessageBox.Show("Asiakkaan lisäys epäonnistui.");
    }
}



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Sähköpostin tarkistuksen regex
            string emailPattern = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
            // Puhelinnumeron tarkistuksen regex (yksinkertaistettu esimerkki)
            string phonePattern = @"^(\+358|0)\d{2,3}-?\d{5,7}$"; // Esimerkki hyväksyy 10-15 numeroa, mahdollisesti "+" etuliitteellä
                                                                  
            // Tarkista sähköpostin muoto
            if (!Regex.IsMatch(textBox7.Text, emailPattern))
            {
                MessageBox.Show("Sähköpostiosoite ei ole oikeaa muotoa.");
                return; // Keskeytä metodi tässä vaiheessa
            }

            // Tarkista puhelinnumeron muoto
            if (!Regex.IsMatch(textBox6.Text, phonePattern))
            {
                MessageBox.Show("Puhelinnumero ei ole oikeaa muotoa.");
                return; // Keskeytä metodi tässä vaiheessa
            }

            // Tarkista, että jokin asiakas on valittuna (esim. DataGridViewista)
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Ota ensimmäisen valitun solun rivin indeksi
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                // Ota DataGridView:n rivi, joka vastaa valittua riviä
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                // Ota valitun rivin asiakasId
                int asiakasId = Convert.ToInt32(selectedRow.Cells["AsiakasId"].Value);

                // Kerää päivitettävät tiedot tekstikentistä
                AsiakasTieto paivitettyAsiakas = new AsiakasTieto
                {
                    AsiakasId = asiakasId,
                    Etunimi = textBox1.Text,
                    Sukunimi = textBox2.Text,
                    Lahiosoite = textBox3.Text,
                    Postinro = textBox4.Text,
                    Puhelinnro = textBox6.Text,
                    Email = textBox7.Text,
                    // Lisää muut tarvittavat kentät...
                };

                // Kutsu repository-metodia päivittämään asiakkaan tiedot
                DatabaseRepository repository = new DatabaseRepository();
                bool onnistui = repository.MuutaAsiakkaanTiedot(paivitettyAsiakas);

                if (onnistui)
                {
                    MessageBox.Show("Asiakkaan tiedot päivitetty onnistuneesti.");
                    LataaAsiakkaatDataGridViewiin(); // Päivitä DataGridView uusilla tiedoilla
                }
                else
                {
                    MessageBox.Show("Asiakkaan tietojen päivittäminen epäonnistui.");
                }
            }
            else
            {
                MessageBox.Show("Valitse ensin päivitettävä asiakas.");
            }
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
            // Käytä tässä bindingSourcea yhdistääksesi asiakasTiedot-listan dataGridViewiin
            bindingSource.DataSource = asiakasTiedot;
            dataGridView1.DataSource = bindingSource;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Varmista, että klikkaus ei ole otsikkorivillä
            {
                // Oletetaan, että asiakasTiedot on lista, jossa on AsiakasTieto-objekteja
                var valittuAsiakas = (AsiakasTieto)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Aseta valitun asiakkaan tiedot tekstikenttiin
                textBox1.Text = valittuAsiakas.Etunimi;
                textBox2.Text = valittuAsiakas.Sukunimi;
                textBox3.Text = valittuAsiakas.Lahiosoite;
                textBox4.Text = valittuAsiakas.Postinro;
                // Aseta valitun asiakkaan paikkakunta ComboBoxin valinnaksi
                foreach (var item in comboBoxPostinumero.Items)
                {
                    Posti posti = (Posti)item;
                    if (posti.Postinro == valittuAsiakas.Postinro) // tai posti.Toimipaikka jos vertaat toimipaikkaan
                    {
                        comboBoxPostinumero.SelectedItem = item;
                        break;
                    }
                }
                textBox6.Text = valittuAsiakas.Puhelinnro;
                textBox7.Text = valittuAsiakas.Email;
            }
        }

        private void LataaAsiakkaatDataGridViewiin()
        {
            // Oletetaan, että tämä metodi hakee asiakastiedot tietokannasta ja asettaa ne DataGridViewin DataSourceksi
            asiakasTiedot.Clear(); // Tyhjennä vanhat tiedot
            LataaAsiakkaatTietokannasta(); // Lataa uudet tiedot tietokannasta
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = asiakasTiedot; // Aseta päivitetyt tiedot DataGridViewin DataSourceksi
                                  
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Piilota AsiakasId-sarake
            if (dataGridView1.Columns.Contains("AsiakasId"))
            {
                dataGridView1.Columns["AsiakasId"].Visible = false;
            }
        }



        //tyhjennä tekstikentät metodi
        private void TyhjennaTekstikentat()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBoxPostinumero.SelectedItem = null;
        }

        private void btn_back2menuAS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_back2VAR_Click(object sender, EventArgs e)
        {
            MajoitusVaraustenHallintaUusi majava2 = new MajoitusVaraustenHallintaUusi();
            majava2.Show();
            this.Close();
        }
    }
}
