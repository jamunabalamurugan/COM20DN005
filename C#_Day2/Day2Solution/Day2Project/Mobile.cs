using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Project
{
    class Mobile
    {
        public string color;//variable
        public float price;//variable creation
        //Constructor
        public Mobile()
        {
            color = "Blue";
            price = 12321.2f;
        }
        public void PrintMobileSpec()
        {
            Console.WriteLine("The color is "+color);
            Console.WriteLine("The price is "+price);
        }
        public void MakeCall()
        {
            Console.WriteLine("Dial number and press the call button");
        }
    }
}
