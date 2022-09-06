using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class przypisz_obsl

        //"SELECT Id_pracownicy, Imie, Nazwisko,  Pesel, Dostepnosc_start,Dostepnosc_end,oblsuga,Funkcja FROM Pracownicy";
    {

        
        public string Id_pracownicy { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Dostepnosc_start { get; set; }
        public string Dostepnosc_end { get; set; }
        public string obsluga { get; set; }
        public string Funkcja { get; set; }
       
    }

}