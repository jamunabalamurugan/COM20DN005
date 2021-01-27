using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesofClasses
{
    partial class Mobile
    {
        public void TouchPhone()
        {
            Console.WriteLine("Touch phone are a boon to senior citizens");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mobile m = new Mobile();
            m.TouchPhone();
        }
    }
}
