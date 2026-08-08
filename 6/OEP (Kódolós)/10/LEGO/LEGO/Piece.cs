namespace LEGO;

public abstract class Piece(string color, int price, Size size)
{
	private readonly string color = color;
	protected readonly int price = price;
	private readonly Size size = size;

	protected string Color => color;
	public int Price => price;
	protected Size Size => size;

	public int Volume()
	{
		return size.Height * size.Width * size.Length;
	}

	public virtual bool IsTile() { return false; }
	public virtual bool IsBrick() { return false; }
	public virtual bool IsCylinder() { return false; }
}

public class Tile(string color, int price, Size size) : Piece(color, price, size)
{
	public override bool IsTile() { return true; }
}
public class Brick(string color, int price, Size size) : Piece(color, price, size)
{
	public override bool IsBrick() { return true; }
}
public class Cylinder(string color, int price, Size size) : Piece(color, price, size)
{
	public override bool IsCylinder() { return true; }
}