using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class logowanie
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Brak Email")]
        public string Login { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Brak hasła")]
        public string Hasło { get; set; }


    }
}