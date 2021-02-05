using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
namespace Isolation_Levels
{
    class Program
    {
    static void Main(string[] args)
    {
        TransactionOptions options = new TransactionOptions();
        Options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted; (allows to read only updated data)
    using (TransactionScope ts = new TransactionScope())
        {
            using (SqlConnection cn = new SqlConnection("Initial Catalog = HR; Data Source = SQLSERVER01; User id = sa; Password = password#1234;"))
{
                cn.Open();
                using (SqlCommand cmd = new SqlConnection("INSERT INTO Product(product_code, product_name, price, quantity) VALUES('P - 0123','Toys', 250, 50)", cn))
                {
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        using (SqlConnection cn1 = new SqlConnection("Initial Catalog = HR; Data Source = SQLSERVER01; User id = sa; Password = password#1234"))
{
                            cn1.Open();
                            using (SqlCommand cmd1 = new SqlCommand("INSERT INTO Order(OrderID, OrderDate, ClientID) VALUES('O - 909','12 - 09 - 2013','C - 787’)", cn1))
                            {
                                int rowUpdated1 = cmd1.ExecuteNonQuery();
                                if (rowsUpdated1 > 0)
                                {
                                    ts.Complete();
                                    Console.WriteLine("Transaction Committed\n");
                                    cn1.Close();
                                }
                            }
                        }
                    }
                }
                cn.Close();
            }
        }
        Console.ReadLine();
    }
}
}

 
