namespace Poll;

public class Council
{
	private readonly Member[] members;

	public int Count => members.Length;
	//public Member this[int ind] => members[ind];

	public Council(int memberNumber)
	{
		members = new Member[memberNumber];

		for (int i = 0; i < memberNumber; ++i)
			members[i] = Member.Instantiate();
	}

	public bool AskTheResult(int ind)
	{
		return members[ind].CouncilAggreement;
	}

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