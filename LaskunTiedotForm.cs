using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Group9_VillageNewbies
{
    public partial class LaskunTiedotForm : Form
    {
        private DatabaseRepository dbRepository;
        private Lasku currentInvoice; // Säilytä laskun tiedot tässä

        public delegate void InvoiceUpdatedEventHandler(object sender, EventArgs e);
        public event InvoiceUpdatedEventHandler InvoiceUpdated;

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
            //checkBoxMaksettu.CheckedChanged += checkBoxMaksettu_CheckedChanged; // Varmista, että tapahtumakäsittelijä on liitetty
        }

        private void checkBoxMaksettu_CheckedChanged(object sender, EventArgs e)
        {
            if (currentInvoice != null)
            {
                dbRepository.UpdateInvoicePaymentStatus(currentInvoice.LaskuId, checkBoxMaksettu.Checked);
                //MessageBox.Show("Laskun maksutila päivitetty onnistuneesti.");
                InvoiceUpdated?.Invoke(this, EventArgs.Empty); // Laukaise tapahtuma

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCreatePdf_Click(object sender, EventArgs e)
        {
            CreatePdf();
        }

        private void CreatePdf()
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Document doc = new Document(PageSize.A4);
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        doc.Add(new Paragraph("Laskun Tiedot"));
                        doc.Add(new Paragraph($"Laskun ID: {currentInvoice.LaskuId}"));
                        doc.Add(new Paragraph($"Summa: {currentInvoice.Summa}"));
                        doc.Add(new Paragraph($"ALV: {currentInvoice.Alv}"));
                        doc.Add(new Paragraph($"Eräpäivä: {currentInvoice.Erapvm.ToShortDateString()}"));
                        doc.Add(new Paragraph($"Maksettu: {(currentInvoice.Maksettu ? "Kyllä" : "Ei")}"));

                        doc.Close();
                        MessageBox.Show("PDF luotu onnistuneesti.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Virhe luodessa PDF-tiedostoa: {ex.Message}", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
