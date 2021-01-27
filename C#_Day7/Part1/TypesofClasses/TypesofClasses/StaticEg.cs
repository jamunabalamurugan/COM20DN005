using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesofClasses
{

     static class Student
    {
        static int id=100;
        static Student()
        {
            Console.WriteLine("I am a static Constructor");
        }
       
        static public void Display()
        {
            Console.WriteLine(id);
        }
    }
    class StaticEg
    {
        static void Main()
        {
            
            Student.Display();
            Console.Read();
        }
    }
}
