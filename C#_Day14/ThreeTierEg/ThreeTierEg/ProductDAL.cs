using System;
using System.Data;
using System.Data.SqlClient;
namespace ProductDALDemo
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public double UnitPrice { get; set; }
    }
    public class ProductDAL
    {
        public DataSet SelectData()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=JAMUNA\SQLEXPRESS;initial catalog=northwind;user id=sa;password=newuser123#");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from products", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int InsertData(Product p)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=JAMUNA\SQLEXPRESS;initial catalog=northwind;user id=sa;password=newuser123#");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert product values(@pid,@pname,@cid,@price)", conn);
            cmd.Parameters.AddWithValue("@pid", p.ProductId);
            cmd.Parameters.AddWithValue("@pname", p.ProductName);
            cmd.Parameters.AddWithValue("@cid", p.CategoryId);
            cmd.Parameters.AddWithValue("@price", p.UnitPrice);
            int z = cmd.ExecuteNonQuery();
            return z;
        }

    }
}
