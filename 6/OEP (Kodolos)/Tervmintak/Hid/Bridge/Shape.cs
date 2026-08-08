namespace Bridge;

public abstract class Shape
{
	private readonly Color color;

	public Color Color => color;

	public Shape(Color color)
	{
		this.color = color;
	}
}