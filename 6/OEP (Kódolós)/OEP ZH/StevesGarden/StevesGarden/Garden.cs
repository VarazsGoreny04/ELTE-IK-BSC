namespace StevesGarden;

public class Garden
{
	private static Garden? instance;
	private readonly List<Parcel> parcels;

	private Garden()
	{
		parcels = [];
	}

	public static Garden Instantiate()
	{
		instance ??= new Garden();

		return instance;
	}

	public void CreateParcel(uint area) => parcels.Add(new Parcel(area));

	public List<uint> FreeSpaces() => parcels.Select(p => p.FreeSpace).ToList();

	public bool ToFirstFreeParcelPlant(Plant plant) => parcels.Find(p => p.Plant(plant)) is not null;

	public uint MelonCount() => (uint)parcels.Sum(p => p.MelonCount());
	public uint PumpkinCount() => (uint)parcels.Sum(p => p.PumpkinCount());
	public uint ZucchiniCount() => (uint)parcels.Sum(p => p.ZucchiniCount());

	public void GrowMelons() => parcels.ForEach(p => p.GrowMelons());
	public void GrowPumpkins() => parcels.ForEach(p => p.GrowPumpkins());
	public void GrowZucchinis() => parcels.ForEach(p => p.GrowZucchinis());

	public uint HappinessMeter() => (uint)parcels.Sum(p => p.SumHappiness());
}