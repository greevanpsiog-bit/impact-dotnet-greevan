using System;
using System.Collections.Generic;
using System.Linq;

namespace Week2.Day4
{
    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }

        // Simple "years since joining" calculation, used by the anonymous
        // projection query below.
        public double YearsOfExperience => (DateTime.Today - JoiningDate).TotalDays / 365.0;
    }

    public class Task2_13_Demo
    {
        public static List<Employee> BuildSampleEmployees()
        {
            return new List<Employee>
            {
                new() { Name = "Arun",    Department = "Engineering", Salary = 65000, JoiningDate = new DateTime(2019, 3, 15) },
                new() { Name = "Meena",   Department = "Engineering", Salary = 72000, JoiningDate = new DateTime(2020, 7, 1) },
                new() { Name = "Karthik", Department = "Engineering", Salary = 48000, JoiningDate = new DateTime(2023, 1, 10) },
                new() { Name = "Priya",   Department = "Sales",       Salary = 55000, JoiningDate = new DateTime(2018, 11, 5) },
                new() { Name = "Ravi",    Department = "Sales",       Salary = 51000, JoiningDate = new DateTime(2021, 6, 20) },
                new() { Name = "Divya",   Department = "Sales",       Salary = 47000, JoiningDate = new DateTime(2022, 9, 12) },
                new() { Name = "Sanjay",  Department = "HR",          Salary = 60000, JoiningDate = new DateTime(2017, 2, 28) },
                new() { Name = "Anitha",  Department = "HR",          Salary = 45000, JoiningDate = new DateTime(2024, 4, 1) },
                new() { Name = "Vikram",  Department = "Finance",     Salary = 80000, JoiningDate = new DateTime(2016, 8, 19) },
                new() { Name = "Lakshmi", Department = "Finance",     Salary = 58000, JoiningDate = new DateTime(2020, 12, 3) },
                new() { Name = "Suresh",  Department = "Finance",     Salary = 52000, JoiningDate = new DateTime(2022, 5, 25) },
            };
        }

        public static void Run()
        {
            Console.WriteLine("---- Task 2.13: LINQ (query syntax vs method syntax) ----");
            List<Employee> employees = BuildSampleEmployees();

            // ===============================================================
            // QUERY 1: filter salary > 50000, order by salary desc
            // ===============================================================

            // Query syntax reads like SQL: "from ... where ... orderby ... select"
            var query1_querySyntax =
                from e in employees
                where e.Salary > 50000
                orderby e.Salary descending
                select e;

            // Method syntax chains extension methods with lambdas.
            // This is what query syntax actually compiles down to under the hood.
            var query1_methodSyntax = employees
                .Where(e => e.Salary > 50000)
                .OrderByDescending(e => e.Salary);

            Console.WriteLine("\nQuery 1 - Query syntax (salary > 50000, desc):");
            foreach (var e in query1_querySyntax)
                Console.WriteLine($"  {e.Name} - {e.Salary:C}");

            Console.WriteLine("Query 1 - Method syntax (should match above):");
            foreach (var e in query1_methodSyntax)
                Console.WriteLine($"  {e.Name} - {e.Salary:C}");

            // ===============================================================
            // QUERY 2: group by department -> count + average salary
            // ===============================================================

            var query2_querySyntax =
                from e in employees
                group e by e.Department into deptGroup
                select new
                {
                    Department = deptGroup.Key,
                    Count = deptGroup.Count(),
                    AverageSalary = deptGroup.Average(x => x.Salary)
                };

            var query2_methodSyntax = employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    Count = g.Count(),
                    AverageSalary = g.Average(x => x.Salary)
                });

            Console.WriteLine("\nQuery 2 - Query syntax (group by department):");
            foreach (var g in query2_querySyntax)
                Console.WriteLine($"  {g.Department}: Count={g.Count}, Avg={g.AverageSalary:C}");

            Console.WriteLine("Query 2 - Method syntax (should match above):");
            foreach (var g in query2_methodSyntax)
                Console.WriteLine($"  {g.Department}: Count={g.Count}, Avg={g.AverageSalary:C}");

            // ===============================================================
            // QUERY 3: project to anonymous type { Name, Experience }
            // ===============================================================

            var query3_querySyntax =
                from e in employees
                select new { e.Name, Experience = Math.Round(e.YearsOfExperience, 1) };

            var query3_methodSyntax = employees
                .Select(e => new { e.Name, Experience = Math.Round(e.YearsOfExperience, 1) });

            Console.WriteLine("\nQuery 3 - Query syntax (anonymous projection):");
            foreach (var e in query3_querySyntax)
                Console.WriteLine($"  {e.Name} - {e.Experience} yrs");

            Console.WriteLine("Query 3 - Method syntax (should match above):");
            foreach (var e in query3_methodSyntax)
                Console.WriteLine($"  {e.Name} - {e.Experience} yrs");

            Console.WriteLine();
        }
    }
}