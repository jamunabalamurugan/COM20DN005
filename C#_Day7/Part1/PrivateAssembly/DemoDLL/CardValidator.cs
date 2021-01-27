using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDLL
{
    public class CardValidator
    {
        public bool Validate(string cardno)
        {
            string cno= cardno.Trim();
                if (cno.Length == 16)
            {
                //Write the logic here for validating the card no
              
                return true;
            }
            else
                return false;
        }
    }
}
