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
        private System.Windows.Forms.ComboBox alueComboBox;
        private System.Windows.Forms.ListBox palveluListBox;
        private DatabaseRepository repository;

        public Palveluhallinta ()
            {
            InitializeComponent();

            repository = new DatabaseRepository();

            // Luo ComboBox
            alueComboBox = new ComboBox();
            alueComboBox.Location = new System.Drawing.Point(10, 10); // Määritä sijainti tarpeidesi mukaan
            alueComboBox.SelectedIndexChanged += AlueComboBox_SelectedIndexChanged;

            // Luo ListBox
            palveluListBox = new ListBox();
            palveluListBox.Location = new System.Drawing.Point(10, 40); // Määritä sijainti tarpeidesi mukaan

            Controls.Add(alueComboBox);
            Controls.Add(palveluListBox);

            // Lataa alueet ComboBoxiin
            PäivitäAlueet();
            }

        private void PäivitäAlueet ()
            {
            try
                {
                // Haetaan alueiden tiedot tietokannasta
                DataTable alueetTable = repository.ExecuteQuery("SELECT * FROM alue");

                // Tyhjennä ComboBox
                alueComboBox.Items.Clear();

                // Lisää alueet ComboBoxiin
                foreach (DataRow row in alueetTable.Rows)
                    {
                    alueComboBox.Items.Add(new Alue
                        {
                        AlueId = Convert.ToInt32(row["alue_id"]),
                        Nimi = row["nimi"].ToString()
                        });
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show($"Virhe päivitettäessä alueita: {ex.Message}");
                }
            }

        private void PäivitäPalvelut ( int alueId )
            {
            DataTable palvelutTable = repository.ExecuteQuery($"SELECT * FROM palvelu WHERE alue_id = {alueId}");

            palveluListBox.Items.Clear(); // Tyhjennä lista ennen päivittämistä

            foreach (DataRow row in palvelutTable.Rows)
                {
                string palveluTiedot = string.Format("{0} {1}, {2}, {3}, {4}",
                    row["palvelu_id"],
                    row["nimi"],
                    row["kuvaus"],
                    row["hinta"],
                    row["alv"]);

                palveluListBox.Items.Add(palveluTiedot);
                }
            }

        private void AlueComboBox_SelectedIndexChanged ( object sender, EventArgs e )
            {
            // Kun alueen valinta muuttuu, päivitä palvelut
            if (alueComboBox.SelectedItem is Alue valittuAlue)
                {
                PäivitäPalvelut(valittuAlue.AlueId);
                }
            }

        
        }
    }
