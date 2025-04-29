using ELTE.Snake.Model;
using System.Collections.ObjectModel;

namespace Snake_Maui.ViewModel;
public class SnakeViewModel : ViewModelBase
{
	private readonly SnakeGameModel _model;
	private bool _isGameLoaded;
	private string _title;

	public string Score { get => _model.Table.Score.ToString(); }
	public uint TableSize { get => _model.Table.Size; }
	public RowDefinitionCollection Rows
	{
		get => new(Enumerable.Repeat(new RowDefinition(GridLength.Star), (int)TableSize).ToArray());
	}
	public ColumnDefinitionCollection Columns
	{
		get => new(Enumerable.Repeat(new ColumnDefinition(GridLength.Star), (int)TableSize).ToArray());
	}
	public GamePhase GamePhase { get; set; }
	public SnakeField[,] Fields { get; set; }
	public ObservableCollection<SnakeField> ObservableFields { get; set; }
	public bool IsGameLoaded
	{
		get { return _isGameLoaded; }
		set { _isGameLoaded = value; OnPropertyChanged(nameof(IsGameLoaded)); }
	}
	public string Title
	{
		get { return _title; }
		set { _title = value; OnPropertyChanged(nameof(Title)); }
	}

	public DelegateCommand NewGameCommand { get; private set; }
	public DelegateCommand ResumeCommand { get; private set; }
	public DelegateCommand PauseCommand { get; private set; }
	public DelegateCommand DirCommand { get; private set; }

	private EventHandler<SnakeUIntEventArgs>? _newGame;
	private EventHandler? _resume;
	private EventHandler? _pause;
	private EventHandler<SnakeUIntEventArgs>? _dir;

	public EventHandler<SnakeUIntEventArgs>? NewGame { get => _newGame; set => _newGame = value; }
	public EventHandler? Resume { get => _resume; set => _resume = value; }
	public EventHandler? Pause { get => _pause; set => _pause = value; }
	public EventHandler<SnakeUIntEventArgs>? Dir { get => _dir; set => _dir = value; }

	public SnakeViewModel(SnakeGameModel model)
	{
		_model = model;
		_model.Moving += new EventHandler<SnakeFieldEventArgs>(FieldChanged);
		_model.GameCreated += new EventHandler<SnakeEventArgs>(GameCreated);

		NewGameCommand = new DelegateCommand(OnNewGame);
		ResumeCommand = new DelegateCommand(param => OnResume());
		PauseCommand = new DelegateCommand(param => OnPause());
		DirCommand = new DelegateCommand(OnDirChange);

		_title = "Snake";
		IsGameLoaded = false;

		Fields = null!;
		ObservableFields = null!;

		GamePhase = GamePhase.Pause;
	}

	public void ScoreAdvanced(SnakeEventArgs e)
	{
		OnPropertyChanged(nameof(Score));

		if (e.EmptyField)
			Fields[_model.Table.Apple.X, _model.Table.Apple.Y].Field = FieldNames.Apple;
	}

	public void FieldChanged(object? sender, SnakeFieldEventArgs e)
	{
		if (e.TailField is not null)
		{
			System.Drawing.Point oldTail = (System.Drawing.Point)e.TailField;
			Fields[oldTail.X, oldTail.Y].Field = FieldNames.Grass;
		}

		Fields[e.HeadField.X, e.HeadField.Y].Field = FieldNames.Snake;
	}

	private void GameCreated(object? sender, SnakeEventArgs e)
	{
		ObservableFields = new ObservableCollection<SnakeField>();
		Fields = new SnakeField[TableSize, TableSize];

		for (int i = 0; i < TableSize; ++i)
		{
			for (int j = 0; j < TableSize; ++j)
			{
				SnakeField oneField = new(j, i);
				ObservableFields.Add(oneField);
				Fields[j, TableSize - i - 1] = oneField;
			}
		}

		foreach (System.Drawing.Point point in _model.Table.Walls)
			Fields[point.X, point.Y].Field = FieldNames.Wall;

		foreach (System.Drawing.Point point in _model.Table.Snake)
			Fields[point.X, point.Y].Field = FieldNames.Snake;

		Fields[_model.Table.Apple.X, _model.Table.Apple.Y].Field = FieldNames.Apple;

		OnPropertyChanged(nameof(Score));
		OnPropertyChanged(nameof(TableSize));
		OnPropertyChanged(nameof(ObservableFields));
	}

	private void OnNewGame(object? sender)
	{
		if (sender is string s)
		{
			uint num = uint.Parse(s);
			_newGame?.Invoke(this, new SnakeUIntEventArgs(num));
		}
	}

	private void OnDirChange(object? sender)
	{
		if (sender is string s)
		{
			uint num = uint.Parse(s);
			_dir?.Invoke(this, new SnakeUIntEventArgs(num));
		}
	}

	private void OnResume()
	{
		_resume?.Invoke(this, EventArgs.Empty);
	}

	private void OnPause()
	{
		_pause?.Invoke(this, EventArgs.Empty);
	}
}