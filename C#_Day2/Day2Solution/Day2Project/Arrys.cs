using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Project
{
    class Arrys
    {
        static void array1()
        {
            int _size;
            Console.WriteLine("Enter array size");
            _size = int.Parse(Console.ReadLine());
            int[] a = new int[_size];
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("enter a[" + i + "] value");
                //Console.WriteLine("enter a[{0}] value",i);
                a[i] = int.Parse(Console.ReadLine());
            }
            //Max
            int _max;
            _max = a[0];
            foreach (int k in a)
            {
                if (_max < k)
                {
                    _max = k;
                }
            }
            Console.WriteLine("Maximum value =" + _max);
            Console.Read();
        }
        static void array2()
        {
            int[,] a = new int[2, 3] { { 2, 5, 7 }, { 4, 8, 3 } };
            //lenght of the array
            Console.WriteLine("Lenght= " + a.Length);
            //rank of the array
            Console.WriteLine("Rank= " + a.Rank);
            Console.WriteLine();
            foreach (int i in a)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();

            //Returns max rowindex
            Console.WriteLine(a.GetUpperBound(0));
            //Returns max column index
            Console.WriteLine(a.GetUpperBound(1));
            //Display in Multiple rows and columns
            Console.WriteLine("\n");
            for (int i = 0; i <= a.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= a.GetUpperBound(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.Read();
        }
        static void array3()
        {
            //char array
            char[] ch = { 'a', 'r', 'y', 'o' };
            Console.WriteLine(ch[2]);
            string[] s1 = new string[3];
            s1[0] = "David";
            s1[1] = "Peter";
            s1[2] = "Rahul";
            foreach (string s in s1)
            {
                Console.WriteLine(s);
            }
            Console.Read();
        }
        static void array4()
        {
            string[,] emp = { { "E0001", "David", "Teamleader" },
                            { "E0002", "Peter", "Programmer" },
             { "E0003", "Kavin", "Programmer" },
              { "E0004", "Kanav", "Programmer" }
            };
            string _empid;
            Console.WriteLine("Enter Employee Id");

            _empid = Console.ReadLine();
            int _flag = 0;
            for (int i = 0; i <= emp.GetUpperBound(0); i++)
            {
                if (_empid == emp[i, 0])
                {
                    Console.WriteLine("Empname= " + emp[i, 1]);
                    Console.WriteLine("Designation=" + emp[i, 2]);
                    _flag = 1;
                }

            }
            if (_flag == 0)
            {
                Console.WriteLine("Invalid Empid");
            }
            Console.Read();
        }
        static void Main()
        {
            array1();
           // array4();
        }

    }
}
