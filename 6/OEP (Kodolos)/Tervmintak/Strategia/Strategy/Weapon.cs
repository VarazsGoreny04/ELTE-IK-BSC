namespace Strategy;

public abstract class Weapon
{
	public virtual uint Fire()
	{
		return 0;
	}
}

public class DesertEagle : Weapon
{
	public override uint Fire()
	{
		return 45;
	}
}

public class UMP : Weapon
{
	public override uint Fire()
	{
		return 25;
	}
}

public class Nova : Weapon
{
	public override uint Fire()
	{
		return 90;
	}
}

public class AK_47 : Weapon
{
	public override uint Fire()
	{
		return 40;
	}
}

public class AWP : Weapon
{
	public override uint Fire()
	{
		return 100;
	}
}