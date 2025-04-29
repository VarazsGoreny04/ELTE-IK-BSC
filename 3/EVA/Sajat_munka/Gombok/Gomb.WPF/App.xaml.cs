using HOK.Gomb.Model;
using HOK.Gomb.Persistence;
using HOK.Gomb.WPF.ViewModel;
using Microsoft.Win32;
using System.Windows;

namespace HOK.Gomb.WPF;
public partial class App : Application
{
	private GombGameModel _model = null!;
	private GombViewModel _viewModel = null!;
	private MainWindow _menu = null!;

	public App()
	{
		Startup += new StartupEventHandler(AppStartup);
	}

	private void AppStartup(object sender, StartupEventArgs e)
	{
		_model = new GombGameModel(new GombFileDataAccess());
		_model.Handler += new EventHandler<GombEventArgs>(Switch);

		_viewModel = new GombViewModel(_model);
		_viewModel.SaveGame += new EventHandler(SaveGame);
		_viewModel.LoadGame += new EventHandler(LoadGame);

		_menu = new MainWindow { DataContext = _viewModel };
		_menu.Show();
	}

	private void Switch(object? sender, GombEventArgs e)
	{
		_viewModel.Light1Field.OnOff = e.One;

		_viewModel.Light2Field.OnOff = e.Two;
	}

	private async void SaveGame(object? sender, EventArgs e)
	{
		try
		{
			SaveFileDialog saveFileDialog = new()
			{
				Title = "Saving Gomb table",
				Filter = "Gomb table|*.txt"
			};

			if (saveFileDialog.ShowDialog() == true)
				await _model.SaveGameAsync(saveFileDialog.FileName);
		}
		catch
		{
			MessageBox.Show("Save failed!\nWrong path, or the library is not writable.", "Gomb", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}

	private async void LoadGame(object? sender, EventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new()
			{
				Title = "Loading Gomb table",
				Filter = "Gomb table|*.txt"
			};

			if (openFileDialog.ShowDialog() == true)
				await _model.LoadGameAsync(openFileDialog.FileName);
		}
		catch
		{
			MessageBox.Show("Load failed!\nWrong path, or the library is not readable.", "Gomb", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
}