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
    public partial class Majoittumiset : Form
    {
        private DatabaseRepository dbRepository;


        public Majoittumiset()
        {
            InitializeComponent();
            dbRepository = new DatabaseRepository();

        }

        private void Form_Load(object sender, EventArgs e)
        {
            var alueet = Alue.HaeKaikkiAlueet();
            Console.WriteLine("Löytyi {0} aluetta.", alueet.Count);
            comboBox1.DataSource = alueet;
            comboBox1.DisplayMember = "Nimi";
            comboBox1.ValueMember = "AlueId";
        }

        private void comboBoxAlue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)  // Tarkistetaan, että comboboxista on valittu jokin kohde
            {
                // Oletetaan, että textBoxAlueNimi on TextBox-komponenttisi nimi
                textBox1.Text = comboBox1.Text;  // Asettaa valitun alueen nimen TextBoxiin
                //txtAlueId.Text = comboBox1.SelectedValue; //.ToString();  // Asettaa valitun alueen ID:n piilotettuun tekstikenttään
                textBox4.Text = comboBox1.SelectedValue.ToString();  // Asettaa valitun alueen ID:n piilotettuun tekstikenttään

            }
        }

        // hae datatimeepickerin arvo ja tulosta textboxiin
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerAloitus.Value;
            string dateFormatted = date.ToString("yyyy-MM-dd");
            textBox2.Text = dateFormatted;
        }

        private void dateTimePickerAloitus_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerAloitus.Value;
            string dateFormatted = startDate.ToString("yyyy-MM-dd");
            textBox2.Text = dateFormatted;

            // Tarkista myös, ettei dateTimePicker2 ole ennen dateTimePicker1
            if (dateTimePickerLopetus.Value < startDate)
            {
                MessageBox.Show("Loppupäivämäärä ei voi olla ennen alkupäivämäärää.", "Virheellinen syöte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerLopetus.Value = startDate; // Aseta kelvollinen päivämäärä
            }
        }


        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerLopetus.Value;
            string dateFormatted = date.ToString("yyyy-MM-dd");
            textBox3.Text = dateFormatted;
        }

        private void dateTimePickerLopetus_ValueChanged(object sender, EventArgs e)
        {
            // Hae dateTimePicker2:n arvo
            DateTime endDate = dateTimePickerLopetus.Value;

            // Hae dateTimePicker1:n arvo
            DateTime startDate = dateTimePickerAloitus.Value;

            if (endDate < startDate)
            {
                // Aseta dateTimePicker2:n arvoksi sama kuin dateTimePicker1:ssä
                // tai näytä virheilmoitus ja aseta arvo takaisin kelvolliseksi
                MessageBox.Show("Loppupäivämäärä ei voi olla ennen alkupäivämäärää.", "Virheellinen syöte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerLopetus.Value = startDate; // Aseta kelvollinen päivämäärä
            }
            else
            {
                // Jos päivämäärä on kelvollinen, muotoile se ja aseta tekstilaatikkoon
                string dateFormatted = endDate.ToString("yyyy-MM-dd");
                textBox3.Text = dateFormatted;
            }

      
        }

        private void btnHaePalvelut_Click(object sender, EventArgs e)
        {
            
            //int alueId = int.Parse(txtAlueId.Text); // Oletetaan, että käyttäjä syöttää alueen ID:n johonkin tekstikenttään
            //int alueId = 4;
            int alueId = Convert.ToInt32(comboBox1.SelectedValue);  // Muunnetaan valittu arvo kokonaisluvuksi
            DateTime aloitusPvm = dateTimePickerAloitus.Value;
            //DateTime aloitusPvm = new DateTime(2021, 1, 1);
            DateTime lopetusPvm = dateTimePickerLopetus.Value;
            //DateTime lopetusPvm = new DateTime(2028, 1, 1);

            DataTable palvelut = dbRepository.HaePalvelutAlueeltaJaAjalta(alueId, aloitusPvm, lopetusPvm);
            // Tee jotain haettujen tietojen kanssa, esim. näytä ne DataGridView:ssä
            dataGridView1.DataSource = palvelut;
        }


        private void LataaPalvelut()
        {
            try
            {
                int alueId = 3;
                //DateTime aloitusPvm = dateTimePickerAloitus.Value;
                DateTime aloitusPvm = new DateTime(2021, 1, 1);
                //DateTime lopetusPvm = dateTimePickerLopetus.Value;
                DateTime lopetusPvm = new DateTime(2028, 1, 1);
                dataGridView1.DataSource = dbRepository.HaePalvelutAlueeltaJaAjalta(alueId, aloitusPvm, lopetusPvm);

                dataGridView1.Refresh(); // Pakota DataGridView päivittymään

            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe laskujen lataamisessa: " + ex.Message, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
