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

		dungeon = new(map, 20, player);

		dungeon.AddEntity(new Entity(3, 1, EntityType.CopperCoin));
		dungeon.AddEntity(new Entity(5, 1, EntityType.SilverCoin));
		dungeon.AddEntity(new Entity(2, 6, EntityType.SilverCoin));
		dungeon.AddEntity(new Entity(6, 3, EntityType.GoldenCoin));
		dungeon.AddEntity(new Entity(5, 5, EntityType.GoldenCoin));
		dungeon.AddEntity(new Entity(3, 3, EntityType.Trap));
		dungeon.AddEntity(new Entity(4, 4, EntityType.Obelisk));
		dungeon.AddEntity(new Entity(3, 5, EntityType.Ghost));
	}

	public void Run()
	{
		Console.CursorVisible = false;
		Console.SetWindowSize(20, 16); // Cry Linux users, cry

		int newI, newJ;
		int maxJ = dungeon.Map.GetLength(1);

		dungeon.Write();
		Console.SetCursorPosition(1, maxJ + 1);
		Console.WriteLine(dungeon.Player.Bytrils);

		while (dungeon.TurnsLeft > 0 && dungeon.Player.Hp > 0)
		{
			(newI, newJ) = (0, 0);

			if (ChangeDirection(ref newI, ref newJ))
			{
				dungeon.MovePlayer((newI, newJ));

				Console.SetCursorPosition(0, 0);
				dungeon.Write();

				Console.SetCursorPosition(1, maxJ + 1);
				Console.WriteLine(dungeon.Player.Bytrils);
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