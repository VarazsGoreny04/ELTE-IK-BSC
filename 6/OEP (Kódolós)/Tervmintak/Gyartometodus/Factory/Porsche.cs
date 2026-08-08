namespace Factory;

public class Porsche : IFactory
{
	public Product ProducesProduct()
	{
		Random rnd = new();
		string serealNumber = string.Empty;

		for (int i = 0; i < 3; ++i)
			serealNumber += (char)('A' + rnd.Next(26));

		serealNumber += $"-{rnd.Next(100, 1000)}";

		return new Car(serealNumber);
	}
}