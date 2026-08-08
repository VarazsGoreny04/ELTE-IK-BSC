namespace StarSystem;

public class StarSystem
{
	public Star star;
	public List<Planet> planets;

	public StarSystem(Star star)
	{
		this.star = star;
		planets = new List<Planet>();
	}

	public void AddPlanet(Planet p)
	{
		planets.Add(p);
	}

	public int Habitables()
	{
		int n = 0; ;

		foreach (Planet p in planets)
		{
			double pDist = Coordinate.Distance(star.coord, p.coord);
			if (star.habitatableMin < pDist && pDist < star.habitatableMax)
				n++;
		}

		return n;

		/*return planets.FindAll(p =>
			star.habitatableMin < Coordinate.Distance(star.coord, p.coord) &&
			Coordinate.Distance(star.coord, p.coord) < star.habitatableMax).Count;*/
	}
}