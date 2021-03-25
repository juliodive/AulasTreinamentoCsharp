using System;
using Entities;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Linq_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            try
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        string email = line[1];
                        double salary = double.Parse(line[2], CultureInfo.InvariantCulture);
                        employees.Add(new Employee(name, email, salary));
                    }
                }
                Console.Write("Enter salary: ");
                double valueSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                var viewsEmail = employees
                    .Where(p => p.Salary > valueSalary)
                    .OrderBy(p => p.Email)
                    .Select(p => p.Email);
                foreach(string emp in viewsEmail)
                {
                    Console.WriteLine(emp);
                }

                var sumSalary = employees.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " 
                    + sumSalary.ToString("F2",CultureInfo.InvariantCulture));

            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
