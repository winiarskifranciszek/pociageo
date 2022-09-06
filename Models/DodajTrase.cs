using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class DodajTrase
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Stacja Początkowa")]
        public string stacja_1 { get; set; }


        [Display(Name = "Stacja Końcowa")]
        public string stacja_2 { get; set; }



        [Display(Name = "ID pociagu")]
        public int Id_Pociągu { get; set; }
    }
}