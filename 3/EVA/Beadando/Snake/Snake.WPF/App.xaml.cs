using ELTE.Snake.Model;
using ELTE.Snake.Persistence;
using ELTE.Snake.WPF.ViewModel;
using ELTE.Snake.WPF.View;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Media;
using Microsoft.Win32;

namespace ELTE.Snake.WPF;
public partial class App : Application
{
	private const int BLOCK = 40;

	private SnakeGameModel _model = null!;
	private SnakeViewModel _viewModel = null!;
	private MainWindow _menu = null!;
	private GameWindow _game = null!;
	private DispatcherTimer _timer = null!;

	public App()
	{
		Startup += new StartupEventHandler(AppStartup);
	}

	public void AppStartup(object? sender, StartupEventArgs e)
	{
		_model = new SnakeGameModel(new SnakeFileDataAccess());
		_model.Moving += new EventHandler<SnakeFieldEventArgs>(Moving);
		_model.EndGame += new EventHandler<SnakeEventArgs>(ScoreAdvanced);

		_viewModel = new SnakeViewModel(_model);
		_viewModel.NewGame += new EventHandler(NewGame);
		_viewModel.Resume += new EventHandler(Resume);
		_viewModel.Pause += new EventHandler(Pause);

		_menu = new MainWindow { DataContext = _viewModel };
		_menu.Closing += new CancelEventHandler(Closing);
		_menu.Show();

		_game = new GameWindow { DataContext = _viewModel };
		_game.Closing += new CancelEventHandler(Closing);
		_game.KeyDown += InputConverter;


		_timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.4d) };
		_timer.Tick += new EventHandler(OneStep);
	}

	private async void NewGame(object? sender, EventArgs e)
	{
		uint tableSize = (uint)Math.Round(_menu.sliderTableSize.Value);

		_viewModel.InitializeGame(tableSize);

		try
		{
			OpenFileDialog openFileDialog = new()
			{
				Title = "Load Snake table",
				Filter = "Snake table|*.txt"
			};
			if (openFileDialog.ShowDialog() is true)
				await _model.NewGame(tableSize, openFileDialog.FileName);
			else
				throw new FieldAccessException("You must select a file!");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}

		ShowMenu(false);
		_menu.buttonResume.IsEnabled = true;

		SetWindowSize(tableSize);
		_viewModel.GamePhase = GamePhase.Hold;
	}

	private void Resume(object? sender, EventArgs e)
	{
		ShowMenu(false);

		_viewModel.GamePhase = GamePhase.Start;
		_timer.Start();
	}

	private void Pause(object? sender, EventArgs e)
	{
		_timer.Stop();
		_viewModel.GamePhase = GamePhase.Pause;

		ShowMenu(true);
		_menu.labelTitle.Foreground = Brushes.Black;
		_menu.labelTitle.Content = "Snake";
	}

	private void Closing(object? sender, CancelEventArgs e)
	{
		bool restartTimer = _timer.IsEnabled;

		_timer.Stop();

		if (MessageBox.Show("Are you sure you want to exit?", "Snake", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
		{
			e.Cancel = true;

			if (restartTimer)
				_timer.Start();
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

		_game.MaxHeight = size + 60;
		_game.MinHeight = size + 60;

		_game.MaxWidth = size + 20;
		_game.MinWidth = size + 20;

		_game.Height = size + 60;
		_game.Width = size + 20;
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

	private void OneStep(object? sender, EventArgs e)
	{
		_model.Step();
	}

	private void InputConverter(object sender, KeyEventArgs e)
	{
		if (_viewModel.GamePhase == GamePhase.Hold)
		{
			_viewModel.GamePhase = GamePhase.Start;
			_timer.Start();
		}
		if (_viewModel.GamePhase == GamePhase.Start)
		{
			Dir dir;
			switch (e.Key)
			{
				case Key.W:
					dir = Dir.Up; break;
				case Key.S:
					dir = Dir.Down; break;
				case Key.A:
					dir = Dir.Left; break;
				case Key.D:
					dir = Dir.Right; break;
				default:
					return;
			}
			_model.SetDirection(dir);
		}
	}

	private void Moving(object? sender, SnakeFieldEventArgs e)
	{
		_viewModel.FieldChanged(sender, e);
	}

	private void ScoreAdvanced(object? sender, SnakeEventArgs e)
	{
		_viewModel.ScoreAdvanced(e);

		if (e.EmptyField)
			return;

		_timer.Stop();

		if (e.IsWon)
		{
			_menu.labelTitle.Foreground = Brushes.LawnGreen;
			_menu.labelTitle.Content = "You won :)";
		}
		else
		{
			_menu.labelTitle.Foreground = Brushes.Red;
			_menu.labelTitle.Content = "You lost :(";
		}

		_menu.buttonResume.IsEnabled = false;
		ShowMenu(true);
	}
}