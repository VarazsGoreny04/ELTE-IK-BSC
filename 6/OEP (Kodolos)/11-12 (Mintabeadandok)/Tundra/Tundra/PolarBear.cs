namespace Tundra;

public class PolarBear : Predator
{
	public PolarBear(string nickname, int population) : base(nickname, population) { }

	public override void Hunt(List<Prey> preys)
	{
		preys[Random.Next(preys.Count)].EatenBy(this);
	}

	public override void Reproduce()
	{
		if ((Ecosystem.TurnCounter - StartTurn) % 8 == 0)
			population += population / 4;
	}

	public override void Kills(Lemming lemming)
	{
		int canSurvive = lemming.Dies(2) / 20;

		if (canSurvive < population)
			population = canSurvive;
	}

	public override void Kills(ArcticHare arcticHare)
	{
		int canSurvive = arcticHare.Dies(1) / 10;

		if (canSurvive < population)
			population = canSurvive;
	}

	public override void Kills(Moose moose)
	{
		int canSurvive = moose.Dies(25) * 2;

		if (canSurvive < population)
			population = canSurvive;
	}
}