using System;

namespace Week2.Day2
{
    // ABSTRACT CLASS
    // ---------------
    // Think of "abstract" as: "I am a template. I refuse to be built on my own."
    // You literally cannot write "new Shape()" — the compiler blocks it.
    // It exists ONLY so other classes can inherit from it and finish the job.
    public abstract class Shape
    {
        // No body. Just a promise: "every child class MUST provide this."
        // This is what makes Shape abstract instead of just a normal base class.
        public abstract double CalculateArea();

        // A NORMAL method, fully written here, shared by every child for free.
        // Notice it calls CalculateArea() — but it doesn't know WHICH version
        // will run. That's decided at runtime by the actual object. (Polymorphism!)
        public void DisplayArea()
        {
            Console.WriteLine($"{GetType().Name} Area: {CalculateArea():F2}");
        }
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        // "override" = "I am fulfilling the promise Shape made me sign up for."
        public override double CalculateArea() => Math.PI * radius * radius;
    }

    public class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public override double CalculateArea() => length * width;
    }

    public class Task2_4_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Task 2.4: Abstract Shape ----");

            Circle circle = new Circle(5);
            Rectangle rectangle = new Rectangle(4, 6);

            circle.DisplayArea();     // Circle Area: 78.54
            rectangle.DisplayArea();  // Rectangle Area: 24.00

            // Try uncommenting this line and building the project:
            // Shape s = new Shape();
            //
            // You will get:
            // CS0144: Cannot create an instance of the abstract type or interface 'Shape'
            //
            // That error IS the "Done when" evidence for this task — take a
            // screenshot of it for your learning doc.

            Console.WriteLine();
        }
    }
}