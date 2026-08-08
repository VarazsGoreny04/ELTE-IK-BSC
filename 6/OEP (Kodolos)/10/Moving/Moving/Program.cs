namespace Moving;

internal class Program
{
	static void Main()
	{
		ICanMove obj = new Random().Next(4) switch
		{
			0 => new Rabbit(),
			1 => new Human(),
			2 => new Bird(),
			3 => new Car(),
			_ => throw new Exception()
		};

		Console.Write($"A {obj.GetType().Name} ");
		obj.Move();

		ICanMove obj2 = new Human();

		if (obj2 is Human human)
			human.SolvesEquasion(3, 4);
	}
}