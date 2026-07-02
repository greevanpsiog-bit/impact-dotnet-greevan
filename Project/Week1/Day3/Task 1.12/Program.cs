using System;

namespace Week1.Day3.Conversions
{
    class Program
    {
        static void Main()
        {
            // ==========================================
            // PART 1: Implicit and Explicit Conversions
            // ==========================================
            Console.WriteLine("--- Numeric Conversions ---");

            // 1. Implicit Conversions (Widening)
            // These happen automatically because the target type is larger, meaning no data loss.
            int myInt = 100;
            long myLong = myInt;       // int -> long (Implicit)
            float myFloat = myLong;    // long -> float (Implicit)
            double myDouble = myFloat; // float -> double (Implicit)
            
            Console.WriteLine($"Implicit chain: int({myInt}) -> long({myLong}) -> float({myFloat}) -> double({myDouble})");

            // 2. Explicit Conversions (Narrowing)
            // Requires a cast. Can result in data or precision loss.
            double preciseDouble = 99.99;
            int backToInt = (int)preciseDouble; // double -> int (Explicit)
            
            Console.WriteLine($"Explicit cast: double({preciseDouble}) -> int({backToInt})");
            // NOTE: Precision loss occurred here! The decimal part (.99) is truncated (chopped off), not rounded.


            // ==========================================
            // PART 2: String/Object Conversions & Type Checking
            // ==========================================
            Console.WriteLine("\n--- String & Object Conversions ---");
            
            string numericString = "456";
            object objString = "789"; // Boxed as an object to demonstrate 'is' and 'as'
            object objInt = 101;

            // 1. The 'is' operator (Type Pattern Matching)
            // WHEN TO USE: When you need to check if an object is of a specific type 
            // AND you want to safely use it as that type in the same step without casting twice.
            if (objString is string strValue)
            {
                Console.WriteLine($"'is' check: objString is a string with value '{strValue}'");
            }
            
            if (objInt is int intValue)
            {
                Console.WriteLine($"'is' check: objInt is an int with value '{intValue}'");
            }

            // 2. The 'as' operator (Safe Cast)
            // WHEN TO USE: When casting reference types (or nullable value types) and you prefer 
            // to get 'null' on failure instead of throwing an InvalidCastException.
            // NOTE: 'as' only works with reference types or nullable value types (like int?).
            string castedString = objString as string; 
            int? castedNullableInt = objInt as int?; 
            
            Console.WriteLine($"'as' cast (success): {castedString}");
            Console.WriteLine($"'as' cast (success): {castedNullableInt?.ToString() ?? "null"}");
            
            // If we try to cast a string to an int? using 'as', it results in null, not an exception.
            int? failedCast = objString as int?; 
            Console.WriteLine($"'as' cast (failure): {failedCast?.ToString() ?? "null"} (No exception thrown!)");


            // 3. Convert.ToInt32
            // WHEN TO USE: When you expect the data to be strictly valid and want the application 
            // to fail loudly (throw FormatException) if the string is not a valid number.
            try 
            {
                int converted = Convert.ToInt32(numericString);
                Console.WriteLine($"Convert.ToInt32 (success): {converted}");
                
                // Uncommenting the next line would throw a FormatException:
                // int badConvert = Convert.ToInt32("NotANumber"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Convert.ToInt32 failed: {ex.Message}");
            }


            // 4. int.TryParse
            // WHEN TO USE: The safest and most performant method for user input or external data. 
            // It returns a boolean and never throws exceptions, making it ideal for validation.
            bool success = int.TryParse(numericString, out int parsedInt);
            if (success)
            {
                Console.WriteLine($"int.TryParse (success): {parsedInt}");
            }
            
            bool fail = int.TryParse("InvalidData", out int fallbackInt);
            Console.WriteLine($"int.TryParse (failure): Success={fail}, Fallback Value={fallbackInt} (Defaults to 0)");
        }
    }
}