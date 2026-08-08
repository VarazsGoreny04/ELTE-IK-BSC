using DungeonCrawler.EntityType;

namespace DungeonCrawler;

public class DungeonWriter
{
	private readonly Dungeon dungeon;

	public DungeonWriter(Dungeon dungeon)
	{
		this.dungeon = dungeon;
	}

	public DungeonWriter(string file)
	{
		dungeon = Reader(file);
	}

	public void Run()
	{
		int length = dungeon.Map.GetLength(1);

		Console.CursorVisible = false;
		Console.SetWindowSize(length * 2 + 4, length + 4); // Cry Linux users, cry

		int newI, newJ;

		dungeon.Write();
		Console.SetCursorPosition(1, length + 1);
		Console.WriteLine($"♥{dungeon.Player.Hp}\t${dungeon.Player.Bytrils}");

		while (dungeon.TurnsLeft > 0 && dungeon.Player.Hp > 0)
		{
			(newI, newJ) = (0, 0);

			if (ChangeDirection(ref newI, ref newJ))
			{
				dungeon.MovePlayer((newI, newJ));

				Console.SetCursorPosition(0, 0);
				dungeon.Write();

				Console.SetCursorPosition(1, length + 1);
				Console.WriteLine($"♥{dungeon.Player.Hp}\t${dungeon.Player.Bytrils}");
			}
		}

		Console.SetWindowSize(Math.Max(length * 2 + 4, 48), length + 10); // Cry Linux users, cry
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

	public static Dungeon Reader(string file)
	{
		// TextFileReader reader;
		StreamReader reader;

		try
		{
			reader = new($"./Maps/{file}");
		}
		catch (Exception)
		{
			throw new Exception("A fajl nem talalhato!");
		}

		string line;
		string[] tokens;
		char[] separators = [',', ';'];

		int turns = -1;
		int length;
		int[,] layout = null!;
		Player player = null!;
		List<Entity> entities = [];
		Dungeon dungeon;

		try
		{
			while ((line = reader.ReadLine()!) != null)
			{
				tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

				if (tokens.Length == 0)
					continue;

				switch (tokens[0])
				{
					case "map":
						length = int.Parse(tokens[1]);
						layout = new int[length, length];

						for (int i = 0; i < length; ++i)
						{
							tokens = reader.ReadLine()!.Split(separators, StringSplitOptions.RemoveEmptyEntries);

							for (int j = 0; j < length; j++)
								layout[i, j] = int.Parse(tokens[j]);
						}
						break;
					case "turns":
						turns = (int)uint.Parse(tokens[1]);
						break;
					case "pl":
						player = new(int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]));
						break;
					case "cc":
						entities.Add(new CopperCoin(int.Parse(tokens[1]), int.Parse(tokens[2])));
						break;
					case "sc":
						entities.Add(new SilverCoin(int.Parse(tokens[1]), int.Parse(tokens[2])));
						break;
					case "gc":
						entities.Add(new GoldenCoin(int.Parse(tokens[1]), int.Parse(tokens[2])));
						break;
					case "tr":
						entities.Add(new Trap(int.Parse(tokens[1]), int.Parse(tokens[2])));
						break;
					case "gh":
						entities.Add(new Ghost(int.Parse(tokens[1]), int.Parse(tokens[2])));
						break;
					case "ob":
						entities.Add(new Obelisk(int.Parse(tokens[1]), int.Parse(tokens[2])));
						break;
					default:
						throw new NotImplementedException();
				}
			}
		}
		catch (Exception)
		{
			throw new Exception("Hibas bemenet!");
		}

		if (layout is null || turns < 0 || player is null)
			throw new Exception("Nem eleg adat!");

		dungeon = new(layout, turns, player);

		foreach (Entity entity in entities)
			dungeon.Entities.Add(entity);

		return dungeon;
	}
}