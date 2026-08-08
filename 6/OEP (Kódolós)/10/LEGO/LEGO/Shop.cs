namespace LEGO;

public class Shop(string name, string address)
{
	private readonly string name = name;
	private readonly string address = address;
	private readonly List<LegoBox> supply = [];

	public string Name => name;
	public string Address => address;

	public void StockUp(LegoBox box)
	{
		supply.Add(box);
	}

	public void Sell(LegoBox box)
	{
		supply.Remove(box);
	}

	public string MostExpensive()
	{
		if (supply.Count == 0)
			throw new Exception();

		return supply.MaxBy(x => x.Price())!.Name;
	}

	public int HowMany(string name)
	{
		return supply.Count(x => x.IsThematic() && x.Name == name);
	}

	public bool AllContainsCylinder()
	{
		/*foreach (LegoBox x in supply)
		{
			if (x.IsBasic() && !((x as Basic).HasCylinder()))
				return false;

			if (x is Basic basic)
				basic.HasCylinder();
		}

		return true;*/

		return supply.All(x => !x.IsBasic() || (x as Basic)!.HasCylinder());
	}
}