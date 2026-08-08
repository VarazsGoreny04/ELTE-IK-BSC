namespace Poll;

public class Member
{
	private bool councilAggreement = true;
	private static Member? instance = null;

	public bool CouncilAggreement => councilAggreement;

	private Member() { }

	public static Member Instantiate()
	{
		if (instance is null)
			instance = new Member();

		// instance ??= new Member();

		return instance;
	}

	public bool Vote()
	{
		Random rnd = new();

		bool vote = rnd.Next(0, 10) != 0;
		councilAggreement &= vote;

		return vote;
	}

	public static void NewPoll()
	{
		if (instance is not null)
			instance.councilAggreement = true;
	}
}