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
    public partial class Palveluhallinta : Form
        {
        public Palveluhallinta ()
            {
            InitializeComponent();

            DatabaseRepository repository = new DatabaseRepository();
            DataTable palvelutTable = repository.ExecuteQuery("SELECT * FROM palvelu");

            foreach (DataRow row in palvelutTable.Rows)
                {
                string palveluTiedot = string.Format("{0} {1}, {2}, {3}, {4}",
                    row["palvelu_id"],
                    row["nimi"],
                    row["kuvaus"],
                    row["hinta"],
                    row["alv"]);

                listBox1.Items.Add(palveluTiedot);
                }    

                
            }

        private void btnAdd_Click(object sender, EventArgs e)
            {

            }

        private void btnChange_Click(object sender, EventArgs e)
            {

            }

        private void btnDelete_Click(object sender, EventArgs e)
            {

            }

        private void btnSelect_Click(object sender, EventArgs e)
            {
                
            }
        }
    }
