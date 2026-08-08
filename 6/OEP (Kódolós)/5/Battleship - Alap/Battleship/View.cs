namespace Battleship;

public class View
{
	private readonly Board board;
	private bool hideShips;

	public bool HideShips { get => hideShips; set => hideShips = value; }

	public View()
	{
		board = new Board(10);
		hideShips = true;
	}

	public View(int length)
	{
		board = new Board(length);
		hideShips = true;
	}


	public void Run()
	{
		Console.BackgroundColor = ConsoleColor.Black;
		Console.CursorVisible = false;

		int x = 0;
		int y = 0;

		try
		{
			while (true)
			{
				Console.Clear();
				Display();

				Console.SetCursorPosition(0, 13);

				if (int.TryParse(Console.ReadLine(), out x) && int.TryParse(Console.ReadLine(), out y))
					board.Fire(new Coordinate(x, board.Length - (y + 1)));
			}
		}
		catch (Board.GameOverException)
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.WriteLine("Game End");
		}
	}

	public void Display()
	{
		Console.SetCursorPosition(0, 0);

		string display = board.ToString();

		for (int i = 0; i < board.Length + 2; ++i)
		{
			for (int j = 0; j < board.Length + 2; ++j)
			{
				int index = 25 * i + j * 2;
				string current = display[index..(index + 2)];

				Console.BackgroundColor = current switch
				{
					"##" => ConsoleColor.DarkGray,
					"  " => ConsoleColor.Blue,
					"[]" => hideShips ? ConsoleColor.Blue : ConsoleColor.Gray,
					"!!" => ConsoleColor.Red,
					"XX" => ConsoleColor.DarkRed,
					_ => throw new NotImplementedException()
				};
				if (current == "  " && board.Map[j - 1, i - 1])
					Console.BackgroundColor = ConsoleColor.DarkBlue;

				Console.Write("  ");
			}
			Console.WriteLine();
		}

		Console.BackgroundColor = ConsoleColor.Black;
	}
}