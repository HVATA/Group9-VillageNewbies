﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9_VillageNewbies
{
    public class Asiakas
    {
        public int AsiakasId { get; set; } 
        public string Postinro { get; set; } 
        public string Etunimi { get; set; } 
        public string Sukunimi { get; set; }
        public string Lahiosoite { get; set; }
        public string Email { get; set; } 
        public string Puhelinnro { get; set; }

        public override string ToString()
        {
            return $"{Sukunimi}";

        }

    }



}
