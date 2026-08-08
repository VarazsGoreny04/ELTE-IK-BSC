namespace Moving;

public class Car : ICanMove
{
	public Car() { }

	public void Move()
	{
		Console.WriteLine("rolls on wheels");
	}
}