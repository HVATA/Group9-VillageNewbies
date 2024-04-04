using System;
using System.Windows.Forms;

namespace Group9_VillageNewbies
    {
    public partial class Palvelumuokkaus : Form
        {
        private bool onkoMuokkausTila;

        public Palvelumuokkaus ( string nimi, string kuvaus, string hinta, string alueNimi, string palvelu_id )
            {
            InitializeComponent();
            onkoMuokkausTila = true;

            PalveluNimiTextBox.Text = nimi;
            KuvausTextBox.Text = kuvaus;
            HintaTextBox.Text = hinta;
            AlueNimiTextBox.Text = alueNimi;
            Palvelu_idTextBox.Text = palvelu_id;

            this.Text = "Muokkaa palvelua";
            }

        public Palvelumuokkaus ()
            {
            InitializeComponent();
            onkoMuokkausTila = false;
            this.Text = "Lisää palvelu";
            }

        

        private void BtnBack_Click ( object sender, EventArgs e )
            {
            this.Close();
            }

        private void BtnTallenna_Click ( object sender, EventArgs e )
            {
            string nimi = PalveluNimiTextBox.Text;
            string kuvaus = KuvausTextBox.Text;
            string hinta = HintaTextBox.Text;
            string alueNimi = AlueNimiTextBox.Text;
            string palvelu_id = Palvelu_idTextBox.Text;
            int alv = 24;
            int alue_id = Palvelu.HaeAlueIdNimenPerusteella(alueNimi);

            if (onkoMuokkausTila)
                {
                bool muokkausOnnistui = Palvelu.MuokkaaPalvelu(palvelu_id.ToString(), nimi, kuvaus, hinta, alv, alue_id);
                if (muokkausOnnistui)
                    {
                    MessageBox.Show("Palvelun muokkaus onnistui.", "Onnistui", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    }
                else
                    {
                    MessageBox.Show("Palvelun muokkaus epäonnistui.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            else
                {
                if (alue_id != -1)
                    {
                    bool lisaysOnnistui = Palvelu.LisaaPalvelu(nimi, kuvaus, hinta, 24, alue_id);
                    if (lisaysOnnistui)
                        {
                        MessageBox.Show("Palvelun lisäys onnistui.", "Onnistui", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        }
                    else
                        {
                        MessageBox.Show("Palvelun lisäys epäonnistui.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                else
                    {
                    MessageBox.Show("Aluetta ei löytynyt annetulla nimellä.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
