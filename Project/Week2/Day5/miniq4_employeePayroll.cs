using System;
using System.Collections.Generic;
using System.Linq;

namespace Week2.Day5.Payroll
{
    // ITaxable — a capability contract, only applies to FullTimeEmployee
    // in this exercise. Not every employee type needs to expose tax info,
    // so this stays an interface rather than living on the abstract base.
    public interface ITaxable
    {
        decimal CalculateTax();
    }

    // Abstract base — shared identity (every Employee has a Name, Department)
    // but each subtype computes salary completely differently, so
    // CalculateSalary() is left abstract for each child to implement.
    public abstract class Employee
    {
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;

        public abstract decimal CalculateSalary();
    }

    public class FullTimeEmployee : Employee, ITaxable
    {
        public decimal MonthlySalary { get; set; }

        public override decimal CalculateSalary() => MonthlySalary;

        // Flat 10% tax bracket, kept simple for the exercise.
        public decimal CalculateTax() => MonthlySalary * 0.10m;
    }

    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public override decimal CalculateSalary() => HourlyRate * HoursWorked;
    }

    public class ContractEmployee : Employee
    {
        public decimal ContractAmount { get; set; }

        public override decimal CalculateSalary() => ContractAmount;
    }

    public class Task_MiniQ4_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Mini Q4: Employee Payroll ----");

            List<Employee> employees = new List<Employee>
            {
                new FullTimeEmployee { Name = "Arun", Department = "Engineering", MonthlySalary = 65000 },
                new FullTimeEmployee { Name = "Meena", Department = "Engineering", MonthlySalary = 72000 },
                new PartTimeEmployee { Name = "Karthik", Department = "Engineering", HourlyRate = 400, HoursWorked = 90 },
                new PartTimeEmployee { Name = "Priya", Department = "Sales", HourlyRate = 350, HoursWorked = 100 },
                new ContractEmployee { Name = "Ravi", Department = "Sales", ContractAmount = 40000 },
                new ContractEmployee { Name = "Sanjay", Department = "HR", ContractAmount = 38000 },
                new FullTimeEmployee { Name = "Anitha", Department = "HR", MonthlySalary = 58000 },
            };

            // POLYMORPHISM: every element calls its OWN CalculateSalary(),
            // even though they're all stored as the base type "Employee".
            decimal totalPayroll = employees.Sum(e => e.CalculateSalary());
            Console.WriteLine($"Total Payroll: {totalPayroll:C}");

            // Only FullTimeEmployee implements ITaxable, so we filter+cast
            // using "is" pattern matching to safely find just those.
            Console.WriteLine("\nTax breakdown (FullTime employees only):");
            foreach (Employee emp in employees)
            {
                if (emp is ITaxable taxable)
                    Console.WriteLine($"  {emp.Name}: Tax = {taxable.CalculateTax():C}");
            }

            // LINQ GroupBy department, showing count + total salary per department
            var byDepartment = employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    Count = g.Count(),
                    TotalSalary = g.Sum(e => e.CalculateSalary())
                });

            Console.WriteLine("\nPer-department breakdown:");
            foreach (var d in byDepartment)
                Console.WriteLine($"  {d.Department}: {d.Count} employees, Total = {d.TotalSalary:C}");

            Console.WriteLine();
        }
    }
}