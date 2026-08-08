namespace LEGO;

internal class Program
{
	static void Main()
	{
		Console.WriteLine("Építsünk valami szépet!");

		Shop LEGO_Store = new("LEGO Store", "Allee, Október huszonharmadika u. 8-10");

		LegoBox bonsai = new Thematic("Bonsai fa", 16000);
		LegoBox millenium = new Thematic("Millenium Falcon", 269000);

		List<Piece> pieceList =
		[
			new Cylinder("fekete", 300, new Size(10, 20, 30)),
			new Tile("fekete", 300, new Size(10, 5, 30)),
			new Brick("áttetsző", 300, new Size(20, 20, 20)),
			new Cylinder("zöld", 300, new Size(15, 25, 35))
		];
		LegoBox legoCityHelicopter = new Basic("Mentőhelikopter", pieceList);

		pieceList =
		[
			new Tile("fekete", 300, new Size(10, 22, 30)),
			new Tile("fekete", 300, new Size(10, 5, 30)),
			new Brick("áttetsző", 300, new Size(20, 20, 20)),
			new Brick("zöld", 300, new Size(20, 25, 35))
		];
		LegoBox legoCityTrain = new Basic("Tehervonat", pieceList);

		LEGO_Store.StockUp(bonsai);
		LEGO_Store.StockUp(bonsai);
		LEGO_Store.StockUp(millenium);
		LEGO_Store.StockUp(legoCityHelicopter);

		Console.WriteLine($"2 - {LEGO_Store.HowMany("Bonsai fa")}");
		Console.WriteLine($"true - {LEGO_Store.AllContainsCylinder()}");
		Console.WriteLine($"Millenium Falcon - {LEGO_Store.MostExpensive()}\n");

		LEGO_Store.StockUp(legoCityTrain);

		Console.WriteLine($"1 - {LEGO_Store.HowMany("Millenium Falcon")}");
		Console.WriteLine($"false - {LEGO_Store.AllContainsCylinder()}");
		Console.WriteLine($"Millenium Falcon - {LEGO_Store.MostExpensive()}\n");

		LEGO_Store.Sell(millenium);

		Console.WriteLine($"0 - {LEGO_Store.HowMany("Millenium Falcon")}");
		Console.WriteLine($"false - {LEGO_Store.AllContainsCylinder()}");
		Console.WriteLine($"Bonsai fa - {LEGO_Store.MostExpensive()}\n");
	}
}