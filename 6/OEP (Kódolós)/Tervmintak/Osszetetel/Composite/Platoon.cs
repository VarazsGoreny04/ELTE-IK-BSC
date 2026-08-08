namespace Composite;

public class Platoon : ISoldier
{
	private readonly List<ISoldier> soldiers;

	public List<ISoldier> Soldiers => soldiers;

	public Platoon()
	{
		soldiers = [];
	}

	public Platoon(List<ISoldier> soldiers)
	{
		this.soldiers = soldiers;
	}

	public int Count()
	{
		return soldiers.Sum(s => s.Count());
	}
}