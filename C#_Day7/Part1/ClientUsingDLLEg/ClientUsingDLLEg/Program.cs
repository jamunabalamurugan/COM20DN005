using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoDLL;
using PrivateAssembly;
using SharedAssembly;
namespace ClientUsingDLLEg
{
    class Program
    {
        static void Main(string[] args)
        {
            //CardValidator obj1 = new CardValidator();
            //CalculatorService cs = new CalculatorService();
            //Console.WriteLine(cs.Add(45, 67));

            TaxCalculator tc = new TaxCalculator();
            tc.Calculator(50000);
           // Console.WriteLine(  "The Tax Amount if {0}", tc.Calculator(50000));

            Console.ReadLine();


        }
    }
}
