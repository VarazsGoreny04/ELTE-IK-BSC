using DungeonCrawler.TileType;

namespace DungeonCrawler.EntityType;

public class GoldenCoin : Entity
{
	public GoldenCoin(int i, int j) : base(i, j) { }

	public override void Update(Player player, Tile[,] layout, ref int turnsLeft)
	{
		if (player.I == i && player.J == j && canInteract)
		{
			canInteract = false;
			player.GiveMoney(10);
		}
	}
}