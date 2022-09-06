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
    public class AdminController : Controller
    {
      

        public ActionResult Admin1()
        {

            return View();
        }
        public ActionResult FunkcjeAdmina()
        {

            if (Session.Contents.Count != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
             public ActionResult DodajPracownika()
        {
            if (Session.Contents.Count != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult dodajStacje()
        {
            if (Session.Contents.Count != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult dodaj_sklad()
        {
            if (Session.Contents.Count != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult dodaj_trase()
        {

            if (Session.Contents.Count != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
       



        // GET: Admin

            /// <summary>
            /// POŁĄCZENIE
            /// </summary>
            /// <param name="zapytanie"></param>
            /// <returns></returns>
            /// 


        public SqlCommand Polaczenie(string zapytanie)
        {

            SqlConnection connect = new SqlConnection("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=NazwaBazy;Integrated Security=True");
            SqlCommand query = new SqlCommand(zapytanie, connect);
            connect.Open();
            return query;
        }
        public ActionResult panel()
        {

            if (Session.Contents.Count != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("logowanie", "Admin");
            }


        }


        

        [HttpPost]
        public ActionResult admin(admin admin)
        {
        

            bool status = false;
            string zapytanie = "Select ID_ADMIN from Admin where login='" + admin.Log + "'AND haslo='" + admin.Hasło + "';";


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

                bool cos = true;
                Session["status"] = true;
              

                return RedirectToAction("FunkcjeAdmina", "Admin", cos);
            }

            else
            {
                ViewBag.alert = false;
                return RedirectToAction("index", "Home");
            }
        }
        [ValidateAntiForgeryToken]
        public ActionResult dodajSta(dodajStacje Add)
        {

            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Home", "Index");
            }




            string wsad = "insert into Stacje(nazwa,miejscowosc) " +
                "VALUES ('" + Add.Nazwa + "','" + Add.Miejscowosc +  "');";
            Polaczenie(wsad).ExecuteNonQuery();


       
            ViewBag.alert=true;
            return RedirectToAction("FunkcjeAdmina");
        }


        [ValidateAntiForgeryToken]
        public ActionResult dodajPra(pracownik Add)
        {

            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }



            string wsad = "insert into Pracownicy(Imie,Nazwisko,Pesel,Dostepnosc_start,Dostepnosc_end,Funkcja) " +
                "VALUES ('" + Add.Imie + "','" + Add.Nazwisko + "','" + Add.pesel + "','" + Add.data1 + "','" + Add.data2 + "','"+Add.funkcja+"');";
            Polaczenie(wsad).ExecuteNonQuery();



            ViewBag.alert = true;
            return RedirectToAction("FunkcjeAdmina");
        }

        [ValidateAntiForgeryToken]
        public ActionResult dodaj_skla(sklad Add)
        {

            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }



            string wsad = "insert into Pociag(Nr_pociagu ,Wolne_miejsca) " +
                "VALUES ('" + Add.nr_skladu + "','" + Add.miejsca +  "');";
            Polaczenie(wsad).ExecuteNonQuery();



            ViewBag.alert = true;
            return RedirectToAction("FunkcjeAdmina");
        }

        

        [ValidateAntiForgeryToken]
        public ActionResult dodaj_tra(DodajTrase Add)
        {


            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }



            string wsad = "insert into Trasa(Stacja_Poczatkowa ,Stacja_Koncowa,ID_POCIAG) " +
                "VALUES ('" + Add.stacja_1 + "','" + Add.stacja_2 + "','" + Add.Id_Pociągu + "');";
            Polaczenie(wsad).ExecuteNonQuery();



            ViewBag.alert = true;
            return RedirectToAction("FunkcjeAdmina");
        }

        //Lista tras

    



        public ActionResult Zaplanuj_Trase()
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            string query = "SELECT Id_trasy, Stacja_Poczatkowa, ID_POCIAG,  Stacja_Koncowa FROM Trasa";
            DataTable reader = DANESQL.ReadDB(query);
            List<znajdz_trase> list = new List<znajdz_trase>();
            for (int i = 0; i < reader.Rows.Count; i++)
            {
                list.Add(new znajdz_trase { ID = reader.Rows[i][0].ToString(), stacja_1 = reader.Rows[i][1].ToString(), Id_Pociag = reader.Rows[i][2].ToString(), stacja_2 = reader.Rows[i][3].ToString() });
            }
            return View(list);
        }


        /// <summary>
        /// dla urzytkownika
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        /// 

        public ActionResult Zaplanuj_Trase_v2()
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            string query = "SELECT Id_trasy, Stacja_Poczatkowa, ID_POCIAG,  Stacja_Koncowa FROM Trasa";
            DataTable reader = DANESQL.ReadDB(query);
            List<znajdz_trase> list = new List<znajdz_trase>();
            for (int i = 0; i < reader.Rows.Count; i++)
            {
                list.Add(new znajdz_trase { ID = reader.Rows[i][0].ToString(), stacja_1 = reader.Rows[i][1].ToString(), Id_Pociag = reader.Rows[i][2].ToString(), stacja_2 = reader.Rows[i][3].ToString() });
            }
            return View(list);
        }


        //public ActionResult dodaj_przystanek(przejscie add)
        //{
        //    if (Session.Keys.Count == 0)
        //    {
        //        return RedirectToAction("Home", "Index");
        //    }
        //    string query = "SELECT Id_trasy, Stacja_Poczatkowa, ID_POCIAG,  Stacja_Koncowa FROM Trasa";
        //    DataTable reader = DANESQL.ReadDB(query);
        //    List<znajdz_trase> list = new List<znajdz_trase>();
        //    for (int i = 0; i < reader.Rows.Count; i++)
        //    {
        //        list.Add(new znajdz_trase { ID = reader.Rows[i][0].ToString(), stacja_1 = reader.Rows[i][1].ToString(), Id_Pociag = reader.Rows[i][2].ToString(), stacja_2 = reader.Rows[i][3].ToString() });
        //    }
        //    return View(list);
        //}
        public ActionResult dodaj_przystanek(przejscie add)
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            string query = "SELECT Id_Stacje, nazwa FROM Stacje";
            DataTable reader = DANESQL.ReadDB(query);
            List<dodajStacje> stacje = new List<dodajStacje>();
            for (int i = 0; i<reader.Rows.Count; i++)
            {
                stacje.Add( new dodajStacje { Id = reader.Rows[i][0].ToString(), Nazwa = reader.Rows[i][1].ToString()});
            }
            dodaj_przystanek trasa = new dodaj_przystanek() { Stacja_pocz = add.sta1, Stacja_kon = add.sta2, Stacja = stacje, Id_Trasy = add.ID};
            return View(trasa);
        }



        public ActionResult dodaj_przy(dodaj_przystanek add)
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            string query = "INSERT INTO Trasa_has_stacje(IdStacje, idTrasy, Przyjazd, Odjazd) VALUES(" + add.Id_Stacje + "," + add.Id_Trasy + ",'" + add.Czas_przujazdu + "','" + add.Czas_odjazdu + "')";
            DANESQL.ExecuteDB(query);
            return RedirectToAction("Zaplanuj_Trase");
        }



        public ActionResult Przypisz_Obsluge()
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            string query = "SELECT Id_pracownicy, Imie, Nazwisko,  Pesel, Dostepnosc_start,Dostepnosc_end,obsluga,Funkcja FROM Pracownicy";
            DataTable reader = DANESQL.ReadDB(query);
            List<przypisz_obsl> list = new List<przypisz_obsl>();
            for (int i = 0; i < reader.Rows.Count; i++)
            {
                list.Add(new przypisz_obsl { Id_pracownicy = reader.Rows[i][0].ToString(), Imie = reader.Rows[i][1].ToString(), Nazwisko = reader.Rows[i][2].ToString(), Dostepnosc_start = reader.Rows[i][3].ToString()
                , Dostepnosc_end = reader.Rows[i][4].ToString(),
                   obsluga = reader.Rows[i][5].ToString()
                ,
                    Funkcja= reader.Rows[i][6].ToString()
                });
            }
            return View(list);
        }

        //edit


        public ActionResult edytuj_stacje()
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            string query = "SELECT Id_Stacje, nazwa, miejscowosc FROM Stacje";
            DataTable reader = DANESQL.ReadDB(query);
            List<dodajStacje> list = new List<dodajStacje>();
            for (int i = 0; i < reader.Rows.Count; i++)
            {
                list.Add(new dodajStacje
                {
                    Id = reader.Rows[i][0].ToString(),
                    Nazwa = reader.Rows[i][1].ToString(),
                    Miejscowosc= reader.Rows[i][2].ToString(),

                });
            }
            return View(list);
        }

        public ActionResult edit_wsad(dodajStacje add)
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }



            dodajStacje edit_sta = new dodajStacje() { Id = add.Id, Nazwa = add.Nazwa, Miejscowosc = add.Miejscowosc };
            return View(edit_sta);
        }
        
         public ActionResult wpisz_edit_sta(dodajStacje add)
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            string query = "UPDATE Stacje SET nazwa = "+add.Nazwa+" , miejscowosc = "+add.Miejscowosc+ " WHERE Id_Stacje="+add.Id+" ";
            DANESQL.ExecuteDB(query);
            return RedirectToAction("FunkcjeAdmina");
        }

      
            public ActionResult usun_Stacje()
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            string query = "SELECT Id_Stacje, nazwa, miejscowosc FROM Stacje";
            DataTable reader = DANESQL.ReadDB(query);
            List<dodajStacje> list = new List<dodajStacje>();
            for (int i = 0; i < reader.Rows.Count; i++)
            {
                list.Add(new dodajStacje
                {
                    Id = reader.Rows[i][0].ToString(),
                    Nazwa = reader.Rows[i][1].ToString(),
                    Miejscowosc = reader.Rows[i][2].ToString(),

                });
            }
            return View(list);
        }
        

              public ActionResult usun_to_stacja(dodajStacje add)
        {
            if (Session.Keys.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            string query = "delete from Stacje WHERE Id_Stacje=" + add.Id + " ";
            DANESQL.ExecuteDB(query);
            return RedirectToAction("FunkcjeAdmina");
        }


    }
}