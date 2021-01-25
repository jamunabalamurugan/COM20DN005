using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseProtectedInternalEgGAC
{
    class Company
    {
        Employee[] employees;
        // indexer
        public Employee this[int index]//"this" is an implicit reff to the curr object
        {
            get { return employees[index]; }
            set { employees[index] = value; }
        }
        public Company()
        {
            int size;
            Console.WriteLine("Please enter the number of employees");
            while (!int.TryParse(Console.ReadLine(), out size) || size < 1)
            {
                Console.WriteLine("Invalid number. Please enter again");
            }
            employees = new Employee[size];
        }
        public void AddEmployees()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = new Employee();
                employees[i].TakeEmployeeDatafromUser((i + 1));
            }
        }
        public Employee GetEmployeeByID(int id)
        {
            Employee employee = null;
            if (id > 0 && id <= employees.Length)
            {
                employee = employees[id - 1];
            }
            return employee;
        }
        public void UpdateEmployee()
        {
            Console.WriteLine("Please enter the emloyee id for updation");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 1)
            {
                Console.WriteLine("Invalid id. Please enter again");
            }
            Employee employee = GetEmployeeByID(id);
            if (employee == null)
                Console.WriteLine("Invalid Id. No such employee");
            else
            {
                Console.WriteLine("The employee current details are");
                employee.PrintEmployeeData();
                Employee updatedEmployee = new Employee();
                updatedEmployee.TakeEmployeeDatafromUser(id);
                employees[id - 1] = updatedEmployee;
            }
        }
        public void DeleteEmployee()
        {
            Console.WriteLine("Please enter the emloyee id for deletion");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 1)
            {
                Console.WriteLine("Invalid id. Please enter again");
            }
            if (id <= employees.Length)
            {
                employees[id - 1] = null;
            }
            else
                Console.WriteLine("No such employee. No employee deleted!!");
        }
        public void PrintAllEmployees()
        {
            foreach (var employee in employees)
            {
                if (employee != null)
                    employee.PrintEmployeeData();
                else
                    Console.WriteLine("Employee deleted");
                Console.WriteLine("--------------------------------------");
            }
        }
    }

    class UseCompanyProgram
    {
        void PrintMenu()
        {
            Company company = new Company();
            company.AddEmployees();
            int iChoice = 0;
            do
            {
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. Update Employee details");
                Console.WriteLine("2. Delete an Employee");
                Console.WriteLine("3. Print All Employees");
                Console.WriteLine("4. Print One Employee");
                Console.WriteLine("5. Exit");
                while (!int.TryParse(Console.ReadLine(), out iChoice) || iChoice > 4)
                {
                    Console.WriteLine("Invald entry please try again...");
                }
                switch (iChoice)
                {
                    case 1:
                        Console.WriteLine("You can update employee details by enteringthe id");
                        company.UpdateEmployee();
                        break;
                    case 2:
                        Console.WriteLine("You can delete employee details by entering the id");
                        company.DeleteEmployee();
                        break;
                    case 3:
                        Console.WriteLine("All employee details");
                        company.PrintAllEmployees();
                        break;
                    case 4:
                        int id;
                        Console.WriteLine("Please enter the id");
                        while (!int.TryParse(Console.ReadLine(), out id) || id < 1)
                        {
                            Console.WriteLine("Invalid id. Please enter again");
                        }
                        company[id - 1].PrintEmployeeData();
                        break;
                    case 5:
                        Console.WriteLine("Bye bye.......");
                        break;
                    default:
                        Console.WriteLine("Invald entry please try again...");
                        break;
                }

            } while (iChoice != 5);
        }
        static void Main(string[] args)
        {
            UseCompanyProgram program = new UseCompanyProgram();
            program.PrintMenu();
            Console.ReadKey();
        }
    }
}
