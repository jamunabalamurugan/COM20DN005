using System.Drawing;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace SqlTransactionClassinAdodotNet
{
    public partial class Program
    {
        static SqlConnection conn;
        static SqlCommand comm1, comm2, comm3;
        static SqlTransaction trans;
        static SqlDataAdapter adapter1, adapter2;
        DataSet ds1, ds2;
        static string constring = @"Data Source=JAMUNA\SQLEXPRESS;Initial Catalog=Northwind;user id=sa;password=newuser123#";
        static void Main()
        {
            conn = new SqlConnection(constring);
            conn.Open();
            comm1 = new SqlCommand("select userid from userdet", conn);
            SqlDataReader reader = comm1.ExecuteReader();
            List<string> userid = new List<string>();
            while (reader.Read())
            {
                userid.Add(reader[0].ToString());
            }
            reader.Close();
            conn.Close();
        }

        private void showrecord_Click()
        {
            adapter1 = new SqlDataAdapter("select * from userdet", constring);
            adapter2 = new SqlDataAdapter("select * from moneytrans", constring);
            ds1 = new System.Data.DataSet();
            adapter1.Fill(ds1);
            ds2 = new System.Data.DataSet();
            adapter2.Fill(ds2);
            
               
                conn = new SqlConnection(constring);
                conn.Open();
                comm2 = new SqlCommand("insert into moneytrans values(2,2500)", conn);
                comm3 = new SqlCommand("update userdet set amount=amount-2500 where userid=2", conn);
    
                trans = conn.BeginTransaction();
                comm2.Transaction = trans;
                comm3.Transaction = trans;
                try
                {
                    comm2.ExecuteNonQuery();
                    comm3.ExecuteNonQuery();
                    trans.Commit();
                System.Console.WriteLine("Transaction Completed");
                }
                catch (System.Exception e)
                {
                    trans.Rollback();
                System.Console.WriteLine("Transaction Failed");
                }
            
            conn.Close();
        }
    }
}