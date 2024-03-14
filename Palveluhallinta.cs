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
        List<Palvelu> palveluntiedot = new List<Palvelu>();

        public Palveluhallinta ()
            {
            InitializeComponent();
            LataaAlueetTietokannasta();
            LataaPalvelutTietokannasta();
            }

        private void LataaAlueetTietokannasta ()
            {
            // Tässä voit lisätä koodin alueiden lataamiseksi tietokannasta, jos tarpeen
            }

        private void LataaPalvelutTietokannasta ()
            {
            // Käytä uutta Palvelu-luokan staattista metodia hakeaksesi kaikki palvelut tietokannasta
            palveluntiedot = Palvelu.HaeKaikkiPalvelut();

            // Lisää palvelut DataGridViewiin
            dataGridView1.DataSource = palveluntiedot;
            }
        }
    }

