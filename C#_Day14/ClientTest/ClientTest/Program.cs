using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruYumBAL;

namespace ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateBAL c = new CalculateBAL();
            Console.WriteLine("Tax Amount that will be deducted for the year is : {0}", c.CalculateTaxBAL(8000));
            Console.ReadKey();
        }
    }
}
