namespace IceCream;

public abstract class IceCream
{
	protected readonly int weight;

	public int Weight => weight;

	public IceCream(int weight)
	{
		this.weight = weight;
	}

	public override string ToString()
	{
		return "ice cream";
	}
}

public class Vanilla : IceCream
{
	public Vanilla(int weight) : base(weight) { }

	public override string ToString()
	{
		return $"vanilla ({weight})";
	}
}

public class Chocolate : IceCream
{
	public Chocolate(int weight) : base(weight) { }

	public override string ToString()
	{
		return $"chocolate ({weight})";
	}
}

public class Punch : IceCream
{
	private int raisins;

	public int Raisins
	{
		get { return raisins; } 
		set
		{
			if (value < 0)
				throw new Exception();

			raisins = value;
		} 
	}

	public Punch(int weight, int raisins) : base(weight)
	{
		this.raisins = raisins;
	}

	public override string ToString()
	{
		return $"punch ({weight}, {raisins})";
	}
}