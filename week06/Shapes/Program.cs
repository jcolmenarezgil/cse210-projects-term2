using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Circle("Blue", 5.0));
        shapes.Add(new Rectangle("Green", 4.0, 9.0));
        shapes.Add(new Square("Yellow", 30.0));

        foreach (Shape s in shapes)
        {
            Console.WriteLine($"Color: {s.GetColor()}, Area: {s.GetArea()}");
        }
    }
}