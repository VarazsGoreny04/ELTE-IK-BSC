namespace Tundra;

public class ArcticHare : Prey
{
	public ArcticHare(string nickname, int population) : base(nickname, population)
	{
		if (this.population >= 100)
			this.population = 20;
	}

	public override void Reproduce()
	{
		if ((Ecosystem.TurnCounter - StartTurn) % 2 == 0)
		{
			population = (int)(population * 1.5);   // Lefelé kerekít

			if (population >= 100)
				population = 20;
		}
	}

	public override void EatenBy(Predator predator)
	{
		predator.Kills(this);
	}
}