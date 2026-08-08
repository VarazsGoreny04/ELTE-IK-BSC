namespace Visitor;

class Circle : IShape
{
	public void Accept(IShapeVisitor visitor)
	{
		visitor.Visit(this);
	}
}