using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Project
{
    class Student
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public Student()
        { }
        public void TakeStudentData()
        {
            Console.WriteLine("Please enter the student ID");
            Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the student Name");
            Name = Console.ReadLine();
            int day, month, year;
            Console.WriteLine("Please enter the student day of birth");
            day = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the student month of birth");
            month = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the student year of birth");
            year = int.Parse(Console.ReadLine());
            DateOfBirth = new DateTime(year, month, day);
        }
        public void PrintStudentDetails()
        {
            Console.WriteLine("ID " + Id + "\nName " + Name + "\nDate of birth  " + DateOfBirth);
        }
    }
}
