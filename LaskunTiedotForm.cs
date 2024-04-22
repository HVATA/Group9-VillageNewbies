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
    public partial class LaskunTiedotForm : Form
    {
        public LaskunTiedotForm()
        {
            InitializeComponent();
        }

        public void SetLaskuData(Lasku lasku)
        {
            textBoxSumma.Text = lasku.Summa.ToString();
            textBoxALV.Text = lasku.Alv.ToString();
            textBoxErapvm.Text = lasku.Erapvm.ToShortDateString();
            checkBoxMaksettu.Checked = lasku.Maksettu;
        }
    }
}
