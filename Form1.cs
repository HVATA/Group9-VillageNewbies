﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //AsiakasDemo avataan
        private void btn_asiakas_Click(object sender, EventArgs e)
        {
            Asiakashallinta asiakas = new Asiakashallinta();
            asiakas.Show();
        }
        
        private void btn_aluemokki_Click(object sender, EventArgs e)
        {
            //TÄLLÄ SIIRRYTÄÄ UUTEEN SIVUUN KOPIOIKAA JA VAIHTAA OMAT TIEDOT
            MokkiAluehallinta mokit = new MokkiAluehallinta();
            mokit.Show();
        }

        private void btn_lasku_Click(object sender, EventArgs e)
        {
            Laskujenhallinta laskut = new Laskujenhallinta();
            laskut.Show();
        }

        private void btn_majava2_Click(object sender, EventArgs e)
        {
            
            MajoitusVaraustenHallintaUusi majava2 = new MajoitusVaraustenHallintaUusi();
            majava2.Show();

        }

        private void btn_majoittutumiset_Click(object sender, EventArgs e)
        {
            Palveluhallinta palveluhallinta = new Palveluhallinta();
            palveluhallinta.Show();
        }
    }
}
