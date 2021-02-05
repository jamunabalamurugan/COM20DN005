using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruYumLibrary;
namespace TruYumBAL
{
    public class CalculateBAL
    {
        public double CalculateTaxBAL(float sal)
        {
            if(sal>50000)
            {
                Calculator c = new Calculator();
                return c.CalculateTax(sal);
            }
            return 0;
        }
    }
}
