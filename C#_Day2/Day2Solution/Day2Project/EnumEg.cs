using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Project
{
    class EnumEg
    {

        public enum Range : byte
        {
            Min = byte.MinValue, Max = byte.MaxValue

        };

        public enum Days
        {
            Sun=1,Mon,Tue,Wed,Thur,Fri,Sat
        };
            static void EnumEx1()
            {
                int val = (int)Days.Sat;
                Console.WriteLine(val);

                Console.WriteLine("value of {0} ={1}", Range.Min, (byte)Range.Min);
                Console.WriteLine("value of {0} ={1}", Range.Max, (byte)Range.Max);
                Console.Read();
            }
        public enum Errmsg
        {
            LoginSuccess = 1,
            LoginFailed=0

        };
            static Errmsg Validate(string uname, string pwd)
            {
                if (uname == "David" && pwd == "12345")
                {

                    return Errmsg.LoginSuccess;
                }
                else
                {
                    return Errmsg.LoginFailed;
                }
            }
    
        static void Main()
        {
            EnumEx1();
            Console.WriteLine(Validate("David", "1234"));
            Console.ReadKey();
        }
        
    }
}
