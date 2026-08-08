namespace Battleship;

public class Board
{
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