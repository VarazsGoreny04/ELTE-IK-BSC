namespace Moving;

public class Bird : ICanMove
{
	public Bird() { }

	public void Move()
	{
		Console.WriteLine("flies with wings");
	}
}