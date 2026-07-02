namespace Day4Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 1.14: Tuples & Deconstruction ===\n");

            // ---------------------------------------------------------
            // 1. GetMinMax: Returns a named tuple (int Min, int Max)
            // ---------------------------------------------------------
            int[] numbers = { 14, 5, 92, 3, 7, 28, 1 };
            
            // Deconstructing the tuple directly into separate variables
            var (minValue, maxValue) = GetMinMax(numbers);
            
            Console.WriteLine("--- Array Min/Max ---");
            Console.WriteLine($"Array: [{string.Join(", ", numbers)}]");
            Console.WriteLine($"Deconstructed -> Min: {minValue}, Max: {maxValue}\n");


            // ---------------------------------------------------------
            // 2. Employee Lookup: Returns a 3-part named tuple
            // ---------------------------------------------------------
            int empId = 101;
            
            // Deconstructing the employee tuple into separate variables
            var (empName, empAge, empDept) = GetEmployeeDetails(empId);
            
            Console.WriteLine("--- Employee Lookup ---");
            Console.WriteLine($"Lookup for ID: {empId}");
            Console.WriteLine($"Deconstructed -> Name: {empName} | Age: {empAge} | Department: {empDept}\n");


            // ---------------------------------------------------------
            // Bonus: You can also deconstruct into EXISTING variables
            // ---------------------------------------------------------
            string name;
            int age;
            string dept;
            
            // Using existing variables for deconstruction
            (name, age, dept) = GetEmployeeDetails(102);
            Console.WriteLine($"Reassigned to existing variables -> {name}, {age}, {dept}");
        }

        /// <summary>
        /// Calculates the minimum and maximum values in an array.
        /// Returns them as a named tuple.
        /// </summary>
        static (int Min, int Max) GetMinMax(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Array cannot be null or empty.");

            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (int num in numbers)
            {
                if (num < min) min = num;
                if (num > max) max = num;
            }

            // Returning the tuple. The names match the method signature.
            return (min, max); 
        }

        /// <summary>
        /// Simulates an employee database lookup.
        /// Returns a named tuple with 3 elements.
        /// </summary>
        static (string Name, int Age, string Department) GetEmployeeDetails(int employeeId)
        {
            // Mock database logic
            if (employeeId == 101)
                return ("Alice Smith", 29, "Engineering");
            else if (employeeId == 102)
                return ("Bob Jones", 34, "Human Resources");
            else
                return ("Unknown", 0, "Unassigned");
        }
    }
}