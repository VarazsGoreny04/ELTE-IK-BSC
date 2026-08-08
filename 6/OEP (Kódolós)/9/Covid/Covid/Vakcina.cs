namespace Covid;

public abstract class Vakcina(DateOnly lejar)
{
	protected readonly DateOnly lejar = lejar;

	public DateOnly Lejar => lejar;

	public abstract string Nev();

	public abstract int Ism();
}

public class Astrazeneca(DateOnly lejar) : Vakcina(lejar)
{
	public override string Nev()
	{
		return "astrazeneca";
	}

	public override int Ism()
	{
		return 84;
	}
}

public class Moderna(DateOnly lejar) : Vakcina(lejar)
{
	public override string Nev()
	{
		return "moderna";
	}

	public override int Ism()
	{
		return 21;
	}
}

public class Pfizer(DateOnly lejar) : Vakcina(lejar)
{
	public override string Nev()
	{
		return "pfizer";
	}

	public override int Ism()
	{
		return 28;
	}
}