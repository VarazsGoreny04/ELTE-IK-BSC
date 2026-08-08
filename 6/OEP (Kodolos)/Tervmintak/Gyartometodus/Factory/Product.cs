namespace Factory;

public abstract class Product
{
	private readonly string id;

	public string Id => id;

	protected Product(string id)
	{
		this.id = id;
	}
}