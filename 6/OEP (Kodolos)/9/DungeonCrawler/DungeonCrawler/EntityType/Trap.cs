using DungeonCrawler.TileType;

namespace DungeonCrawler.EntityType;

public class Trap : Entity
{
	public Trap(int i, int j) : base(i, j) { }

	public override void Update(Player player, Tile[,] layout, ref int turnsLeft)
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
}
