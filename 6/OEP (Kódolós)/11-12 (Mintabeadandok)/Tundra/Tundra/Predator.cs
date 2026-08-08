namespace Tundra;

public abstract class Predator : Animal
{
	private static readonly Random random = new();

	protected static Random Random => random;

	public Predator(string nickname, int population) : base(nickname, population) { }

	public abstract void Hunt(List<Prey> preys);

	public abstract void Kills(Lemming lemming);
	public abstract void Kills(ArcticHare arcticHare);
	public abstract void Kills(Moose moose);
}