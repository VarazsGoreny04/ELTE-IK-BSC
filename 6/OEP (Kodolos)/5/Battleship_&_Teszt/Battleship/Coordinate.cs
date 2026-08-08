namespace Battleship;

public class Coordinate
{
	private readonly int x;
	private readonly int y;

	public int X => x;
	public int Y => y;

	public Coordinate(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public override bool Equals(object? obj)
	{
		return obj is Coordinate coord && (x, y) == (coord.x, coord.y);
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	public static bool operator ==(Coordinate a, Coordinate b) => Equals(a, b);
	public static bool operator !=(Coordinate a, Coordinate b) => !Equals(a, b);
}