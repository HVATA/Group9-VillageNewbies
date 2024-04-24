

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
    public partial class VarausAddEditDelete : Form
    {
        List<AlueTieto> alueTiedot = new List<AlueTieto>();
        List<MokkiTieto> mokkiTiedot = new List<MokkiTieto>();
        List<AsiakasTieto> asiakasTiedot = new List<AsiakasTieto>();
        List<Palvelu> palveluTiedot = new List<Palvelu>();
        List<Varaus> varausTiedot = new List<Varaus>();
        public string connectionString = "DSN=Village Newbies;Uid=root;Pwd=root1;";
        public string lisaysquery;
        public string poistoquery;
        public string muokkausquery;
        public string hakuquery;
        public string sAlueMok;
        public int varaus_id = 0;
        public int asiakas_id;
        public int mokki_mokki_id;
        DateTime varattu_pvm = DateTime.Now;
        DateTime vahvistus_pvm = DateTime.Now;
        DateTime varattu_alkupvm = DateTime.Now;
        DateTime varattu_loppupvm = DateTime.Now;
        public VarausAddEditDelete()
        {
            InitializeComponent();
            LataaAlueetKannasta();
            LataaMokitKannasta();
            LataaAsiakkaatTietokannasta();
            LataaPalvelutKannasta();
            LataaVarauksetKannasta();
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
            foreach (AlueTieto al in alueTiedot)
            {
                comboBox_VarVarAlue.Items.Add(al.AlueNimi);
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
                comboBox_VarVarMokki.Items.Add(mok.Mokkinimi);
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
                comboBox_VarVarAsiakas.Items.Add(asiak.Etunimi + " " + asiak.Sukunimi + "," + asiak.AsiakasId);
            }
        }
        private void LataaPalvelutKannasta()//Haetaan alueet kannasta
        {

            palveluTiedot.Clear(); // Tyhjennä lista varmuuden vuoksi
            DatabaseRepository repository = new DatabaseRepository();
            DataTable palveluTable = repository.ExecuteQuery("SELECT p.palvelu_id, p.nimi, p.kuvaus, p.hinta, p.alv, p.alue_id, a.nimi AS alueen_nimi " +
                                                            "FROM palvelu p " +
                                                            "INNER JOIN alue a ON p.alue_id = a.alue_id");

            foreach (DataRow row in palveluTable.Rows)
            {
                Palvelu palvelu = new Palvelu(

                    Convert.ToInt32(row["palvelu_id"]),
                    row["nimi"].ToString(),
                    row["kuvaus"].ToString(),
                    row["hinta"].ToString(),
                    Convert.ToInt32(row["alv"]),
                    Convert.ToInt32(row["alue_id"]),
                    row["alueen_nimi"].ToString()
                );

                palveluTiedot.Add(palvelu);
            }
            foreach (Palvelu pal in palveluTiedot)
            {
                comboBox_VarVarPalvelut.Items.Add(pal.Nimi);
            }
        }
        private void LataaVarauksetKannasta()//Haetaan alueet kannasta
        {

            varausTiedot.Clear(); // Tyhjennä lista varmuuden vuoksi
            DatabaseRepository repository = new DatabaseRepository();
            DataTable varausTable = repository.ExecuteQuery("SELECT * from varaus");

            foreach (DataRow row in varausTable.Rows)
            {
                Varaus varaus = new Varaus(

                    Convert.ToInt32(row["varaus_id"]),
                    Convert.ToInt32(row["asiakas_id"]),
                    Convert.ToInt32(row["mokki_mokki_id"]),
                    Convert.ToDateTime(row["varattu_pvm"]),
                    Convert.ToDateTime(row["vahvistus_pvm"]),
                    Convert.ToDateTime(row["varattu_alkupvm"]),
                    Convert.ToDateTime(row["varattu_loppupvm"])
                );
                varausTiedot.Add(varaus);
            }
        }
        
        private void btn_back2Var_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VarausAddEditDelete_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.varaus' table. You can move, or remove it, as needed.
            this.varausTableAdapter.Fill(this.dataSet2.varaus);

        }

        private void btn_LisaaVaraus_Click(object sender, EventArgs e)
        {
            if (comboBox_VarVarAlue.SelectedIndex == -1)
            {
                MessageBox.Show("Valise alue");
            }
            else if (comboBox_VarVarMokki.SelectedIndex == -1)
            {
                MessageBox.Show("Valise mökki");
            }
            else if (comboBox_VarVarAsiakas.SelectedIndex == -1)
            {
                MessageBox.Show("Valise asiakas");
            }
            else
            {
                int suurinId = 0;
                foreach(Varaus v in varausTiedot)
                {
                    if(v.Varaus_id > suurinId)
                    {
                        suurinId = v.Varaus_id;
                    }
                }
                varaus_id = suurinId + 1;
                Varaus uusiVaraus = new Varaus(
                    varaus_id, asiakas_id, mokki_mokki_id,
                    varattu_pvm, vahvistus_pvm, varattu_alkupvm,
                    varattu_loppupvm);
                DatabaseRepository db = new DatabaseRepository();
                db.LisaaVaraus(uusiVaraus);
                LataaVarauksetKannasta();
                UpdateDataGridView();

            }
        }
        private void UpdateDataGridView()
        {
           
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = varausTiedot;
        }

        private void btn_EditVaraus_Click(object sender, EventArgs e)
        {
            if (comboBox_VarVarAlue.SelectedIndex == -1)
            {
                MessageBox.Show("Valise alue");
            }
            else if (comboBox_VarVarMokki.SelectedIndex == -1)
            {
                MessageBox.Show("Valise mökki");
            }
            else if (comboBox_VarVarAsiakas.SelectedIndex == -1)
            {
                MessageBox.Show("Valise asiakas");
            }
            else
            {
                Varaus pVaraus = new Varaus(
                    varaus_id, asiakas_id, mokki_mokki_id,
                    varattu_pvm, vahvistus_pvm, varattu_alkupvm,
                    varattu_loppupvm);
                DatabaseRepository db = new DatabaseRepository();
                db.MuutaVaraus(pVaraus);
                LataaVarauksetKannasta();
                UpdateDataGridView();

            }
        }

        private void btn_DeleteVaraus_Click(object sender, EventArgs e)
        {
            Varaus pVaraus = new Varaus(
                    varaus_id, asiakas_id, mokki_mokki_id,
                    varattu_pvm, vahvistus_pvm, varattu_alkupvm,
                    varattu_loppupvm);
            DatabaseRepository db = new DatabaseRepository();
            db.PoistaVaraus(pVaraus);
            LataaVarauksetKannasta();
            UpdateDataGridView();

        }

        private void comboBox_VarVarPalvelut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_VarVarAlue_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_VarVarMokki.Items.Clear();
            foreach (MokkiTieto mokki in mokkiTiedot)
            {
                if (mokki.Alue == comboBox_VarVarAlue.Text)
                {
                    comboBox_VarVarMokki.Items.Add(mokki.Mokkinimi);
                }
            }
        }

        private void comboBox_VarVarMokki_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (MokkiTieto mok in mokkiTiedot)
            {
                if (mok.Mokkinimi == comboBox_VarVarMokki.Text)
                {
                    mokki_mokki_id = Convert.ToInt32(mok.Mokki_id);
                }
            }
        }

        private void comboBox_VarVarAsiakas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string splitData = comboBox_VarVarAsiakas.Text;
            string[] osat = splitData.Split(',');
            string nimi = osat[0];
            string id = osat[1];
            foreach (AsiakasTieto asiakas in asiakasTiedot)
            {
                if (asiakas.AsiakasId.ToString() == id)
                {
                    asiakas_id = asiakas.AsiakasId;
                }
            }
        }

        private void dateTimePickerVarStart_ValueChanged(object sender, EventArgs e)
        {
            varattu_alkupvm = dateTimePickerVarStart.Value;
        }

        private void dateTimePickerVarEnd_ValueChanged(object sender, EventArgs e)
        {
            varattu_loppupvm = dateTimePickerVarEnd.Value;
        }

        private void btn_AddPalveluToVaraus_Click(object sender, EventArgs e)
        {
            if (comboBox_VarVarPalvelut.SelectedIndex == -1)
            {
                MessageBox.Show("Valise palvelu");
            }
        }

        private void btn_deleteVarPalvelu_Click(object sender, EventArgs e)
        {
            if (listBox_VarValitutPalvelut.SelectedIndex == -1)
            {
                MessageBox.Show("Valise palvelu");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
   
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Haetaan tiedot valitusta DataGridView-rivistä
                int varausId = Convert.ToInt32(row.Cells["varausidDataGridViewTextBoxColumn"].Value);
                int asiakasId = Convert.ToInt32(row.Cells["asiakasidDataGridViewTextBoxColumn"].Value);
                int mokkiId = Convert.ToInt32(row.Cells["mokkimokkiidDataGridViewTextBoxColumn"].Value);
                DateTime varattu_pvm = Convert.ToDateTime(row.Cells["varattupvmDataGridViewTextBoxColumn"].Value);
                DateTime vahvistus_pvm = Convert.ToDateTime(row.Cells["vahvistuspvmDataGridViewTextBoxColumn"].Value);
                DateTime varattu_alkupvm = Convert.ToDateTime(row.Cells["varattualkupvmDataGridViewTextBoxColumn"].Value);
                DateTime varattu_loppupvm = Convert.ToDateTime(row.Cells["varattuloppupvmDataGridViewTextBoxColumn"].Value);
                varaus_id = varausId;
                // Luodaan uusi Varaus-olio ja asetetaan sille arvot valitusta DataGridView-rivistä
                Varaus varaus = new Varaus
                {
                    Varaus_id = varausId,
                    Asiakas_id = asiakasId,
                    Mokki_Mokki_id = mokkiId,
                    Varattu_pvm = varattu_pvm,
                    Vahvistu_pvm = vahvistus_pvm,
                    Varattu_alkupvm = varattu_alkupvm,
                    Varattu_loppupvm = varattu_loppupvm
                };
                foreach (MokkiTieto mok in mokkiTiedot)
                {
                    if (Convert.ToInt32(mok.Mokki_id) == varaus.Mokki_Mokki_id)
                    {
                        comboBox_VarVarMokki.Text = mok.Mokkinimi;
                        sAlueMok = mok.Alue;
                    }
                }
                foreach (AsiakasTieto asiak in asiakasTiedot)
                {
                    if (varaus.Asiakas_id == Convert.ToInt32(asiak.AsiakasId))
                    {
                        comboBox_VarVarAsiakas.Text = asiak.Etunimi + " " + asiak.Sukunimi + "," + asiak.AsiakasId;
                    }
                }
                foreach(AlueTieto alue in alueTiedot)
                {
                    if(alue.AlueNimi == sAlueMok)
                    {
                        comboBox_VarVarAlue.Text = alue.AlueNimi;
                    }
                }
                dateTimePickerVarStart.Value = varattu_alkupvm;
                dateTimePickerVarEnd.Value = varattu_loppupvm;
               
            }  

        }
        
    }
}
