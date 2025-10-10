public abstract class Shape
{
    public string Color { get; set; }

    public Shape(string color)
    {
        Color = color;
    }

    public abstract double GetArea(); // Método abstracto: cada figura implementará su propia lógica
}
