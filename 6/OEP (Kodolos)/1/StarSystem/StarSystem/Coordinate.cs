namespace StarSystem;

public class Coordinate
{
	public readonly double X;
	public readonly double Y;
	public readonly double Z;

	public Coordinate(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public static double Distance(Coordinate a, Coordinate b)
	{
		return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.Z - a.Z, 2));
	}
}