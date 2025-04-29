using ELTE.Snake.Model;
using ELTE.Snake.Persistence;

namespace ELTE.Snake.WinForms.View
{
	public partial class GameForm : Form
	{
		private const int BLOCK = 40;

		private readonly ISnakeDataAccess _dataAccess = null!;
		private readonly SnakeGameModel _model = null!;
		private Label[,] _matrix = null!;
		private int _gamePhase;

		public GameForm()
		{
			InitializeComponent();

			BackColor = Color.Gray;

			_dataAccess = new SnakeFileDataAccess();

			timer.Interval = 400;
			timer.Tick += OneStep;

			_model = new SnakeGameModel(_dataAccess);
			_model.Moving += new EventHandler<SnakeFieldEventArgs>(Moving);
			_model.EndGame += new EventHandler<SnakeEventArgs>(ScoreAdvanced);

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
			buttonPause.Enabled = !onOff;

			panelGame.Visible = !onOff;

			panelMenu.Visible = onOff;
			panelMenu.Enabled = onOff;

			panelMenu.Location = new Point(Width / 2 - panelMenu.Width / 2 - 10, Height / 2 - panelMenu.Height / 2 - 20);
		}

		private async Task InitializeGame(uint tableSize)
		{
			try
			{
				OpenFileDialog openFileDialog = new()
				{
					Title = "Load Snake table",
					Filter = "Snake table|*.txt"
				};
				if (openFileDialog.ShowDialog() is DialogResult.OK)
					await _model.NewGame(tableSize, openFileDialog.FileName);
				else
					throw new FieldAccessException("You must select a file!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			_matrix = new Label[tableSize, tableSize];
			int size = (int)tableSize * BLOCK;
			labelScoreScore.Text = Convert.ToString(_model.Table.Score);

			SetWindowSize(new Size(size + 40, size + 120));

			panelGame.Controls.Clear();
			panelGame.Size = new Size(size, size);

			buttonPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			labelScoreScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			ShowMenu(false);
			buttonResume.Enabled = true;

			for (int i = 0; i < tableSize; ++i)
				for (int j = 0; j < tableSize; ++j)
				{
					_matrix[j, i] = new Label
					{
						Size = new Size(BLOCK, BLOCK),
						Location = new Point(j * BLOCK, (int)(tableSize - i - 1) * BLOCK),
						BackColor = Color.LightGreen
					};

					panelGame.Controls.Add(_matrix[j, i]);
				}

			foreach (Point wall in _model.Table.Walls)
				_matrix[wall.X, wall.Y].BackColor = Color.Gray;

			foreach (Point tube in _model.Table.Snake)
				_matrix[tube.X, tube.Y].BackColor = Color.Green;

			_matrix[_model.Table.Apple.X, _model.Table.Apple.Y].BackColor = Color.Red;

			_gamePhase = 1;
		}

		private void ButtonPause_Click(object sender, EventArgs e)
		{
			timer.Stop();
			_gamePhase = 0;

			ShowMenu(true);
			labelTitle.Text = "Snake";
			labelTitle.ForeColor = Color.Black;
		}

		private void ButtonResume_Click(object sender, EventArgs e)
		{
			ShowMenu(false);

			_gamePhase = 2;
			timer.Start();
		}

		private async void Button10_Click(object sender, EventArgs e)
		{
			await InitializeGame(10);
		}

		private async void Button15_Click(object sender, EventArgs e)
		{
			await InitializeGame(15);
		}

		private async void Button20_Click(object sender, EventArgs e)
		{
			await InitializeGame(20);
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

		private void Moving(object? sender, SnakeFieldEventArgs e)
		{
			if (e.TailField is not null)
			{
				Point tail = (Point)e.TailField;
				_matrix[tail.X, tail.Y].BackColor = Color.LightGreen;
			}

			_matrix[e.HeadField.X, e.HeadField.Y].BackColor = Color.Green;
		}

		private void ScoreAdvanced(object? sender, SnakeEventArgs e)
		{
			labelScoreScore.Text = Convert.ToString(e.Score);

			if (e.EmptyField)
			{
				_matrix[_model.Table.Apple.X, _model.Table.Apple.Y].BackColor = Color.Red;
				return;
			}

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