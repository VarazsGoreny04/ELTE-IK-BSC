using EVA.Game.Model;
using System.Collections.ObjectModel;

namespace EVA.Game.MAUI.ViewModel;
public class GameViewModel : ViewModelBase
{
	#region Fields

	private readonly GameGameModel _model;
	private int _tableSize;
	private bool _paused;

	#endregion

	#region Properties

	public DelegateCommand NewGameCommand { get; private set; }
	public DelegateCommand PauseCommand { get; private set; }
	public DelegateCommand LoadGameCommand { get; private set; }
	public DelegateCommand SaveGameCommand { get; private set; }

	public ObservableCollection<GameField> Fields { get; set; }

	public int TableSize
	{
		get => _tableSize;
		set
		{
			_tableSize = value;
			OnPropertyChanged();
			OnPropertyChanged(nameof(GameTableRows));
			OnPropertyChanged(nameof(GameTableColumns));
		}
	}

	public RowDefinitionCollection GameTableRows
	{
		get => new(Enumerable.Repeat(new RowDefinition(GridLength.Star), TableSize).ToArray());
	}

	public ColumnDefinitionCollection GameTableColumns
	{
		get => new(Enumerable.Repeat(new ColumnDefinition(GridLength.Star), TableSize).ToArray());
	}

	public bool Paused
	{
		get { return _paused; }
		set { _paused = value; OnPropertyChanged(nameof(Paused)); }
	}

	#endregion

	#region Events

	public event EventHandler? NewGame;
	public event EventHandler? Pause;
	public event EventHandler? LoadGame;
	public event EventHandler? SaveGame;

	#endregion

	#region Constructors

	public GameViewModel(GameGameModel model)
	{
		_model = model;
		_model.GameCreated += new EventHandler(GameCreated);

		NewGameCommand = new DelegateCommand(param => OnNewGame());
		PauseCommand = new DelegateCommand(param => OnPause());
		LoadGameCommand = new DelegateCommand(param => OnLoadGame());
		SaveGameCommand = new DelegateCommand(param => OnSaveGame());

		TableSize = _model.Table.Size;
		Paused = true;

		Fields = new ObservableCollection<GameField>();
		for (int i = 0; i < _model.Table.Size; i++)
		{
			for (int j = 0; j < _model.Table.Size; j++)
			{
				Fields.Add(new GameField
				{
					Alive = true,
					X = i,
					Y = j,
					StepCommand = new DelegateCommand(param =>
					{
						if (param is System.Drawing.Point p && Paused)
							FieldChanged(p);
					})
				});
			}
		}

		RefreshTable();
	}

	#endregion

	public void StepGame()
	{
		_model.Table.FlipCells();

		RefreshTable();
	}

	#region Private methods

	private void RefreshTable()
	{
		foreach (GameField field in Fields)
		{
			field.Alive = _model.Table[field.X, field.Y];
		}

		OnPropertyChanged(nameof(Fields));
	}

	private void FieldChanged(System.Drawing.Point p)
	{
		_model.Table.FlipCell(new System.Drawing.Point(p.X, p.Y));

		RefreshTable();
	}

	#endregion

	#region Game event handlers

	private void GameCreated(object? sender, EventArgs e)
	{
		RefreshTable();
	}

	#endregion

	#region Event methods

	private void OnNewGame()
	{
		NewGame?.Invoke(this, EventArgs.Empty);
	}

	private void OnPause()
	{
		Pause?.Invoke(this, EventArgs.Empty);
	}

	private void OnLoadGame()
	{
		LoadGame?.Invoke(this, EventArgs.Empty);
	}

	private void OnSaveGame()
	{
		SaveGame?.Invoke(this, EventArgs.Empty);
	}

	#endregion
}
