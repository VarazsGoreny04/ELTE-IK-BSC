namespace Tundra;

internal class Program
{
	static void Main()
	{
		List<Predator> predators =
		[
			new SnowyOwl("Owl", 10),
			new ArcticFox("Fox", 13),
			new PolarBear("Bear", 100)
		];

		List<Prey> preys =
		[
			new Lemming("Lemming1", 99),
			new Lemming("Lemming2", 90),
			new Lemming("Lemming3", 69),
			new Lemming("Lemming4", 40),
			new Lemming("Lemming5", 110),
			new Lemming("Lemming6", 15),
			new Lemming("Lemming7", 99),
			new ArcticHare("Rabbit1", 45),
			new ArcticHare("Rabbit2", 55),
			new ArcticHare("Rabbit3", 80),
			new ArcticHare("Rabbit4", 20),
			new ArcticHare("Rabbit5", 45),
			new ArcticHare("Rabbit6", 90),
			new ArcticHare("Rabbit7", 45),
			new Moose("Moose1", 49),
			new Moose("Moose2", 20),
			new Moose("Moose3", 25),
			new Moose("Moose4", 70),
			new Moose("Moose5", 44)
		];

		Ecosystem ecosystem = new(predators, preys);

		ecosystem.Simulate();

		Console.WriteLine($"\nIs there any extinct species: {(ecosystem.HasExtinct() ? "Yes" : "No")}");
	}
}