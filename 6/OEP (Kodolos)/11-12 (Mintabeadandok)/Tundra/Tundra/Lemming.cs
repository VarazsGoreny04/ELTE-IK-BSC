namespace Tundra;

public class Lemming : Prey
{
	public Lemming(string nickname, int population) : base(nickname, population)
	{
		if (this.population >= 200)
			this.population = 30;
	}

	public override void Reproduce()
	{
		if ((Ecosystem.TurnCounter - StartTurn) % 2 == 0)
		{
			population *= 2;

			if (population >= 200)
				population = 30;
		}
	}

	public override void EatenBy(Predator predator)
	{
		predator.Kills(this);
	}
}