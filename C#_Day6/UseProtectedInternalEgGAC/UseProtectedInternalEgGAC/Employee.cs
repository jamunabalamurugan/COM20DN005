using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseProtectedInternalEgGAC
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get => age; set => age = value; }

        int age;

        public string[] Skills;//created the reff

        public Employee()
        {
            Console.WriteLine("Please enter the number of skills");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size < 1)
            {
                Console.WriteLine("Invalid number of skills. Please enter again");
            }
            Skills = new string[size];
        }
        /// <summary>
        /// Takes Employee data from user in the console
        /// </summary>
        /// <param name="id">The employee id is passed as parameter</param>
        public void TakeEmployeeDatafromUser(int id)
        {
            Id = id;
            Console.WriteLine("Please enter the employee name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter the employee age");
            while (!int.TryParse(Console.ReadLine(), out age) || age < 18)
            {
                Console.WriteLine("Invalid age. Please enter again");
            }
            Console.WriteLine("Please enter all the {0} the skills", (Skills.Length));
            for (int i = 0; i < Skills.Length; i++)
            {
                Skills[i] = Console.ReadLine();
            }
        }

        public void PrintEmployeeData()
        {
            Console.WriteLine("The employee ID is " + Id);
            Console.WriteLine("The employee name is " + Name);
            Console.WriteLine("The Employee age is " + age);
            Console.WriteLine("The employee skills are");
            foreach (string skill in Skills)
            {
                Console.WriteLine(skill);
            }
        }


    }
}
