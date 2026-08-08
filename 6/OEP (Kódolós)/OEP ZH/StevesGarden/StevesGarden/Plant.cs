namespace StevesGarden;

public abstract class Plant(uint cropNumber, uint area)
{
	protected readonly uint cropNumber = cropNumber;
	protected readonly uint area = area;
	protected State state = new Seedling();

	public uint CropNumber => cropNumber;
	public uint Area => area;

	public void Ripen() => state.Ripen(ref state);

	public virtual uint MelonCount() => 0u;
	public virtual uint PumpkinCount() => 0u;
	public virtual uint ZucchiniCount() => 0u;

	public abstract uint GetHappiness();
}

public class Melon(uint cropNumber) : Plant(cropNumber, 5u)
{
	public override uint MelonCount() => cropNumber;

	public override uint GetHappiness() => state.Happiness(this) * cropNumber * (state.CanHarvest() ? 2u : 1u);
}

public class Pumpkin(uint cropNumber) : Plant(cropNumber, 4u)
{
	public override uint PumpkinCount() => cropNumber;

	public override uint GetHappiness() => state.Happiness(this) * cropNumber * (state.CanHarvest() ? 2u : 1u);
}

public class Zucchini(uint cropNumber) : Plant(cropNumber, 3u)
{
	public override uint ZucchiniCount() => cropNumber;

	public override uint GetHappiness() => state.Happiness(this) * cropNumber * (state.CanHarvest() ? 2u : 1u);
}