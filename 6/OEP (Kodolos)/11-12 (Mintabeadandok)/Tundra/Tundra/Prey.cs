namespace Tundra;

public abstract class Prey : Animal
{
	public Prey(string nickname, int population) : base(nickname, population) { }

	public int Dies(int percent)
	{
		ArgumentOutOfRangeException.ThrowIfGreaterThan(percent, 100);
		/*if (percent > 100)											// Mindkettő ugyanazt jelenti
			throw new ArgumentOutOfRangeException();*/

		int dead = (int)((percent / 100f) * population);

		population -= dead;

		return dead;
	}

	public abstract void EatenBy(Predator predator);
}