using ELTE.Game.Model;
using ELTE.Game.Persistence;
using Game.WPF.ViewModel;
using Game.WPF.View;
using System.Windows;
using System.ComponentModel;
using System.Windows.Media;
using Microsoft.Win32;

namespace Game.WPF
{
	public partial class App : Application
	{
		private const int BLOCK = 60;

		private GameGameModel _model = null!;
		private GameViewModel _viewModel = null!;
		private MainWindow _menu = null!;
		private GameWindow _game = null!;

		public App()
		{
			Startup += new StartupEventHandler(AppStartup);
		}

		public void AppStartup(object? sender, StartupEventArgs e)
		{
			_model = new GameGameModel(new GameFileDataAccess());
			//_model.Moving += new EventHandler<GameFieldEventArgs>(Moving);
			_model.EndGame += new EventHandler<GameEventArgs>(ScoreAdvanced);

			_viewModel = new GameViewModel(_model);
			_viewModel.NewGame += new EventHandler<GameFieldEventArgs>(NewGame);
			_viewModel.Resume += new EventHandler(Resume);
			_viewModel.Pause += new EventHandler(Pause);

			_menu = new MainWindow { DataContext = _viewModel };
			_menu.Closing += new CancelEventHandler(Closing);
			_menu.Show();

			_game = new GameWindow { DataContext = _viewModel };
			_game.Closing += new CancelEventHandler(Closing);
		}

		private void NewGame(object? sender, GameFieldEventArgs e)
		{
			uint tableSize = (uint)e.TableSize;

			_model.NewGame(tableSize);

			_viewModel.InitializeGame(tableSize);

			SetWindowSize(tableSize);
			ShowMenu(false);

			_menu.buttonResume.IsEnabled = true;
		}

		private async void LoadGame(object? sender, EventArgs e)
		{

			try
			{
				OpenFileDialog openFileDialog = new()
				{
					Title = "Load Game table",
					Filter = "Game table|*.txt"
				};
				if (openFileDialog.ShowDialog() is true)
					await _model.LoadGame(openFileDialog.FileName);
				else
					throw new FieldAccessException("You must select a file!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			_viewModel.InitializeGame(_model.Table.Size);

			SetWindowSize(_model.Table.Size);
			ShowMenu(false);

			_menu.buttonResume.IsEnabled = true;
		}

		private async void SaveGame(object? sender, EventArgs e)
		{
			try
			{
				SaveFileDialog saveFileDialog = new()
				{
					Title = "Save Game table",
					Filter = "Game table|*.txt"
				};
				if (saveFileDialog.ShowDialog() is true)
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

		private void Resume(object? sender, EventArgs e)
		{
			ShowMenu(false);
		}

		private void Pause(object? sender, EventArgs e)
		{
			ShowMenu(true);
			_menu.labelTitle.Foreground = Brushes.Black;
			_menu.labelTitle.Content = "Game";
		}

		private void Closing(object? sender, CancelEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to exit?", "Game", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
			{
				e.Cancel = true;
			}
			else
			{
				_menu.Closing -= new CancelEventHandler(Closing);
				_game.Closing -= new CancelEventHandler(Closing);
				try
				{
					_menu.Close();
				}
				catch { }
				try
				{
					_game.Close();
				}
				catch { }
			}
		}

		private void SetWindowSize(uint tableSize)
		{
			uint size = tableSize * BLOCK;

			_game.MaxHeight = size + 20;
			_game.MinHeight = size + 20;
			_game.Height = size + 20;

			_game.MaxWidth = size + 20 + 2 * BLOCK;
			_game.MinWidth = size + 20 + 2 * BLOCK;
			_game.Width = size + 20 + 2 * BLOCK;
		}

		private void ShowMenu(bool onOff)
		{
			if (onOff)
			{
				_menu.Show();
				_game.Hide();
			}
			else
			{
				_menu.Hide();
				_game.Show();
			}
		}

		private void ButtonPause_Click(object sender, EventArgs e)
		{
			ShowMenu(true);
			_menu.labelTitle.Content = "Game";
			_menu.labelTitle.Foreground = Brushes.Black;
		}

		private void ButtonResume_Click(object sender, EventArgs e)
		{
			ShowMenu(false);
		}

		private void ScoreAdvanced(object? sender, GameEventArgs e)
		{
			_menu.buttonResume.IsEnabled = false;

			MessageBox.Show($"{e.Who}. player wins with {e.Score} points");

			_menu.buttonResume.IsEnabled = false;
			ShowMenu(true);
		}
	}
}