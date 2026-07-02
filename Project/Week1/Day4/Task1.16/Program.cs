using System;

namespace Day4Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 1.16: Class Anatomy, Validation & Constants ===\n");

            // ---------------------------------------------------------
            // 1. Constructor Chaining & Valid Age
            // ---------------------------------------------------------
            Console.WriteLine("--- 1. Constructor Chaining ---");
            Student student1 = new Student("Alice Smith", 22, "STU-1001");
            student1.PrintDetails();

            // Using the chained constructor (omits EnrollmentId)
            Student student2 = new Student("Bob Jones", 19);
            student2.PrintDetails();

            // ---------------------------------------------------------
            // 2. Property Validation (Rejecting out-of-range age)
            // ---------------------------------------------------------
            Console.WriteLine("\n--- 2. Property Validation ---");
            try
            {
                Console.WriteLine("Attempting to create a student with age 105...");
                Student invalidStudent = new Student("Charlie Brown", 105, "STU-1003");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"[Caught Exception] Validation rejected the age! Message: {ex.Message}");
            }

            // ---------------------------------------------------------
            // 3. Overloaded CalculateGrade()
            // ---------------------------------------------------------
            Console.WriteLine("\n--- 3. Overloaded CalculateGrade() ---");
            double percentage = 88.5;
            Console.WriteLine($"Standard Grade: {student1.CalculateGrade(percentage)}");
            Console.WriteLine($"Honors Grade:   {student1.CalculateGrade(percentage, true)}");

            // ---------------------------------------------------------
            // 4. Const vs Readonly Fields
            // ---------------------------------------------------------
            Console.WriteLine("\n--- 4. Const vs Readonly Fields ---");
            Console.WriteLine($"School Name (Const):   {Student.SchoolName}");
            Console.WriteLine($"Enrollment ID (Readonly): {student1.EnrollmentId}");

            // INSTRUCTIONS FOR YOUR LEARNING DOCUMENT:
            // Uncomment the lines below one by one to trigger compile errors.
            // Take screenshots of the Error List in Visual Studio / VS Code.
            
            // Error 1: Cannot change a const field outside of its declaration.
            // Student.SchoolName = "New School"; 

            // Error 2: Cannot change a readonly field outside of a constructor.
            // student1.EnrollmentId = "STU-9999"; 
        }
    }

    public class Student
    {
        // CONST: Compile-time constant. Must be initialized at declaration.
        // Implicitly static, so we access it via the Class name (Student.SchoolName).
        public const string SchoolName = "Global Tech Academy";

        // READONLY: Runtime constant. Can be initialized at declaration OR in the constructor.
        // It is an instance field, so we access it via the object (student1.EnrollmentId).
        public readonly string EnrollmentId;

        // Auto-implemented property
        public string Name { get; set; }

        // Backing field for Age to allow custom validation logic
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 5 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Age must be between 5 and 100.");
                }
                _age = value;
            }
        }

        // Primary Parameterized Constructor
        public Student(string name, int age, string enrollmentId)
        {
            Name = name;
            Age = age; // This triggers the validation in the property setter
            EnrollmentId = enrollmentId; // Readonly field assigned in constructor
        }

        // Chained Constructor using : this(...)
        // If EnrollmentId is not provided, it defaults to "UNKNOWN-ID"
        public Student(string name, int age) : this(name, age, "UNKNOWN-ID")
        {
            // No extra logic needed here, the chained constructor handles it
        }

        // Overloaded Method 1
        public string CalculateGrade(double percentage)
        {
            if (percentage >= 90) return "A";
            if (percentage >= 80) return "B";
            if (percentage >= 70) return "C";
            if (percentage >= 60) return "D";
            return "F";
        }

        // Overloaded Method 2 (Adds an honors distinction)
        public string CalculateGrade(double percentage, bool isHonors)
        {
            string baseGrade = CalculateGrade(percentage);
            return isHonors ? $"{baseGrade} (Honors)" : baseGrade;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"  -> Student: {Name} | Age: {Age} | ID: {EnrollmentId} | School: {SchoolName}");
        }
    }
}