namespace Kert;

public abstract class Virag : Novenyfajta
{
	public Virag(int eresiIdo) : base(eresiIdo) { }

	public override bool IsVirag()
	{
		return true;
	}
}

public class Tulipan : Virag
{
	private static Tulipan? instance;

	private Tulipan(int eresiIdo) : base(eresiIdo) { }

	public static Tulipan Instantiate()
	{
		instance ??= new Tulipan(1);

		return instance;
	}
}

public class Szegfu : Virag
{
	private static Szegfu? instance;

	private Szegfu(int eresiIdo) : base(eresiIdo) { }

	public static Szegfu Instantiate()
	{
		instance ??= new Szegfu(2);

		return instance;
	}
}

public class Rozsa : Virag
{
	private static Rozsa? instance;

	private Rozsa(int eresiIdo) : base(eresiIdo) { }

	public static Rozsa Instantiate()
	{
		instance ??= new Rozsa(3);

		return instance;
	}
}