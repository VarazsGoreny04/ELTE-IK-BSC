namespace HOK.Gomb.Persistence;
public class GombTable
{
	private bool _light1;
	private bool _light2;

	public bool Light1 { get { return _light1; } }

	public bool Light2 { get { return _light2; } }

	public GombTable(bool light1 = false, bool light2 = false)
	{
		_light1 = light1;
		_light2 = light2;
	}

	public void SwitchLight1()
	{
		_light1 = !_light1;
	}

	public void SwitchLight2()
	{
		_light2 = !_light2;
	}
}