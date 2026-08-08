namespace Snake;

public class Board
{
	public override string ToString()
	{
		int wall = 1;
		int[,] map = new int[length + 2, length + 2];

		for (int i = 0; i < length + 2; ++i)
		{
			map[i, 0] = wall;
			map[0, i] = wall;
			map[i, length + 1] = wall;
			map[length + 1, i] = wall;
		}

		foreach (Coordinate coord in snake.Body)
			map[coord.Y + 1, coord.X + 1] = 2;

		string result = string.Empty;
		for (int i = 0; i < length + 2; ++i)
		{
			for (int j = 0; j < length + 2; ++j)
			{
				result += map[i, j] switch
				{
					0 => "  ",
					1 => "[]",
					2 => "()",
					_ => throw new Exception()
				};
			}

			result += '\n';
		}

		return result;
	}
}