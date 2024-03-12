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
    public partial class MokkiAluehallinta : Form
        {
        public MokkiAluehallinta ()
        {
                InitializeComponent();
        }
        
        private void btnClearAlue_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAlue_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeAlue_Click(object sender, EventArgs e)
        {

        }

        private void BtnDeleteAlue_Click(object sender, EventArgs e)
        {

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

        private void listBoxAlue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxMokki_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
