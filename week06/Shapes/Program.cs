using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear una lista de formas
        List<Shape> shapes = new List<Shape>();

        // Agregar diferentes tipos de formas
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        // Recorrer la lista y mostrar color + área
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.Color}, Área: {shape.GetArea()}");
        }
    }
}
