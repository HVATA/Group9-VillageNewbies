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
            //DataTable asiakkaatTable = repository.ExecuteQuery("SELECT * FROM asiakas");
            DataTable asiakkaatTable = repository.ExecuteQuery(@"
                SELECT 
                    a.etunimi, 
                    a.sukunimi, 
                    a.lahiosoite, 
                    a.postinro, 
                    p.toimipaikka, 
                    a.puhelinnro, 
                    a.email 
                FROM asiakas a
                JOIN posti p ON a.postinro = p.postinro");

            foreach (DataRow row in asiakkaatTable.Rows)
            {
                // Rakenna merkkijono, jossa kaikki halutut kentät ovat eroteltuna pilkulla ja välilyönnillä
                string asiakasTiedot = string.Format("{0} {1}, {2}, {3} {4}, {5}, {6}",
                    row["etunimi"],
                    row["sukunimi"],
                    row["lahiosoite"],
                    row["postinro"],
                    row["toimipaikka"],
                    row["puhelinnro"],
                    row["email"]);

                // Lisää muodostettu merkkijono ListBoxiin
                listBox1.Items.Add(asiakasTiedot);
            }

            //if (asiakkaatTable.Rows.Count > 0)
            //{
            //    DataRow row = asiakkaatTable.Rows[0]; // Oletetaan, että haluamme näyttää vain ensimmäisen tietueen
            //
            //    textBox1.Text = row["etunimi"].ToString();
            //    textBox2.Text = row["sukunimi"].ToString();
            //    textBox3.Text = row["lahiosoite"].ToString();
            //    textBox4.Text = row["postinro"].ToString();
            //    textBox5.Text = row["toimipaikka"].ToString(); // Huom! Tämä on postinumero-taulusta, ei asiakas-taulusta
            //    textBox6.Text = row["puhelinnro"].ToString();
            //    textBox7.Text = row["email"].ToString();
            //}


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        // Metodi joka suoritetaan kun käyttäjä valitsee jonkun asiakkaan ListBoxista
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var tiedot = listBox1.SelectedItem.ToString().Split(',');
                if (tiedot.Length >= 5) // Varmista, että kaikki kentät ovat läsnä
                {
                    // Erota nimet (oletetaan, että ne ovat ensimmäisessä kentässä ja erotettu pilkuilla)
                    var nimet = tiedot[0].Trim().Split(' ');
                    if (nimet.Length > 2)
                    {
                        textBox1.Text = string.Join(" ", nimet.Take(nimet.Length - 1)); // Etunimet
                        textBox2.Text = nimet.Last(); // Sukunimi
                    }
                    else if (nimet.Length == 2)
                    {
                        textBox1.Text = nimet[0]; // Etunimi
                        textBox2.Text = nimet[1]; // Sukunimi
                    }

                    textBox3.Text = tiedot[1].Trim(); // Osoite (sisältää talonumeron)

                    // Erota postinumero ja paikkakunta (oletetaan, että ne ovat kolmannessa kentässä)
                    var postiJaPaikka = tiedot[2].Trim().Split(' ');
                    if (postiJaPaikka.Length >= 2)
                    {
                        textBox4.Text = postiJaPaikka[0]; // Postinumero
                        textBox5.Text = string.Join(" ", postiJaPaikka.Skip(1)); // Paikkakunta
                    }

                    textBox6.Text = tiedot[3].Trim(); // Puhelinnumero
                    textBox7.Text = tiedot[4].Trim(); // Sähköpostiosoite
                }
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
