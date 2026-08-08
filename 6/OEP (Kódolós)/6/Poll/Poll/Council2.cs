namespace Poll;

public class Council2
{
	public readonly int count;

	public int Count => count;

	public Council2(int memberNumber)
	{
		count = memberNumber;
	}

	public bool AskTheResult(int ind)
	{
		return Member2.CouncilAggreement;
	}

	public void StartPoll()
	{
		Member2.NewPoll();
		Console.WriteLine();

		for (int i = 0; i < count; ++i)
		{
			Console.Write('\t');
			Lamp(Member2.Vote());
		}
		Console.WriteLine('\n');

		Console.Write("A szavazas eredmenye: ");
		Lamp(Member2.CouncilAggreement);
		Console.WriteLine();
	}

	public static void Lamp(bool onOff)
	{
		Console.BackgroundColor = onOff ? ConsoleColor.Green : ConsoleColor.Red;
		Console.Write("  ");
		Console.BackgroundColor = ConsoleColor.Black;
	}
}