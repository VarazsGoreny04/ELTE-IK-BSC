using EVA.Game.Persistence;
using EVA.Game.Model;
using EVA.Game.WPF.ViewModel;
using EVA.Game.WPF.View;
using Microsoft.Win32;
using System.ComponentModel;
using System;
using System.Windows;
using System.Windows.Threading;

namespace EVA.Game.WPF;
public partial class App : Application
{
	#region Fields

	private GameGameModel _model = null!;
	private GameViewModel _viewModel = null!;
	private MainWindow _view = null!;
	private DispatcherTimer _timer = null!;

	#endregion

	#region Constructors

	public App()
	{
		Startup += new StartupEventHandler(App_Startup);
	}

	#endregion

	#region Application event handlers

	private void App_Startup(object? sender, StartupEventArgs e)
	{
		_model = new GameGameModel(new GameFileDataAccess());
		_model.GameOver += new EventHandler<GameEventArgs>(Model_GameOver);
		_model.NewGame();

		_viewModel = new GameViewModel(_model);
		_viewModel.NewGame += new EventHandler(ViewModel_NewGame);
		_viewModel.ExitGame += new EventHandler(ViewModel_ExitGame);
		_viewModel.LoadGame += new EventHandler(ViewModel_LoadGame);
		_viewModel.SaveGame += new EventHandler(ViewModel_SaveGame);

		_view = new MainWindow { DataContext = _viewModel };
		_view.Closing += new CancelEventHandler(View_Closing);
		_view.Show();

		_timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
		_timer.Tick += new EventHandler(Timer_Tick);
		_timer.Start();
	}

	private void Timer_Tick(object? sender, EventArgs e)
	{
		_model.AdvanceTime();
	}

	#endregion

	#region View event handlers

	private void View_Closing(object? sender, CancelEventArgs e)
	{
		bool restartTimer = _timer.IsEnabled;

		_timer.Stop();

		if (MessageBox.Show("Biztos, hogy ki akar lépni?", "Game", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
		{
			e.Cancel = true;

			if (restartTimer)
				_timer.Start();
		}
	}

	#endregion

	#region ViewModel event handlers

	private void ViewModel_NewGame(object? sender, EventArgs e)
	{
		_model.NewGame();
		_timer.Start();
	}

	private async void ViewModel_LoadGame(object? sender, System.EventArgs e)
	{
		bool restartTimer = _timer.IsEnabled;

		_timer.Stop();

		try
		{
			OpenFileDialog openFileDialog = new()
			{
				Title = "Game tábla betöltése",
				Filter = "Game tábla|*.stl"
			};
			if (openFileDialog.ShowDialog() == true)
			{
				await _model.LoadGameAsync(openFileDialog.FileName);

				_timer.Start();
			}
		}
		catch (GameDataException)
		{
			MessageBox.Show("A fájl betöltése sikertelen!", "Game", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		if (restartTimer)
			_timer.Start();
	}

	private async void ViewModel_SaveGame(object? sender, EventArgs e)
	{
		bool restartTimer = _timer.IsEnabled;

		_timer.Stop();

		try
		{
			SaveFileDialog saveFileDialog = new()
			{
				Title = "Game tábla betöltése",
				Filter = "Game tábla|*.stl"
			};
			if (saveFileDialog.ShowDialog() == true)
			{
				try
				{
					await _model.SaveGameAsync(saveFileDialog.FileName);
				}
				catch (GameDataException)
				{
					MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}
		catch
		{
			MessageBox.Show("A fájl mentése sikertelen!", "Game", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		if (restartTimer)
			_timer.Start();
	}

	private void ViewModel_ExitGame(object? sender, System.EventArgs e)
	{
		_view.Close();
	}

	#endregion

	#region Model event handlers

	private void Model_GameOver(object? sender, GameEventArgs e)
	{
		_timer.Stop();

		if (e.IsWon) // győzelemtől függő üzenet megjelenítése
		{
			MessageBox.Show("Gratulálok, győztél!" + Environment.NewLine +
							"Összesen " + e.GameStepCount + " lépést tettél meg és " +
							TimeSpan.FromSeconds(e.GameTime).ToString("g") + " ideig játszottál.",
							"Game játék",
							MessageBoxButton.OK,
							MessageBoxImage.Asterisk);
		}
		else
		{
			MessageBox.Show("Sajnálom, vesztettél, lejárt az idő!",
							"Game játék",
							MessageBoxButton.OK,
							MessageBoxImage.Asterisk);
		}
	}

	#endregion
}