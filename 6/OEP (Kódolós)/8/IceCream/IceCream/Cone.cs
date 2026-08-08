namespace IceCream;

public abstract class Cone
{
	protected readonly List<IceCream> iceCreams;

	public List<IceCream> IceCreams => iceCreams;

	public Cone(List<IceCream> iceCreams)
	{
		this.iceCreams = iceCreams;
	}

	public override string ToString()
	{
		return "cone";
	}
}

public class Sweet : Cone
{
	public Sweet(List<IceCream> iceCreams) : base(iceCreams) { }

	public override string ToString()
	{
		return "sweet";
	}
}

public class Classic : Cone
{
	public Classic(List<IceCream> iceCreams) : base(iceCreams) { }

	public override string ToString()
	{
		return "classic";
	}
}