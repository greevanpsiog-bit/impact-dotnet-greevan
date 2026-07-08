
using System;
using System.Collections.Generic;

namespace Week2.Day2
{
    // =====================================================================
    // PART 1: METHOD OVERLOADING
    // Same method name, different parameter list. The COMPILER decides
    // which one to call based on the arguments you pass — this is
    // resolved at compile time, not runtime.
    // =====================================================================
    public class Calculator
    {
        public int Add(int a, int b) => a + b;

        public double Add(double a, double b) => a + b;

        public int Add(int a, int b, int c) => a + b + c;

        // params lets the caller pass any number of ints: Add(1,2,3,4,5)
        public int Add(params int[] numbers)
        {
            int sum = 0;
            foreach (int n in numbers) sum += n;
            return sum;
        }
    }

    // =====================================================================
    // PART 2: RUNTIME POLYMORPHISM
    // Reuses Shape / Circle / Rectangle from Task 2.4.
    // A List<Shape> can hold Circles and Rectangles at the same time,
    // and calling DisplayArea() on each picks the correct CalculateArea()
    // automatically. This is decided at RUNTIME based on the actual object.
    // =====================================================================

    // =====================================================================
    // PART 3: METHOD HIDING ("new") vs OVERRIDING ("override")
    // =====================================================================
    public class Logger
    {
        public void Log(string message) => Console.WriteLine($"[Logger] {message}");
    }

    public class FileLogger : Logger
    {
        // "new" HIDES the parent method — it does NOT override it.
        // FileLogger.Log and Logger.Log become two separate, unrelated methods
        // that just happen to share a name. Which one runs depends on the
        // COMPILE-TIME (declared) type of the variable, not the real object type.
        public new void Log(string message) => Console.WriteLine($"[FileLogger] {message}");
    }

    public class Task2_6_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Task 2.6: Overloading / Polymorphism / Method Hiding ----");

            // ---- Part 1: Overloading ----
            Calculator calc = new Calculator();
            Console.WriteLine(calc.Add(2, 3));           // -> int version: 5
            Console.WriteLine(calc.Add(2.5, 3.5));        // -> double version: 6
            Console.WriteLine(calc.Add(1, 2, 3));         // -> 3-arg version: 6
            Console.WriteLine(calc.Add(1, 2, 3, 4, 5));   // -> params version: 15

            // ---- Part 2: Polymorphism via List<Shape> ----
            List<Shape> shapes = new List<Shape>
            {
                new Circle(3),
                new Rectangle(2, 5)
            };

            foreach (Shape s in shapes)
                s.DisplayArea(); // Circle prints circle area, Rectangle prints rectangle area

            // ---- Part 3: Method hiding vs overriding ----
            FileLogger fileLogger = new FileLogger();
            Logger loggerRef = fileLogger; // same object, viewed through the base type

            fileLogger.Log("Hello");  // declared type FileLogger -> "[FileLogger] Hello"
            loggerRef.Log("Hello");   // declared type Logger     -> "[Logger] Hello"

            // Compare this to Task 2.4's override behaviour: if Log() had used
            // "override" instead of "new", BOTH lines above would print
            // "[FileLogger] Hello", because overriding is resolved by the
            // actual object in memory, not by the type of the reference
            // pointing at it. That difference is the whole point of this task.

            Console.WriteLine();
        }
    }
}