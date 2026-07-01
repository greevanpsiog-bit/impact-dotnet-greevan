using System;

namespace Week1.Day3.MemoryModel
{
    // 1. Define a Struct (Value Type)
    public struct CoordinateStruct
    {
        public int X;
        public int Y;
    }

    // 2. Define a Class (Reference Type)
    public class CoordinateClass
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // ==========================================
            // TEST 1: Two Ints (Value Types)
            // ==========================================
            int a = 10;
            int b = a; // A copy of the value is made
            b = 20;    // Modifying 'b'
            
            Console.WriteLine($"--- Ints ---");
            Console.WriteLine($"a: {a}, b: {b}");
            // Output: a: 10, b: 20
            // EXPLANATION: 'int' is a value type. When assigned to 'b', the actual data (10) is copied. 
            // They occupy separate memory locations, so modifying one does not affect the other.


            // ==========================================
            // TEST 2: int[] (Reference Types)
            // ==========================================
            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = arr1; // A copy of the *reference* is made, not the array data
            arr2[0] = 99;      // Modifying the data through 'arr2'
            
            Console.WriteLine($"\n--- Array ---");
            Console.WriteLine($"arr1[0]: {arr1[0]}, arr2[0]: {arr2[0]}");
            // Output: arr1[0]: 99, arr2[0]: 99
            // EXPLANATION: Arrays are reference types. 'arr1' and 'arr2' both hold a reference (pointer) to the exact same array object in memory. 
            // Modifying the contents via either reference affects the single shared object.


            // ==========================================
            // TEST 3: Coordinate Struct (Value Type)
            // ==========================================
            CoordinateStruct struct1 = new CoordinateStruct { X = 5, Y = 5 };
            CoordinateStruct struct2 = struct1; // A copy of the struct's data is made
            struct2.X = 100;                    // Modifying 'struct2'
            
            Console.WriteLine($"\n--- Struct ---");
            Console.WriteLine($"struct1.X: {struct1.X}, struct2.X: {struct2.X}");
            // Output: struct1.X: 5, struct2.X: 100
            // EXPLANATION: Structs are value types. Just like the 'int', assigning 'struct1' to 'struct2' copies all the fields. 
            // They are independent instances in memory, so changing one does not affect the other.


            // ==========================================
            // TEST 4: Coordinate Class (Reference Type)
            // ==========================================
            CoordinateClass class1 = new CoordinateClass { X = 5, Y = 5 };
            CoordinateClass class2 = class1; // A copy of the *reference* is made
            class2.X = 100;                  // Modifying the object through 'class2'
            
            Console.WriteLine($"\n--- Class ---");
            Console.WriteLine($"class1.X: {class1.X}, class2.X: {class2.X}");
            // Output: class1.X: 100, class2.X: 100
            // EXPLANATION: Classes are reference types. 'class1' and 'class2' point to the exact same object in memory. 
            // Modifying the object's state via 'class2' is immediately visible when accessing it through 'class1'.
        }
    }
}