namespace StevesGarden;

public static class Program
{
	public static void Main()
	{
		Garden istvanBacsiKertecskeje = Garden.Instantiate();
		List<uint> parcels = [10, 14, 10];
		List<Plant> plants =
		[
			new Melon(2),
			new Melon(4),
			new Pumpkin(4),
			new Pumpkin(3),
			new Zucchini(1),
			new Melon(2),
			new Pumpkin(6),
			new Melon(2),
			new Melon(2)
		];
		List<bool> results = [];

		parcels.ForEach(istvanBacsiKertecskeje.CreateParcel);

        Console.WriteLine($"[ {string.Join(", ", istvanBacsiKertecskeje.FreeSpaces())} ]");

		plants.ForEach(plant => results.Add(istvanBacsiKertecskeje.ToFirstFreeParcelPlant(plant)));

		Console.WriteLine($"Steve's happiness: {istvanBacsiKertecskeje.HappinessMeter()}");

		istvanBacsiKertecskeje.GrowMelons();
		istvanBacsiKertecskeje.GrowMelons();

		Console.WriteLine($"Steve's happiness: {istvanBacsiKertecskeje.HappinessMeter()}");

		istvanBacsiKertecskeje.GrowZucchinis();

		Console.WriteLine($"[ {string.Join(", ", istvanBacsiKertecskeje.FreeSpaces())} ]");
        Console.WriteLine($"[ {string.Join(", ", results)} ]");
        Console.WriteLine($"Steve's happiness: {istvanBacsiKertecskeje.HappinessMeter()}");
	}
}