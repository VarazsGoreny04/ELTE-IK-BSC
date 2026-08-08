namespace Composite;

internal class Program
{
	static void Main()
	{
		List<ISoldier> platoon4 =
		[
			new Soldier(),			// 1
			new Soldier(),			// 2
			new Soldier(),			// 3
			new Soldier()			// 4
		];

		List<ISoldier> platoon3 =
		[
			new Soldier(),			// 5
			new Soldier(),			// 6
			new Platoon(platoon4)
		];

		List<ISoldier> platoon2 =
		[
			new Soldier(),			// 7
			new Soldier(),			// 8
			new Soldier(),			// 9
			new Soldier(),			// 10
			new Soldier()			// 11
		];

		List<ISoldier> platoon1 =
		[
			new Soldier(),			// 12
			new Soldier(),			// 13
			new Soldier(),			// 14
			new Platoon(platoon2),
			new Platoon(platoon3)
		];

		ISoldier army = new Platoon(platoon1);

		Console.WriteLine($"There are {army.Count()} soldiers in this army");
	}
}