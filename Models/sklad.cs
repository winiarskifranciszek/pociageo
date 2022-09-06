using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class sklad
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Nr skladu")]
        public string nr_skladu { get; set; }


        [Display(Name = "Ilość miejsc")]
        public int miejsca { get; set; }
        
    }
}