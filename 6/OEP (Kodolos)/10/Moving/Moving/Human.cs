namespace Moving;

public class Human : ICanMove
{
	public Human() { }

	public void Move()
	{
		Console.WriteLine("walks");
	}

	public void SolvesEquasion(float a, float b)
	{
		Console.WriteLine($"{a}^2 + {b}^2 = {Math.Sqrt(a * a + b * b)}^2");
	}
}