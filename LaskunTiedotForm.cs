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
        private DatabaseRepository dbRepository;
        private Lasku currentInvoice; // Säilytä laskun tiedot tässä

        public LaskunTiedotForm()
        {
            InitializeComponent();
            dbRepository = new DatabaseRepository(); // Alusta tietokanta repository
        }

        public void SetLaskuData(Lasku lasku)
        {
            currentInvoice = lasku; // Tallenna lasku muuttujaan
            textBoxID.Text = lasku.LaskuId.ToString();
            textBoxSumma.Text = lasku.Summa.ToString() + " €";
            textBoxALV.Text = lasku.Alv.ToString();
            textBoxErapvm.Text = lasku.Erapvm.ToShortDateString();
            checkBoxMaksettu.Checked = lasku.Maksettu;
            checkBoxMaksettu.CheckedChanged += checkBoxMaksettu_CheckedChanged; // Varmista, että tapahtumakäsittelijä on liitetty
        }

        private void checkBoxMaksettu_CheckedChanged(object sender, EventArgs e)
        {
            if (currentInvoice != null)
            {
                dbRepository.UpdateInvoicePaymentStatus(currentInvoice.LaskuId, checkBoxMaksettu.Checked);
                MessageBox.Show("Laskun maksutila päivitetty onnistuneesti.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
