using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class rejestracja
    {

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string Imię { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string Nazwisko { get; set; }

       

        

     

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Wprowadź poprawny adres e-mail!")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
        public string E_mail { get; set; }

        

       

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Wprowadź hasło!")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Twoje hasło musi posiadać conajmniej 8 znaków!")]
        public string Hasło { get; set; }

        [Display(Name = "Powtórz hasło")]
        [DataType(DataType.Password)]
        [Compare("Hasło", ErrorMessage = "Powtórzone hasła muszą byc identyczne!")]
        public string Powtórz_hasło { get; set; }

      
        

     

    
    }
}