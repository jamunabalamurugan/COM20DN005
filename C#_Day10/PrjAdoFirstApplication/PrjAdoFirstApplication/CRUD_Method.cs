using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Configuration;

namespace PrjAdoFirstApplication
{

    class CRUDOperation
    {
        public static SqlConnection con = null;
        public static SqlCommand cmd = null;
     static string  connection = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        #region Connection
        public static SqlConnection  GetConnection()
        {
            /* con = new SqlConnection(
             "Data Source=.;Initial Catalog=Northwind;" +
             "User ID=sa;Password=newuser123#");*/
            con = new SqlConnection(connection);
          
            con.Open();
            return con;
        }

        #endregion
        /// <summary>
        /// result : No of rows inserted
        /// </summary>
        /// <param name="id"></param>
        /// <param name="des"></param>
        #region Insert
        public void Insert(int id, string des)
        {
          con= GetConnection();
            cmd = new SqlCommand
                ("insert into Region(RegionId,RegionDescription) " +
                "values(@RegionId,@RegionDesc)", con);
            cmd.Parameters.AddWithValue("@RegionId", id);
            cmd.Parameters.AddWithValue("@RegionDesc", des);



            //Executing Insert Statement
            int rowsinserted = cmd.ExecuteNonQuery();
            Console.WriteLine("No of rows inserted is {0}", rowsinserted);
        }

        #endregion

        #region Delete
        public void Delete()
        {
           con = GetConnection();
            Console.WriteLine("Enter the Region Id to be Deleted");
            int getvalue = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("delete Region where RegionId=@Rid", con);
            cmd.Parameters.AddWithValue("@Rid", getvalue);
           Console.WriteLine("No of rows deleted {0}", cmd.ExecuteNonQuery());
        }

        #endregion
    }
    class CRUD_Method
    {
        static void Main()
        {
            CRUDOperation cobj = new CRUDOperation();
            try
            {
                Console.WriteLine("Enter the operation to be performed  1:Insertion 2:Deletion");
                int Choice = Convert.ToInt32(Console.ReadLine());
                if (Choice ==1)
                { cobj.Insert(10, "AAAA"); }
                else if(Choice ==2)
                {
                    cobj.Delete();
                }
                else if(Choice==0)
                {
                    Environment.Exit(0);
                }
               
            }
            catch(Exception exmessage)
            {
                Console.WriteLine(exmessage);
            }
          
            Console.Read();

        }
    }
}
