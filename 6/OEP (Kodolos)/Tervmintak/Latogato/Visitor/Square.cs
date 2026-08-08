namespace Visitor;

class Square : IShape
{
	public void Accept(IShapeVisitor visitor)
	{
		visitor.Visit(this);
	}
}