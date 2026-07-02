namespace BridgeCourse.Week1;

public partial class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }

    // Partial method declaration (returns void, classic partial method signature)
    partial void OnCreated();

    public Employee(string name, int id)
    {
        Name = name;
        Id = id;
        OnCreated(); // Invokes the partial method
    }
}