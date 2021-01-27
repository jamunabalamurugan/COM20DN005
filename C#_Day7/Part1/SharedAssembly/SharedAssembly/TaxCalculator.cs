using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAssembly
{
    public class TaxCalculator
    {
        public void Calculator(int Salary)
        {
            int Result;
            if((Salary*12)>300000)
            {
                Result = (Salary * 12) / 10;
            }
            else
            {
                Result = 0;
            }

            Console.WriteLine("Amount to be Paid is :{0}", Result);
        }
       
    }
}
