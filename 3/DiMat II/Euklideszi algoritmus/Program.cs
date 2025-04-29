internal class Program
{
	// { q, x, y, r }
	private static List<int?[]> excel = new List<int?[]>();

	static void Main()
	{
		List<(int, int)> lista = new List<(int, int)>
		{
			(12,   15),
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
			Diofantikus();

			Console.WriteLine();

			foreach (int?[] thisRow in excel)
				Console.WriteLine($"{thisRow[0]}; {thisRow[1]}; {thisRow[2]}; {thisRow[3]}");
			
			Console.WriteLine("\n\n\n");

			excel.Clear();
		}
	}

	static void Lnko(int a, int b)
	{
		int r = a % b, q = a / b;
		excel.Add(new int?[] { q, null, null, r });

		if (r != 0)
		{
			Console.WriteLine($"{a} = {q}×{b} + {r}");
			Lnko(b, r);
		}
		else
			Console.WriteLine($"{a} = {q}×{b}\n(a,b) = {b}");
	}

	static void Diofantikus()
	{
		(int?, int?) i_2 = (1, 0), i_1 = (0, 1), flat;

		for (int i = -1; i < excel.Count - 1; ++i)
		{
			int?[] thisRow = excel[i + 1];

			if (i == -1)
				excel[i + 1] = new int?[] { thisRow[0], 1, 0, thisRow[3] };
			else if (i == 0)
				excel[i + 1] = new int?[] { thisRow[0], 0, 1, thisRow[3] };
			else
			{
				flat = (i_2.Item1 - thisRow[0] * i_1.Item1, i_2.Item2 - thisRow[0] * i_1.Item2);
				excel[i + 1] = new int?[] { thisRow[0], flat.Item1, flat.Item2, thisRow[3] };
				i_2 = i_1;
				i_1 = flat;
			}
		}
	}
}