using System;

namespace Week2.Day2
{
    // INTERFACE
    // ----------
    // A pure contract. No fields, no implementation (in modern C# you *can*
    // add default bodies, but for this task treat it as signatures only).
    // It says: "any class that implements me MUST provide these methods."
    public interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
    }

    public interface IDrawable
    {
        void Draw();
    }

    // One class can implement MANY interfaces (unlike abstract classes,
    // where you can only inherit from ONE base class).
    public class Square : IShape, IDrawable
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
        }

        public double CalculateArea() => side * side;

        public double CalculatePerimeter() => 4 * side;

        public void Draw() => Console.WriteLine($"Drawing a square with side {side}");
    }

    /*
     * ===================================================================
     *  INTERFACE vs ABSTRACT CLASS — the comment block the task asks for
     * ===================================================================
     *
     * Abstract class (see Task 2.4's Shape):
     *   - CAN have fields, constructors, and fully-written (concrete) methods.
     *   - A class can inherit from only ONE abstract/base class.
     *     C# does not allow multiple class inheritance.
     *   - Models an "IS-A" relationship where the child genuinely shares
     *     identity and state with the parent. A Circle IS-A Shape.
     *
     * Interface:
     *   - Cannot hold state (no fields). Just a list of capabilities.
     *   - A class can implement AS MANY interfaces as it wants.
     *   - Models a "CAN-DO" relationship between otherwise unrelated types.
     *     A Square and a company Logo have nothing to do with each other,
     *     but both CAN Draw(). That's what IDrawable captures.
     *
     * Rule of thumb: if you're describing what something IS, lean abstract
     * class. If you're describing what something CAN DO, lean interface.
     * In real projects you often use both together, exactly like Square
     * could inherit from an abstract Shape AND implement IDrawable.
     */

    public class Task2_5_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Task 2.5: Interfaces ----");

            Square square = new Square(4);
            square.Draw();
            Console.WriteLine($"Area: {square.CalculateArea()}, Perimeter: {square.CalculatePerimeter()}");

            Console.WriteLine();
        }
    }
}