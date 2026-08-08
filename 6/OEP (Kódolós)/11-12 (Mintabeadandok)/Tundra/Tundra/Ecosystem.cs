using System.Linq;

namespace Tundra;

public class Ecosystem
{
	private static int turnCounter = 0;

	private readonly int predatorCount;
	private readonly List<Predator> predators;
	private readonly List<Prey> preys;

	public static int TurnCounter => turnCounter;

	public List<Predator> Predators => predators;
	public List<Prey> Preys => preys;

	public Ecosystem(List<Predator> predators, List<Prey> preys)
	{
		this.predators = predators;
		this.preys = preys;

		predatorCount = this.predators.Sum(p => p.Population);      // LinQ-val megoldva
		/*predatorCount = 0;										// impreatívan megoldva
		foreach (Predator p in predators)
			predatorCount += p.Population;*/
	}

	public static void EndTurn()
	{
		++turnCounter;
	}

	public static void ResetTurns()
	{
		turnCounter = 0;
	}

	public bool HasExtinct()
	{
		if (predators.Any(p1 => p1.Population == 0 && predators.All(p2 => p1.GetType() != p2.GetType() || p2.Population == 0)))
			return true;

		if (preys.Any(p1 => p1.Population == 0 && preys.All(p2 => p1.GetType() != p2.GetType() || p2.Population == 0)))
			return true;

		return false;
	}

	public void Simulate()
	{
		Write();

		EndTurn();

		do
		{
			predators.ForEach(p => p.Hunt(preys));                  // LinQ-val megoldva
			/*foreach (Predator p in predators)						// impreatívan megoldva
				p.Hunt();*/

			predators.ForEach(p => p.Reproduce());
			preys.ForEach(p => p.Reproduce());

			EndTurn();

			Write();

		} while (!(predators.All(p => p.Population < 4) || predatorCount * 2 <= predators.Sum(p => p.Population)));
	}

	public void Write()
	{
		Console.WriteLine($"{turnCounter}. turn\n-------------------------");

		Console.WriteLine("Predators:");
		foreach (Predator p in predators)
			Console.WriteLine($"{p.GetType().Name} named {p.Nickname} counts {p.Population} animals");

		Console.WriteLine("Preys:");
		foreach (Prey p in preys)
			Console.WriteLine($"{p.GetType().Name} named {p.Nickname} counts {p.Population} animals");
		Console.WriteLine();
	}
}