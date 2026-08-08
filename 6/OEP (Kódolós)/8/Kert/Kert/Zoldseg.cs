namespace Kert;

public abstract class Zoldseg : Novenyfajta
{
	public Zoldseg(int eresiIdo) : base(eresiIdo) { }

	public override bool IsZoldseg()
	{
		return true;
	}
}

public class Burgonya : Zoldseg
{
	private static Burgonya? instance;

	private Burgonya(int eresiIdo) : base(eresiIdo) { }

	public static Burgonya Instantiate()
	{
		instance ??= new Burgonya(7);

		return instance;
	}
}

public class Borso : Zoldseg
{
	private static Borso? instance;

	private Borso(int eresiIdo) : base(eresiIdo) { }

	public static Borso Instantiate()
	{
		instance ??= new Borso(2);

		return instance;
	}
}

public class Hagyma : Zoldseg
{
	private static Hagyma? instance;

	private Hagyma(int eresiIdo) : base(eresiIdo) { }

	public static Hagyma Instantiate()
	{
		instance ??= new Hagyma(3);

		return instance;
	}
}