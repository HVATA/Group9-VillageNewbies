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
    public partial class Laskujenhallinta : Form
    {
        private DatabaseRepository dbRepository;
        public Laskujenhallinta()
        {
            InitializeComponent();
            dbRepository = new DatabaseRepository(); // Aseta oikea yhteysmerkkijono konstruktorissa, jos tarpeen
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick; // Liitä tapahtumankäsittelijä
            LoadInvoices();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadInvoices()
        {
            try
            {
                dataGridView1.DataSource = dbRepository.GetInvoicesWithDetails();
                dataGridView1.Columns["sahkoposti"].Visible = false; // Esimerkki sähköpostiosoitteen piilottamisesta
                dataGridView1.Columns["puhelinnumero"].Visible = false; // Esimerkki puhelinnumeron piilottamisesta
                dataGridView1.Columns["etunimi"].HeaderText = "Etunimi"; // Muuttaa etunimi-sarakkeen otsikon
                dataGridView1.Columns["sukunimi"].HeaderText = "Sukunimi"; // Muuttaa sukunimi-sarakkeen otsikon
                dataGridView1.Columns["katuosoite"].HeaderText = "Katuosoite"; // Muuttaa katuosoite-sarakkeen otsikon
                dataGridView1.Columns["postinumero"].Visible = false; // Muuttaa postinumero-sarakkeen otsikon
                dataGridView1.Columns["mokkinimi"].HeaderText = "Mökki"; // Muuttaa mokkinimi-sarakkeen otsikon
                dataGridView1.Columns["lasku_id"].HeaderText = "Laskun numero"; // Muuttaa lasku_id-sarakkeen otsikon
                //dataGridView1.Columns["lasku_id"].Visible = false; // Piilottaa lasku_id sarakkeen
                dataGridView1.Columns["varaus_id"].Visible = false; // Piilottaa varaus_id sarakkeen
                dataGridView1.Columns["summa"].DefaultCellStyle.Format = "0.00 €"; // Muotoilee summa-sarakkeen valuutaksi
                dataGridView1.Columns["alv"].Visible = false; 
                dataGridView1.Refresh(); // Pakota DataGridView päivittymään

            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe laskujen lataamisessa: " + ex.Message, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAllInvoices_Click(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnShowUnpaidInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDataGridView();
                dataGridView1.DataSource = dbRepository.GetUnpaidInvoices();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe maksamattomien laskujen näyttämisessä: " + ex.Message, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowPaidInvoices_Click(object sender, EventArgs e)
        {
            ClearDataGridView();
            dataGridView1.DataSource = dbRepository.GetPaidInvoices();
        }

        private void btnOverdue_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDataGridView(); // Tyhjentää vanhan datan
                dataGridView1.DataSource = dbRepository.GetOverdueUnpaidInvoices(); // Hakee myöhässä olevat maksamattomat laskut
                dataGridView1.Refresh(); // Päivittää näkymän
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe haettaessa myöhässä olevia laskuja: " + ex.Message, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh(); // Pakota DataGridView päivittymään
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                Lasku lasku = new Lasku
                {
                    Etunimi = row.Cells["etunimi"].Value.ToString(),
                    Sukunimi = row.Cells["sukunimi"].Value.ToString(),
                    Lahiosoite = row.Cells["katuosoite"].Value.ToString(),
                    Postinro = row.Cells["postinumero"].Value.ToString(),
                    Toimipaikka = row.Cells["paikkakunta"].Value.ToString(),
                    Email = row.Cells["sahkoposti"].Value.ToString(),
                    Puhelinnro = row.Cells["puhelinnumero"].Value.ToString(),
                    //LaskunPvm = Convert.ToDateTime(row.Cells["laskun_pvm"].Value),
                    Mokkinimi = row.Cells["mokkinimi"].Value.ToString(),
                    LaskuId = Convert.ToInt32(row.Cells["lasku_id"].Value),
                    VarausId = Convert.ToInt32(row.Cells["varaus_id"].Value),
                    Summa = Convert.ToDouble(row.Cells["summa"].Value),
                    Alv = Convert.ToDouble(row.Cells["alv"].Value),
                    Maksettu = Convert.ToBoolean(row.Cells["maksettu"].Value),
                    Erapvm = Convert.ToDateTime(row.Cells["erapvm"].Value)
                };

                // Avaa laskun tiedot lomake
                LaskunTiedotForm laskunTiedotForm = new LaskunTiedotForm();
                laskunTiedotForm.SetLaskuData(lasku);
                laskunTiedotForm.InvoiceUpdated += (s, args) => LoadInvoices(); // Tilaa tapahtuma
                laskunTiedotForm.ShowDialog();
            }
        }



    }
}
