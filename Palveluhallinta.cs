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

        private void LataaPalvelutTietokannasta ()
            {
            // Haetaan kaikki palvelutietojen tiedot tietokannasta
            List<Palvelu> palveluTiedot = Palvelu.HaeKaikkiPalvelut();

            // Päivitä BindingSource palvelutietojen tiedoilla
            palveluBindingSource.DataSource = palveluTiedot;
            DataGridView1.DataSource = palveluBindingSource;

            // Piilota palvelu_id -sarake alv -sarake ja alue_id -sarake
            DataGridView1.Columns["Palvelu_id"].Visible = false;
            DataGridView1.Columns["Alv"].Visible = false;
            DataGridView1.Columns["AlueId"].Visible = false;

            // Aseta ensimmäisen kolumnin (PalvelunKuvaus) leveys Fill-tilaan
            DataGridView1.Columns["kuvausDataGridViewTextBoxColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Aseta muiden kolumnien leveydet
            DataGridView1.Columns["nimiDataGridViewTextBoxColumn"].Width = 100;
            DataGridView1.Columns["hintaDataGridViewTextBoxColumn"].Width = 100;
            DataGridView1.Columns["alueNimiDataGridViewTextBoxColumn"].Width = 100;

            // Aseta otsikoiden järjestys
            DataGridView1.Columns["alueNimiDataGridViewTextBoxColumn"].DisplayIndex = 0;
            DataGridView1.Columns["nimiDataGridViewTextBoxColumn"].DisplayIndex = 1;
            DataGridView1.Columns["hintaDataGridViewTextBoxColumn"].DisplayIndex = 2;
            DataGridView1.Columns["KuvausDataGridViewTextBoxColumn"].DisplayIndex = 3;


            }

        

        private void Palveluhallinta_Load ( object sender, EventArgs e )
            {
            // TODO: This line of code loads data into the 'dataSet1.palvelu' table. You can move, or remove it, as needed.
            this.palveluTableAdapter.Fill(this.dataSet1.palvelu);
            }

        private void BtnDelete_Click ( object sender, EventArgs e )
            {
            // Täytä tarvittavat toiminnot poista-painikkeen painalluksen käsittelyyn
            }

        private void BtnAdd_Click ( object sender, EventArgs e )
            {
            // Täytä tarvittavat toiminnot lisää-painikkeen painalluksen käsittelyyn
            }

        private void BtnChange_Click ( object sender, EventArgs e )
            {
            // Täytä tarvittavat toiminnot muuta-painikkeen painalluksen käsittelyyn
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


        }
    }
