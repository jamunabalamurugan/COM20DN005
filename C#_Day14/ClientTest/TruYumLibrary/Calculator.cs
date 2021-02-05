using System;

namespace TruYumLibrary
{
    public class Calculator
    {
        public double CalculateTax(float sal)
        {
            double taxamount = (sal * 12) * 0.3;
            return taxamount;
        }
    }
}
