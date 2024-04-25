

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
        List<Varauksen_palvelut> varPalveluTiedot = new List<Varauksen_palvelut>();
        List<Varauksen_palvelut> tarkistusVarPalveluTiedot = new List<Varauksen_palvelut>();
        public string connectionString = "DSN=Village Newbies;Uid=root;Pwd=root1;";
        public string lisaysquery;
        public string poistoquery;
        public string muokkausquery;
        public string hakuquery;
        public string sAlueMok;
        public string varattuPalveluNimi;
        public int varaus_id = 0;
        public int asiakas_id;
        public int mokki_mokki_id;
        public int varattuPalveluId;
        public int lkmInput;
        public int iTarkPalId = 0;
        public int iTarkistaTarkistusListaRemove = 0;
        public int iEiPalveluitaVarauksella = 0;
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
            LataaVarPalvelutKannasta();
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
        private void LataaVarPalvelutKannasta()//Haetaan alueet kannasta
        {
            tarkistusVarPalveluTiedot.Clear();
            varPalveluTiedot.Clear(); // Tyhjennä lista varmuuden vuoksi
            DatabaseRepository repository = new DatabaseRepository();
            DataTable varPalveluTable = repository.ExecuteQuery("SELECT * FROM varauksen_palvelut");

            foreach (DataRow row in varPalveluTable.Rows)
            {
                Varauksen_palvelut varpa = new Varauksen_palvelut(

                    Convert.ToInt32(row["varaus_id"]),
                    Convert.ToInt32(row["palvelu_id"]),
                    Convert.ToInt32(row["lkm"])
                );

                varPalveluTiedot.Add(varpa);
                tarkistusVarPalveluTiedot.Add(varpa);
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

               

                if (listBox_VarValitutPalvelut.Items.Count > 0)
                {
                    Varauksen_palvelut varpalvel = new Varauksen_palvelut();
                    foreach (var item in listBox_VarValitutPalvelut.Items)
                    {
                        foreach(Palvelu pal in palveluTiedot)
                        {
                            if(pal.Nimi == item)
                            {
                                varpalvel.Palvelu_id = pal.Palvelu_id;
                            }
                        }   
                    }
                    varpalvel.Varaus_id = varaus_id;
                    varpalvel.Lkm = lkmInput;
                    db.LisaaVarauksenPalvelu(varpalvel);
                }
                LuoJaPaivitaLasku(uusiVaraus.Varaus_id, uusiVaraus.Asiakas_id, uusiVaraus.Mokki_Mokki_id);
                varPalveluTiedot.Clear();
                LataaVarauksetKannasta();
                LataaVarPalvelutKannasta();
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

            if (string.IsNullOrEmpty(comboBox_VarVarAlue.Text))
            {
                MessageBox.Show("Valise alue");
            }
            else if (string.IsNullOrEmpty(comboBox_VarVarMokki.Text))
            {
                MessageBox.Show("Valise mökki");
            }
            else if (string.IsNullOrEmpty(comboBox_VarVarAsiakas.Text))
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
                if(iTarkistaTarkistusListaRemove > 0) //jos tarkistuslistasta on poistettu jotain
                {
                    foreach (Varauksen_palvelut varauspal in varPalveluTiedot)
                    {
                        if (!tarkistusVarPalveluTiedot.Contains(varauspal))
                        {
                            db.PoistaVarauksenPalvelu(varauspal);
                            
                        }
                    }
                    iTarkistaTarkistusListaRemove = 0;
                }
                if(iEiPalveluitaVarauksella > 0) //Jos listbox oli tyhjä
                {
                    if (listBox_VarValitutPalvelut.Items.Count > 0)
                    {
                        Varauksen_palvelut varpalvel = new Varauksen_palvelut();
                        foreach (var item in listBox_VarValitutPalvelut.Items)
                        {
                            foreach (Palvelu pal in palveluTiedot)
                            {
                                if (pal.Nimi == item)
                                {
                                    varpalvel.Palvelu_id = pal.Palvelu_id;
                                }
                            }
                        }
                        varpalvel.Varaus_id = varaus_id;
                        varpalvel.Lkm = lkmInput;
                        db.LisaaVarauksenPalvelu(varpalvel);
                    }
                    iEiPalveluitaVarauksella = 0;
                }
                db.MuutaVaraus(pVaraus);
                LataaVarauksetKannasta();
                LataaVarPalvelutKannasta();
                UpdateDataGridView();
            }
        }

        private void btn_DeleteVaraus_Click(object sender, EventArgs e)
        {
            Varaus pVaraus = new Varaus(
                    varaus_id, asiakas_id, mokki_mokki_id,
                    varattu_pvm, vahvistus_pvm, varattu_alkupvm,
                    varattu_loppupvm);
            Varauksen_palvelut varausP = new Varauksen_palvelut();
            varausP.Varaus_id = varaus_id;
            foreach (Varauksen_palvelut var in varPalveluTiedot)
            {
                if (var.Varaus_id == varausP.Varaus_id)
                {
                    varausP.Palvelu_id = var.Palvelu_id;
                    varausP.Lkm = var.Lkm;
                }
            }
            DatabaseRepository db = new DatabaseRepository();
            db.PoistaVarauksenPalvelu(varausP);
            db.PoistaVaraus(pVaraus);
            LataaVarauksetKannasta();
            UpdateDataGridView();

        }

        private void comboBox_VarVarPalvelut_SelectedIndexChanged(object sender, EventArgs e)
        {
            varattuPalveluNimi = comboBox_VarVarPalvelut.Text;
        }

        private void comboBox_VarVarAlue_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTark = 0;
            string alueid = "";
            comboBox_VarVarPalvelut.Items.Clear();
            comboBox_VarVarMokki.Items.Clear();
            foreach(AlueTieto al in alueTiedot)
            {
                if(al.AlueNimi == comboBox_VarVarAlue.Text)
                {
                    alueid = al.Alue_id;
                }
            }
            foreach (MokkiTieto mokki in mokkiTiedot)
            {
                if (mokki.Alue == comboBox_VarVarAlue.Text)
                {
                    comboBox_VarVarMokki.Items.Add(mokki.Mokkinimi);
                }
            }
            foreach(Palvelu pal in palveluTiedot)
            {
                if(pal.AlueId.ToString() == alueid)
                {
                    comboBox_VarVarPalvelut.Items.Add(pal.Nimi);
                }
            }
            /*if(listBox_VarValitutPalvelut.Items.Count > 0)
            {
                foreach(var item in listBox_VarValitutPalvelut.Items)
                {
                    if (item.ToString() != (comboBox_VarVarPalvelut.Items[0].ToString()))
                    {
                        listBox_VarValitutPalvelut.Items.Remove(item);
                        foreach(Palvelu palvelu in palveluTiedot)
                        {
                            if(palvelu.Nimi == item.ToString())
                            {
                                idTark = palvelu.Palvelu_id;
                            }
                        }
                        foreach(Varauksen_palvelut varp in tarkistusVarPalveluTiedot)
                        {
                            if(varp.Varaus_id == varaus_id && varp.Palvelu_id == idTark)
                            {
                                tarkistusVarPalveluTiedot.Remove(varp);
                            }
                        }
                    }
                }
            }*/
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
            if (listBox_VarValitutPalvelut.Items.Count > 0)
            {
                foreach (var item in listBox_VarValitutPalvelut.Items)
                {
                    if (comboBox_VarVarPalvelut.SelectedIndex > -1)
                    {
                        if (comboBox_VarVarPalvelut.SelectedItem != item)
                        {
                            iEiPalveluitaVarauksella++;
                        }
                    }

                }
            }
            if (lkmInput == 0)
            {
                MessageBox.Show("Virhe, palvelun määrää ei ole valittu");
            }
            else
            {
                if (comboBox_VarVarPalvelut.SelectedIndex == -1)
                {
                    MessageBox.Show("Valise palvelu");
                }
                varattuPalveluNimi = comboBox_VarVarPalvelut.Text;
                varattuPalveluNimi = comboBox_VarVarPalvelut.Text;
                Varauksen_palvelut varpalo = new Varauksen_palvelut();
                varpalo.Varaus_id = varaus_id;
                foreach (Palvelu pal in palveluTiedot)
                {
                    if (pal.Nimi == varattuPalveluNimi)
                    {
                        varpalo.Palvelu_id = pal.Palvelu_id;
                    }
                }
                varpalo.Lkm = lkmInput;
                //MessageBox.Show(varpalo.Varaus_id.ToString());//Tarkistus että tiedonhaku toimii
                //MessageBox.Show(varpalo.Palvelu_id.ToString());//Tarkistus että tiedonhaku toimii
                //MessageBox.Show(varpalo.Lkm.ToString());//Tarkistus että tiedonhaku toimii
                foreach(Palvelu pal in palveluTiedot)
                {
                    if(pal.Palvelu_id == varpalo.Palvelu_id)
                    {
                        listBox_VarValitutPalvelut.Items.Add(pal.Nimi);
                    }
                }
            }
        }

        private void btn_deleteVarPalvelu_Click(object sender, EventArgs e)
        {
            foreach (Palvelu pal in palveluTiedot)
            {
                if (pal.Nimi == listBox_VarValitutPalvelut.SelectedItem.ToString())
                {
                    iTarkPalId = pal.Palvelu_id;
                }
            }
            for (int i = tarkistusVarPalveluTiedot.Count - 1; i >= 0; i--)
            {
                Varauksen_palvelut varplou = tarkistusVarPalveluTiedot[i];
                if (varplou.Palvelu_id == iTarkPalId && varplou.Varaus_id == varaus_id)
                {
                    tarkistusVarPalveluTiedot.RemoveAt(i);
                    iTarkistaTarkistusListaRemove++;

                }
            }
            if (listBox_VarValitutPalvelut.SelectedIndex == -1)
            {
                MessageBox.Show("Valise palvelu");
            }
            else
            {
                listBox_VarValitutPalvelut.Items.Remove(listBox_VarValitutPalvelut.SelectedItem);
            }
            
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            listBox_VarValitutPalvelut.Items.Clear();
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
                
                foreach(Varauksen_palvelut varpale in varPalveluTiedot)
                {
                    if(varausId == varpale.Varaus_id)
                    {
                        foreach (Palvelu pal in palveluTiedot)
                        {
                            if (pal.Palvelu_id == varpale.Palvelu_id)
                            {
                                listBox_VarValitutPalvelut.Items.Add(pal.Nimi);
                            }
                        }
                    }
                }
                if(listBox_VarValitutPalvelut.Items.Count == 0)
                {
                    iEiPalveluitaVarauksella++;
                }
                
                
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
        private void lkmInputElement_ValueChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(comboBox_VarVarPalvelut.Text))
            { 
                if (lkmInputElement.Equals(0))
                {
                    MessageBox.Show("Valitse lukumäärä!");
                }
                else
                {
                    lkmInput = Convert.ToInt32(lkmInputElement.Value);
                }
            }
        }

        private void LuoJaPaivitaLasku(int varausId, int asiakasId, int mokkiId)
        {
            // Haetaan mökin hinta
            double hinta = HaeMokinHinta(mokkiId);

            // Haetaan palveluiden hinta
            double palveluidenHinta = LaskePalveluidenHinta(varausId);

            double loppusumma = hinta + palveluidenHinta;
            double alv = 24;


            // Asetetaan eräpäivä 30 päivän päähän tästä hetkestä
            DateTime tanaan = DateTime.Now;
            DateTime erapvm = tanaan.AddDays(30);

            DatabaseRepository repository = new DatabaseRepository();

            //if (LaskuOnOlemassa(varausId))
            //{
                // Päivitä olemassaoleva lasku
            //    repository.ExecuteNonQuery($"UPDATE lasku SET summa = {loppusumma}, alv = {alv} WHERE varaus_id = {varausId}");
            //}
            //else
            //{
                // Luo uusi lasku
                int laskuId = HaeSeuraavaLaskuId();
                //repository.ExecuteNonQuery($"INSERT INTO lasku (lasku_id, varaus_id, summa, alv, maksettu, erapmv) VALUES ({laskuId}, {varausId}, {loppusumma}, {alv}, 0, '{erapvm:yyyy-MM-dd}')");
                repository.ExecuteNonQuery($"INSERT INTO lasku (lasku_id, varaus_id, summa, alv, maksettu, erapvm) VALUES ({laskuId}, {varausId}, {loppusumma}, {alv}, 0, '{erapvm:yyyy-MM-dd}')");
            //}
        }



        private bool LaskuOnOlemassa(int varausId)
        {
            bool olemassa = false;

            DatabaseRepository repository = new DatabaseRepository();
            DataTable laskuTable = repository.ExecuteQuery($"SELECT COUNT(*) FROM lasku WHERE varaus_id = {varausId}");

            if (laskuTable.Rows.Count > 0 && Convert.ToInt32(laskuTable.Rows[0][0]) > 0)
            {
                olemassa = true;
            }

            return olemassa;
        }


        private void LisaaUusiLasku(int varausId, int asiakasId, double summa, double alv)
        {
            DatabaseRepository repository = new DatabaseRepository();
            repository.ExecuteNonQuery($"INSERT INTO lasku (varaus_id, asiakas_id, summa, alv, maksettu, erapmv) VALUES ({varausId}, {asiakasId}, {summa}, {alv}, FALSE, '2025-08-01')");
        }


        private void PaivitaLasku(int varausId, double summa, double alv)
        {
            DatabaseRepository repository = new DatabaseRepository();
            repository.ExecuteNonQuery($"UPDATE lasku SET summa = {summa}, alv = {alv} WHERE varaus_id = {varausId}");
        }


        private double laskeSumma(Varaus varaus)
        {
            double summa = 0;

            // Lisätään mökin hinta summaan
            var mokki = mokkiTiedot.FirstOrDefault(m => m.Mokki_id == varaus.Mokki_Mokki_id.ToString());
            if (mokki != null)
            {
                summa += double.Parse(mokki.Hinta);
            }

            // Lisätään varattujen palveluiden hinnat
            var palvelutVaraukselle = varPalveluTiedot.Where(v => v.Varaus_id == varaus.Varaus_id);
            foreach (var vp in palvelutVaraukselle)
            {
                var palvelu = palveluTiedot.FirstOrDefault(p => p.Palvelu_id == vp.Palvelu_id);
                if (palvelu != null)
                {
                    summa += double.Parse(palvelu.Hinta) * vp.Lkm; // Oletetaan, että hinta on per yksikkö
                }
            }

            return summa;
        }

        private double laskeALV()
        {
            return 24.0;  // ALV on kiinteästi 24%
        }

        private double HaeMokinHinta(int mokkiId)
        {
            double hinta = 0; // Oletusarvo

            DatabaseRepository repository = new DatabaseRepository();
            DataTable mokkiTable = repository.ExecuteQuery($"SELECT hinta FROM mokki WHERE mokki_id = {mokkiId}");

            if (mokkiTable.Rows.Count > 0)
            {
                hinta = Convert.ToDouble(mokkiTable.Rows[0]["hinta"]);
            }

            return hinta;
        }

        private double LaskePalveluidenHinta(int varausId)
        {
            double summa = 0;
            DatabaseRepository repository = new DatabaseRepository();
            DataTable palvelutTable = repository.ExecuteQuery($"SELECT Palvelu_id, Lkm FROM Varauksen_palvelut WHERE Varaus_id = {varausId}");

            foreach (DataRow row in palvelutTable.Rows)
            {
                int palveluId = Convert.ToInt32(row["Palvelu_id"]);
                int lkm = Convert.ToInt32(row["Lkm"]);
                DataTable hintaTable = repository.ExecuteQuery($"SELECT hinta FROM palvelu WHERE palvelu_id = {palveluId}");
                if (hintaTable.Rows.Count > 0)
                {
                    double hinta = Convert.ToDouble(hintaTable.Rows[0]["hinta"]);
                    summa += hinta * lkm;
                }
            }

            return summa;
        }

        private int HaeSeuraavaLaskuId()
        {
            DatabaseRepository repository = new DatabaseRepository();
            DataTable dt = repository.ExecuteQuery("SELECT MAX(lasku_id) FROM lasku");

            int suurinId = 0;
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                suurinId = Convert.ToInt32(dt.Rows[0][0]);
            }

            // Varmistetaan, että ID on vähintään viisinumeroinen
            int seuraavaId = Math.Max(suurinId + 1, 10000);

            return seuraavaId;
        }







    }
}
