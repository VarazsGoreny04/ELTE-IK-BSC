using ELTE.Game.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace Game.WPF.ViewModel
{
	public class GameViewModel : ViewModelBase
	{
		private readonly GameGameModel _model;
		public uint TableSize { get => _model.Table.Size; }
		public Team GamePhase { get; set; }
		public GameField[,] Fields { get; set; }
		public ObservableCollection<GameField> ObservableFields { get; set; }
		public ObservableCollection<GameField> ObservableFields1 { get; set; }
		public ObservableCollection<GameField> ObservableFields2 { get; set; }

		public DelegateCommand NewGameCommand { get; private set; }
		public DelegateCommand SaveCommand { get; private set; }
		public DelegateCommand LoadCommand { get; private set; }
		public DelegateCommand ResumeCommand { get; private set; }
		public DelegateCommand PauseCommand { get; private set; }

		private EventHandler<GameFieldEventArgs>? _newGame;
		private EventHandler? _save;
		private EventHandler? _load;
		private EventHandler? _resume;
		private EventHandler? _pause;

		public EventHandler<GameFieldEventArgs>? NewGame { get { return _newGame; } set { _newGame = value; } }
		public EventHandler? Save { get { return _save; } set { _save = value; } }
		public EventHandler? Load { get { return _load; } set { _load = value; } }
		public EventHandler? Resume { get { return _resume; } set { _resume = value; } }
		public EventHandler? Pause { get { return _pause; } set { _pause = value; } }

		public GameViewModel(GameGameModel model)
		{
			_model = model;
			//_model.Moving += new EventHandler<GameFieldEventArgs>(FieldChanged);
			//_model.GameCreated += new EventHandler<GameEventArgs>(GameCreated);

			NewGameCommand = new DelegateCommand(param => OnNewGame(param));
			SaveCommand = new DelegateCommand(param => OnSave());
			LoadCommand = new DelegateCommand(param => OnLoad());
			ResumeCommand = new DelegateCommand(param => OnResume());
			PauseCommand = new DelegateCommand(param => OnPause());

			Fields = null!;
			ObservableFields = null!;
			ObservableFields1 = null!;
			ObservableFields2 = null!;
		}

		public void InitializeGame(uint tableSize)
		{
			ObservableFields = new ObservableCollection<GameField>();
			ObservableFields1 = new ObservableCollection<GameField>();
			ObservableFields2 = new ObservableCollection<GameField>();
			Fields = new GameField[tableSize, tableSize];
			GameField oneField;

			for (int i = 0; i < tableSize; ++i)
			{
				for (int j = 0; j < tableSize; ++j)
				{
					oneField = new(j, i)
					{
						StepCommand = new DelegateCommand(param =>
						{
							if (param is System.Drawing.Point position)
								FieldChanged(new System.Drawing.Point(position.X, position.Y));
						})
					};
					ObservableFields.Add(oneField);
					Fields[j, i] = oneField;
				}
			}

			for (int i = 0; i < 3; ++i)
			{
				for (int j = 0; j < 3; ++j)
				{
					oneField = new(j, i);
					ObservableFields1.Add(oneField);
					Fields[j, i] = oneField;
				}
			}

			for (int i = 0; i < 3; ++i)
			{
				for (int j = 0; j < 3; ++j)
				{
					oneField = new(j, i);
					ObservableFields2.Add(oneField);
					Fields[j, i] = oneField;
				}
			}

			GameCreated();
		}

		public void FieldChanged(System.Drawing.Point point)
		{
			if (!_model.Step(point))
			{
				MessageBox.Show("You can't place here!");
			}
			RefreshTable();
		}

		private void GameCreated()
		{
			RefreshTable();

			OnPropertyChanged(nameof(TableSize));
		}

		private void RefreshTable()
		{
			for (int i = 0; i < TableSize; i++)
			{
				for (int j = 0; j < TableSize; j++)
				{
					Debug.Write($"{_model.Table[j, i]} ");
				}
				Debug.WriteLine("");
			}
			Debug.WriteLine("\n");

			for (int i = 0; i < _model.Table.Size; ++i)
			{
				for (int j = 0; j < _model.Table.Size; ++j)
				{
					Fields[j, i].Color = (Team)_model.Table[j, i];
				}
			}

			for (int i = 0; i < 3; ++i)
			{
				for (int j = 0; j < 3; ++j)
				{
					ObservableFields1[i * 3 + j].Color = (Team)_model.Table.Players[0][j, i];
					ObservableFields2[i * 3 + j].Color = (Team)_model.Table.Players[1][j, i];
				}
			}

			OnPropertyChanged(nameof(ObservableFields));
			OnPropertyChanged(nameof(ObservableFields1));
			OnPropertyChanged(nameof(ObservableFields2));
		}

		private void OnNewGame(object? param)
		{
			try
			{
				int p;
				p = int.Parse((string)param);
				_newGame?.Invoke(this, new GameFieldEventArgs(p));
			}
			catch { }
		}
		private void OnSave()
		{
			_save?.Invoke(this, EventArgs.Empty);
		}
		private void OnLoad()
		{
			_load?.Invoke(this, EventArgs.Empty);
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
}