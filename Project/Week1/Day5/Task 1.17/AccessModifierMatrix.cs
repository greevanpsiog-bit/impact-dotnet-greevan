namespace BridgeCourse.Week1;

public class AccessModifierMatrix
{
    // 1. Public: Accessible from anywhere
    public string PublicField = "Public";
    
    // 2. Private: Accessible only within this class
    private string _privateField = "Private";
    
    // 3. Protected: Accessible within this class and derived classes
    protected string ProtectedField = "Protected";
    
    // 4. Internal: Accessible only within the same assembly
    internal string InternalField = "Internal";
    
    // 5. Protected Internal: Accessible within the same assembly OR from derived classes in other assemblies
    protected internal string ProtectedInternalField = "Protected Internal";
    
    // 6. Private Protected: Accessible only by derived classes within the same assembly
    private protected string PrivateProtectedField = "Private Protected";

    public void PrintMatrix()
    {
        Console.WriteLine($"- {PublicField}");
        Console.WriteLine($"- {_privateField}");
        Console.WriteLine($"- {ProtectedField}");
        Console.WriteLine($"- {InternalField}");
        Console.WriteLine($"- {ProtectedInternalField}");
        Console.WriteLine($"- {PrivateProtectedField}");
    }
}