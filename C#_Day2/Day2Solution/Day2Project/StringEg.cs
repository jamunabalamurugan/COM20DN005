using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Project
{
    class StringEg
    {
        static void Main()
        {
            ArrayEg();
            Console.ReadKey();
        }
        static void ArrayEg()
        {
            String[] students = { "Kavin", "Alwin", "Kanav" };
            Console.WriteLine(students.Length);
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine(students[0]);

        }
        static void Method1()
        {
            //Declaration of a string
            string str = "Welcome to strings";
            string s1;
            //copy
            //s1=str
            s1 = string.Copy(str);
            s1 = " in c#";
            //concat
            //str = str + s1;
            str = string.Concat(str, s1);
            Console.WriteLine(str);
            s1 = "WelcoMe";
            string s2 = "welcome";
            //if (s1 == s2)
            //{
            //    Console.WriteLine("2 strings are equal");
            //}
            if (string.Compare(s1, s2, true) == 0)
            {
                Console.WriteLine("strings are equal");
            }
            else
            {
                Console.WriteLine("strings are not equal");
            }
            //toupper
            s1 = "welcome to CSharp";
            Console.WriteLine(s1.ToUpper());
            //tolower
            Console.WriteLine(s1.ToLower());
            //length
            Console.WriteLine(s1.Length);
            //return a specific char
            Console.WriteLine(s1[5]);
            Console.Read();

        }
        static void ReplaceSpaces()
        {
            Console.WriteLine("enter any string");
            string s1 = Console.ReadLine();
            string s2 = null;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == ' ')
                {
                    s2 += "_";
                }
                else
                {
                    s2 += s1[i];
                }
            }
            Console.WriteLine(s2);
            Console.ReadKey();
        }
        static void Method2()
        {
            Console.WriteLine("enter any string");
            string s1 = Console.ReadLine();
            string s2 = null;
            char[] ch = new char[s1.Length];
            for (int i = 0; i < ch.Length; i++)
            {
                if (s1[i] == ' ')
                {
                    ch[i] = '_';
                }
                else
                {
                    ch[i] = s1[i];
                }
            }
            //converting char array to string
            string _result = new string(ch);
            Console.WriteLine(ch);
            Console.WriteLine(s2);
            Console.WriteLine(_result);
            
        }
        static void Method3()
        {
            //convert string to char array
            string s1 = "welcome to CSharp";
            //ToCharArray() convets string to given char array
            char[] c1 = s1.ToCharArray();
            foreach (char c in c1)
            {
                Console.Write(c);
            }
            //split
            Console.WriteLine();
            string s2 = "C#.net,vb.net asp.net_SQL";
            string[] s = s2.Split(',', ' ', '_');
            foreach (string k in s)
            {
                Console.WriteLine(k);
            }
        }
        static void Method4()
        { 
            //join
            string[] s1 = { "c#.net", "vb.net", "asp.net" };
            string s = string.Join("~", s1);
            bool _result = s1.Contains("vb.net");
            Console.WriteLine(_result);
            Console.WriteLine(s);
            //Replace
            s = s.Replace('~', '_');
            Console.WriteLine(s);
            s = s.Replace("asp.net", "sql server");
            Console.WriteLine(s);
            //substring
            string s3 = "PNR10033453CHE";
            s3 = s3.Substring(3, 8);
            Console.WriteLine(s3);
            //format string
            double d =1200;
            Console.WriteLine(string.Format("{0:C}", d));
            Console.WriteLine(DateTime.Today);
            DateTime dob = DateTime.Parse("01/05/2021");
            Console.WriteLine(string.Format("{0:D}",dob));

           
        }
        static void Method5()
        {

            CultureInfo us = CultureInfo.GetCultureInfo("en-US");
            CultureInfo ind = CultureInfo.GetCultureInfo("hi-IN");
            CultureInfo brit = CultureInfo.GetCultureInfo("en-GB");
            //string s = string.Format(us, "{0:C}", value);
            decimal moneyvalue = 1924371.39m;
            string result = String.Format(us, "Order Total: {0:C}", moneyvalue);

            Console.WriteLine(result);

             result = String.Format(ind, "Order Total: {0:C}", moneyvalue);

            Console.WriteLine(result);
            result = String.Format(brit, "Order Total: {0:C}", moneyvalue);

            Console.WriteLine(result);

            //CultureInfo[] custom = CultureInfo.GetCultures(CultureTypes.AllCultures);
            //    Console.WriteLine("Custom cultures:");
            //    foreach (var culture in custom)
            //        Console.WriteLine("   {0} -- {1}", culture.Name, culture.DisplayName);
        }
        static void  Method6()
        {
            int _dollor = 1230;
            int _precentage = 134;
            double _fraction = 13.4456;
            string s = DateTime.Now.ToString();
            Console.WriteLine("Dollor Format:{0:C}", _dollor);
            Console.WriteLine("Percentage Format:{0:P}", _precentage);
            Console.WriteLine("Fraction Format:{0:F3}", _fraction);
            Console.WriteLine(s);
            DateTime d = DateTime.Now;
            Console.WriteLine("Long date:{0:D}", d);
            Console.WriteLine("short date:{0:d}", d);
            Console.WriteLine("Long Time:{0:T}", d);
            Console.WriteLine("short Time:{0:t}", d);
            Console.Read();
        }
        static void Method7()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("welcome ");
            _sb.Append("to ");
            _sb.Append("Cognizant ");
            _sb.Append("Technolgies Chennai");
            _sb.AppendFormat("{0:C}", 1200);

            Console.WriteLine(_sb);
            //convert stringbuilder into string
            string s = _sb.ToString();
            Console.WriteLine(s);
            StringBuilder sb1 = new StringBuilder();
            object i = 123;
            sb1.AppendFormat("{0:C}", i);
            Console.WriteLine(sb1);
            Console.Read();
        }
      
    }
}
