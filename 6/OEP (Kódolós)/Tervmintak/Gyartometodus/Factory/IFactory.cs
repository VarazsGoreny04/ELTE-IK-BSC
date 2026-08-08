namespace Factory;

public interface IFactory
{
	public virtual List<Product> Order(int number)
	{
		List<Product> products = [];

		for (int i = 0; i < number; ++i)
		{
			Product p = ProducesProduct();
			products.Add(p);
		}

		return products;
	}

	public abstract Product ProducesProduct();
}