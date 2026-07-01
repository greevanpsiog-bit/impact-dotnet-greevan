using System;

namespace Week1.Day3.Enums
{
    // 1. Standard Enum: Represents mutually exclusive states (a day can only be one day)
    public enum DaysOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6
    }

    // 2. Flags Enum: Represents combinable states using powers of 2
    // [Flags]
    public enum FilePermission
    {
        None = 0,
        Read = 1,    // Binary: 001
        Write = 2,   // Binary: 010
        Execute = 4  // Binary: 100
    }

    class Program
    {
        static void Main()
        {
            // ==========================================
            // PART 1: DaysOfWeek (Standard Enum)
            // ==========================================
            Console.WriteLine("--- Days of Week ---");
            for (int i = 0; i <= 6; i++)
            {
                // Cast the integer to the Enum type
                DaysOfWeek day = (DaysOfWeek)i;
                Console.WriteLine($"Number {i} corresponds to: {day}");
            }


            // ==========================================
            // PART 2: FilePermission (Flags Enum)
            // ==========================================
            Console.WriteLine("\n--- File Permissions ---");

            // COMBINE permissions using the Bitwise OR operator (|)
            FilePermission userPerms = FilePermission.Read | FilePermission.Write;
            FilePermission adminPerms = FilePermission.Read | FilePermission.Write | FilePermission.Execute;

            // Print combined permissions. 
            // Because of the [Flags] attribute, C# automatically formats this as a comma-separated string!
            Console.WriteLine($"User Permissions: {userPerms}");   // Output: Read, Write
            Console.WriteLine($"Admin Permissions: {adminPerms}"); // Output: Read, Write, Execute


            // TEST for a single permission using the Bitwise AND operator (&)
            // The rule for checking a flag with & is: (variable & FlagToCheck) == FlagToCheck
            bool userCanRead = (userPerms & FilePermission.Read) == FilePermission.Read;
            bool userCanExecute = (userPerms & FilePermission.Execute) == FilePermission.Execute;

            Console.WriteLine($"\nChecking User Permissions:");
            Console.WriteLine($"Can Read? {userCanRead}");       // Output: True
            Console.WriteLine($"Can Execute? {userCanExecute}"); // Output: False
            
            // Note: In modern C#, you can also use the .HasFlag() method, which does the exact same bitwise check under the hood:
            // bool userCanReadAlt = userPerms.HasFlag(FilePermission.Read); 
        }
    }
}
