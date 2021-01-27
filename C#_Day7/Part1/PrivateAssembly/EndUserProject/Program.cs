using System;
using PrivateAssembly;


namespace EndUserProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorService calculatorService = new CalculatorService();
            Console.WriteLine("Addition:{0}", calculatorService.Add(7, 8));
            Console.WriteLine("Subtraction:{0}", calculatorService.Sub(20, 8));
            Console.Read();
        }
    }
}
