
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTaxCalculator;
namespace ClientUsingGAC
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxCalculator tc = new TaxCalculator();
            tc.Calculator(40000);
            Console.ReadKey();
        }
    }
}
