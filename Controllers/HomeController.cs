using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Projekt.Models;
using System.Security.Cryptography;
using System.Data;

namespace Projekt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult admin()
        {
            return View();
        }

        public ActionResult panel()
        {

            if (Session.Contents.Count != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("logowanie", "Home");
            }


        }
        public ActionResult About()
        {
            ViewBag.Message = "Którki opis";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt do firmy";

            return View();
        }
        public ActionResult logowanie()
        {

            return View();
        }

        /*public ActionResult rozklad()
        {
            return View();
        }

        public ActionResult znajdz(znajdz trasa)
        {
            string query = "SELECT Trasa.Id_trasy, Trasa.Stacja_Poczatkowa, Trasa.Stacja_Koncowa FORM Trasa WHERE Stacja_Poczatkowa = " + trasa.stacja1 + "' AND Stacja_koncowa = '" + trasa.stacja2 + "'";
            DataTable reader = DANESQL.ReadDB(query);
            if(reader.Rows.Count != 0)
            {

            }
            return View();
        }*/
        public ActionResult rejestracja()
        {
            return View();
        }
        //ŁĄCZENIE z baza
        public SqlCommand Polaczenie(string zapytanie)
        {
           
            SqlConnection connect = new SqlConnection("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=NazwaBazy;Integrated Security=True");
            SqlCommand query = new SqlCommand(zapytanie, connect);
            connect.Open();
            return query;
        }


        public string Hash256(string randomString)
        {
            string sol = "8gd";
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString + sol));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        //login


        [HttpPost]
        public ActionResult logowanie(logowanie logowanie)
        {
            bool status = false;
            string zapytanie = "Select Id_uzytkownicy from Uzytkownik where Email='" + logowanie.Login + "'AND Haslo='" + Hash256(logowanie.Hasło) + "';";


            SqlDataReader wynik = Polaczenie(zapytanie).ExecuteReader();
            wynik.Read();
            if (wynik.HasRows)
            {
                status = true;
                var id = wynik[0];
                Session["id"] = id;
            }


            if (status == true)
            {
               

                Session["status"] = true;
             
                return RedirectToAction("panel", "Home");
            }

            else
            {
                ViewBag.alert = false;
                return View();
            }
        }
        [HttpPost]


        

        //REJESTRACJA
        ////[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult rejestracja(rejestracja Add)
        {





            string wsad= "insert into Uzytkownik(Imie,Nazwisko,Email,Haslo) " +
                "VALUES ('" + Add.Imię + "','" + Add.Nazwisko + "','" + Add.E_mail +  "','" + Hash256(Add.Hasło) + "');";
            Polaczenie(wsad).ExecuteNonQuery();



            return RedirectToAction("Index");
        }

        public ActionResult Dodaj_srodki()
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
       
     



        public ActionResult dodaj_pie(przelew add)
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index");
            }
            string query = "INSERT INTO Portfel(kasa, Id_uzytkownik) VALUES (" + add.kwota + ",1)";
            DANESQL.ExecuteDB(query);
            return RedirectToAction("panel");

        }

    }
}