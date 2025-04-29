using ELTE.Game.Model;
using ELTE.Game.Persistence;

namespace Game.WinForms.View
{
	public partial class Form1 : Form
	{
		private const int BLOCK = 40;

		private readonly IGameDataAccess _dataAccess = null!;
		private readonly GameGameModel _model = null!;
		private Label[,] _matrix = null!;
		private int _gamePhase;

		public Form1()
		{
			InitializeComponent();

			BackColor = Color.Gray;

			_dataAccess = new GameFileDataAccess();

			timer.Interval = 400;
			timer.Tick += OneStep;

			_model = new GameGameModel(_dataAccess);
			_model.Moving += new EventHandler<GameFieldEventArgs>(Moving);
			_model.EndGame += new EventHandler<GameEventArgs>(ScoreAdvanced);

			_gamePhase = 0;

			SetWindowSize(new Size(10 * BLOCK + 40, 10 * BLOCK + 120));

			ShowMenu(true);
		}

		private void SetWindowSize(Size size)
		{
			Size = size;
			MaximumSize = size;
			MinimumSize = size;
		}

		private void ShowMenu(bool onOff)
		{
			buttonPause.Visible = !onOff;
			panelGame.Visible = !onOff;
			panelMenu.Visible = onOff;

			buttonPause.Enabled = !onOff;
			panelMenu.Enabled = onOff;

			panelMenu.Location = new Point(Width / 2 - panelMenu.Width / 2 - 10, Height / 2 - panelMenu.Height / 2 - 20);
		}

		private void InitializeGame()
		{
			panelGame.Controls.Clear();
			_matrix = new Label[_model.Table.Size, _model.Table.Size];

			int size = (int)_model.Table.Size * BLOCK;
			SetWindowSize(new Size(size + 40, size + 120));
			panelGame.Size = new Size(size, size);

			buttonPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			labelScoreScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			for (int i = 0; i < _model.Table.Size; ++i)
			{
				for (int j = 0; j < _model.Table.Size; ++j)
				{
					_matrix[j, i] = new Label
					{
						Size = new Size(BLOCK, BLOCK),
						Location = new Point(j * BLOCK, i * BLOCK),
						BackColor = Color.LightGreen
					};

					panelGame.Controls.Add(_matrix[j, i]);
				}
			}

			for (int i = 0; i < _model.Table.Size; i++)
			{
				for (int j = 0; j < _model.Table.Size; j++)
				{
					_matrix[j, i].BackColor = Color.Gray;
				}
			}

			ShowMenu(false);
			buttonSave.Enabled = true;
			buttonResume.Enabled = true;

			labelScoreScore.Text = Convert.ToString(_model.Round);
			_gamePhase = 1;
		}

		private void ButtonPause_Click(object sender, EventArgs e)
		{
			timer.Stop();
			_gamePhase = 0;

			ShowMenu(true);
			labelTitle.Text = "Game";
			labelTitle.ForeColor = Color.Black;
		}

		private void ButtonResume_Click(object sender, EventArgs e)
		{
			ShowMenu(false);

			_gamePhase = 2;
			timer.Start();
		}

		private void ButtonNewGame_Click(object sender, EventArgs e)
		{
			_model.NewGame();
			InitializeGame();
		}

		private async void ButtonSave_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog saveFileDialog = new()
				{
					Title = "Save Game table",
					Filter = "Game table|*.txt"
				};
				if (saveFileDialog.ShowDialog() is DialogResult.OK)
					await _model.SaveGame(saveFileDialog.FileName);
				else
					throw new FieldAccessException("You must select a file!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
		}

		private async void ButtonLoad_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new()
				{
					Title = "Load Game table",
					Filter = "Game table|*.txt"
				};
				if (openFileDialog.ShowDialog() is DialogResult.OK)
					await _model.LoadGame(openFileDialog.FileName);
				else
					throw new FieldAccessException("You must select a file!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			InitializeGame();
		}

		private void OneStep(object? sender, EventArgs e)
		{
			_model.Step();
		}

		private void InputConverter(object sender, KeyEventArgs e)
		{
			if (_gamePhase == 1)
			{
				_gamePhase = 2;
				timer.Start();
			}
			if (_gamePhase == 2)
			{
				Dir dir;
				switch (e.KeyCode)
				{
					case Keys.W:
						dir = Dir.Up; break;
					case Keys.S:
						dir = Dir.Down; break;
					case Keys.A:
						dir = Dir.Left; break;
					case Keys.D:
						dir = Dir.Right; break;
					default:
						return;
				}
				_model.SetDirection(dir);
			}
		}

		private void Moving(object? sender, GameFieldEventArgs e)
		{
			if (e.OldField is not null)
			{
				Point tail = (Point)e.OldField;
				_matrix[tail.X, tail.Y].BackColor = Color.LightGreen;
			}

			_matrix[e.NewField.X, e.NewField.Y].BackColor = Color.Green;
		}

		private void ScoreAdvanced(object? sender, GameEventArgs e)
		{
			labelScoreScore.Text = Convert.ToString(e.Score);

			timer.Stop();
			_gamePhase = 0;

			if (e.IsWon)
			{
				labelTitle.ForeColor = Color.LawnGreen;
				labelTitle.Text = "You won :)";
			}
			else
			{
				labelTitle.Text = "You lost :(";
				labelTitle.ForeColor = Color.Red;
			}

			buttonResume.Enabled = false;
			ShowMenu(true);
		}
	}
}