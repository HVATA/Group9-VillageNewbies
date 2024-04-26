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
            Text = $"Laskun tiedot - Lasku ID: {lasku.LaskuId}"; // Aseta ikkunan otsikko
            textBoxEtunimi.Text = lasku.Etunimi;
            textBoxSukunimi.Text = lasku.Sukunimi;
            textBoxOsoite.Text = lasku.Lahiosoite + ", " + lasku.Postinro + " " + lasku.Toimipaikka;
            textBoxPuhelinnumero.Text = lasku.Puhelinnro;
            textBoxEmail2.Text = lasku.Email;
            textBoxEmail.Text = lasku.Email;
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


        private void CreatePdf(Lasku lasku)
        {
            // Tallenna lasku muuttujaan ja aseta ikkunan otsikko
            currentInvoice = lasku;
            Text = $"Laskun tiedot - Lasku ID: {lasku.LaskuId}";

            // Luodaan PDF-tiedoston polku käyttäen laskun ID:tä tiedostonimenä
            string filename = $"Lasku{lasku.LaskuId}.pdf";
            string filepath = Path.Combine(@"C:\Users\sakuk\OneDrive\Opiskelut\Savonia\ohjelmistotuotanto1\", filename);
            currentInvoice.FilePath = filepath; // Tallenna polku lasku-olioon, jos haluat käyttää sitä myöhemmin

            try
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                doc.Open();

                // Lisää kuva
                string imagePath = @"C:\Users\sakuk\OneDrive\Opiskelut\Savonia\ohjelmistotuotanto1\VillageLogo.png"; // Osoite kuvalle
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
                image.ScaleToFit(140f, 120f);
                image.Alignment = Element.ALIGN_CENTER;
                doc.Add(image);

                // Lisää otsikko isommalla fontilla
                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                doc.Add(new Paragraph($"Lasku", titleFont));

                // Lisää laskun tiedot
                doc.Add(new Paragraph($"Laskun numero: {lasku.LaskuId}"));
                doc.Add(new Paragraph($"Etunimi: {lasku.Etunimi}"));
                doc.Add(new Paragraph($"Sukunimi: {lasku.Sukunimi}"));
                doc.Add(new Paragraph($"Osoite: {lasku.Lahiosoite}, {lasku.Postinro} {lasku.Toimipaikka}"));
                doc.Add(new Paragraph($"Puhelinnumero: {lasku.Puhelinnro}"));
                doc.Add(new Paragraph($"Sähköposti: {lasku.Email}"));
                doc.Add(new Paragraph($"Summa: {lasku.Summa} €"));
                doc.Add(new Paragraph($"ALV: {lasku.Alv}"));
                doc.Add(new Paragraph($"Eräpäivä: {lasku.Erapvm.ToShortDateString()}"));
                doc.Add(new Paragraph($"Maksettu: {(lasku.Maksettu ? "Kyllä" : "Ei")}"));

                // Lisää saajan tiedot
                iTextSharp.text.Font footerFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                Paragraph footer = new Paragraph("Saajan tiedot:\nVillage Newbies Oy\nRukatie 4\n88888 Ruka\nY-tunnus 2929292-1\nPUH: 101000223\nTILI: FI51 4455 5566 5511 22 OKOUHHF", footerFont);
                footer.Alignment = Element.ALIGN_LEFT;
                footer.SpacingBefore = 50; // Lisää tarvittaessa välimatkaa edelliseen tekstiosioon
                doc.Add(footer);

                doc.Close();
                //MessageBox.Show("PDF luotu onnistuneesti.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //tähän messabox joka kertoo että polun ja sen että pdf on luotu onnistuneesti
                MessageBox.Show("PDF luotu onnistuneesti.\nPolku: " + filepath, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Virhe luodessa PDF-tiedostoa: {ex.Message}", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SendEmailWithPdfAttachment()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                string recipientEmail = textBoxEmail.Text; // Ota sähköpostiosoite TextBoxista
                if (string.IsNullOrWhiteSpace(recipientEmail))
                {
                    MessageBox.Show("Anna sähköpostiosoite.");
                    return;
                }

                mail.From = new MailAddress("saku.karkkainen@village.com");
                mail.To.Add(recipientEmail);
                mail.Subject = "Lasku";
                mail.Body = "Liitteenä on laskunne.";

                // Lisää liite käyttäen laskun tallennettua tiedostopolku
                if (!File.Exists(currentInvoice.FilePath))
                {
                    MessageBox.Show("PDF-tiedostoa ei ole olemassa.");
                    return;
                }

                Attachment attachment = new Attachment(currentInvoice.FilePath);
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
                SendEmailWithPdfAttachment();
            }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
