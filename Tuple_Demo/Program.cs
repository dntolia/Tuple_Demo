using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<string, string, double> _tuple = Tuple.Create("John Clark", "B.E. - Computer Engineering", 85.63);
            //_tuple.Item3 = 70; //This will give compilation error
            Console.WriteLine($"{_tuple.Item1}'s got {_tuple.Item3}% score in the {_tuple.Item2}.");
            Console.WriteLine();
            Console.WriteLine("---------------Demo Object As Item in Tuple---------------");
            Console.WriteLine();
            Employee employee = new Employee() { EmployeeId = 1, EmployeeName = "John Clark" };
            Tuple<Employee, string, double> _tupleEmployee = Tuple.Create(employee, "B.E. - Computer Engineering", 85.63);
            Console.WriteLine($"Tuple Item1: {_tupleEmployee.Item1.EmployeeName}");
            _tupleEmployee.Item1.EmployeeName = "John Cloak";
            Console.WriteLine($"Tuple Item1: {_tupleEmployee.Item1.EmployeeName}");
            Console.WriteLine($"Id: {_tupleEmployee.Item1.EmployeeId} Name: {_tupleEmployee.Item1.EmployeeName}'s got {_tuple.Item3}% score in the {_tuple.Item2}.");
            Console.WriteLine();
            Console.WriteLine("---------------Demo As Return Type & Nested Tuple---------------");
            Console.WriteLine();
            Tuple<List<Employee>, List<Result>, Tuple<string, int>, double> _employeeSalary = GetResult();
            Console.WriteLine($"Company Name: {_employeeSalary.Item3.Item1} & No of Employees: {_employeeSalary.Item3.Item2} & Total revenue is: {_employeeSalary.Item4}");
            Console.WriteLine("All employee salaries are as below");
            foreach (var item in _employeeSalary.Item1)
            {
                Console.WriteLine($"Employee Name: {item.EmployeeName}");
                Console.WriteLine($"Employee Salary: {_employeeSalary.Item2.FirstOrDefault(x=>x.EmployeeId==item.EmployeeId).Salary}");
            }
            Console.ReadLine();
        }
        static Tuple<List<Employee>, List<Result>,Tuple<string,int>,double> GetResult()
        {
            List<Employee> _employees = new List<Employee>()
            {
                new Employee() { EmployeeId=1,EmployeeName="Emp1"},
                new Employee() { EmployeeId=2,EmployeeName="Emp2"},
                new Employee() { EmployeeId=3,EmployeeName="Emp3"}
            };
            List<Result> _results = new List<Result>()
            {
                new Result() { EmployeeId=1,Salary=75000},
                new Result() { EmployeeId=2,Salary=85000},
                new Result() { EmployeeId=3,Salary=15000}
            };
            return new Tuple<List<Employee>, List<Result>, Tuple<string, int>,double>(_employees, _results, Tuple.Create("Techy Company",3),500000);
        }
    }
}
