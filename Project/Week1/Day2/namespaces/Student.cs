namespace SchoolManagement;

public class Student
{
    public String name {get;set;} = String.Empty;
    public int Id{get;set;}
    public int grade {get;set;}

    public void DisplayStudentInfo()
    {
        Console.WriteLine($"Student ID: {Id}, Name: {name}, Grade: {grade}");
    }

}