using System;

namespace Week1.Day3.NullableTypes
{
    class Program
    {
        static void Main()
        {
            // ==========================================
            // PART 1: Nullable int with HasValue
            // ==========================================
            Console.WriteLine("--- Nullable Int ---");
            
            // The '?' makes the int a Nullable<int>. It can now hold an int OR null.
            int? nullableInt = null;
            
            // .HasValue is a boolean property that tells us if the variable contains data
            if (nullableInt.HasValue)
            {
                // If it has a value, we can safely access it using .Value
                Console.WriteLine($"The value is: {nullableInt.Value}");
            }
            else
            {
                Console.WriteLine("The nullable int is currently null (no value).");
            }

            // Now, let's assign an actual integer to it
            nullableInt = 42;
            if (nullableInt.HasValue)
            {
                Console.WriteLine($"Now the value is: {nullableInt.Value}");
            }


            // ==========================================
            // PART 2: ApplyDiscount Method with ??
            // ==========================================
            Console.WriteLine("\n--- Apply Discount ---");
            
            double basePrice = 100.00;

            // TEST 1: Passing null (Should default to 5% / 0.05)
            double priceWithNullDiscount = basePrice - (basePrice * ApplyDiscount(null));
            Console.WriteLine($"Price with null discount: ${priceWithNullDiscount:F2}"); 
            // Expected Output: $95.00 (100 - 5% of 100)

            // TEST 2: Passing a specific value (Should use 20% / 0.20)
            double priceWithCustomDiscount = basePrice - (basePrice * ApplyDiscount(0.20));
            Console.WriteLine($"Price with 20% discount: ${priceWithCustomDiscount:F2}"); 
            // Expected Output: $80.00 (100 - 20% of 100)
            
            // TEST 3: Passing 0 explicitly (Should use 0%)
            double priceWithZeroDiscount = basePrice - (basePrice * ApplyDiscount(0.0));
            Console.WriteLine($"Price with 0% discount: ${priceWithZeroDiscount:F2}");
            // Expected Output: $100.00
        }

        /// <summary>
        /// Calculates the discount to apply. 
        /// If null is passed, it defaults to 5% (0.05).
        /// </summary>
        static double ApplyDiscount(double? discount)
        {
            // The null-coalescing operator (??) checks the left side.
            // If 'discount' is NOT null, it returns 'discount'.
            // If 'discount' IS null, it returns the right side (0.05).
            return discount ?? 0.05; 
        }
    }
}