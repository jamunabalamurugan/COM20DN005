using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Project
{
    class Laptop
    {
        public float speed;
         private string display;
        public Laptop()
        {
            speed = 11.2f;
            display = "LED";
        }

       public void ShowDetails()
        {
            Console.WriteLine("The laptop details are");
            Console.WriteLine(speed);
            Console.WriteLine(display);
        }
        public void SwitchOn()
        {
            Console.WriteLine("The laptop is powered on");
        }
        public void PowerOff()
        {
            Console.WriteLine("Power gone.....");
        }
    }
}
