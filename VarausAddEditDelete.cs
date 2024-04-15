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
    public partial class VarausAddEditDelete : Form
    {
        public VarausAddEditDelete()
        {
            InitializeComponent();
        }

        private void btn_back2Var_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VarausAddEditDelete_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.varaus' table. You can move, or remove it, as needed.
            this.varausTableAdapter.Fill(this.dataSet2.varaus);

        }

        private void btn_LisaaVaraus_Click(object sender, EventArgs e)
        {
            if (comboBox_VarVarAlue.SelectedIndex == -1)
            {
                MessageBox.Show("Valise alue");
            }
            else if(comboBox_VarVarMokki.SelectedIndex == -1)
            {
                MessageBox.Show("Valise mökki");
            }
            else if (comboBox_VarVarAsiakas.SelectedIndex == -1)
            {
                MessageBox.Show("Valise asiakas");
            }
            

        }

        private void btn_EditVaraus_Click(object sender, EventArgs e)
        {

        }

        private void btn_DeleteVaraus_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_VarVarPalvelut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_VarVarAlue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_VarVarMokki_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_VarVarAsiakas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerVarStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerVarEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_AddPalveluToVaraus_Click(object sender, EventArgs e)
        {

        }

        private void btn_deleteVarPalvelu_Click(object sender, EventArgs e)
        {

        }
    }
}
