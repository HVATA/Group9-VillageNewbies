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
        List<Alue> aluetiedot = new List<Alue>();
        List<Palvelu> palveluntiedot = new List<Palvelu> ();
        
        public Palveluhallinta()
            {
            InitializeComponent ();
            LataaAlueetTietokannasta();
            }
            private void LataaAlueetTietokannasta()
            {
                DatabaseRepository repository = new DatabaseRepository();
                aluetiedot.Clear(); //Listan tyhjennys varmuuden vuoksi
            DataTable alueTable = repository.ExecuteQuery(@"select alue_id, nimi FROM alue");

            foreach (DataRow row in alueTable.Rows)
                {
                // Assuming you have a class called AlueLista to represent area data
                Alue alue = new Alue
                    {
                    AlueId = Convert.ToInt32(row["alue_id"]),
                    Nimi = row["nimi"].ToString()
                    };

                aluetiedot.Add(alue);

                // Add area names to the ComboBox
                alueComboBox.Items.Add(alue.Nimi);
                }
            }

        private void fillByToolStripButton_Click ( object sender, EventArgs e )
            {
            try
                {
                this.palveluTableAdapter.FillBy(this.dataSet1.palvelu);
                }
            catch (System.Exception ex)
                {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
        }
    }
