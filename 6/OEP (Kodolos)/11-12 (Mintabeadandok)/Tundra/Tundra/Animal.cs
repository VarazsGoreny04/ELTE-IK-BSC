namespace Tundra;

public abstract class Animal
{
	private readonly string nickname;
	private readonly int startTurn;
	protected int population;

	public string Nickname => nickname;
	public int Population => population;
	public int StartTurn => startTurn;

	public Animal(string nickname, int population)
	{
		this.nickname = nickname;
		this.population = population;
		startTurn = Ecosystem.TurnCounter;
	}

	public abstract void Reproduce();
}