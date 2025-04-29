internal class Program
{
	static void Main()
	{
		List<(int, int)> lista = new List<(int, int)>
		{
			(86,   31),
			(675,  471),
			(420,  154),
			(430,  300),
			(139,  102),
			(432,  300),
			(1080, 285),
			(2355, 450),
			(255,  111),
			(756,  333),
			(2016, 880),
			(300,  132),
			(332,  88),
			(504,  150),
			(30,   22),
			(518,  154)
		};

		foreach ((int, int) i in lista)
		{
			Lnko(i.Item1, i.Item2);
			Console.WriteLine();
		}
	}

	static void Lnko(int a, int b)
	{
		int r = a % b;

		if (r != 0)
		{
			Console.WriteLine($"{a} = {a / b}×{b} + {r}");
			Lnko(b, r);
		}
		else
		{
			Console.WriteLine($"{a} = {a / b}×{b}\n(a,b) = {b}");
		}
	}
}