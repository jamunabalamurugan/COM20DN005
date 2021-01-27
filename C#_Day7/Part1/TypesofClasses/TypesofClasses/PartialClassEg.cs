using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesofClasses
{
  partial class Mobile
    {
        public void Call()
        {
            Console.WriteLine("HI!!");
        }

    }

   partial class Mobile
    {
        public void Message()
        {
            Console.WriteLine("Don't Sleep!!");
        }
    }
    namespace AnotherNS
    {
        class Demo
        {

        }
    }
    class PartialClassEg
    {
        static void Main()
        {
            Mobile mobj = new Mobile();
            mobj.Call();
            mobj.Message();
            //mobj.NewMethod();
            
            Console.ReadKey();
        }
    }
}

namespace NewTypesOfClasses
{
    partial class Mobile
    {

    }
}
