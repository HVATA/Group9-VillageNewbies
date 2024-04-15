﻿using System;
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
            comboBox_VarFindAlue.Items.Add("Valitse alue");
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
            comboBox_VarFindMokki.Items.Add("Valitse mokki");
            foreach (MokkiTieto mok in mokkiTiedot)
            {
                comboBox_VarFindMokki.Items.Add(mok.Mokkinimi + ", " + mok.Mokki_id);
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
            comboBox_VarFindAsiakas.Items.Add("Valitse asiakas");
            foreach (AsiakasTieto asiak in asiakasTiedot)
            {
                comboBox_VarFindAsiakas.Items.Add(asiak.Sukunimi + ", " + asiak.AsiakasId);
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

        private void btn_EtsiVaraus_Click(object sender, EventArgs e)
        {
            string sId = ""; //tähä tee ehdolliset hakuqueryt riippuen hausta!
            foreach(AlueTieto al in alueTiedot)
            {
                if(al.AlueNimi == sFindAlue)
                {
                    sId = al.Alue_id;
                }
            }
            MessageBox.Show(sId);
            hakuquery = "SELECT * FROM varaus WHERE mokki_mokki_id IN (SELECT mokki_id FROM mokki WHERE alue_id = " + sId + ");";
            PaivitaGridview();
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

        private void comboBox_VarFindMokki_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox_VarFindAlue_SelectedIndexChanged(object sender, EventArgs e)
        {
            sFindAlue = comboBox_VarFindAlue.SelectedIndex.ToString();
            foreach (var alue in alueTiedot)
            {
                if(alue.AlueNimi == comboBox_VarFindAlue.Text)
                {
                    sFindAlue = alue.AlueNimi;
                }
            }
            MessageBox.Show(sFindAlue);
        }

        private void comboBox_VarFindAsiakas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}