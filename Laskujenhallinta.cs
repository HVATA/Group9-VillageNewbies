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

        private void ClearDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh(); // Pakota DataGridView päivittymään
        }


    }
}
