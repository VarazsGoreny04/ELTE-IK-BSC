namespace Inheritance_demo;

public abstract class Cone
{
	protected List<IceCream> iceCreams;

	public List<IceCream> IceCreams => iceCreams;

	public Cone()
	{
		iceCreams = [];
	}

	public Cone(List<IceCream> iceCreams)
	{
		this.iceCreams = iceCreams;
	}

	public override string ToString()
	{
		return GetType().Name;
	}
}

public class Classic : Cone
{
	public Classic()
	{
		iceCreams = [];
	}

	public Classic(List<IceCream> iceCreams) : base(iceCreams) { }

	public override string ToString()
	{
		return "classic";
	}
}

public class Sweet : Cone
{
	public Sweet()
	{
		iceCreams = [];
	}

	public Sweet(List<IceCream> iceCreams) : base(iceCreams) { }

	public override string ToString()
	{
		return "sweet";
	}
}