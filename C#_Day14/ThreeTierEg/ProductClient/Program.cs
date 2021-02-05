using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductBALDemo;
namespace ProductClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductBAL balobj = new ProductBAL();
            DataSet ds = balobj.SelectDataBAL();
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                foreach (var item in dr.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
            Console.Read();
        }
    }
}
