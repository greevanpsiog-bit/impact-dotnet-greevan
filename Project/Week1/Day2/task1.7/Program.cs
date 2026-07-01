// ==========================================================
// Task 1.7: Identifiers, Conventions, and the @ Verbatim Prefix
// ==========================================================

// 1. camelCase for Local Variables (5 standard variables)
// ✅ EXECUTABLE CODE MUST COME FIRST!
string studentName = "Alice Johnson";
int studentAge = 20;
bool isEnrolled = true;
double gpa = 3.85;
CourseRecord currentCourse = new CourseRecord(); // We can still use the class here

// 2. The Error: Trying to use a reserved keyword
// string class = "Math 101"; 
/* 
   ERROR OBSERVED: CS1041 - Identifier expected; 'class' is a keyword.
   The compiler gets confused because it thinks you are trying to 
   declare a new class, not a variable.
*/

// 3. The Fix: Use the @ prefix to tell the compiler "this is a variable name, not a keyword"
string @class = "Math 101";

// 4. Output to prove it works
Console.WriteLine($"Name: {studentName}, Age: {studentAge}, Enrolled: {isEnrolled}, GPA: {gpa}");
Console.WriteLine($"Class: {@class}");
currentCourse.PrintDetails();


// ==========================================================
// ✅ TYPE DECLARATIONS MUST COME AFTER TOP-LEVEL STATEMENTS
// ==========================================================

// PascalCase for Types (Classes) and Methods
public class CourseRecord
{
    // PascalCase for Method
    public void PrintDetails()
    {
        Console.WriteLine("Course details printed.");
    }
}