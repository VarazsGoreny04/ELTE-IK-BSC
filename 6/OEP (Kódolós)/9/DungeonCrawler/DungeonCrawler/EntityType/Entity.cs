using DungeonCrawler.TileType;

namespace DungeonCrawler.EntityType;

public abstract class Entity
{
	protected int i;
	protected int j;
	protected bool canInteract;

	public int I { get => i; }
	public int J { get => j; }
	public bool CanInteract { get => canInteract; set => canInteract = value; }

	public Entity(int i, int j)
	{
		this.i = i;
		this.j = j;
		canInteract = true;
	}

	public virtual /*abstract*/ void Update(Player player, Tile[,] layout, ref int turnsLeft) { }
}