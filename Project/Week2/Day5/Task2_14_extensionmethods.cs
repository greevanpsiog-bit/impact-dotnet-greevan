using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Week2.Day5
{
    // EXTENSION METHODS
    // ------------------
    // These let you "add" a method to a type you don't own the source code
    // for (like string, List<T>, or int) WITHOUT modifying that type or
    // inheriting from it. Requirements:
    //   1. Must live in a static class.
    //   2. Must be a static method.
    //   3. The FIRST parameter has "this" in front of it — that marks
    //      which type is being extended, and becomes the thing you call
    //      the method ON (e.g. myString.ToTitleCase()).
    public static class StringExtensions
    {
        public static string ToTitleCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();
                words[i] = char.ToUpper(word[0]) + word.Substring(1);
            }
            return string.Join(' ', words);
        }
    }

    public static class ListExtensions
    {
        // Handy because "list == null || list.Count == 0" is written constantly
        // in real code — an extension method turns that into a one-liner.
        public static bool IsNullOrEmpty<T>(this List<T>? list)
        {
            return list is null || list.Count == 0;
        }
    }

    public static class IntExtensions
    {
        private static readonly string[] Ones =
        {
            "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
            "Seventeen", "Eighteen", "Nineteen"
        };

        private static readonly string[] Tens =
        {
            "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        // Converts 0-999 into words, e.g. 452 -> "Four Hundred Fifty Two"
        public static string ToWords(this int number)
        {
            if (number < 0 || number > 999)
                throw new ArgumentOutOfRangeException(nameof(number), "Only 0-999 supported.");

            if (number < 20)
                return Ones[number];

            if (number < 100)
            {
                int tens = number / 10;
                int ones = number % 10;
                return ones == 0 ? Tens[tens] : $"{Tens[tens]} {Ones[ones]}";
            }

            // 100-999
            int hundreds = number / 100;
            int remainder = number % 100;
            StringBuilder sb = new StringBuilder($"{Ones[hundreds]} Hundred");
            if (remainder > 0)
                sb.Append(' ').Append(remainder.ToWords());

            return sb.ToString();
        }
    }

    public class Task2_14_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Task 2.14: Extension Methods ----");

            // string.ToTitleCase()
            string title = "the quick BROWN fox".ToTitleCase();
            Console.WriteLine($"ToTitleCase: '{title}'"); // "The Quick Brown Fox"

            // List<T>.IsNullOrEmpty()
            List<int>? emptyList = new List<int>();
            List<int>? nullList = null;
            List<int> filledList = new List<int> { 1, 2, 3 };

            Console.WriteLine($"emptyList.IsNullOrEmpty()  = {emptyList.IsNullOrEmpty()}");  // True
            Console.WriteLine($"nullList.IsNullOrEmpty()   = {nullList.IsNullOrEmpty()}");   // True
            Console.WriteLine($"filledList.IsNullOrEmpty() = {filledList.IsNullOrEmpty()}"); // False

            // int.ToWords()
            Console.WriteLine($"7.ToWords()   = {7.ToWords()}");
            Console.WriteLine($"45.ToWords()  = {45.ToWords()}");
            Console.WriteLine($"452.ToWords() = {452.ToWords()}");
            Console.WriteLine($"999.ToWords() = {999.ToWords()}");

            // ANONYMOUS TYPE PROJECTION
            var employees = new List<(string Name, decimal Salary)>
            {
                ("Arun", 65000), ("Meena", 72000)
            };

            var projected = employees.Select(e => new { e.Name, AnnualSalary = e.Salary * 12 });

            Console.WriteLine("Anonymous projection { Name, AnnualSalary }:");
            foreach (var p in projected)
                Console.WriteLine($"  {p.Name}: {p.AnnualSalary:C}");

            Console.WriteLine();
        }
    }

    /*
     * ===================================================================
     *  WHY AN ANONYMOUS TYPE CAN'T BE RETURNED FROM A METHOD
     * ===================================================================
     * new { Name = "...", AnnualSalary = ... } creates a real class, but
     * the COMPILER invents its name behind the scenes (something like
     * <>f__AnonymousType0) — you never get to see or write that name
     * yourself, and it's only visible within the method that created it.
     *
     * A method signature has to declare a return TYPE:
     *     public ??? GetSummary() { return new { Name = "x", AnnualSalary = 1 }; }
     *
     * There is no way to write "???" for an anonymous type, because you
     * don't know its compiler-generated name, and even if you did, it's
     * only meant to exist locally. So you literally cannot write a method
     * signature that returns one (other than returning "object" or
     * "dynamic", which throws away all the useful compile-time type
     * checking that anonymous types are good for in the first place).
     *
     * Workarounds when you DO need to return this kind of shape:
     *   - Use a proper named class or a "record" (record EmployeeSummary
     *     (string Name, decimal AnnualSalary);) — one line, gets you
     *     equality and ToString() for free, just like an anonymous type.
     *   - Use a tuple: (string Name, decimal AnnualSalary) GetSummary() {...}
     *
     * Anonymous types are best kept local — e.g. inside a single LINQ
     * query, exactly like Task 2.13's projections.
     */
}