namespace Tundra;

public class ArcticFox : Predator
{
	public ArcticFox(string nickname, int population) : base(nickname, population) { }

	public override void Hunt(List<Prey> preys)
	{
		preys[Random.Next(preys.Count)].EatenBy(this);
	}

	public override void Reproduce()
	{
		if ((Ecosystem.TurnCounter - StartTurn) % 3 == 0)
			population += (population / 4) * 3;
	}

	public override void Kills(Lemming lemming)
	{
		int canSurvive = lemming.Dies(5) / 4;

		if (canSurvive < population)
			population = canSurvive;
	}

	public override void Kills(ArcticHare arcticHare)
	{
		int canSurvive = arcticHare.Dies(35) / 2;

		if (canSurvive < population)
			population = canSurvive;
	}

	public override void Kills(Moose moose) { }
}