namespace Moving;

public class Rabbit : ICanMove
{
	public Rabbit() { }

	public void Move()
	{
		Console.WriteLine("hops on four legs");
	}
}