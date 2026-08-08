namespace Rally;

public abstract class Kategoria()
{
	private int hely = 0;

	public int Hely { get => hely; set => hely = value; }

	public int Pont(int db)
	{
		return (db + 1 - hely) * Szorzo();
	}

	public abstract int Szorzo();
}

public class Sport() : Kategoria
{
	public override int Szorzo() { return 3; }
}

public class Teher() : Kategoria
{
	public override int Szorzo() { return 4; }
}

public class Motor() : Kategoria
{
	public override int Szorzo() { return 1; }
}