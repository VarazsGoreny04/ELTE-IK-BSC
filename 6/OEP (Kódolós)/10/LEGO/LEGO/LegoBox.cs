namespace LEGO;

public abstract class LegoBox(string name)
{
	private readonly string name = name;

	public string Name => name;

	public virtual bool IsBasic() { return false; }

	public virtual bool IsThematic() { return false; }

	public abstract int Price();
}

public class Basic(string name, List<Piece> pieces) : LegoBox(name)
{
	private readonly List<Piece> pieces = pieces;

	public override bool IsBasic() { return true; }

	public override int Price()
	{
		return pieces.Sum(x => x.Price);
	}

	public bool HasCylinder()
	{
		return pieces.Any(x => x.IsCylinder());
	}
}

public class Thematic(string name, int price) : LegoBox(name)
{
	private readonly int price = price;

	public override bool IsThematic()
	{
		return true;
	}

	public override int Price()
	{
		return price;
	}
}