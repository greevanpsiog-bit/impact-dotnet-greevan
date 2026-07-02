namespace BridgeCourse.Week1;

public partial class Employee
{
    // Partial method implementation
    partial void OnCreated()
    {
        Console.WriteLine($"[Partial Method] Employee '{Name}' (ID: {Id}) was successfully created.");
    }

    public void Display()
    {
        Console.WriteLine($"Employee Details -> Name: {Name}, ID: {Id}");
    }
}