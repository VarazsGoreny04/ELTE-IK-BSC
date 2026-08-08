namespace DungeonCrawler;

public class DungeonWriter
{
	private readonly Dungeon dungeon;

	public DungeonWriter(Dungeon dungeon)
	{
		this.dungeon = dungeon;
	}

	public DungeonWriter()
	{
		int[,] map =
		{
			{ 1,1,1,1,1,1,1,1 },
			{ 1,0,1,0,0,0,0,1 },
			{ 1,0,1,1,0,1,0,1 },
			{ 1,0,0,0,0,0,0,1 },
			{ 1,0,1,0,0,1,0,1 },
			{ 1,0,1,0,1,0,0,1 },
			{ 1,1,0,0,0,0,1,1 },
			{ 1,1,1,1,1,1,1,1 }
		};

		Player player = new(1, 1);

		dungeon = new(map, 10, player);

		dungeon.AddEntity(new Entity(3, 1, EntityType.CopperCoin));
		dungeon.AddEntity(new Entity(5, 1, EntityType.SilverCoin));
		dungeon.AddEntity(new Entity(2, 6, EntityType.SilverCoin));
		dungeon.AddEntity(new Entity(6, 3, EntityType.GoldenCoin));
		dungeon.AddEntity(new Entity(5, 5, EntityType.GoldenCoin));
		dungeon.AddEntity(new Entity(4, 4, EntityType.Obelisk));
	}

	public void Run()
	{
		Console.CursorVisible = false;
		Console.SetWindowSize(20, 16); // Cry Linux users, cry

		int newI, newJ;
		int maxJ = dungeon.Map.GetLength(1);

		dungeon.Write();
		Console.SetCursorPosition(1, maxJ + 1);
		Console.WriteLine(dungeon.BytrilCollected);

		while (dungeon.TurnsLeft > 0)
		{
			(newI, newJ) = (dungeon.Player.I, dungeon.Player.J);

			if (ChangeDirection(ref newI, ref newJ))
			{

				Console.SetCursorPosition(dungeon.Player.J * 2, dungeon.Player.I);
				Console.Write("  ");

				Console.SetCursorPosition(1, maxJ + 2);
				dungeon.MovePlayer((newI - dungeon.Player.I, newJ - dungeon.Player.J));

				Console.SetCursorPosition(dungeon.Player.J * 2, dungeon.Player.I);
				Console.Write("PL");

				Console.SetCursorPosition(1, maxJ + 1);
				Console.WriteLine(dungeon.BytrilCollected);
			}
		}
	}

	private static bool ChangeDirection(ref int newI, ref int newJ)
	{
		ConsoleKeyInfo key;

		key = Console.ReadKey();
		Console.Write("\b");

		switch (key.Key)
		{
			case ConsoleKey.UpArrow:
				--newI;
				break;
			case ConsoleKey.DownArrow:
				++newI;
				break;
			case ConsoleKey.LeftArrow:
				--newJ;
				break;
			case ConsoleKey.RightArrow:
				++newJ;
				break;
			default:
				return false;
		}

		return true;
	}
}