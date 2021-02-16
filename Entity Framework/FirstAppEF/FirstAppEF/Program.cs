using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppEF
{
    class Program
    {
       // static dbADOExampleEntities db = new dbADOExampleEntities();
        static dbHumanResourceEntities hrdb = new dbHumanResourceEntities();
        static void Main(string[] args)
        {
            tblEmployeeInfo employee = new tblEmployeeInfo();
            List<tblEmployeeInfo> employees = new List<tblEmployeeInfo>();

            tblDepartment department = new tblDepartment();
            List<tblDepartment> departments = new List<tblDepartment>();

            //Console.WriteLine("Dept Table");
            //foreach (var item in hrdb.tblDepartments)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.WriteLine("Enter New Department");
            //department.Name = Console.ReadLine();
            //Console.WriteLine("Enter Dept id");
            //department.DepId = int.Parse(Console.ReadLine());

            //hrdb.tblDepartments.Add(department);//This adds the department to the DBSet only
            //hrdb.SaveChanges();//From the Dbcpnect make the changes to the database permenantly

            //department = hrdb.tblDepartments.Find(5);
            //Console.WriteLine(department.Name);
          

            departments = (from d in hrdb.tblDepartments
                         where d.Name.Contains("S")
                         select d).ToList();

            foreach (var item in departments)
            {
                Console.WriteLine(item.DepId+"\t"+item.Name);
            }
            Console.ReadKey();




            //tblStudent student = new tblStudent();
            //List<tblStudent> students = db.tblStudents.ToList();
            //foreach (var item in students)
            //{
            //    Console.WriteLine(item.name);
            //}

            //student.id = 105;
            //student.name = "Banu";
            //student.age = 21;
            //db.tblStudents.Add(student);
            //db.SaveChanges();


            //students.Add(new tblStudent { id = 106, name = "Jamuna", age = 21 });
            //students.Add(new tblStudent { id = 107, name = "Joshi", age = 21 });
            ////db.tblStudents.Add(students);

            //Console.ReadKey();
        }
    }
}
