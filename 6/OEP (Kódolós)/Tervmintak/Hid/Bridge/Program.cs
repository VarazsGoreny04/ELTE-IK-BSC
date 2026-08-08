namespace Bridge;

internal class Program
{
    static void Main()
    {
        Shape redTriangle = new Triangle(new Red());
        Shape greenSquare = new Square(new Green());
        Shape blueCircle = new Circle(new Blue());

        Console.WriteLine($"redTriangle is a {redTriangle.Color.GetType().Name} {redTriangle.GetType().Name}");
        Console.WriteLine($"greenSquare is a {greenSquare.Color.GetType().Name} {greenSquare.GetType().Name}");
        Console.WriteLine($"blueCircle is a {blueCircle.Color.GetType().Name} {blueCircle.GetType().Name}");
	}
}