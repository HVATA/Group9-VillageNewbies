using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Group9_VillageNewbies
{
    public partial class MokkiAluehallinta : Form
    {
        List<AlueTieto> alueTiedot = new List<AlueTieto>();
        public MokkiAluehallinta()
        {
            InitializeComponent();
            LataaAlueetKannasta();
            PaivitaAlueLista();
        }
        private void LataaAlueetKannasta()//Haetaan alueet kannasta
        {   

            alueTiedot.Clear(); // Tyhjennä lista varmuuden vuoksi
            DatabaseRepository repository = new DatabaseRepository();
            DataTable alueTable = repository.ExecuteQuery(@"SELECT * FROM alue");

            foreach (DataRow row in alueTable.Rows)
            {
                AlueTieto alue = new AlueTieto()
                {
                    // Aseta tiedot row:sta
                    AlueNimi = row["nimi"].ToString(),


                };
                alueTiedot.Add(alue);
            }
        }
        private void PaivitaAlueLista()//Lisätää haetut alueet listaan
        {
            listBoxAlue.Items.Clear(); // Tyhjennä listbox ennen uusien tietojen lisäämistä

            // Käydään läpi asiakasTiedot-lista ja lisätään jokainen asiakas ListBoxiin
            foreach (var alue in alueTiedot)
            {
                // Muodosta merkkijono, jossa on asiakkaan tiedot ja lisää se ListBoxiin
                string alueTieto = $"{alue.AlueNimi}";
                listBoxAlue.Items.Add(alueTieto);
            }
        }
        
        private void btnClearAlue_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAlue_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeAlue_Click(object sender, EventArgs e)
        {

        }

        private void BtnDeleteAlue_Click(object sender, EventArgs e)
        {

        }

        private void btnClearMokki_Click(object sender, EventArgs e)
        {

        }

        private void btnAddMokki_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeMokki_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteMokki_Click(object sender, EventArgs e)
        {

        }

        private void btnPalveluihin_Click(object sender, EventArgs e)
        {
            Palveluhallinta pavela = new Palveluhallinta();
            pavela.ShowDialog();
        }

        private void listBoxAlue_SelectedIndexChanged(object sender, EventArgs e)//asetetaan listboxista tieto textboxiin.
        {
            if (listBoxAlue.SelectedIndex != -1)
            {
                var tiedot = listBoxAlue.SelectedItem.ToString();
                textBoxAlue.Text = tiedot;
            }
        }

        private void listBoxMokki_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxAlue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
