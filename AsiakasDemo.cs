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
            AsiakasRepository asiakasRepository = new AsiakasRepository();
            List<Asiakas> asiakkaat = asiakasRepository.HaeAsiakkaat();

            MessageBox.Show("Asiakkaita haettu: " + asiakkaat.Count);


            foreach (Asiakas asiakas in asiakkaat)
            {
                listBox1.Items.Add(asiakas.Etunimi);
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
