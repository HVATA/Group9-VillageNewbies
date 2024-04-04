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
    public partial class Palveluhallinta : Form
        {
        private BindingSource palveluBindingSource = new BindingSource();
        private BindingSource alueBindingSource = new BindingSource();
        private List<Alue> aluetiedot = new List<Alue>();

        public Palveluhallinta ()
            {
            InitializeComponent();
            LataaAlueetTietokannasta();
            LataaPalvelutTietokannasta();
            }
        private void Palveluhallinta_Activated ( object sender, EventArgs e )
            {
            LataaPalvelutTietokannasta(); // Päivitä palvelutiedot, kun lomake tulee aktiiviseksi
            }

        private void LataaAlueetTietokannasta ()
            {
            // Haetaan kaikki alueet tietokannasta
            aluetiedot = Alue.HaeKaikkiAlueet();

            // Lisätään "Kaikki palvelut" -valinta ComboBoxiin
            aluetiedot.Insert(0, new Alue { AlueId = -1, Nimi = "Kaikki palvelut" });

            // Päivitä BindingSource alueiden tiedoilla
            alueBindingSource.DataSource = aluetiedot;
            AlueComboBox.DataSource = alueBindingSource;

            

            // Asetetaan "Kaikki palvelut" -valinta oletusvalinnaksi
            AlueComboBox.SelectedIndex = 0;
            }

        public void LataaPalvelutTietokannasta ()
            {
            // Haetaan kaikki palvelutietojen tiedot tietokannasta
            List<Palvelu> palveluTiedot = Palvelu.HaeKaikkiPalveluTiedot();

            // Päivitä BindingSource palvelutietojen tiedoilla
            palveluBindingSource.DataSource = palveluTiedot;
            DataGridView1.DataSource = palveluBindingSource;

            // Piilota palvelu_id  ja alue_id -sarake
            DataGridView1.Columns["Palvelu_id"].Visible = false;
            DataGridView1.Columns["Alv"].Visible = false;
            DataGridView1.Columns["AlueId"].Visible = false;

            // Aseta ensimmäisen kolumnin (PalvelunKuvaus) leveys Fill-tilaan
            DataGridView1.Columns["kuvausDataGridViewTextBoxColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Aseta muiden kolumnien leveydet
            DataGridView1.Columns["nimiDataGridViewTextBoxColumn"].Width = 150;
            DataGridView1.Columns["hintaDataGridViewTextBoxColumn"].Width = 100;
            DataGridView1.Columns["alueNimiDataGridViewTextBoxColumn"].Width = 100;
            

            // Aseta otsikoiden järjestys
            
            DataGridView1.Columns["alueNimiDataGridViewTextBoxColumn"].DisplayIndex = 1;
            DataGridView1.Columns["nimiDataGridViewTextBoxColumn"].DisplayIndex = 2;
            DataGridView1.Columns["hintaDataGridViewTextBoxColumn"].DisplayIndex = 3;
            DataGridView1.Columns["KuvausDataGridViewTextBoxColumn"].DisplayIndex = 4;


            }
       
        private void Palveluhallinta_Load ( object sender, EventArgs e )
            {
            // TODO: This line of code loads data into the 'dataSet1.palvelu' table. You can move, or remove it, as needed.
            this.palveluTableAdapter.Fill(this.dataSet1.palvelu);
            }


        private void AlueComboBox_SelectedIndexChanged ( object sender, EventArgs e )
            {
            // Tarkista, että SelectedItem ei ole null
            if (AlueComboBox.SelectedItem != null)
                {
                // Hae valittu alue
                Alue valittuAlue = (Alue) AlueComboBox.SelectedItem;

                // Tarkista, että valittu alue ei ole null ja että sen nimi ei ole tyhjä
                if (valittuAlue != null && !string.IsNullOrEmpty(valittuAlue.Nimi))
                    {
                    int valittuAlueId = valittuAlue.AlueId;

                    if (valittuAlueId == -1) // Kaikki palvelut valittu
                        {

                        // Päivitä DataGridView kaikilla palvelutiedoilla
                        palveluBindingSource.DataSource = Palvelu.HaeKaikkiPalvelut();
                        }
                    else
                        {
                        // Haetaan valitun alueen palvelutietojen tiedot ja päivitetään näkymä
                        
                        palveluBindingSource.DataSource = Palvelu.HaeAlueenPalvelut(valittuAlueId);
                        }
                    }
                else
                    {
                    // Jos valittu alue tai sen nimi on tyhjä, näytä virheilmoitus
                    MessageBox.Show("Virhe: Valittu alue tai sen nimi on tyhjä.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        private void BtnClose_Click ( object sender, EventArgs e )
            {
             this.Close();
            }

        private void BtnDelete_Click ( object sender, EventArgs e )
            {
            // Tarkista, onko käyttäjä valinnut rivin
            if (DataGridView1.SelectedRows.Count > 0)
                {
                // Hae valitun rivin tiedot
                DataGridViewRow selectedRow = DataGridView1.SelectedRows[0];

                // Varmista, että solu, jossa on palvelu_id, ei ole null
                if (selectedRow.Cells["Palvelu_id"].Value != null)
                    {
                    string palveluId = selectedRow.Cells["Palvelu_id"].Value.ToString();

                    // Varmista, että käyttäjä haluaa varmasti poistaa valitun rivin
                    DialogResult result = MessageBox.Show("Haluatko varmasti poistaa valitun palvelun?", "Vahvista poisto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Jos käyttäjä vahvistaa poiston, kutsu PoistaPalvelu-metodia
                    if (result == DialogResult.Yes)
                        {
                        // Kutsu PoistaPalvelu-metodia ja tarkista sen palauttama arvo
                        if (Palvelu.PoistaPalvelu(palveluId))
                            {
                            // Jos palvelun poisto onnistui, päivitä näkymä
                            LataaPalvelutTietokannasta();

                            MessageBox.Show("Palvelu on poistettu onnistuneesti.", "Poisto onnistui", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        else
                            {
                            MessageBox.Show("Palvelun poistaminen epäonnistui.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                else
                    {
                    MessageBox.Show("Valitulla rivillä ei ole palvelu_id-tietoa.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            else
                {
                MessageBox.Show("Valitse ensin poistettava palvelu.", "Huomio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



        private void BtnChange_Click ( object sender, EventArgs e )
            {
            if (DataGridView1.SelectedRows.Count > 0)
                {
                // Hae valitun rivin tiedot
                DataGridViewRow selectedRow = DataGridView1.SelectedRows[0];
                string nimi = selectedRow.Cells["nimiDataGridViewTextBoxColumn"].Value.ToString();
                string kuvaus = selectedRow.Cells["kuvausDataGridViewTextBoxColumn"].Value.ToString();
                string hinta = selectedRow.Cells["hintaDataGridViewTextBoxColumn"].Value.ToString();
                string alueNimi = selectedRow.Cells["alueNimiDataGridViewTextBoxColumn"].Value.ToString();
                string palvelu_id = selectedRow.Cells["Palvelu_id"].Value.ToString();

                // Avaa Palvelumuokkaus-lomake valitun rivin tiedoilla
                Palvelumuokkaus muokkauslomake = new Palvelumuokkaus(nimi, kuvaus, hinta, alueNimi, palvelu_id);
                muokkauslomake.ShowDialog();

                // Päivitä palvelutiedot muokkauksen jälkeen
                LataaPalvelutTietokannasta();
                }
            else
                {
                MessageBox.Show("Valitse ensin muokattava palvelu.", "Huomio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        private void BtnAdd_Click ( object sender, EventArgs e )
            {
            // Avaa Palvelumuokkaus-lomake uuden palvelun lisäämistä varten
            Palvelumuokkaus lisayslomake = new Palvelumuokkaus();
            lisayslomake.ShowDialog();

            // Päivitä palvelutiedot lisäyksen jälkeen
            LataaPalvelutTietokannasta();
            }






        }
    }
    
