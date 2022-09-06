
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt.Models
{
    public class DANESQL
    {
        public static DataTable ReadDB(string query)
        {
           
                using (SqlConnection conn = new SqlConnection("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=NazwaBazy;Integrated Security=True"))
                {
                    DataTable data = new DataTable();
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    data.Load(reader);
                    return data;
                }
            
            //catch (SqlException exception)
            //{
            //    DataTable data = new DataTable();
            //    return data;
            //}
        }

        public static bool ExecuteDB(string query)
        {
           
                using (SqlConnection conn = new SqlConnection("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=NazwaBazy;Integrated Security=True"))
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
          
            //catch (SqlException exception)
            //{
            //    return false;
            //}
        }
    }
}