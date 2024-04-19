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
    public partial class MajoitusVaraustenHallintaUusi : Form
    {
        List<AlueTieto> alueTiedot = new List<AlueTieto>();
        List<MokkiTieto> mokkiTiedot = new List<MokkiTieto>();
        List<AsiakasTieto> asiakasTiedot = new List<AsiakasTieto>();
        public string connectionString = "DSN=Village Newbies;Uid=root;Pwd=root1;";
        public string sFindAlue = "";
        public string sFindMokki = "";
        public string sFindAsiakas = "";
        public string hakuquery;
        public MajoitusVaraustenHallintaUusi()
        {
            InitializeComponent();
            LataaAlueetKannasta();
            LataaMokitKannasta();
            LataaAsiakkaatTietokannasta();
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
                    Alue_id = row["alue_id"].ToString(),

                };
                alueTiedot.Add(alue);

            }
            alueTiedot.Sort((a, b) => string.Compare(a.Alue_id, b.Alue_id)); //Järjestetää listaan alue_id:n mukaisesti
            foreach(AlueTieto al in alueTiedot) 
            { 
                comboBox_VarFindAlue.Items.Add(al.AlueNimi);
            }
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
                    Mokki_id = row["mokki_id"].ToString(),
                    Alue = row["alueen_nimi"].ToString(),
                    Postinro = row["postinro"].ToString(),
                    Mokkinimi = row["mokkinimi"].ToString(),
                    Katuosoite = row["katuosoite"].ToString(),
                    Hinta = row["hinta"].ToString(),
                    Kuvaus = row["kuvaus"].ToString(),
                    Henkilomaara = row["henkilomaara"].ToString(),
                    Varustelu = row["varustelu"].ToString()

                };
                mokkiTiedot.Add(mokki);
            }
            foreach (MokkiTieto mok in mokkiTiedot)
            {
                comboBox_VarFindMokki.Items.Add(mok.Mokkinimi);
            }
        }
        private void LataaAsiakkaatTietokannasta()
        {
            DatabaseRepository repository = new DatabaseRepository();
            asiakasTiedot.Clear(); // Tyhjennä lista varmuuden vuoksi
            DataTable asiakkaatTable = repository.ExecuteQuery(@"SELECT a.asiakas_id, a.etunimi, a.sukunimi, a.lahiosoite, a.postinro, p.toimipaikka, a.puhelinnro, a.email FROM asiakas a JOIN posti p ON a.postinro = p.postinro");

            foreach (DataRow row in asiakkaatTable.Rows)
            {
                AsiakasTieto asiakas = new AsiakasTieto()
                {
                    // Aseta tiedot row:sta
                    AsiakasId = row["asiakas_id"] != DBNull.Value ? Convert.ToInt32(row["asiakas_id"]) : 0,
                    Etunimi = row["etunimi"].ToString(),
                    Sukunimi = row["sukunimi"].ToString(),
                    Lahiosoite = row["lahiosoite"].ToString(),
                    Postinro = row["postinro"].ToString(),
                    Toimipaikka = row["toimipaikka"].ToString(),
                    Puhelinnro = row["puhelinnro"].ToString(),
                    Email = row["email"].ToString(),

                };
                asiakasTiedot.Add(asiakas);
            }
            foreach (AsiakasTieto asiak in asiakasTiedot)
            {
                comboBox_VarFindAsiakas.Items.Add(asiak.Etunimi + " " + asiak.Sukunimi + " " + asiak.AsiakasId);
            }
        }
        private void btn_back2menuVar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PaivitaGridview()
        {
            try
            {
                
                OdbcConnection connection = new OdbcConnection(connectionString);
                connection.Open();
                DataTable dataTable = new DataTable();
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(hakuquery, connection))
                {
                    adapter.FillSchema(dataTable, SchemaType.Source);
                    adapter.Fill(dataTable);
                }
                dataGridView_Varaus.DataSource = dataTable;

                dataGridView_Varaus.Columns[0].HeaderText = "Varaustunnus";
                dataGridView_Varaus.Columns[1].HeaderText = "Asiakastunnus";
                dataGridView_Varaus.Columns[2].HeaderText = "Mökki";
                dataGridView_Varaus.Columns[3].HeaderText = "Varaus tehty";
                dataGridView_Varaus.Columns[4].HeaderText = "Varaus vahvistettu";
                dataGridView_Varaus.Columns[5].HeaderText = "Varauksen alkupäivä";
                dataGridView_Varaus.Columns[6].HeaderText = "Varauksen päättymispäivä";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void PaivitaMokkiComboBox()
        {
            comboBox_VarFindMokki.Items.Clear();
            comboBox_VarFindMokki.Items.Add("Valitse mokki");
            foreach (MokkiTieto mokki in mokkiTiedot)
            {
                if(mokki.Alue == sFindAlue) 
                {
                    comboBox_VarFindMokki.Items.Add(mokki.Mokkinimi);
                }
            }
        }

        private void btn_EtsiVaraus_Click(object sender, EventArgs e)
        {
            string sAlueId = ""; //tähä tee ehdolliset hakuqueryt riippuen hausta!
            string sMokkiId = "";
            string sAsiakasId = "";
            if (comboBox_VarFindAlue.SelectedIndex > -1 && comboBox_VarFindMokki.SelectedIndex > -1) //alue ja mokki etsintä
            {
                foreach (AlueTieto al in alueTiedot)
                {
                    if (al.AlueNimi == sFindAlue)
                    {
                        sAlueId = al.Alue_id;
                    }
                }
                foreach (MokkiTieto mok in mokkiTiedot)
                {
                    if (mok.Mokkinimi == sFindMokki)
                    {
                        sMokkiId = mok.Mokki_id;
                    }
                }
                MessageBox.Show("Haetaan varaukset kohdasta: " + sFindAlue + ", " + sFindMokki);
                hakuquery = "SELECT * FROM varaus WHERE mokki_mokki_id = " + sMokkiId + ";";
                PaivitaGridview();
            }
            if (comboBox_VarFindMokki.SelectedIndex > -1 && comboBox_VarFindAsiakas.SelectedIndex > -1) //mokki ja asiakas etsintä
            {
                foreach (AsiakasTieto asiak in asiakasTiedot)
                {
                    if (asiak.AsiakasId.ToString() == sFindAsiakas)
                    {
                        sAsiakasId = asiak.AsiakasId.ToString();
                    }
                }
                foreach (MokkiTieto mok in mokkiTiedot)
                {
                    if (mok.Mokkinimi == sFindMokki)
                    {
                        sMokkiId = mok.Mokki_id;
                    }
                }
                MessageBox.Show("Haetaan varaukset kohdasta: " + sFindMokki + ", " + sFindAsiakas);
                hakuquery = "SELECT * FROM varaus WHERE mokki_mokki_id = " + sMokkiId + " AND asiakas_id = " + sAsiakasId + ";";
                PaivitaGridview();
            }
            else if (comboBox_VarFindAlue.SelectedIndex > -1) //alue-etsintä
            {
                foreach (AlueTieto al in alueTiedot)
                {
                    if (al.AlueNimi == sFindAlue)
                    {
                        sAlueId = al.Alue_id;
                    }
                }
                MessageBox.Show("Haetaan varaukset kohdasta: " + sFindAlue); //Tarkistus
                hakuquery = "SELECT * FROM varaus WHERE mokki_mokki_id IN (SELECT mokki_id FROM mokki WHERE alue_id = " + sAlueId + ");";
                PaivitaGridview();
            }
            else if (comboBox_VarFindMokki.SelectedIndex > -1)//mokki-etsintä
            {
                foreach (MokkiTieto mok in mokkiTiedot)
                {
                    if (mok.Mokkinimi == sFindMokki)
                    {
                        sMokkiId = mok.Mokki_id;
                    }
                }
                MessageBox.Show("Haetaan varaukset kohdasta: " + sFindMokki); //Tarkistus
                hakuquery = "SELECT * FROM varaus WHERE mokki_mokki_id = " + sMokkiId + ";";
                PaivitaGridview();
            }
            else if (comboBox_VarFindAsiakas.SelectedIndex > -1)//asiakas-etsintä
            {
                foreach (AsiakasTieto asiak in asiakasTiedot)
                {
                    if (asiak.AsiakasId.ToString() == sFindAsiakas)
                    {
                        sAsiakasId = asiak.AsiakasId.ToString();
                    }
                }
                MessageBox.Show("Haetaan varaukset kohdasta: " + sFindAsiakas); //Tarkistus
                hakuquery = "SELECT * FROM varaus WHERE mokki_mokki_id = " + sAsiakasId + ";";
                PaivitaGridview();
            }
            
            

        }

        private void MajoitusVaraustenHallintaUusi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.varaus' table. You can move, or remove it, as needed.
            this.varausTableAdapter.Fill(this.dataSet2.varaus);
            // TODO: This line of code loads data into the 'dataSet1.palvelu' table. You can move, or remove it, as needed.
            this.palveluTableAdapter.Fill(this.dataSet1.palvelu);

        }

        private void btn_toAddEditDelete_Click(object sender, EventArgs e)
        {
            
            AsiakasKysyPopUp askypop = new AsiakasKysyPopUp();
            askypop.Show();
        }
        private void comboBox_VarFindAlue_SelectedIndexChanged(object sender, EventArgs e)
        {
            sFindAlue = comboBox_VarFindAlue.SelectedIndex.ToString();
            foreach (var alue in alueTiedot)
            {
                if (alue.AlueNimi == comboBox_VarFindAlue.Text)
                {
                    sFindAlue = alue.AlueNimi;
                }
            }
            MessageBox.Show(sFindAlue);
            PaivitaMokkiComboBox();
        }
        private void comboBox_VarFindMokki_SelectedIndexChanged(object sender, EventArgs e)
        {
            sFindMokki = comboBox_VarFindMokki.SelectedIndex.ToString();
            foreach(var mokki in mokkiTiedot)
            {
                if(mokki.Mokkinimi == comboBox_VarFindMokki.Text)
                {
                    sFindMokki = mokki.Mokkinimi;
                }
            }
            MessageBox.Show(sFindMokki);
        }


        private void comboBox_VarFindAsiakas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_VarFindAsiakas.SelectedItem != null)
            {
                string itemText = comboBox_VarFindAsiakas.SelectedItem.ToString(); // Käytä valitun kohteen tekstiä
                string[] parts = itemText.Split(' ');
                if (parts.Length >= 3) // Tarkista, että osia on tarpeeksi
                {
                    string aEtunimi = parts[0].Trim();
                    string aSukunimi = parts[1].Trim();
                    string aId = parts[2].Trim();
                    foreach (var asiakas in asiakasTiedot)
                    {
                        if (asiakas.AsiakasId.ToString() == aId) // Vertaa asiakas ID:tä, ei toimipaikkaa
                        {
                            sFindAsiakas = aId;
                        }
                    }
                }
                MessageBox.Show(sFindAsiakas);
            }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void emptyHakuEhdot_Click(object sender, EventArgs e)
        {
            if (comboBox_VarFindMokki != null)
                comboBox_VarFindMokki.SelectedItem = null;

            if (comboBox_VarFindAlue != null)
                comboBox_VarFindAlue.SelectedItem = null;

            if (comboBox_VarFindAsiakas != null)
                comboBox_VarFindAsiakas.SelectedItem = null;

            
        }
    }
}
