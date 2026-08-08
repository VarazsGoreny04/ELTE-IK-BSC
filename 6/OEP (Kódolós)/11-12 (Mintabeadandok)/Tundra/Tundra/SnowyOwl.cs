namespace Tundra;

public class SnowyOwl : Predator
{
	public SnowyOwl(string nickname, int population) : base(nickname, population) { }

	public override void Hunt(List<Prey> preys)
	{
		preys[Random.Next(preys.Count)].EatenBy(this);
	}

	public override void Reproduce()
	{
		if ((Ecosystem.TurnCounter - StartTurn) % 3 == 0)
			population += (population / 4) * 2;
	}

	public override void Kills(Lemming lemming)
	{
		int canSurvive = lemming.Dies(30) / 2;

		if (canSurvive < population)
			population = canSurvive;
	}

	public override void Kills(ArcticHare arcticHare)
	{
		int canSurvive = arcticHare.Dies(20);

		if (canSurvive < population)
			population = canSurvive;
	}

	public override void Kills(Moose moose) { }
}