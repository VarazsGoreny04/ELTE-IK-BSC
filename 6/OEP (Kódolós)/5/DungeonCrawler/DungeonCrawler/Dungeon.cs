namespace DungeonCrawler;

public class Dungeon
{
	private readonly Tile[,] map;
	private readonly Player player;
	private readonly List<Entity> entities;
	private int turnsLeft;

	public Tile[,] Map { get => map; }
	public Player Player { get => player; }
	public List<Entity> Entities { get => entities; }
	public int TurnsLeft { get => turnsLeft; }

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
		entities = [];
		turnsLeft = turns;
	}

	public void AddEntity(Entity entity)
	{
		entities.Add(entity);
	}

	public void MovePlayer((int, int) dir)
	{
		Player.Move(dir, map);

		foreach (Entity entity in Entities)
			entity.Update(player, Map, ref turnsLeft);

		--turnsLeft;

		if (turnsLeft == -1)
			Console.WriteLine(" You left the dungeon. Bytril collected: " + player.Bytrils);
		else if (turnsLeft == 0 || player.Hp < 1)
			Console.WriteLine(" Your greed became your demise.");
	}

	public void Write()
	{
		int[,] dungeon = new int[map.GetLength(0), map.GetLength(1)];

		for (int i = 0; i < map.GetLength(0); ++i)
		{
			for (int j = 0; j < map.GetLength(1); ++j)
				dungeon[i, j] = (int)map[i, j].Type;
		}

		foreach (Entity entity in entities)
			dungeon[entity.I, entity.J] = (!entity.CanInteract) ? (int)TileType.Floor : (int)entity.Type + 2;

		dungeon[player.I, player.J] = -1;

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
					6 => "GH",
					7 => "TR",
					_ => "PL"
				});
			}
			Console.WriteLine();
		}
	}
}