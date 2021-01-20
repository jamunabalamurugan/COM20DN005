using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Project
{
    class Product
    {
        int productid;
        string name;
       // the constructor that the compiler would provide
        //public Product() { }
        public Product()
        {
            productid = 100;
            name = "Laptop";
        }
        public void PrintProduct()
        {

            Console.WriteLine("The number is "+productid);
            Console.WriteLine("The Name is " + name);
        }
    }
    class UseProgram
    {
        static void Main()
        {
            Product p1 = new Product() ;
            p1.PrintProduct();

            Laptop laptop1 = new Laptop();

            laptop1.ShowDetails();
            laptop1.PowerOff();
            Console.WriteLine(laptop1.speed);
            Console.WriteLine(laptop1.display);

            Console.ReadKey();
        }
    }
}
