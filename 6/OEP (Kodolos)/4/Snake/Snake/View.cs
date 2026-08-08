namespace Snake;

public class View
{
	private readonly Board board;

	public View()
	{
		board = new Board();
	}

	public View(int length)
	{
		board = new Board(length);
	}

	public void Run()
	{
		Console.CursorVisible = false;

		Direction dir = Direction.RIGHT;

		try
		{
			while (true)
			{
				Console.SetCursorPosition(0, 0);
				Console.WriteLine(board.ToString());

				dir = Console.ReadKey().Key switch
				{
					ConsoleKey.W => Direction.UP,
					ConsoleKey.S => Direction.DOWN,
					ConsoleKey.A => Direction.LEFT,
					ConsoleKey.D => Direction.RIGHT,
					_ => dir
				};
				Console.WriteLine("\b ");
				
				board.Move(dir);
			}
		}
		catch (Exception)
		{
			Console.WriteLine("Game End");
		}
	}
}
