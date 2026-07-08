using System;

namespace Week2.Day3
{
    // DELEGATE
    // ---------
    // A delegate is a "type-safe function pointer" — a variable that holds
    // a reference to a METHOD instead of a value like an int or string.
    // This declaration says: "MathOperation can point at any method that
    // takes two doubles and returns a double."
    public delegate double MathOperation(double a, double b);

    public class MathOperations
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }
    }

    public class Task2_8_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Task 2.8: Delegates ----");

            // Single delegate pointing at one method
            MathOperation op = MathOperations.Add;
            Console.WriteLine($"Add: {op(5, 3)}"); // 8

            // Point it somewhere else — delegates are reassignable like any variable
            op = MathOperations.Multiply;
            Console.WriteLine($"Multiply: {op(5, 3)}"); // 15

            // MULTICAST DELEGATE
            // A delegate can hold a LIST of methods, not just one, using +=.
            // Calling it runs every method in the list, in order.
            MathOperation multi = MathOperations.Add;
            multi += MathOperations.Multiply;

            Console.WriteLine("Multicast invocation (Add + Multiply):");
            // NOTE: multi(5,3) still only RETURNS the result of the LAST method
            // (Multiply), but BOTH methods DO run. This is a classic gotcha —
            // multicast delegates are great for "fire and forget" actions
            // (like events, Task 2.9), risky when you actually need the return value.
            double result = multi(5, 3);
            Console.WriteLine($"Return value shown (last method only): {result}"); // 15

            // Same multicast, but manually calling each subscriber to see BOTH results
            foreach (MathOperation single in multi.GetInvocationList())
                Console.WriteLine($"  -> {single(5, 3)}"); // 8, then 15

            // REWRITE USING Func<double,double,double>
            // Func<T1,T2,TResult> is a BUILT-IN generic delegate — same idea as
            // MathOperation, but you don't have to declare your own delegate type.
            Func<double, double, double> addFunc = MathOperations.Add;
            Func<double, double, double> multiplyFunc = MathOperations.Multiply;

            Func<double, double, double> multiFunc = addFunc;
            multiFunc += multiplyFunc;

            Console.WriteLine($"Func version (last method only): {multiFunc(5, 3)}"); // 15

            Console.WriteLine();
        }
    }
}