namespace Poll;

public static class Member2
{
	private static bool councilAggreement = true;

	public static bool CouncilAggreement => councilAggreement;

	public static bool Vote()
	{
		Random rnd = new();

		bool vote = rnd.Next(0, 10) != 0;
		councilAggreement &= vote;

		return vote;
	}

	public static void NewPoll()
	{
		councilAggreement = true;
	}
}