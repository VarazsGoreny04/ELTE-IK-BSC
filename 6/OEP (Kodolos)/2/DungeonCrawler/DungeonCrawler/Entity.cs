namespace DungeonCrawler;

public class Entity
{
	private readonly int i;
	private readonly int j;
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
}