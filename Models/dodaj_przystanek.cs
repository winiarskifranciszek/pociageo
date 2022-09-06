using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class dodaj_przystanek
    {
        [ScaffoldColumn(false)]
        public string Id_Stacje { get; set; }
        [ScaffoldColumn(false)]
        public string Id_Trasy { get; set; }
        [Display(Name = "Stacja Początkowa")]
        public string Stacja_pocz { get; set; }
        [Display(Name = "Czas przyjazdu")]
        [DataType(DataType.Time)]
        public string Czas_przujazdu { get; set; }
        [Display(Name = "Czas odjazdu")]
        [DataType(DataType.Time)]
        public string Czas_odjazdu { get; set; }
        [Display(Name = "Stacja")]
        public List<dodajStacje> Stacja { get; set; }
        [Display(Name = "Stacja Końcowa")]
        public string Stacja_kon { get; set; }

    }
}