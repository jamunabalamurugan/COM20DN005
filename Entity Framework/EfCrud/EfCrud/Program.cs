using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCrud
{
    class Program
    {
        NorthwindEntities mydb = new NorthwindEntities();
        public void Create()
        {
            Shipper s = new Shipper();
            Console.WriteLine("Please enter Shipper Details to be Inserted");
            Console.WriteLine("Enter Company Name");
            s.CompanyName = Console.ReadLine();
            Console.WriteLine("Enter Phone");
            s.Phone = Console.ReadLine();
            mydb.Shippers.Add(s);
            mydb.SaveChanges();
        }
        public void Edit()
        {
            Console.WriteLine("Enter Shipper Id to be Modified");
            int id = Int32.Parse(Console.ReadLine());
            Shipper s = mydb.Shippers.Find(id);
            Console.WriteLine(s.CompanyName);
            Console.WriteLine(s.Phone);
            Console.WriteLine("Enter Company Name");
            s.CompanyName = Console.ReadLine();
            Console.WriteLine("Enter Phone");
            s.Phone = Console.ReadLine();
            //Before Saving changes mark the record which has been modified
            mydb.Entry(s).State = EntityState.Modified;
            mydb.SaveChanges();

        }
        public void Delete()
        {
            Console.WriteLine("Enter Shipper Id to be Delete");
            int id = Int32.Parse(Console.ReadLine());
            Shipper s = mydb.Shippers.Find(id);

            mydb.Shippers.Remove(s);
            mydb.SaveChanges();
            
        }

        public void SearchCustomer()
        {
            Console.WriteLine("Enter Customer ID");
            string id = Console.ReadLine();
            Customer cust = mydb.Customers.Find(id);
            Console.WriteLine(cust.ContactName);
            Console.WriteLine(cust.Country);

        }

        public void CustByCountry()
        {
            Console.WriteLine("Enter the country");
            string str = Console.ReadLine();
            //Customer cust = mydb.Customers.Find(country);

            //IEnumerable<Customer> customers =
            var customers=
                from custs in mydb.Customers
                where custs.Country.Contains(str)
                //select custs;
                select new { custs.ContactName, custs.Country };

            foreach (var item in customers)
            {
                Console.WriteLine(item.ContactName+" "+item.Country);

            }
        }

        public void DisplayProduct()
        {
            Console.WriteLine("Please Enter Category Id");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = from prod in mydb.Products
                         where prod.CategoryID == id
                       //  select prod; This will select all columns from Products

            select new
            {
                prod.ProductName,
                prod.Category.CategoryName,
                prod.Supplier.CompanyName
            };

            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName+"\t"+item.CompanyName);
               
            }

        }

        public void DisplaySalesByCat()
        {
            try
            {
                Console.WriteLine("Enter Category");
            string name = Console.ReadLine();
            Console.WriteLine("Enter year");
            string year = Console.ReadLine();

              
                var result = mydb.SalesByCategory(name, year).ToList();
                List<SalesByCategory_Result> result1 = mydb.SalesByCategory(name, year).ToList();

               // SalesByCategory_Result result2 = mydb.SalesByCategory(name, year).FirstOrDefault();
                if (result.Count()==0)
                {
                    Console.WriteLine("Please enter valid Category and year");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Executed Succesfully");
                }
                foreach (var item in result)
                {
                    Console.WriteLine(item.ProductName + "\t" + item.TotalPurchase);
                }
              }
            catch(SqlException e)
            {
                Console.WriteLine("Try after sometime...Database is busy now");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
}
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.Create();
            //p.Edit();
            //p.Delete();
            //p.SearchCustomer();
            p.CustByCountry();
             p.DisplayProduct();
            p.DisplaySalesByCat();
            Console.ReadKey();
        }
    }
}
