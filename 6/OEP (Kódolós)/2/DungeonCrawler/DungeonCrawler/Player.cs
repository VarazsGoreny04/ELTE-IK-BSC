namespace DungeonCrawler;

public class Player
{
	private int i;
	private int j;

	public int I { get => i; set => i = value; }
	public int J { get => j; set => j = value; }

	public Player(int i, int j)
	{
		this.i = i;
		this.j = j;
	}
}