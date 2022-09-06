using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class znajdz
    {
        [Display(Name = "Stacja Początkowa")]
        public string stacja1{ get; set; }
        [Display(Name = "Stacja Końcowa")]
        public string stacja2 { get; set; }

    }
}