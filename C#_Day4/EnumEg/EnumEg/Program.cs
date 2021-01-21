using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumEg
{
    enum cities
    {
        Chennai=1,Hyderabad, Bangalore, Mumbai,Pune,Delhi
    };

    class Emp
    {
        public int eid { get; set; }//Auto Implemented Properties
        public string ename { get; set; }
        public cities location { get; set; }

        public Emp()  //Default Constructor
        {
            eid = 2000000000;
            ename = "Kavin";
            location = cities.Bangalore;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Emp e = new Emp();
            try
            {
                Console.WriteLine("Enter the Empid");
                e.eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the name");
                e.ename = Console.ReadLine();
                Console.WriteLine("Enter the location(Chennai,Hyderabad, Bangalore, Mumbai,Pune,Delhi");
                string w = Console.ReadLine();
                e.location = (cities)Enum.Parse(typeof(cities), w);
                Console.WriteLine("The employee details are :" + e.eid + " " + e.ename + " " + e.location);
                Console.ReadKey();
            }


            //catch (InvalidEnumArgumentException)
            //{
            //    Console.WriteLine("InvalidEnumArgumentException.....Pls enter a valid City");
            //}
            //catch (ArgumentException)
            //{
            //    Console.WriteLine("ArgumentException....Pls enter a valid City");
            //}
            //catch (FormatException e1)
            //{
            //    Console.WriteLine("Kindly enter Empid in the correct format(int)");
            //}

            catch (Exception e1)
            {
                Console.WriteLine(e1.Source);
                Console.WriteLine(e1.Message);

                Console.WriteLine("Sorry....Incorrect data has been entered for Employee!!!");
            }

            finally
            {
                Console.WriteLine("Inside Finally Block...Its called whether an exception occurs or not");

            }
            Console.WriteLine("After Finally Block");
            Console.Read();
        }
    }
}
