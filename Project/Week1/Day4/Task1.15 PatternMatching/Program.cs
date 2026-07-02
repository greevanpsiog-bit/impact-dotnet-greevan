using System;

namespace Day4Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 1.15: Pattern Matching ===\n");

            // ---------------------------------------------------------
            // 1. Object-param method: Type & Null Patterns
            // ---------------------------------------------------------
            Console.WriteLine("--- 1. Type & Null Patterns ---");
            AnalyzeObject(42);
            AnalyzeObject("Hello Pattern Matching");
            AnalyzeObject(3.14159);
            AnalyzeObject(null);
            AnalyzeObject(new DateTime()); // To show the default fallback

            // ---------------------------------------------------------
            // 2. Grade calculator: Relational Patterns
            // ---------------------------------------------------------
            Console.WriteLine("\n--- 2. Relational Patterns (Grade Calculator) ---");
            int[] scores = { 95, 82, 74, 65, 40, 105, -5 };
            foreach (int score in scores)
            {
                Console.WriteLine($"Score: {score,-4} -> Grade: {GetGrade(score)}");
            }

            // ---------------------------------------------------------
            // 3. Order discount: Property Patterns
            // ---------------------------------------------------------
            Console.WriteLine("\n--- 3. Property Patterns (Order Discount) ---");
            var orders = new[]
            {
                new Order { Status = "Premium", Amount = 1500m },
                new Order { Status = "Premium", Amount = 500m },
                new Order { Status = "Standard", Amount = 2000m },
                new Order { Status = "Standard", Amount = 100m }
            };

            foreach (var order in orders)
            {
                decimal discount = CalculateDiscount(order);
                decimal finalPrice = order.Amount * (1 - discount);
                Console.WriteLine($"Order [{order.Status,-8} | ${order.Amount,6}] -> Discount: {discount:P0} | Final: ${finalPrice:F2}");
            }
        }

        /// <summary>
        /// Uses Type Patterns and the Null Pattern.
        /// </summary>
        static void AnalyzeObject(object obj)
        {
            switch (obj)
            {
                case int i:
                    Console.WriteLine($"  -> It's an integer: {i}");
                    break;
                case string s:
                    Console.WriteLine($"  -> It's a string (Length {s.Length}): \"{s}\"");
                    break;
                case double d:
                    Console.WriteLine($"  -> It's a double: {d}");
                    break;
                case null:
                    Console.WriteLine("  -> It's null!");
                    break;
                default:
                    Console.WriteLine($"  -> It's something else: {obj.GetType().Name}");
                    break;
            }
        }

        /// <summary>
        /// Uses Relational Patterns (>=, <) and Logical Patterns (or).
        /// </summary>
        static string GetGrade(int score) => score switch
        {
            < 0 or > 100 => "Invalid Score",
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };

        /// <summary>
        /// Uses Property Patterns to inspect the internal state of the Order object.
        /// </summary>
        static decimal CalculateDiscount(Order order) => order switch
        {
            { Status: "Premium", Amount: > 1000m } => 0.20m, // 20% discount
            { Status: "Premium", Amount: <= 1000m } => 0.10m, // 10% discount
            { Status: "Standard", Amount: > 1000m } => 0.05m, // 5% discount
            _ => 0.00m                                       // No discount
        };
    }

    // Simple class to demonstrate Property Patterns
    public class Order
    {
        public string Status { get; set; }
        public decimal Amount { get; set; }
    }
}