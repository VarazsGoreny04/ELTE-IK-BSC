namespace DungeonCrawler;

public class Player
{
	private int i;
	private int j;
	private int bytrils;
	private int hp;

	public int I { get => i; set => i = value; }
	public int J { get => j; set => j = value; }
	public int Bytrils { get => bytrils; }
	public int Hp { get => hp; }

	public Player(int i, int j)
	{
		this.i = i;
		this.j = j;
		hp = 1;
	}

	public void Move((int, int) direction, Tile[,] map)
	{
		if (map[i + direction.Item1, j + direction.Item2].Type == TileType.Floor)
		{
			i += direction.Item1;
			j += direction.Item2;
		}
	}

	public void GiveMoney(int amount)
	{
		if (amount > 0)
			bytrils += amount;
	}

	public void InflictDamage(int dmg)
	{
		hp -= dmg;
	}
}