using EVA.Game.Persistence;

namespace EVA.Game.Model;
public class GameGameModel
{
	#region Fields

	private readonly IGameDataAccess _dataAccess;
	private GameTable _table;
	private int _gameStepCount;
	private int _gameTime;

	#endregion

	#region Properties

	public int GameStepCount { get { return _gameStepCount; } }
	public int GameTime { get { return _gameTime; } }
	public GameTable Table { get { return _table; } }
	public bool IsGameOver { get { return (_gameTime == 0 || _table.IsFilled); } }

	#endregion

	#region Events

	public event EventHandler<GameFieldEventArgs>? FieldChanged;
	public event EventHandler<GameEventArgs>? GameAdvanced;
	public event EventHandler<GameEventArgs>? GameOver;
	public event EventHandler<GameEventArgs>? GameCreated;

	#endregion

	#region Constructor

	public GameGameModel(IGameDataAccess dataAccess)
	{
		_dataAccess = dataAccess;
		_table = new GameTable();
	}

	#endregion

	#region Public game methods

	public void NewGame()
	{
		_table = new GameTable();
		_gameStepCount = 0;

		OnGameCreated();
	}

	public void AdvanceTime()
	{
		if (IsGameOver)
			return;

		_gameTime--;
		OnGameAdvanced();

		if (_gameTime == 0)
			OnGameOver(false);
	}

	public void Step(int x, int y)
	{
		if (IsGameOver)
			return;
		if (_table.IsLocked(x, y))
			return;

		_table.StepValue(x, y);
		OnFieldChanged(x, y);

		_gameStepCount++;

		OnGameAdvanced();

		if (_table.IsFilled)
		{
			OnGameOver(true);
		}
	}

	public async Task LoadGameAsync(string path)
	{
		if (_dataAccess == null)
			throw new InvalidOperationException("No data access is provided.");

		_table = await _dataAccess.LoadAsync(path);
		_gameStepCount = 0;

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

	private void GenerateFields(int count)
	{
		Random random = new();

		for (int i = 0; i < count; i++)
		{
			int x, y;

			do
			{
				x = random.Next(_table.Size);
				y = random.Next(_table.Size);
			}
			while (!_table.IsEmpty(x, y));

			do
			{
				for (int j = random.Next(10) + 1; j >= 0; j--)
				{
					_table.StepValue(x, y);
				}
			}
			while (_table.IsEmpty(x, y));

			_table.SetLock(x, y);
		}
	}

	#endregion

	#region Private event methods

	private void OnFieldChanged(int x, int y)
	{
		FieldChanged?.Invoke(this, new GameFieldEventArgs(x, y));
	}

	private void OnGameAdvanced()
	{
		GameAdvanced?.Invoke(this, new GameEventArgs(false, _gameStepCount, _gameTime));
	}

	private void OnGameOver(bool isWon)
	{
		GameOver?.Invoke(this, new GameEventArgs(isWon, _gameStepCount, _gameTime));
	}

	private void OnGameCreated()
	{
		GameCreated?.Invoke(this, new GameEventArgs(false, _gameStepCount, _gameTime));
	}

	#endregion
}