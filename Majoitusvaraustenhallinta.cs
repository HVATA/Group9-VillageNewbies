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
    public partial class Majoitusvaraustenhallinta : Form
    {
        List<MokkiTieto> mokkiTiedot = new List<MokkiTieto>();
        public Majoitusvaraustenhallinta()
        {
            InitializeComponent();
            DatabaseRepository repository = new DatabaseRepository();
            LataaMokitKannasta();
            AlustaDataGridView();
        }

        private void header_Click(object sender, EventArgs e)
        {

        }

        private void LataaMokitDataGridViewiin()
        {
            DatabaseRepository repository = new DatabaseRepository();
            //mokkiTiedot = repository.HaeKaikkiMokit();
            dataGridViewMokit.DataSource = mokkiTiedot;
            //Lata
        }

        private void LataaMokitKannasta()//Haetaan alueet kannasta
        {

            mokkiTiedot.Clear(); // Tyhjennä lista varmuuden vuoksi
            DatabaseRepository repository = new DatabaseRepository();
            DataTable mokkiTable = repository.ExecuteQuery(@"SELECT mokki.*, alue.nimi AS alueen_nimi
                                                                FROM mokki
                                                            JOIN alue ON mokki.alue_id = alue.alue_id");

            foreach (DataRow row in mokkiTable.Rows)
            {
                MokkiTieto mokki = new MokkiTieto()
                {
                    // Aseta tiedot row:sta
                    Alue = row["alueen_nimi"].ToString(),
                    Mokkinimi = row["mokkinimi"].ToString(),
                    Postinro = row["postinro"].ToString(),
                    Katuosoite = row["katuosoite"].ToString(),
                    Hinta = row["hinta"].ToString(),
                    Kuvaus = row["kuvaus"].ToString(),
                    Henkilomaara = row["henkilomaara"].ToString(),
                    Varustelu = row["varustelu"].ToString()

                };
                mokkiTiedot.Add(mokki);
            }
        }

        private void AlustaDataGridView()
        {
            // Oletetaan, että dataGridViewMokit on DataGridView-komponenttisi nimi
            dataGridViewMokit.AutoGenerateColumns = false; // Estä automaattinen sarakkeiden luonti


            // Luodaan uusi sarake
            DataGridViewTextBoxColumn mokkinimiColumn = new DataGridViewTextBoxColumn();
            mokkinimiColumn.HeaderText = "Mökin nimi";
            mokkinimiColumn.DataPropertyName = "Mokkinimi";
            mokkinimiColumn.Width = 120; // Asetetaan leveys 150 pikseliksi
            dataGridViewMokit.Columns.Add(mokkinimiColumn);

            DataGridViewTextBoxColumn alueColumn = new DataGridViewTextBoxColumn();
            alueColumn.HeaderText = "Alue";
            alueColumn.DataPropertyName = "Alue";
            alueColumn.Width = 80; // Esimerkiksi leveys 100 pikseliksi
            dataGridViewMokit.Columns.Add(alueColumn);

            // Katuosoite-sarake
            DataGridViewTextBoxColumn katuosoiteColumn = new DataGridViewTextBoxColumn();
            katuosoiteColumn.HeaderText = "Katuosoite";
            katuosoiteColumn.DataPropertyName = "Katuosoite";
            katuosoiteColumn.Width = 140; // Leveys esimerkiksi 200 pikseliksi
            dataGridViewMokit.Columns.Add(katuosoiteColumn);

            // Hinta-sarake
            DataGridViewTextBoxColumn hintaColumn = new DataGridViewTextBoxColumn();
            hintaColumn.HeaderText = "Hinta";
            hintaColumn.DataPropertyName = "Hinta";
            hintaColumn.Width = 40; // Leveys esimerkiksi 80 pikseliksi
            dataGridViewMokit.Columns.Add(hintaColumn);

            // Kuvaus-sarake
            DataGridViewTextBoxColumn kuvausColumn = new DataGridViewTextBoxColumn();
            kuvausColumn.HeaderText = "Kuvaus";
            kuvausColumn.DataPropertyName = "Kuvaus";
            kuvausColumn.Width = 200; // Leveys esimerkiksi 250 pikseliksi
            dataGridViewMokit.Columns.Add(kuvausColumn);

            // Henkilömäärä-sarake
            DataGridViewTextBoxColumn henkilomaaraColumn = new DataGridViewTextBoxColumn();
            henkilomaaraColumn.HeaderText = "Henkilömäärä";
            henkilomaaraColumn.DataPropertyName = "Henkilomaara";
            henkilomaaraColumn.Width = 40; // Leveys esimerkiksi 100 pikseliksi
            dataGridViewMokit.Columns.Add(henkilomaaraColumn);

            // Varustelu-sarake
            DataGridViewTextBoxColumn varusteluColumn = new DataGridViewTextBoxColumn();
            varusteluColumn.HeaderText = "Varustelu";
            varusteluColumn.DataPropertyName = "Varustelu";
            varusteluColumn.Width = 200; // Leveys esimerkiksi 200 pikseliksi
            dataGridViewMokit.Columns.Add(varusteluColumn);


            // Sidotaan data uudestaan
            dataGridViewMokit.DataSource = null;
            dataGridViewMokit.DataSource = mokkiTiedot; // Oletetaan, että mokkiTiedot on List<MokkiTieto>, jossa on mökkien tiedot
        }


        private void dataGridViewMokit_SelectionChanged(object sender, EventArgs e)
        {
            // Haetaan valitun rivin tiedot ja asetetaan ne tekstikenttiin
            if (dataGridViewMokit.SelectedRows.Count > 0)
            {
                MokkiTieto valittuMokki = (MokkiTieto)dataGridViewMokit.SelectedRows[0].DataBoundItem;
                textBoxNimi.Text = valittuMokki.Mokkinimi;
                //textBoxPostinro.Text = valittuMokki.Postinro;
                textBoxOsoite.Text = valittuMokki.Katuosoite;
                textBoxHinta.Text = valittuMokki.Hinta;
                //textBoxKuvaus.Text = valittuMokki.Kuvaus;
                textBoxHenkilomaara.Text = valittuMokki.Henkilomaara;
                textBoxVarustelu.Text = valittuMokki.Varustelu;
            }
        }
    }
}
