namespace Visitor;

public class Program
{
	public static void Main()
	{
		List<IShape> shapes = 
		[
			new Circle(), 
			new Square(), 
			new Triangle()
		];

		AreaCalculator areaCalculator = new();

		foreach (IShape shape in shapes)
			shape.Accept(areaCalculator);

		Console.WriteLine($"Total area: {areaCalculator.TotalArea}");
	}
}