using EVA.Game.Persistence;

namespace EVA.Game.Model;
public class GameGameModel
{
	#region Fields

	private readonly IGameDataAccess _dataAccess;
	private GameTable _table;

	#endregion

	#region Properties
	public GameTable Table { get { return _table; } }

	#endregion

	#region Events

	public event EventHandler<GameFieldEventArgs>? FieldChanged;
	public event EventHandler? GameAdvanced;
	public event EventHandler? GameOver;
	public event EventHandler? GameCreated;

	#endregion

	#region Constructor

	public GameGameModel(IGameDataAccess dataAccess)
	{
		_dataAccess = dataAccess;
		_table = new GameTable();
	}

	#endregion

	#region Public game methods

	public void NewGame(int size)
	{
		_table = new GameTable(size);

		OnGameCreated();
	}

	public async Task LoadGameAsync(string path)
	{
		if (_dataAccess == null)
			throw new InvalidOperationException("No data access is provided.");

		_table = await _dataAccess.LoadAsync(path);

		OnGameCreated();
	}

	public async Task SaveGameAsync(string path)
	{
		if (_dataAccess == null)
			throw new InvalidOperationException("No data access is provided.");

		await _dataAccess.SaveAsync(path, _table);
	}

	#endregion

	#region Private game methods


	#endregion

	#region Private event methods

	private void OnFieldChanged(int x, int y)
	{
		FieldChanged?.Invoke(this, new GameFieldEventArgs(x, y));
	}

	private void OnGameAdvanced()
	{
		GameAdvanced?.Invoke(this, EventArgs.Empty);
	}

	private void OnGameOver()
	{
		GameOver?.Invoke(this, EventArgs.Empty);
	}

	private void OnGameCreated()
	{
		GameCreated?.Invoke(this, EventArgs.Empty);
	}

	#endregion
}