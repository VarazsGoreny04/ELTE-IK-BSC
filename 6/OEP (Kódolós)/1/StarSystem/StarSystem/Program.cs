namespace StarSystem;

internal class Program
{
	private static void Main()
	{
		Star star = new Star(4, 6, new Coordinate(0, 0, 0));

		StarSystem starSystem = new StarSystem(star);

		for (int i = 0; i < 6; i++)
		{
			Planet planet = new Planet(new Coordinate(2, 2, 2 + i));
			starSystem.AddPlanet(planet);
		}

		Console.WriteLine(starSystem.Habitables());
	}
}