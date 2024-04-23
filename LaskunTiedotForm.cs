using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
        private string pdfPath;

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
            //CreatePdf();
            CreatePdf(currentInvoice);
        }

        private void CreatePdf2()
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

        private void CreatePdf3()
        {
            try
            {
                string pdfPath = @"C:\Users\sakuk\OneDrive\Opiskelut\Savonia\ohjelmistotuotanto1\testilasku.pdf"; // Esimerkkipolku, muuta tarpeen mukaan

                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
                doc.Open();

                doc.Add(new Paragraph("Laskun Tiedot"));
                doc.Add(new Paragraph($"Laskun ID: {currentInvoice.LaskuId}"));
                doc.Add(new Paragraph($"Summa: {currentInvoice.Summa}"));
                doc.Add(new Paragraph($"ALV: {currentInvoice.Alv}"));
                doc.Add(new Paragraph($"Eräpäivä: {currentInvoice.Erapvm.ToShortDateString()}"));
                doc.Add(new Paragraph($"Maksettu: {(currentInvoice.Maksettu ? "Kyllä" : "Ei")}"));

                doc.Close();
                MessageBox.Show("PDF luotu onnistuneesti osoitteeseen: " + pdfPath, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Virhe luodessa PDF-tiedostoa: {ex.Message}", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreatePdf(Lasku lasku)
        {
            // Luodaan PDF-tiedoston polku käyttäen laskun ID:tä tiedostonimenä
            string filename = $"Lasku{lasku.LaskuId}.pdf";
            string filepath = Path.Combine(@"C:\Users\sakuk\OneDrive\Opiskelut\Savonia\ohjelmistotuotanto1\", filename);
            currentInvoice.FilePath = filepath; // Tallenna polku lasku-olioon, jos haluat käyttää sitä myöhemmin

            try
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                doc.Open();
                doc.Add(new Paragraph("Laskun Tiedot"));
                doc.Add(new Paragraph($"Laskun ID: {lasku.LaskuId}"));
                doc.Add(new Paragraph($"Summa: {lasku.Summa} €"));
                doc.Add(new Paragraph($"ALV: {lasku.Alv}"));
                doc.Add(new Paragraph($"Eräpäivä: {lasku.Erapvm.ToShortDateString()}"));
                doc.Add(new Paragraph($"Maksettu: {(lasku.Maksettu ? "Kyllä" : "Ei")}"));
                doc.Close();
                MessageBox.Show("PDF luotu onnistuneesti.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Virhe luodessa PDF-tiedostoa: {ex.Message}", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSendEmail_Click2(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sakuka@gmail.com");
                mail.To.Add(new MailAddress("saku.karkkainen@edu.savonia.fi"));
                mail.Subject = "Lasku";
                mail.Body = "Hei, \nLiitteenä löydät laskun. Ystävällisin terveisin, Yrityksesi nimi.";

                // Tarkista onko PDF luotu ja olemassa
                if (!string.IsNullOrEmpty(pdfPath) && File.Exists(pdfPath))
                {
                    Attachment attachment = new Attachment(pdfPath);
                    mail.Attachments.Add(attachment);
                }
                else
                {
                    MessageBox.Show("PDF-tiedostoa ei löydy polusta: " + pdfPath, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Keskeytä lähetys, jos PDF-tiedostoa ei ole
                }

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("sakuka@gmail.com", "hcebsvpklbvpxmyn");
                    smtp.Send(mail);
                    MessageBox.Show("Sähköposti lähetetty!", "Lähetys onnistui", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sähköpostin lähetys epäonnistui: " + ex.Message, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendEmailWithPdfAttachment(Lasku lasku)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("saku.karkkainen@gmail.com");
                mail.To.Add("saku.karkkainen@edu.savonia.fi");
                mail.Subject = "Lasku";
                mail.Body = "Liitteenä on laskunne.";

                // Lisää liite käyttäen laskun tallennettua tiedostopolku
                Attachment attachment = new Attachment(lasku.FilePath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587; // Vaihda tarvittaessa
                SmtpServer.Credentials = new System.Net.NetworkCredential("sakuka@gmail.com", "hcebsvpklbvpxmyn");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Sähköposti lähetetty onnistuneesti.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe sähköpostin lähetyksessä: " + ex.ToString());
            }
        }
        private void btnSendEmail_Click(object sender, EventArgs e)
            {
                SendEmailWithPdfAttachment(currentInvoice);
            }

    }
}
