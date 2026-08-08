namespace Poll;

internal class Program
{
	static void Main()
	{
		Council council = new(10);

		while (true)
		{
			Console.SetCursorPosition(0, 0);
			council.StartPoll();

			for (int i = 0; i < council.Count; ++i)
			{
				Console.Write($"Az {i}. tag szerint a szavazas eredmenye: ");
				Council.Lamp(council.AskTheResult(i));
				Console.WriteLine();
			}

			Console.ReadKey();
		}
	}
}