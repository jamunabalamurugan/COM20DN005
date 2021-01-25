using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtectedInternalEg;
namespace UseProtectedInternalEgGAC
{
    class Program:AnimalEg
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.AnimalName());
            Console.ReadKey();
        }
    }
}
