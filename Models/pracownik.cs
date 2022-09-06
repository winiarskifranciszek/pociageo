using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class pracownik
    {
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string Nazwisko { get; set; }


        [Display(Name = "Pesel")]
        
        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string pesel { get; set; }


        [Display(Name = "Dostępność start")]
      
        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string data1 { get; set; }


        [Display(Name = "Dostępność koniec")]
      
        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string data2 { get; set; }

        [Display(Name = "Funkcja 1=Maszynista 2=Kierownik 3=Pomocnik")]

        [Required(ErrorMessage = "To pole nie może być puste!")]
        public int funkcja { get; set; }
    }
}