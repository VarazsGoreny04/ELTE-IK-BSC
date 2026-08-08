namespace StevesGarden;

public class Parcel
{
	private readonly uint area;
	private uint freeSpace;
	private readonly List<Plant> plants;

	public uint Area => area;
	public uint FreeSpace => freeSpace;

	public Parcel(uint area)
	{
		this.area = area;
		freeSpace = this.area;
		plants = [];
	}

	public bool Plant(Plant plant)
	{
		bool result = freeSpace >= plant.Area;

		if (result)
		{
			plants.Add(plant);
			freeSpace -= plant.Area;
		}

		return result;
	}

	public uint MelonCount() => (uint)plants.Sum(p => p.MelonCount());
	public uint PumpkinCount() => (uint)plants.Sum(p => p.PumpkinCount());
	public uint ZucchiniCount() => (uint)plants.Sum(p => p.ZucchiniCount());

	public void GrowMelons() => plants.FindAll(p => p is Melon).ForEach(p => p.Ripen());
	public void GrowPumpkins() => plants.FindAll(p => p is Pumpkin).ForEach(p => p.Ripen());
	public void GrowZucchinis() => plants.FindAll(p => p is Zucchini).ForEach(p => p.Ripen());

	public uint SumHappiness() => (uint)plants.Sum(p => p.GetHappiness());
}