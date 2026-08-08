namespace Visitor;

interface IShape
{
	public void Accept(IShapeVisitor visitor);
}