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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe laskujen lataamisessa: " + ex.Message, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            ClearDataGridView();
            dataGridView1.DataSource = dbRepository.GetOverdueUnpaidInvoices();
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
                    LaskuId = Convert.ToInt32(row.Cells["lasku_id"].Value),
                    VarausId = Convert.ToInt32(row.Cells["varaus_id"].Value),
                    //KokonaisSumma 
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
