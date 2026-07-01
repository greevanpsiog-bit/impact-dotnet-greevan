using System;

namespace Day4Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 1.13: var vs dynamic ===\n");

            // ---------------------------------------------------------
            // 1. var reassignment compile error
            // ---------------------------------------------------------
            var myVar = "Hello";
            
            // INSTRUCTIONS FOR YOUR LEARNING DOCUMENT:
            // Uncomment the line below to trigger the compile error. 
            // Take a screenshot of the Error List in Visual Studio / VS Code, 
            // then comment it back out so the program can run.
            
            // myVar = 10; 
            
            Console.WriteLine($"'var' is statically typed at compile time. Initial value: {myVar}\n");


            // ---------------------------------------------------------
            // 2. dynamic reassigned string -> int -> bool
            // ---------------------------------------------------------
            Console.WriteLine("--- Dynamic Type Reassignment ---");
            dynamic myDynamic = "I am a string";
            Console.WriteLine($"Value: {myDynamic,-15} | Runtime Type: {myDynamic.GetType()}");

            myDynamic = 42;
            Console.WriteLine($"Value: {myDynamic,-15} | Runtime Type: {myDynamic.GetType()}");

            myDynamic = true;
            Console.WriteLine($"Value: {myDynamic,-15} | Runtime Type: {myDynamic.GetType()}\n");


            // ---------------------------------------------------------
            // 3. dynamic-param add method
            // ---------------------------------------------------------
            Console.WriteLine("--- Dynamic Add Method ---");
            
            int num1 = 15, num2 = 20;
            var intResult = Add(num1, num2);
            Console.WriteLine($"Add({num1}, {num2}) = {intResult} (Runtime Type: {intResult.GetType()})");

            string str1 = "Hello, ", str2 = "Dynamic World!";
            var strResult = Add(str1, str2);
            Console.WriteLine($"Add(\"{str1}\", \"{str2}\") = {strResult} (Runtime Type: {strResult.GetType()})");
        }

        /// <summary>
        /// Accepts dynamic parameters. The '+' operator behavior 
        /// is resolved at runtime based on the actual types passed.
        /// </summary>
        static dynamic Add(dynamic a, dynamic b)
        {
            return a + b;
        }
    }
}