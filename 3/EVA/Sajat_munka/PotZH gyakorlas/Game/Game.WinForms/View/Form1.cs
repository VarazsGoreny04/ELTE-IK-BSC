using EVA.Game.Model;
using EVA.Game.Persistence;

namespace EVA.Game.WinForms.View;
public partial class GameForm : Form
{
	#region Fields

	private readonly IGameDataAccess _dataAccess = null!;
	private readonly GameGameModel _model = null!;
	private Button[,] _buttonGrid = null!;
	private readonly System.Windows.Forms.Timer _timer = null!;

	#endregion

	#region Constructors

	public GameForm()
	{
		InitializeComponent();

		_dataAccess = new GameFileDataAccess();

		_model = new GameGameModel(_dataAccess);
		_model.FieldChanged += new EventHandler<GameFieldEventArgs>(Game_FieldChanged);
		_model.GameAdvanced += new EventHandler<GameEventArgs>(Game_GameAdvanced);
		_model.GameOver += new EventHandler<GameEventArgs>(Game_GameOver);

		_timer = new() { Interval = 1000 };
		_timer.Tick += new EventHandler(Timer_Tick);

		GenerateTable();

		_model.NewGame();
		SetupTable();

		_timer.Start();
	}

	#endregion

	#region Game event handlers

	private void Game_FieldChanged(object? sender, GameFieldEventArgs e)
	{
		if (_model.Table.IsEmpty(e.X, e.Y))
			_buttonGrid[e.X, e.Y].Text = string.Empty;
		else
			_buttonGrid[e.X, e.Y].Text = _model.Table[e.X, e.Y].ToString();
	}

	private void Game_GameAdvanced(object? sender, GameEventArgs e)
	{
		_toolLabelGameTime.Text = TimeSpan.FromSeconds(e.GameTime).ToString("g");
		_toolLabelGameSteps.Text = e.GameStepCount.ToString();
	}

	private void Game_GameOver(object? sender, GameEventArgs e)
	{
		_timer.Stop();

		foreach (Button button in _buttonGrid)
			button.Enabled = false;

		_menuFileSaveGame.Enabled = false;

		if (e.IsWon)
		{
			MessageBox.Show("Gratulálok, gyõztél!" + Environment.NewLine +
							"Összesen " + e.GameStepCount + " lépést tettél meg és " +
							TimeSpan.FromSeconds(e.GameTime).ToString("g") + " ideig játszottál.",
							"Game játék",
							MessageBoxButtons.OK,
							MessageBoxIcon.Asterisk);
		}
		else
		{
			MessageBox.Show("Sajnálom, vesztettél, lejárt az idõ!",
							"Game játék",
							MessageBoxButtons.OK,
							MessageBoxIcon.Asterisk);
		}
	}

	#endregion

	#region Grid event handlers

	private void ButtonGrid_MouseClick(object? sender, MouseEventArgs e)
	{
		if (sender is Button button)
		{
			int x = (button.TabIndex - 100) / _model.Table.Size;
			int y = (button.TabIndex - 100) % _model.Table.Size;

			_model.Step(x, y);
		}
	}

	#endregion

	#region Menu event handlers

	private void MenuFileNewGame_Click(object sender, EventArgs e)
	{
		_menuFileSaveGame.Enabled = true;

		_model.NewGame();
		SetupTable();
		SetupMenus();

		_timer.Start();
	}

	private async void MenuFileLoadGame_Click(object sender, EventArgs e)
	{
		bool restartTimer = _timer.Enabled;
		_timer.Stop();
		if (_openFileDialog.ShowDialog() == DialogResult.OK)
		{
			try
			{
				await _model.LoadGameAsync(_openFileDialog.FileName);
				_menuFileSaveGame.Enabled = true;
			}
			catch (GameDataException)
			{
				MessageBox.Show("Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

				_model.NewGame();
				_menuFileSaveGame.Enabled = true;
			}

			SetupTable();
		}

		if (restartTimer)
			_timer.Start();
	}

	private async void MenuFileSaveGame_Click(object sender, EventArgs e)
	{
		bool restartTimer = _timer.Enabled;
		_timer.Stop();

		if (_saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			try
			{
				await _model.SaveGameAsync(_saveFileDialog.FileName);
			}
			catch (GameDataException)
			{
				MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		if (restartTimer)
			_timer.Start();
	}

	private void MenuFileExit_Click(object sender, EventArgs e)
	{
		bool restartTimer = _timer.Enabled;
		_timer.Stop();

		if (MessageBox.Show("Biztosan ki szeretne lépni?", "Game játék", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			Close();
		}
		else
		{
			if (restartTimer)
				_timer.Start();
		}
	}

	#endregion

	#region Timer event handlers

	private void Timer_Tick(object? sender, EventArgs e)
	{
		_model.AdvanceTime();
	}

	#endregion

	#region Private methods

	private void GenerateTable()
	{
		_buttonGrid = new Button[_model.Table.Size, _model.Table.Size];
		for (int i = 0; i < _model.Table.Size; i++)
		{
			for (int j = 0; j < _model.Table.Size; j++)
			{
				_buttonGrid[i, j] = new Button
				{
					Location = new Point(5 + 50 * j, 35 + 50 * i),
					Size = new Size(50, 50),
					Font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold),
					Enabled = false,
					TabIndex = 100 + i * _model.Table.Size + j,
					FlatStyle = FlatStyle.Flat
				};
				_buttonGrid[i, j].MouseClick += new MouseEventHandler(ButtonGrid_MouseClick);

				Controls.Add(_buttonGrid[i, j]);
			}
		}
	}

	private void SetupTable()
	{
		for (int i = 0; i < _buttonGrid.GetLength(0); i++)
		{
			for (int j = 0; j < _buttonGrid.GetLength(1); j++)
			{
				if (!_model.Table.IsLocked(i, j))
				{
					_buttonGrid[i, j].Text = _model.Table.IsEmpty(i, j)
						? string.Empty
						: _model.Table[i, j].ToString();
					_buttonGrid[i, j].Enabled = true;
					_buttonGrid[i, j].BackColor = Color.White;
				}
				else
				{
					_buttonGrid[i, j].Text = _model.Table[i, j].ToString();
					_buttonGrid[i, j].Enabled = false;
					_buttonGrid[i, j].BackColor = Color.Yellow;
				}
			}
		}

		_toolLabelGameSteps.Text = _model.GameStepCount.ToString();
		_toolLabelGameTime.Text = TimeSpan.FromSeconds(_model.GameTime).ToString("g");
	}

	#endregion
}