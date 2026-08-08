namespace Tundra;

public class Moose : Prey
{
	public Moose(string nickname, int population) : base(nickname, population)
	{
		if (this.population >= 200)
			this.population = 40;
	}

	public override void Reproduce()
	{
		if ((Ecosystem.TurnCounter - StartTurn) % 4 == 0)
		{
			population = (int)(population * 1.2);   // Lefelé kerekít

			if (population >= 200)
				population = 40;
		}
	}

	public override void EatenBy(Predator predator)
	{
		predator.Kills(this);
	}
}