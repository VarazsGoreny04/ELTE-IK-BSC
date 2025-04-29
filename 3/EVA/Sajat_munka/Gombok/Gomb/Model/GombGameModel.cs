using HOK.Gomb.Persistence;

namespace HOK.Gomb.Model;
public class GombGameModel
{
	private GombTable _table;
	private readonly IGombDataAccess _dataAccess;

	public event EventHandler<GombEventArgs>? Handler;

	public GombTable Table { get { return _table; } }

	public GombGameModel(IGombDataAccess _dataAccess)
	{
		_table = new GombTable();
		this._dataAccess = _dataAccess;
	}

	public void NewGame()
	{
		_table = new GombTable();
	}

	public void Button1()
	{
		Table.SwitchLight1();
		Event();
	}

	public void Button12()
	{
		Table.SwitchLight1();
		Table.SwitchLight2();
		Event();
	}
	public async Task SaveGameAsync(string path)
	{
		if (_dataAccess == null)
			throw new InvalidOperationException("No data access is provided.");

		await _dataAccess.SaveAsync(path, _table);
	}
	public async Task LoadGameAsync(string path)
	{
		if (_dataAccess == null)
			throw new InvalidOperationException("No data access is provided.");

		_table = await _dataAccess.LoadAsync(path);
		Event();
	}

	private void Event()
	{
		Handler?.Invoke(this, new GombEventArgs(Table.Light1, Table.Light2));
	}
}