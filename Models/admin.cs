using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class admin
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "ID")]

        public string Log { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Brak hasła")]

        public string Hasło { get; set; }

    }
}