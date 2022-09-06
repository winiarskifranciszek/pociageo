using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class dodajStacje
    {

        [ScaffoldColumn(false)]
        public string Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }


        [Display(Name = "Miejscowść")]
        public string Miejscowosc { get; set; }
       
    }
}