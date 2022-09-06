using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Projekt.Models
{
    public class przelew
    {

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string Nazwisko { get; set; }


        [Display(Name = "nr konta")]

        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string nr_konta { get; set; }


        [Display(Name = "kwota")]

        [Required(ErrorMessage = "To pole nie może być puste!")]
        public decimal kwota { get; set; }


      
    }
}