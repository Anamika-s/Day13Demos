using System;
using Day13Demos.Models;
using System.Collections.Generic;
using System.Linq;
namespace Day13Demos
{
    class Program
    {
        static EmployeeDbContext db = new EmployeeDbContext();
        static int InsertEmployee(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return 1;
        }
        static List<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }
        static Employee GetEmployee(int id)
        {
            Employee employee = db.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }
        static int DeleteEmployee(int id)
        {
            //Employee employee = db.Employees.FirstOrDefault(x => x.Id == id);
            Employee employee = GetEmployee(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                return 1;
            }
            else
                return 0;
        }
        static int UpdateEmployee(int id, string manager, string department, double salary)
        {
            foreach (Employee temp in db.Employees)
            {
                if (temp.Id == id)
                {
                    temp.Department = department;
                    temp.Manager = manager;
                    temp.Salary = salary;
                    break;
                }
            }
            db.SaveChanges();
            return 1;
        }
        static void Main(string[] args)
        {
            string ch = "y";
            while (ch == "y")
            {
                Console.WriteLine("Enter Choice\n1. Add\n 2.Update \n 3. Delete \n 4. Search \n 5. Get All Employee");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Manager Name");
                            string manager = Console.ReadLine();
                            Console.WriteLine("Enter Department");
                            string department = Console.ReadLine();
                            Console.WriteLine("Enter Salary");
                            double salary = double.Parse(Console.ReadLine());
                            Employee emp = new Employee()
                            {
                                Name = name,
                                Manager = manager,
                                Department = department,
                                Salary = salary
                            };
                            int flag = InsertEmployee(emp);
                            if (flag == 1)
                                Console.WriteLine("Record Inserted");
                            break;
                        }
                    case "5":
                        {
                            List<Employee> employees = GetAllEmployees();
                            if (employees.Count == 0)
                                Console.WriteLine("No Records");
                            else
                                foreach (Employee temp in db.Employees)
                                    Console.WriteLine(temp.Id + " " + temp.Name + " " + temp.Department + " " + temp.Manager + " " + temp.Salary);

                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter ID for that you want to search record");
                            int id = int.Parse(Console.ReadLine());
                            Employee employee = GetEmployee(id);
                            if (employee == null)
                                Console.WriteLine("Record with {0} id does not exist", id);
                            else
                                Console.WriteLine(employee.Id + " " + employee.Name + " " + employee.Department + " " + employee.Manager + " " + employee.Salary);

                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter ID for that you want to delete record");
                            int id = int.Parse(Console.ReadLine());
                            int flag = DeleteEmployee(id);
                            if (flag == 1)
                                Console.WriteLine("Record Deleted");
                            else
                                Console.WriteLine("Record with this {0} id does not exist", id);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter ID for that you want to edit record");
                            int id = int.Parse(Console.ReadLine());
                            Employee employee = GetEmployee(id);
                            if (employee != null)
                            {
                                Console.WriteLine("Enter New Manager Name");
                                string manager = Console.ReadLine();
                                Console.WriteLine("Enter New Department");
                                string department = Console.ReadLine();
                                Console.WriteLine("Enter New Salary");
                                double salary = double.Parse(Console.ReadLine());
                                int flag = UpdateEmployee(id, manager, department, salary);
                                if (flag == 1)
                                    Console.WriteLine("Recod updated");
                            }
                            else
                                Console.WriteLine("Record with this {0} id does not exist", id);
                            break;
                        }
                }





                //// Insert Records

                //Employee employee = new Employee()
                //{ Name = "Deepak", Department = "Accts", Manager = "Lalit", Salary = 9000 };
                //db.Employees.Add(employee);
                //db.SaveChanges();
                Console.WriteLine("Do you want to repeat");
                ch = Console.ReadLine();
            }
        }
    }
}