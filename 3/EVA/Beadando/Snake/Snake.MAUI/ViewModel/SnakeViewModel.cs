using ELTE.Snake.Model;
using System.Collections.ObjectModel;

namespace ELTE.Snake.MAUI.ViewModel;
public class SnakeViewModel : ViewModelBase
{
	private readonly SnakeGameModel _model;
	private bool _isGameLoaded;
	private string _title;

	public string Score { get => _model.Score.ToString(); }
	public uint TableSize { get => _model.Table.Size; }
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

	private EventHandler? _newGame;
	private EventHandler? _resume;
	private EventHandler? _pause;

	public EventHandler? NewGame { get => _newGame; set => _newGame = value; }
	public EventHandler? Resume { get => _resume; set => _resume = value; }
	public EventHandler? Pause { get => _pause; set => _pause = value; }

	public SnakeViewModel(SnakeGameModel model)
	{
		_model = model;
		_model.Moving += new EventHandler<SnakeFieldEventArgs>(FieldChanged);
		_model.GameCreated += new EventHandler<SnakeEventArgs>(GameCreated);

		NewGameCommand = new DelegateCommand(param => OnNewGame());
		ResumeCommand = new DelegateCommand(param => OnResume());
		PauseCommand = new DelegateCommand(param => OnPause());

		_title = "Snake";

		Fields = null!;
		ObservableFields = null!;

		GamePhase = GamePhase.Pause;
	}

	public void InitializeGame(uint tableSize)
	{
		ObservableFields = new ObservableCollection<SnakeField>();
		Fields = new SnakeField[tableSize, tableSize];

		for (int i = 0; i < tableSize; ++i)
		{
			for (int j = 0; j < tableSize; ++j)
			{
				SnakeField oneField = new(j, i);
				ObservableFields.Add(oneField);
				Fields[j, tableSize - i - 1] = oneField;
			}
		}
	}

	public void ScoreAdvanced(SnakeEventArgs e)
	{
		OnPropertyChanged(nameof(Score));

		if (e.EmptyField)
			Fields[_model.Table.Apple.X, _model.Table.Apple.Y].Field = FieldNames.Apple;
	}

	public void FieldChanged( object? sender, SnakeFieldEventArgs e)
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
		foreach (System.Drawing.Point point in _model.Table.Walls)
			Fields[point.X, point.Y].Field = FieldNames.Wall;

		foreach (System.Drawing.Point point in _model.Table.Snake)
			Fields[point.X, point.Y].Field = FieldNames.Snake;

		Fields[_model.Table.Apple.X, _model.Table.Apple.Y].Field = FieldNames.Apple;

		OnPropertyChanged(nameof(Score));
		OnPropertyChanged(nameof(TableSize));
		OnPropertyChanged(nameof(ObservableFields));
	}

	private void OnNewGame()
	{
		_newGame?.Invoke(this, EventArgs.Empty);
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