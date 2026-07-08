using System;
using System.Collections.Generic;

namespace Week2.Day3
{
    // THE THREE BUILT-IN GENERIC DELEGATES YOU'LL USE CONSTANTLY
    // -------------------------------------------------------------
    // Action<T>       -> takes input(s), returns NOTHING (void)
    // Func<T,TResult> -> takes input(s), RETURNS a value (last type param = return type)
    // Predicate<T>    -> takes ONE input, returns bool (basically a yes/no question)
    //
    // All three are just delegates with a predefined shape, so you don't
    // have to declare "public delegate ..." yourself like in Task 2.8.
    public class Task2_10_Demo
    {
        // A pipeline: filter -> transform -> output, all passed in as delegates.
        // This is the exact shape LINQ's Where/Select/ForEach are built on.
        public static void ProcessList(
            List<int> numbers,
            Predicate<int> filter,
            Func<int, int> transform,
            Action<string> output)
        {
            foreach (int number in numbers)
            {
                if (filter(number)) // keep only numbers that pass the test
                {
                    int transformed = transform(number); // apply the transformation
                    output(transformed.ToString());       // do something with the result
                }
            }
        }

        public static void Run()
        {
            Console.WriteLine("---- Task 2.10: Action / Func / Predicate ----");

            // Action<string> — prints a string in uppercase. No return value.
            Action<string> printUppercase = s => Console.WriteLine(s.ToUpper());
            printUppercase("hello there");

            // Func<int,int,int> — multiplies two ints, returns an int.
            Func<int, int, int> multiply = (a, b) => a * b;
            Console.WriteLine($"multiply(4, 5) = {multiply(4, 5)}");

            // Predicate<int> — asks a yes/no question about one int.
            Predicate<int> isEven = n => n % 2 == 0;
            Console.WriteLine($"isEven(7) = {isEven(7)}");

            // Now combine all three in the pipeline: filter evens -> square -> print
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Pipeline result (filter evens -> square -> print):");
            ProcessList(
                numbers,
                filter: n => n % 2 == 0,     // Predicate<int>
                transform: n => n * n,       // Func<int,int>
                output: s => Console.WriteLine($"  {s}") // Action<string>
            );
            // Expected: 4, 16, 36, 64, 100

            Console.WriteLine();
        }
    }
}