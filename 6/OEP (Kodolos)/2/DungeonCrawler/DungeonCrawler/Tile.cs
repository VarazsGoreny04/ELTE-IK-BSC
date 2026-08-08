namespace DungeonCrawler;

public class Tile
{
	private readonly TileType type;

	public TileType Type { get => type; }

	public Tile(TileType type)
	{
		this.type = type;
	}
}