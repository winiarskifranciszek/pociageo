using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Projekt.Controllers
{
    public class RozkladController : Controller
    {
        // GET: Rozklad
        public ActionResult rozklad()
        {
            return View();
        }
       

        public ActionResult polaczenie2(znajdz a)
        {
            ViewBag.stacja1=a.stacja1;
            ViewBag.stacja2 =a.stacja2;
            return View();
        }
        public SqlCommand Polaczenie(string zapytanie)
        {

            SqlConnection connect = new SqlConnection("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=NazwaBazy;Integrated Security=True");
            SqlCommand query = new SqlCommand(zapytanie, connect);
            connect.Open();
            return query;
        }

        //[HttpPost]
        //public ActionResult znajdz(znajdz a)
        //{
        //    bool status = false;
        //    //string query = "Select Id_trasy from Stacje where nazwa='" + a.stacja1 + "'AND nazwa='" + a.stacja2 + "';";


        //    //SqlDataReader wynik = Polaczenie(zapytanie).ExecuteReader();
        //    //wynik.Read();
        //    //if (wynik.HasRows)
        //    //{
        //    //    status = true;
        //    //    var id = wynik[0];
        //    //    Session["id"] = id;
        //    //}


        //    //if (status == true)
        //    //{


        //    //    Session["status"] = true;

        //    //    return RedirectToAction("wyszukane", "Rozklad");
        //    //}

        //    //else
        //    //{
        //    //    return RedirectToAction("yyy", "Rozklad");
        //    //}

        //    //DataTable reader = DANESQL.ReadDB(query);
        //    //for(int i = 0; i<reader.Rows.Count; i++)
        //    //{

        //    //}
        //}
        
    }
}