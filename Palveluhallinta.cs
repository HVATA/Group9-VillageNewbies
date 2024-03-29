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
    public partial class Palveluhallinta : Form
        {
        private BindingSource palveluBindingSource = new BindingSource();
        private BindingSource alueBindingSource = new BindingSource();
        private List<Alue> aluetiedot = new List<Alue>();

        public Palveluhallinta ()
            {
            InitializeComponent();
            LataaAlueetTietokannasta();
            LataaPalvelutTietokannasta();
            }

        private void LataaAlueetTietokannasta ()
            {
            // Haetaan kaikki alueet tietokannasta
            aluetiedot = Alue.HaeKaikkiAlueet();

            // Lisätään "Kaikki palvelut" -valinta ComboBoxiin
            aluetiedot.Insert(0, new Alue { AlueId = -1, Nimi = "Kaikki palvelut" });

            // Päivitä BindingSource alueiden tiedoilla
            alueBindingSource.DataSource = aluetiedot;
            alueComboBox.DataSource = alueBindingSource;
            alueComboBox.DisplayMember = "Nimi";
            alueComboBox.ValueMember = "AlueId";

            // Asetetaan "Kaikki palvelut" -valinta oletusvalinnaksi
            alueComboBox.SelectedIndex = 0;
            }

        private void LataaPalvelutTietokannasta ()
            {
            // Haetaan kaikki palvelutietojen tiedot tietokannasta
            List<PalveluTiedot> palveluTiedot = PalveluTiedot.HaePalveluTiedot();

            // Päivitä BindingSource palvelutietojen tiedoilla
            palveluBindingSource.DataSource = palveluTiedot;
            dataGridView1.DataSource = palveluBindingSource;
            }

        private void alueComboBox_SelectedIndexChanged ( object sender, EventArgs e )
            {
            int valittuAlueId = (int) alueComboBox.SelectedValue;

            if (valittuAlueId == -1) // Kaikki palvelut valittu
                {
                // Haetaan kaikki palvelutietojen tiedot tietokannasta
                List<PalveluTiedot> kaikkiPalveluTiedot = PalveluTiedot.HaePalveluTiedot();

                // Päivitä DataGridView kaikilla palvelutiedoilla
                palveluBindingSource.DataSource = kaikkiPalveluTiedot;
                }
            else
                {
                // Haetaan valitun alueen palvelutietojen tiedot ja päivitetään näkymä
                List<PalveluTiedot> alueenPalveluTiedot = PalveluTiedot.HaeAlueenPalveluTiedot(valittuAlueId);
                palveluBindingSource.DataSource = alueenPalveluTiedot;
                }
            }
        }
    }