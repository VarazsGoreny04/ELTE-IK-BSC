using DungeonCrawler.TileType;

namespace DungeonCrawler.EntityType;

public class Ghost : Entity
{
	public Ghost(int i, int j) : base(i, j) { }

	public override void Update(Player player, Tile[,] layout, ref int turnsLeft)
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
				layout[i + d1d, j + d2d] is not Wall && !(player.I == i + d1d && player.J == j + d2d))
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
				player.InflictDamage(player.Hp);
			}
		}
		else
		{
			Random rnd = new();
			(int, int) dir;

			do
			{
				dir = directions[rnd.Next(4)];
			} while (layout[i + dir.Item1, j + dir.Item2] is not Floor);

			i += dir.Item1;
			j += dir.Item2;
		}
	}
}