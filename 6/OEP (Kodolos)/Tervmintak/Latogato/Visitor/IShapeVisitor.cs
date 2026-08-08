namespace Visitor;

interface IShapeVisitor
{
	public void Visit(Circle circle);
	public void Visit(Square square);
	public void Visit(Triangle triangle);
}