using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfSecond
{
    class Program
    {
        static NorthwindEntities db = new NorthwindEntities();

        static public void ShipperDetails()
        {
            foreach (var item in db.Shippers)
            {
                Console.WriteLine(item.ShipperID + "\t" + item.CompanyName + "\t" + item.Phone);
            }

        }
        static public void Insert()
        {
            Shipper obj = new Shipper();
            obj.ShipperID = 7;
            obj.CompanyName = "CTS";
            obj.Phone = "12345678";

            db.Shippers.Add(obj);
            db.SaveChanges();
            Console.WriteLine("Shipper Inserted");
            Console.ReadKey();
        }
        static public void Edit()
        {
            Console.WriteLine("Enter the shipper id for editing");
            int id = int.Parse(Console.ReadLine());
            Shipper obj = db.Shippers.Find(id);
            Console.WriteLine("Pls enter the New Company Name");
            obj.CompanyName = Console.ReadLine();

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

        }
        static public void Delete()
        {
            Console.WriteLine("Enter Shipper Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Shipper obj = db.Shippers.Find(id);
            db.Shippers.Remove(obj);
            db.SaveChanges();
            Console.WriteLine("Record Deleted");
        }
        static public void DeleteWithCheck()
        {
            try
            {
                Console.WriteLine("Enter Shipper Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Shipper obj = db.Shippers.Find(id);
                if (obj != null)
                {
                    Console.WriteLine(obj.ShipperID + "\t" + obj.CompanyName + "\t" + obj.Phone);
                    Console.WriteLine("Are you sure to delete?");
                    string choice = Console.ReadLine();
                    if (choice == "yes")
                    {
                        db.Shippers.Remove(obj);
                        db.SaveChanges();
                        Console.WriteLine("Record Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Record Not deleted");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ShipperId....Pls try again");
                }
            }
            catch(FormatException f)
            {
                Console.WriteLine("Invalid format");
            }
            catch(Exception e)
            {
                Console.WriteLine("Some unexpected error");
            }
        }

        public static void DisplayActiveProducts()
        {
            //var result = db.Products.Find(3);
            //Console.WriteLine(result.ProductName);

            var activeproducts = from ap in db.Products
                                 where ap.Discontinued == false
                                 select ap;

            foreach (var item in activeproducts)
            {
                Console.WriteLine(item.ProductID+"\t"+item.ProductName);
            }
        }
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Welcome to Northwind Project");
                Console.WriteLine("Enter 1.Display Shippers\t 2.Insert\t 3.Edit\t 4.Delete 5.Display Active Products 0.Exit");
                int choice = 0;
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ShipperDetails();
                        break;
                    case 2:
                        Insert();
                        break;
                    case 3:
                        Edit();
                        break;
                    case 4:
                        DeleteWithCheck();
                        break;
                    case 5:
                        DisplayActiveProducts();
                        break;

                    case 0:
                        Console.WriteLine("Exiting.....");
                        return;
                }
            }

        }
    }
}
