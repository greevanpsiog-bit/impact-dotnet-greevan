namespace BridgeCourse.Week1;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("--- 1. Partial Class & Method ---");
        var emp = new Employee("Jane Doe", 101);
        emp.Display();

        Console.WriteLine("\n--- 2. Access-Modifier Matrix ---");
        var matrix = new AccessModifierMatrix();
        matrix.PrintMatrix();

        Console.WriteLine("\n--- 3. Address Record (Equality & 'with') ---");
        var addr1 = new Address("123 Tech Park", "Seattle", "98101");
        var addr2 = new Address("123 Tech Park", "Seattle", "98101");
        
        // ✅ DONE WHEN: Prints True for value equality
        Console.WriteLine($"Value Equality (addr1 == addr2): {addr1 == addr2}"); 

        // ✅ DONE WHEN: 'with' produces a changed copy
        var addr3 = addr1 with { City = "Redmond" };
        Console.WriteLine($"Original Address: {addr1}");
        Console.WriteLine($"Copied & Changed: {addr3}");

        Console.WriteLine("\n--- 4. Playlist Indexers ---");
        var playlist = new Playlist();
        playlist.Add("Bohemian Rhapsody");
        playlist.Add("Stairway to Heaven");
        playlist.Add("Hotel California");

        // Test Int Indexer
        Console.WriteLine($"Song at index 1: {playlist[1]}");
        
        // Test String Indexer
        Console.WriteLine($"Contains 'Hotel California': {playlist["Hotel California"] != null}");
        
        // Test Bounds Checking
        try
        {
            Console.WriteLine(playlist[10]); // This will trigger the bounds check
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bounds Check Caught: {ex.Message}");
        }
    }
}