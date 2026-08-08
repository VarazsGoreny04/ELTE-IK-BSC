namespace Inheritance_demo;

public abstract class IceCream
{
	private readonly int weight;

	public int Weight => weight;

	public IceCream(int weight)
	{
		this.weight = weight;
	}

	public override string ToString()
	{
		return GetType().Name;
	}
}

public class Chocolate : IceCream
{
	public Chocolate(int weight) : base(weight) { }

	public override string ToString()
	{
		return "chocolate";
	}
}

public class Vanilla : IceCream
{
	public Vanilla(int weight) : base(weight) { }

	public override string ToString()
	{
		return "vanilla";
	}
}

public class Punch : IceCream
{
	private int raisins;

	public int Raisins
	{
		get => raisins;
		set // valtoztatunk a mazsolak szaman
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException(nameof(value));

			raisins = value;
		}
	}

	public Punch(int weight, int raisins) : base(weight)
	{
		this.raisins = raisins;
	}
	
	public override string ToString()
	{
		return "punch";
	}
}