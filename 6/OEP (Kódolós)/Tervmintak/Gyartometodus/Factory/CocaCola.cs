namespace Factory;

public class CocaCola : IFactory
{
	public Product ProducesProduct()
	{
		Random rnd = new();
		string barcode = $"{rnd.Next(1, 10)}-{rnd.Next(100000, 1000000)}-{rnd.Next(100000, 1000000)}";

		return new Drink(barcode);
	}
}