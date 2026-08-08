namespace DungeonCrawler;

public class Dungeon
{
	private readonly Tile[,] map;
	private readonly Player player;
	private readonly List<Entity> entities;
	private int turnsLeft;
	private int bytrilCollected;

	public Tile[,] Map { get => map; }
	public Player Player { get => player; }
	public List<Entity> Entities { get => entities; }
	public int BytrilCollected { get => bytrilCollected; }
	public int TurnsLeft { get => turnsLeft;  }

	public Dungeon(int[,] layout, int turns, Player player)
	{
		map = new Tile[layout.GetLength(0), layout.GetLength(1)];

		for (int i = 0; i < layout.GetLength(0); ++i)
		{
			for (int j = 0; j < layout.GetLength(1); ++j)
			{
				if (layout[i, j] == 1)
					map[i, j] = new Tile(TileType.Wall);
				else
					map[i, j] = new Tile(TileType.Floor);
			}
		}

		turnsLeft = turns;
		this.player = player;
		entities = new List<Entity>();
		bytrilCollected = 0;
		turnsLeft = turns;
	}

	public void AddEntity(Entity entity)
	{
		entities.Add(entity);
	}

	public void MovePlayer((int, int) dir)
	{
		int newI = player.I + dir.Item1;
		int newJ = player.J + dir.Item2;

		if ((turnsLeft > 0) && (0 <= newI && newI < map.GetLength(0)) &&
			(0 <= newJ && newJ < map.GetLength(1)) && (map[newI, newJ].Type == TileType.Floor))
		{
			player.I = newI;
			player.J = newJ;
			bool escaped = false;

			List<int> entitiesAtTile = new();
			for (int i = 0; i < entities.Count; ++i)
			{
				if (entities[i].I == newI && entities[i].J == newJ)
					entitiesAtTile.Add(i);
			}

			for (int i = 0; i < entitiesAtTile.Count; ++i)
			{
				switch (entities[entitiesAtTile[i]].Type)
				{
					case EntityType.GoldenCoin:
						if (entities[entitiesAtTile[i]].CanInteract)
						{
							bytrilCollected += 10;
							entities[entitiesAtTile[i]].CanInteract = false;
						}
						break;
					case EntityType.SilverCoin:
						if (entities[entitiesAtTile[i]].CanInteract)
						{
							bytrilCollected += 5;
							entities[entitiesAtTile[i]].CanInteract = false;
						}
						break;
					case EntityType.CopperCoin:
						if (entities[entitiesAtTile[i]].CanInteract)
						{
							bytrilCollected += 1;
							entities[entitiesAtTile[i]].CanInteract = false;
						}
						break;
					case EntityType.Obelisk:
						Console.WriteLine("You left the dungeon. Bytril collected: " + bytrilCollected);
						escaped = true;
						turnsLeft = 0; // Ne léphessünk többet, ha távoztunk.
						break;
				}
			}

			turnsLeft -= 1;

			if (turnsLeft <= 0 && !escaped)
			{
				Console.WriteLine("Your greed became your demise.");
			}
		}
	}

	public void Write()
	{
		int[,] dungeon = new int[map.GetLength(0), map.GetLength(1)];

		for (int i = 0; i < map.GetLength(0); ++i)
		{
			for (int j = 0; j < map.GetLength(1); ++j)
				dungeon[i, j] += (int)map[i, j].Type;
		}

		foreach (Entity entity in entities)
			dungeon[entity.I, entity.J] = (int)entity.Type + 2;

		dungeon[player.I, player.J] = 6;

		for (int i = 0; i < dungeon.GetLength(0); ++i)
		{
			for (int j = 0; j < dungeon.GetLength(1); ++j)
			{
				Console.Write((dungeon[i, j]) switch
				{
					0 => "  ",
					1 => "[]",
					2 => "C$",
					3 => "S$",
					4 => "G$",
					5 => "OB",
					_ => "PL"
				});
			}
			Console.WriteLine();
		}
	}
}