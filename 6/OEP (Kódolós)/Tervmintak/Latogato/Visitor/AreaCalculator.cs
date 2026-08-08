namespace Visitor;

class AreaCalculator : IShapeVisitor
{
	private const double radiusOfCircle = 5;
	private const double sideOfSquare = 4;
	private const double baseOfTriangle = 3;
	private const double heightOfTriangle = 6;

	private double totalArea = 0;

	public double TotalArea => totalArea;

	public void Visit(Circle circle)
	{
		 totalArea += Math.PI * Math.Pow(radiusOfCircle, 2);
	}

	public void Visit(Square square)
	{
		totalArea += Math.Pow(sideOfSquare, 2);
	}

	public void Visit(Triangle triangle)
	{
		totalArea += (baseOfTriangle * heightOfTriangle) / 2;
	}
}