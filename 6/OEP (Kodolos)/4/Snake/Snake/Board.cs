namespace Snake;

public class Board
{
	private readonly int length;
	private readonly Snake snake;

	public Board()
	{
		length = 10;
		snake = new Snake(new Coordinate(5, 4));
	}

	public Board(int length)
	{
		if (length < 6)
			throw new Exception();

		this.length = length;
		snake = new Snake(new Coordinate(length / 2, length / 2 - 1));
	}

	public void Move(Direction dir)
	{
		snake.Move(dir);

		if (snake.Head.X < 0 || snake.Head.Y < 0 || snake.Head.X >= length || snake.Head.Y >= length 
			/*|| snake.Body.IndexOf(snake.Head) < snake.Body.Count - 1*/)
			throw new Exception();
	}

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