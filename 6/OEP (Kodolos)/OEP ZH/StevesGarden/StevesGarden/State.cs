namespace StevesGarden;

public abstract class State
{
	public abstract void Ripen(ref State stateOfPlant);

	public virtual bool CanHarvest() => false;

	public abstract uint Happiness(Melon p);
	public abstract uint Happiness(Pumpkin p);
	public abstract uint Happiness(Zucchini p);
}

public class Seedling : State
{
	public override void Ripen(ref State stateOfPlant) => stateOfPlant = new Green();

	public override uint Happiness(Melon p) => 2u;
	public override uint Happiness(Pumpkin p) => 1u;
	public override uint Happiness(Zucchini p) => 1u;
}

public class Green : State
{
	public override void Ripen(ref State stateOfPlant) => stateOfPlant = new Ripe();

	public override uint Happiness(Melon p) => 3u;
	public override uint Happiness(Pumpkin p) => 3u;
	public override uint Happiness(Zucchini p) => 2u;
}

public class Ripe : State
{
	public override void Ripen(ref State stateOfPlant) => stateOfPlant = new Overripe();

	public override bool CanHarvest() => true;

	public override uint Happiness(Melon p) => 4u;
	public override uint Happiness(Pumpkin p) => 3u;
	public override uint Happiness(Zucchini p) => 3u;
}

public class Overripe : State
{
	public override void Ripen(ref State stateOfPlant) { }

	public override uint Happiness(Melon p) => 0u;
	public override uint Happiness(Pumpkin p) => 0u;
	public override uint Happiness(Zucchini p) => 0u;
}