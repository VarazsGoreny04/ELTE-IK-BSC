namespace Battleship;

public class Segment
{
	private readonly Coordinate coordinate;
	private bool isDamaged;

	public Coordinate Coordinate => coordinate;
	public bool IsDamaged { get => isDamaged; }

	public Segment(Coordinate coordinate)
	{
		this.coordinate = coordinate;
		isDamaged = false;
	}

	public void Hit()
	{
		isDamaged = true;
	}
}