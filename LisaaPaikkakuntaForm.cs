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

namespace Group9_VillageNewbies
{
    public partial class LisaaPaikkakuntaForm : Form
    {
        public LisaaPaikkakuntaForm()
        {
            InitializeComponent();

          

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Tarkista syötteet
            if (string.IsNullOrWhiteSpace(txtPostinumero.Text) || string.IsNullOrWhiteSpace(txtPaikkakunta.Text))
            {
                MessageBox.Show("Syötä sekä postinumero että paikkakunta.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lisää paikkakunta tietokantaan
            try
            {
                using (OdbcConnection connection = new OdbcConnection("DSN=Village Newbies;Uid=root;Pwd=root1;"))
                {
                    string query = "INSERT INTO posti (postinro, toimipaikka) VALUES (?, ?)";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("postinro", txtPostinumero.Text.Trim());
                        command.Parameters.AddWithValue("toimipaikka", txtPaikkakunta.Text.Trim());

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Paikkakunta lisätty onnistuneesti.", "Lisätty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Asetetaan lomakkeen DialogResult, jotta pääohjelma tietää päivittää paikkakuntien listan
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Virhe tietokantaan lisättäessä: {ex.Message}", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
