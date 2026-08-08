namespace StarSystem;

public class Star
{
	public readonly double habitatableMin;
	public readonly double habitatableMax;
	public readonly Coordinate coord;

	public Star(double habitatableMin, double habitatableMax, Coordinate coord)
	{
		this.habitatableMin = habitatableMin;
		this.habitatableMax = habitatableMax;
		this.coord = coord;
	}
}