namespace Poll;

public class Council
{
	public void StartPoll()
	{
		Member.NewPoll();
		Console.WriteLine();

		for (int i = 0; i < members.Length; ++i)
		{
			Console.Write('\t');
			Lamp(members[i].Vote());
		}
		Console.WriteLine('\n');

		Console.Write("A szavazas eredmenye: ");
		Lamp(members[0].CouncilAggreement);
		Console.WriteLine();
	}

	public static void Lamp(bool onOff)
	{
		Console.BackgroundColor = onOff ? ConsoleColor.Green : ConsoleColor.Red;
		Console.Write("  ");
		Console.BackgroundColor = ConsoleColor.Black;
	}
}