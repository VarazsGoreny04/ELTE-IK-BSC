namespace HOK.Gomb.Model;
public class GombEventArgs
{
	private readonly bool _one;
	private readonly bool _two;

	public bool One { get { return _one; } }
	public bool Two { get { return _two; } }

	public GombEventArgs(bool _one, bool _two)
	{
		this._one = _one;
		this._two = _two;
	}
}
