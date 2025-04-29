using System;
using System.Collections.ObjectModel;
using System.Linq;
using EVA.Game.Model;

namespace EVA.Game.WPF.ViewModel;
public class GameViewModel : ViewModelBase
{
	#region Fields

	private readonly GameGameModel _model;
	private int _tableSize;

	#endregion

	#region Properties

	public DelegateCommand NewGameCommand { get; private set; }
	public DelegateCommand LoadGameCommand { get; private set; }
	public DelegateCommand SaveGameCommand { get; private set; }
	public DelegateCommand ExitCommand { get; private set; }

	public ObservableCollection<GameField> Fields { get; set; }

	public int GameStepCount { get { return _model.GameStepCount; } }

	public string GameTime { get { return TimeSpan.FromSeconds(_model.GameTime).ToString("g"); } }

	public int TableSize
	{
		get => _tableSize;
		set
		{
			_tableSize = value;
			OnPropertyChanged();
		}
	}

	#endregion

	#region Events

	public event EventHandler? NewGame;
	public event EventHandler? LoadGame;
	public event EventHandler? SaveGame;
	public event EventHandler? ExitGame;

	#endregion

	#region Constructors

	public GameViewModel(GameGameModel model)
	{
		_model = model;
		_model.FieldChanged += new EventHandler<GameFieldEventArgs>(Model_FieldChanged);
		_model.GameAdvanced += new EventHandler<GameEventArgs>(Model_GameAdvanced);
		_model.GameOver += new EventHandler<GameEventArgs>(Model_GameOver);
		_model.GameCreated += new EventHandler<GameEventArgs>(Model_GameCreated);

		NewGameCommand = new DelegateCommand(param => OnNewGame());
		LoadGameCommand = new DelegateCommand(param => OnLoadGame());
		SaveGameCommand = new DelegateCommand(param => OnSaveGame());
		ExitCommand = new DelegateCommand(param => OnExitGame());

		TableSize = _model.Table.Size;

		Fields = new ObservableCollection<GameField>();
		for (int i = 0; i < _model.Table.Size; i++)
		{
			for (int j = 0; j < _model.Table.Size; j++)
			{
				Fields.Add(new GameField
				{
					IsLocked = true,
					Text = string.Empty,
					X = i,
					Y = j,
					StepCommand = new DelegateCommand(param =>
					{
						if (param is Tuple<int, int> position)
							StepGame(position.Item1, position.Item2);
					})
				});
			}
		}

		RefreshTable();
	}

	#endregion

	#region Private methods

	private void RefreshTable()
	{
		foreach (GameField field in Fields)
		{
			field.Text = !_model.Table.IsEmpty(field.X, field.Y) ? _model.Table[field.X, field.Y].ToString() : string.Empty;
			field.IsLocked = _model.Table.IsLocked(field.X, field.Y);
		}

		OnPropertyChanged(nameof(GameTime));
		OnPropertyChanged(nameof(GameStepCount));
	}

	private void StepGame(int x, int y)
	{
		_model.Step(x, y);
	}

	#endregion

	#region Game event handlers

	private void Model_FieldChanged(object? sender, GameFieldEventArgs e)
	{
		GameField field = Fields.Single(f => f.X == e.X && f.Y == e.Y);

		field.Text = !_model.Table.IsEmpty(field.X, field.Y) ? _model.Table[field.X, field.Y].ToString() : string.Empty;
		OnPropertyChanged(nameof(GameStepCount));
	}

	private void Model_GameOver(object? sender, GameEventArgs e)
	{
		foreach (GameField field in Fields)
			field.IsLocked = true;
	}

	private void Model_GameAdvanced(object? sender, GameEventArgs e)
	{
		OnPropertyChanged(nameof(GameTime));
	}

	private void Model_GameCreated(object? sender, GameEventArgs e)
	{
		RefreshTable();
	}

	#endregion

	#region Event methods

	private void OnNewGame()
	{
		NewGame?.Invoke(this, EventArgs.Empty);
	}

	private void OnLoadGame()
	{
		LoadGame?.Invoke(this, EventArgs.Empty);
	}

	private void OnSaveGame()
	{
		SaveGame?.Invoke(this, EventArgs.Empty);
	}

	private void OnExitGame()
	{
		ExitGame?.Invoke(this, EventArgs.Empty);
	}

	#endregion
}
