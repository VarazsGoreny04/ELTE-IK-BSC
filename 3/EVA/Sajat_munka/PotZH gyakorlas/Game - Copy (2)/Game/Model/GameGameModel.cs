using EVA.Game.Persistence;

namespace EVA.Game.Model;
public class GameGameModel
{
	#region Fields

	private readonly IGameDataAccess _dataAccess;
	private GameTable _table;
	private readonly Random _random;

	#endregion

	#region Properties

	public GameTable Table { get { return _table; } }

	#endregion

	#region Events

	public event EventHandler? FieldChanged;
	public event EventHandler? GameOver;

	#endregion

	#region Constructor

	public GameGameModel(IGameDataAccess dataAccess)
	{
		_dataAccess = dataAccess;
		_table = new GameTable();
		_random = new Random();
	}

	#endregion

	#region Public game methods

	public void NewGame()
	{
		_table = new GameTable();

		for (int i = 0; i < 10; i++)
		{
			_table.Rotate((Corners)_random.Next(0, 4));
		}
	}

	public void Step(Corners c)
	{
		_table.Rotate(c);
		OnFieldChanged();

		if (IsWon())
			OnGameOver();
	}

	/*public async Task LoadGameAsync(string path)
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
	}*/

	#endregion

	#region Private game methods

	private bool IsWon()
	{
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < _table.Size - 1; j++)
			{
				if (_table[j, i] != _table[j + 1, i])
					return false;
			}
		}
		return true;
	}

	#endregion

	#region Private event methods

	private void OnFieldChanged()
	{
		FieldChanged?.Invoke(this, new EventArgs());
	}

	private void OnGameOver()
	{
		GameOver?.Invoke(this, new EventArgs());
	}

	/*private void OnGameCreated()
	{
		GameCreated?.Invoke(this, new GameEventArgs(false, _gameStepCount, _gameTime));
	}*/

	#endregion
}