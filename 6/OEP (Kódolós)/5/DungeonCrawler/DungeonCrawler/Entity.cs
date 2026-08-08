namespace DungeonCrawler;

public class Entity
{
	private int i;
	private int j;
	private readonly EntityType type;
	private bool canInteract;

	public int I { get => i; }
	public int J { get => j; }
	public EntityType Type { get => type; }
	public bool CanInteract { get => canInteract; set => canInteract = value; }

	public Entity(int i, int j, EntityType type)
	{
		this.i = i;
		this.j = j;
		this.type = type;
		canInteract = true;
	}

	// Dependency injection
	public void Update(Player player, Tile[,] layout, ref int turnsLeft)
	{
		switch (type)
		{
			case EntityType.GoldenCoin: GoldenCoinBehaviour(player); break;
			case EntityType.SilverCoin: SilverCointBehaviour(player); break;
			case EntityType.CopperCoin: CopperCoinBehaviour(player); break;
			case EntityType.Obelisk: ObeliskBehaviour(player, ref turnsLeft); break;
			case EntityType.Trap: TrapBehaviour(player); break;
			case EntityType.Ghost: GhostBehaviour(player, layout); break;
			default: break;
		}
	}

	private void GoldenCoinBehaviour(Player player)
	{
		if (player.I == i && player.J == j && canInteract)
		{
			canInteract = false;
			player.GiveMoney(10);
		}
	}

	private void SilverCointBehaviour(Player player)
	{
		if (player.I == i && player.J == j && canInteract)
		{
			canInteract = false;
			player.GiveMoney(5);
		}
	}

	private void CopperCoinBehaviour(Player player)
	{
		if (player.I == i && player.J == j && canInteract)
		{
			canInteract = false;
			player.GiveMoney(1);
		}
	}

	private void ObeliskBehaviour(Player player, ref int turnsLeft)
	{
		if (player.I == i && player.J == j && canInteract)
			turnsLeft = -1;
	}

	private void TrapBehaviour(Player player)
	{
		Random rnd = new();

		if (rnd.Next(4) == 0)
			canInteract = !canInteract;

		if (canInteract && player.I == i && player.J == j)
		{
			canInteract = false;
			player.InflictDamage(1);
		}
	}

	private void GhostBehaviour(Player player, Tile[,] layout)
	{
		bool chaseMode = false;
		(int, int)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];
		(int, int) targetDirection = (0, 0);
		int distance = 0;
		int d1d, d2d;

		foreach ((int, int) dir in directions)
		{
			distance = 0;
			(d1d, d2d) = (0, 0);

			while (0 <= i + d1d && 0 <= j + d2d && layout.GetLength(0) > i + d1d && layout.GetLength(1) > j + d2d &&
				layout[i + d1d, j + d2d].Type != TileType.Wall && !(player.I == i + d1d && player.J == j + d2d))
			{
				++distance;
				d1d += dir.Item1;
				d2d += dir.Item2;
			}

			if (player.I == i + d1d && player.J == j + d2d)
			{
				chaseMode = true;
				targetDirection = dir;
				break;
			}
		}

		if (chaseMode)
		{
			if (distance > 0)
			{
				i += targetDirection.Item1;
				j += targetDirection.Item2;

				if (distance > 1)
				{
					i += targetDirection.Item1;
					j += targetDirection.Item2;
				}
			}

			if (player.I == i && player.J == j)
			{
				// TODO: teleport player
				player.InflictDamage(1);
			}
		}
		else
		{
			Random rnd = new();
			(int, int) dir;

			do
			{
				dir = directions[rnd.Next(4)];
			} while (layout[i + dir.Item1, j + dir.Item2].Type != TileType.Floor);

			i += dir.Item1;
			j += dir.Item2;
		}
	}
}