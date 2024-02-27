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


            DatabaseRepository repository = new DatabaseRepository();
            DataTable asiakkaatTable = repository.ExecuteQuery("SELECT * FROM asiakas");
            DataTable mokitTable = repository.ExecuteQuery("SELECT * FROM mokki");


            foreach (DataRow row in asiakkaatTable.Rows)
            {
                // Rakenna merkkijono, jossa kaikki halutut kentät ovat eroteltuna pilkulla ja välilyönnillä
                string asiakasTiedot = string.Format("{0} {1}, {2}, {3} {4}, {5}, {6}",
                    row["etunimi"],
                    row["sukunimi"],
                    row["lahiosoite"],
                    row["postinro"],
                    row["paikkakunta"],
                    row["puhelinnro"],
                    row["email"]);

                // Lisää muodostettu merkkijono ListBoxiin
                listBox1.Items.Add(asiakasTiedot);
            }

            if (asiakkaatTable.Rows.Count > 0)
            {
                DataRow row = asiakkaatTable.Rows[0]; // Oletetaan, että haluamme näyttää vain ensimmäisen tietueen

                textBox1.Text = row["etunimi"].ToString();
                textBox2.Text = row["sukunimi"].ToString();
                textBox3.Text = row["lahiosoite"].ToString();
                textBox4.Text = row["postinro"].ToString();
                textBox5.Text = row["paikkakunta"].ToString();
                textBox6.Text = row["puhelinnro"].ToString();
                textBox7.Text = row["email"].ToString();
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
