namespace Battleship;

public class Board
{
	public class GameOverException : Exception { }

	private const int SHIPLENGTH = 3;

	private readonly int length;
	private readonly bool[,] map;
	private readonly List<Ship> ships;

	public int Length => length;
	public bool[,] Map => map;
	public List<Ship> Ships => ships;

	public Board(int length)
	{
		if (length < 5 || length > 12)
			throw new ArgumentOutOfRangeException(nameof(length));

		this.length = length;
		map = new bool[length, length];
		ships = new(length / 2);

		List<Coordinate> haventTried = [];

		for (int i = 0; i < length; ++i)
		{
			for (int j = 0; j < length; ++j)
				haventTried.Add(new Coordinate(j, i));
		}

		Random rnd = new();

		for (int i = length / 2; i > 0; --i)
		{
			bool failure = true;
			do
			{
				List<Coordinate> coordinates = [];

				Coordinate chosen = haventTried[rnd.Next(haventTried.Count)];
				coordinates.Add(chosen);

				bool xDown = rnd.Next(2) == 1;

				for (int j = 1; j < SHIPLENGTH; ++j)
					coordinates.Add(new Coordinate(chosen.X + (xDown ? j : 0), chosen.Y + (!xDown ? j : 0)));

				if (coordinates.All(c => haventTried.Any(h => c == h)))
				{
					ships.Add(new Ship(coordinates));
					coordinates.ToList().ForEach(c => haventTried.Remove(c));
					failure = false;
				}
			} while (failure);
		}
	}

	public bool Fire(Coordinate coordinate)
	{
		if (0 > coordinate.X || coordinate.X >= length || 0 > coordinate.Y || coordinate.Y >= length)
			return false;

		map[coordinate.X, coordinate.Y] = true;

		for (int i = 0; i < ships.Count; ++i)
			ships[i].Hit(coordinate);

		if (ships.All(s => s.Sunken))
			throw new GameOverException();

		return true;
	}

	public override string ToString()
	{
		int wall = -1;
		int[,] map = new int[length + 2, length + 2];

		for (int i = 0; i < length + 2; ++i)
		{
			map[i, 0] = wall;
			map[0, i] = wall;
			map[i, length + 1] = wall;
			map[length + 1, i] = wall;
		}

		foreach (Ship ship in ships)
		{
			foreach (Segment segment in ship.Segments)
				map[segment.Coordinate.Y + 1, segment.Coordinate.X + 1] = 1 + (segment.IsDamaged ? 1 : 0) + (ship.Sunken ? 1 : 0);
		}

		string result = string.Empty;
		for (int i = 0; i < length + 2; ++i)
		{
			for (int j = 0; j < length + 2; ++j)
			{
				result += map[i, j] switch
				{
					-1 => "##",
					0 => "  ",
					1 => "[]",
					2 => "!!",
					3 => "XX",
					_ => throw new Exception()
				};
			}

			result += '\n';
		}

		return result;
	}
}