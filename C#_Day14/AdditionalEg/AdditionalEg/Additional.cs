using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalEg
{
    class Demo
    {
        public int a;
        private int b;

        public int c { get; }//read only

        //static
        //ref
        //out
        //Constructor
        //Exceptions
        //Operators
        //SC,COMPILER,MSIL,CLR,JIT,EXECUTABLE
        //CLS,CTS
        //BOX,UNBOXING


        //public Calculate(int a,ref int b,out int total,int[] x)
        //{
        //    int c = 10;
        //}

      
        public bool Calculate(int a,int b)
        {
            bool status = false;
            this.a = a + 10;
            this.b = b;
            b = c + 5; //We can readv the value of c and assign it to b....but the reverse is possible
          //  c = b + 5;//set method is not available....so we cannot assign a value

            //if (a > 5)
            //{
            //    bool status = trueou
            //}
            //else
            //{
            //    bool status = false;
            //}

            return status;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Demo d = new Demo();
            d.Calculate(25, 11);


            //Console.WriteLine("The value of a is {0} and b is {1}", d.a, d.b);
            int a, b = 0;
            try
            {
                
                a = 0;
                b = 1150/ a;
                a += b;
                int i=a++;
                --a;
                Console.WriteLine("b is now {0}", b);

            }
            
            //catch(DivideByZeroException e)
            //{
            //    Console.WriteLine("Derived Class Exception b is {0}",b);
            //}
            catch (ArithmeticException e)
            {
                Console.WriteLine("Exception occured....b is {0}", b);
            }
            catch (Exception e)
            {
                Console.WriteLine("Outer Base Exception is {0}",b);
            }
            Console.ReadLine();
        }
    }
}
