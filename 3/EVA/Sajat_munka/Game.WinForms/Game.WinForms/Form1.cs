using ELTE.Game.Model;
using ELTE.Game.Persistence;

namespace Game
{
	public partial class Form1 : Form
	{
		private const int BLOCK = 100;
		private const int TABLESIZE = 4;

		private readonly IGameDataAccess _dataAccess = null!;
		private readonly GameGameModel _model = null!;
		private Button[,] _matrix = null!;
		private Button[,] _block = null!;

		public Form1()
		{
			InitializeComponent();

			BackColor = Color.Gray;

			_dataAccess = new GameFileDataAccess();

			_model = new GameGameModel(_dataAccess);
			_model.EndGame += new EventHandler<GameEventArgs>(EndGame);

			ShowMenu(true);
		}

		private void InitializeGame()
		{
			panelGame.Controls.Clear();
			panelBlock.Controls.Clear();
			_model.NewGame();
			_matrix = new Button[TABLESIZE, TABLESIZE];
			_block = new Button[2, 2];

			labelScoreScore.Text = Convert.ToString(_model.Table.Score);

			int size = TABLESIZE * BLOCK;
			SetWindowSize(new Size(size + 260, size + 120));
			panelGame.Size = new Size(size, size);

			buttonPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			labelScoreScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			ShowMenu(false);
			buttonResume.Enabled = true;

			for (int i = 0; i < TABLESIZE; ++i)
			{
				for (int j = 0; j < TABLESIZE; ++j)
				{
					_matrix[j, i] = new Button
					{
						Size = new Size(BLOCK, BLOCK),
						Location = new Point(j * BLOCK, i * BLOCK),
						BackColor = Color.White,
					};
					_matrix[j, i].Click += ButtonPlace_Click;

					panelGame.Controls.Add(_matrix[j, i]);
				}
			}

			for (int i = 0; i < 2; ++i)
			{
				for (int j = 0; j < 2; ++j)
				{
					_block[j, i] = new Button
					{
						Size = new Size(BLOCK, BLOCK),
						Location = new Point(j * BLOCK, i * BLOCK),
						BackColor = _model.Table.Blocks[_model.Table.Block][i, j] ? Color.Blue : Color.White,
					};

					panelBlock.Controls.Add(_block[j, i]);
				}
			}

			for (int i = 0; i < 4; ++i)
			{
				for (int j = 0; j < 4; ++j)
				{
					if (_model.Table.Table[j, i])
						_matrix[j, i].BackColor = Color.Blue;
				}
			}
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
			panelBlock.Visible = !onOff;

			panelMenu.Visible = onOff;
			panelMenu.Enabled = onOff;

			panelMenu.Location = new Point(Width / 2 - panelMenu.Width / 2 - 10, Height / 2 - panelMenu.Height / 2 - 20);
		}
		private void ButtonPause_Click(object sender, EventArgs e)
		{
			ShowMenu(true);
		}

		private void ButtonResume_Click(object sender, EventArgs e)
		{
			ShowMenu(false);
		}

		private void ButtonNewGame_Click(object sender, EventArgs e)
		{
			InitializeGame();
		}

		private async void ButtonLoadGame_Click(object sender, EventArgs e)
		{
			InitializeGame();

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

			buttonResume.Enabled = true;
			buttonSaveGame.Enabled = true;
			labelScoreScore.Text = Convert.ToString(_model.Table.Score);

			for (int i = 0; i < 4; ++i)
			{
				for (int j = 0; j < 4; ++j)
				{
					if (_model.Table.Table[j, i])
						_matrix[j, i].BackColor = Color.Blue;
					else
						_matrix[j, i].BackColor = Color.White;
				}
			}
		}
		
		private async void ButtonSaveGame_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog saveFileDialog = new()
				{
					Title = "Load Game table",
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

		private void ButtonPlace_Click(object? sender, EventArgs e)
		{
			if (sender is Button button)
			{
				Point temp = new(button.Location.X / BLOCK, button.Location.Y / BLOCK);

				if (_model.PlaceBlock(temp))
				{
					for (int i = 0; i < 4; ++i)
					{
						for (int j = 0; j < 4; ++j)
						{
							if (_model.Table.Table[j, i])
								_matrix[j, i].BackColor = Color.Blue;
							else
								_matrix[j, i].BackColor = Color.White;
						}
					}

					for (int i = 0; i < 2; ++i)
					{
						for (int j = 0; j < 2; ++j)
						{
							if (_model.Table.Blocks[_model.Table.Block][i, j])
								_block[j, i].BackColor = Color.Blue;
							else
								_block[j, i].BackColor = Color.White;
						}
					}

					labelScoreScore.Text = Convert.ToString(_model.Table.Score);
				}
			}
		}

		private void EndGame(object? sender, GameEventArgs e)
		{
			ShowMenu(true);
			buttonResume.Enabled = false;
			buttonSaveGame.Enabled = false;
		}
	}
}
