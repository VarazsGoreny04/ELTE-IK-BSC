using HOK.Gomb.Model;
using HOK.Gomb.Persistence;
using HOK.Gomb.MAUI.ViewModel;
using HOK.Gomb.MAUI.View;

namespace HOK.Gomb.MAUI;
public partial class AppShell : Shell
{
	#region Fields

	private readonly GombGameModel _GombGameModel;
	private readonly GombViewModel _GombViewModel;

	private readonly IStore _store;
	private readonly StoredGameBrowserModel _storedGameBrowserModel;
	private readonly StoredGameBrowserViewModel _storedGameBrowserViewModel;

	#endregion

	#region Application methods

	public AppShell(IStore GombStore, GombGameModel GombGameModel, GombViewModel GombViewModel)
	{
		InitializeComponent();

		_store = GombStore;
		_GombGameModel = GombGameModel;
		_GombViewModel = GombViewModel;

		_GombGameModel.Handler += Switch;

		_GombViewModel.SaveGame += SaveGame;
		_GombViewModel.LoadGame += LoadGame;

		_storedGameBrowserModel = new StoredGameBrowserModel(_store);
		_storedGameBrowserViewModel = new StoredGameBrowserViewModel(_storedGameBrowserModel);
		_storedGameBrowserViewModel.GameSaving += GameSaving;
		_storedGameBrowserViewModel.GameLoading += GameLoading;
	}

	#endregion

	#region ViewModel event handlers

	private async void GameLoading(object? sender, StoredGameEventArgs e)
	{
		await Navigation.PopAsync();

		try
		{
			await _GombGameModel.LoadGameAsync(e.Name);
			await DisplayAlert("Gomb", "The game has been loaded successfully.", "OK");
		}
		catch
		{
			await DisplayAlert("Gomb", "A problem occurred during the loading.", "OK");
		}
	}

	private async void GameSaving(object? sender, StoredGameEventArgs e)
	{
		await Navigation.PopAsync();

		try
		{
			await _GombGameModel.SaveGameAsync(e.Name);
			await DisplayAlert("Gomb", "The game has been saved successfully.", "OK");
		}
		catch
		{
			await DisplayAlert("Gomb", "A problem occurred during the saving.", "OK");
		}
	}

	private void Switch(object? sender, GombEventArgs e)
	{
		_GombViewModel.Light1Field.OnOff = e.One;

		_GombViewModel.Light2Field.OnOff = e.Two;
	}

	private async void SaveGame(object? sender, EventArgs e)
	{
		await _storedGameBrowserModel.UpdateAsync();
		await Navigation.PushAsync(new SavePage
		{
			BindingContext = _storedGameBrowserViewModel
		});
	}

	private async void LoadGame(object? sender, EventArgs e)
	{
		await _storedGameBrowserModel.UpdateAsync();
		await Navigation.PushAsync(new LoadPage
		{
			BindingContext = _storedGameBrowserViewModel
		});
	}

	#endregion
}