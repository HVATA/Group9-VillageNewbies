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
    public partial class AsiakasKysyPopUp : Form
    {
        public AsiakasKysyPopUp()
        {
            InitializeComponent();
        }

        private void btn_asUusi_Click(object sender, EventArgs e)
        {
            Asiakashallinta asiakas = new Asiakashallinta();
            asiakas.Show();
            this.Close();
        }

        private void btn_asVanha_Click(object sender, EventArgs e)
        {
            VarausAddEditDelete varausAddEditDelete = new VarausAddEditDelete();
            varausAddEditDelete.ShowDialog();
            this.Close();
        }
    }
}
