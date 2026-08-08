namespace LEGO;

public class Size(int n, int m, int sz)
{
	private readonly int height = n;
	private readonly int width = m;
	private readonly int length = sz;

	public int Height => height;
	public int Width => width;
	public int Length => length;
}