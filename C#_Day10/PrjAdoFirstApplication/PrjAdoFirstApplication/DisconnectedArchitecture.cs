using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PrjAdoFirstApplication
{
    class DisconnectedArchitecture
    {
        static void Main()
        {
             string connection = ConfigurationManager.ConnectionStrings["Northwindconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            SqlDataAdapter da = new SqlDataAdapter("select * from Region", con);
           
            con.Open();
            DataSet ds = new DataSet();

          
            //Select Command
              da.Fill(ds,"Regiontable"); //region is userdefined name
               DataTable dt = ds.Tables["Regiontable"];
         
               foreach(DataRow row in dt.Rows)
               {
                   foreach (DataColumn col in dt.Columns)
                       Console.WriteLine(row[col]);
                   Console.WriteLine("".PadLeft(20, '='));
               }
            da = new SqlDataAdapter("select * from emptax", con);
            da.Fill(ds, "emptax");
            DataTable dt1 = ds.Tables["emptax"];
            foreach (DataRow row in dt1.Rows)
            {
                foreach (DataColumn col in dt1.Columns)
                    Console.WriteLine(row[col]);
                Console.WriteLine("".PadLeft(20, '='));
            }


            Console.Read();
               con.Close();



        }
    }
}
