using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9_VillageNewbies
{
    internal class Varauksen_palvelut
    {
        public int Varaus_id { get; set; }
        public int Palvelu_id { get; set; }
        public int Lkm { get; set; }

        public Varauksen_palvelut(int varaus_id, int palvelu_id, int lkm)
        {
            Varaus_id = varaus_id;
            Palvelu_id = palvelu_id;
            Lkm = lkm;
        }
        public Varauksen_palvelut()
        { 
            
        }
            
        public static List<Varauksen_palvelut> HaeKaikkiVarauksenPalvelutTiedot()
        {
            List<Varauksen_palvelut> varauksen_palvelut = new List<Varauksen_palvelut>();
            DatabaseRepository repository = new DatabaseRepository();

            DataTable varauksen_palvelutTable = repository.ExecuteQuery("SELECT * FROM varauksen_palvelut");

            foreach (DataRow row in varauksen_palvelutTable.Rows)
            {
                Varauksen_palvelut varauksen_palvelu = new Varauksen_palvelut(
                    Convert.ToInt32(row["varaus_id"]),
                    Convert.ToInt32(row["palvelu_id"]),
                    Convert.ToInt32(row["lkm"]));
                varauksen_palvelut.Add(varauksen_palvelu);
            }
            return varauksen_palvelut;
            }
        }
    }

