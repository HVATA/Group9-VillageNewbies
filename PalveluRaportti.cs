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
    public partial class PalveluRaportti : Form
        {
        private BindingSource palveluBindingSource = new BindingSource();

        private BindingSource alueBindingSource = new BindingSource();

        private List<Alue> aluetiedot = new List<Alue>();

        private List<Varauksen_palvelut> varatutPalvelut = new List<Varauksen_palvelut>();

        private List<Palvelu> palveluTiedot = new List<Palvelu>();

        public PalveluRaportti ()
            {
            InitializeComponent();

            LataaPalvelutTietokannasta();
            LataaVaratutPalvelut();
            LataaAlueetTietokannasta();
            LataaDataGrid();
            }

        // lataa varatut palvelut 

    public void LataaVaratutPalvelut ()
            {
            // Haetaan kaikki varatut palvelut tietokannasta
            List<Varauksen_palvelut> varatutPalvelut = Varauksen_palvelut.HaeKaikkiVarauksenPalvelutTiedot();
            }
        public void LataaPalvelutTietokannasta ()
            {
            // Haetaan kaikki palvelutietojen tiedot tietokannasta
            List<Palvelu> palveluTiedot = Palvelu.HaeKaikkiPalveluTiedot();
            
            }

        private void LataaDataGrid ()
            {
            DataGridView1.Rows.Clear();

            // Lisätään kaikki varatut palvelut DataGridViewiin

            foreach (Varauksen_palvelut varattuPalvelu in varatutPalvelut)
                {
                // Haetaan varatun palvelun tiedot
                Palvelu palvelu = palveluTiedot.Find(p => p.Palvelu_id == varattuPalvelu.Palvelu_id);

                // Lisätään varatun palvelun tiedot DataGridViewiin
                DataGridView1.Rows.Add(varattuPalvelu.Varaus_id, palvelu.Nimi, varattuPalvelu.Lkm);
                }

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

        private void button1_Click ( object sender, EventArgs e )
            {

            }

        private void PalveluRaportti_Load ( object sender, EventArgs e )
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
        }
    }
