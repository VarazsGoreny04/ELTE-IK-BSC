namespace Battleship;

public class Ship
{
	private readonly List<Segment> segments;
	private bool sunken;

	public List<Segment> Segments => segments;
	public bool Sunken { get => sunken; }

	public Ship(List<Coordinate> coordinates)
	{
		for (int i = coordinates.Count - 1; i > 0; --i)
		{
			for (int j = i - 1; j >= 0; --j)
			{
				if (coordinates[j] == coordinates[i])
					throw new Exception();
			}
		}

		segments = coordinates.ToList().ConvertAll(x => new Segment(x));
		sunken = false;
	}

	public void Hit(Coordinate coordinate)
	{
		Segment? hitSegment = segments.FirstOrDefault(x => x.Coordinate == coordinate);

		if (hitSegment is not null)
		{
			hitSegment.Hit();
			sunken = segments.All(x => x.IsDamaged);
		}
	}
}