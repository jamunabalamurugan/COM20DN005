using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoDLL;
namespace ClientUsingDLL
{
    class Program
    {
        static void Main(string[] args)
        {
            CardValidator cv = new CardValidator() ;
           Console.WriteLine("Enter a card no");
            string cardno = Console.ReadLine();
            if(cv.Validate(cardno))
                Console.WriteLine("Valid Card number");
            else
                Console.WriteLine("Invalid Card number");

            Console.ReadKey();
        }
    }
}
