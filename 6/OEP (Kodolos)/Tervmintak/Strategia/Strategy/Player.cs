namespace Strategy;

public class Player
{
	private uint hp; 
	private Weapon? weapon;

	public uint TakesHit
	{
		get => hp;
		set => hp = Math.Max(hp - value, 0);
	}

	public Player()
	{
		hp = 100;
		weapon = null;
	}

	public void PickUp(Weapon weapon)
	{
		this.weapon = weapon;
	}

	public void Shoot(Player enemy)
	{
		enemy.TakesHit = weapon is null ? 0 : weapon.Fire();
	}
}
