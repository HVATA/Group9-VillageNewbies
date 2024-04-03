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
    public partial class Palvelumuokkaus : Form
        {
        private bool onkoMuokkausTila;

        // Konstruktori muokkaustoiminnolle
        public Palvelumuokkaus ( string nimi, string kuvaus, string hinta, string alueNimi )
            {
            InitializeComponent();
            onkoMuokkausTila = true;

            // Täytä lomakkeen kentät saaduilla tiedoilla
            PalveluNimiTextBox.Text = nimi;
            KuvausTextBox.Text = kuvaus;
            HintaTextBox.Text = hinta;
            AlueNimiTextBox.Text = alueNimi;

            this.Text = "Muokkaa palvelua";
            }

        // Konstruktori lisäystoiminnolle
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
            if (onkoMuokkausTila)
                {
                // Toteuta muokkaustoiminto
                }
            else
                {
                // Toteuta lisäystoiminto
                }
            this.Close();
            }
        }
    }
