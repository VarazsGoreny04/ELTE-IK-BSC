namespace Visitor;

class Triangle : IShape
{
	public void Accept(IShapeVisitor visitor)
	{
		visitor.Visit(this);
	}
}