using Group9_VillageNewbies;
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
    public partial class AsiakasDemo : Form
    {

        public AsiakasDemo()

        {
            InitializeComponent();


            //tähän kutsu asiakaslistan hakuun
            //AsiakasRepository asiakasRepository = new AsiakasRepository();
            //List<Asiakas> asiakkaat = asiakasRepository.HaeAsiakkaat();

            //foreach (Asiakas asiakas in asiakkaat)
            //{
            //    listBox1.Items.Add(asiakas.Etunimi);
            //}

            DatabaseRepository repository = new DatabaseRepository();
            DataTable asiakkaatTable = repository.ExecuteQuery("SELECT * FROM asiakas");
            DataTable mokitTable = repository.ExecuteQuery("SELECT * FROM mokki");


            foreach (DataRow row in asiakkaatTable.Rows)
            {
                listBox1.Items.Add(row["etunimi"]);
            }

            foreach (DataRow row in mokitTable.Rows)
            {
                listBox2.Items.Add(row["mokkinimi"]);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
