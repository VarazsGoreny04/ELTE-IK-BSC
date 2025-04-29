using EVA.Game.Persistence;
using EVA.Game.Model;
using EVA.Game.MAUI.ViewModel;
using EVA.Game.MAUI.View;

namespace EVA.Game.MAUI;
public partial class AppShell : Shell
{
	#region Fields

	private readonly GameGameModel _GameGameModel;
	private readonly GameViewModel _GameViewModel;

	private readonly IDispatcherTimer _timer;

	private readonly IStore _store;
	private readonly StoredGameBrowserModel _storedGameBrowserModel;
	private readonly StoredGameBrowserViewModel _storedGameBrowserViewModel;

	#endregion

	#region Application methods

	public AppShell(IStore GameStore,
		GameGameModel GameGameModel,
		GameViewModel GameViewModel)
	{
		InitializeComponent();

		_store = GameStore;
		_GameGameModel = GameGameModel;
		_GameViewModel = GameViewModel;

		_timer = Dispatcher.CreateTimer();
		_timer.Interval = TimeSpan.FromSeconds(1);
		_timer.Tick += (_, _) => _GameGameModel.AdvanceTime();

		_GameGameModel.GameOver += GameGameModel_GameOver;

		_GameViewModel.NewGame += GameViewModel_NewGame;
		_GameViewModel.LoadGame += GameViewModel_LoadGame;
		_GameViewModel.SaveGame += GameViewModel_SaveGame;
		_GameViewModel.ExitGame += GameViewModel_ExitGame;

		_storedGameBrowserModel = new StoredGameBrowserModel(_store);
		_storedGameBrowserViewModel = new StoredGameBrowserViewModel(_storedGameBrowserModel);
		_storedGameBrowserViewModel.GameLoading += StoredGameBrowserViewModel_GameLoading;
		_storedGameBrowserViewModel.GameSaving += StoredGameBrowserViewModel_GameSaving;
	}

	#endregion

	#region Internal methods

	internal void StartTimer() => _timer.Start();

	internal void StopTimer() => _timer.Stop();

	#endregion

	#region Model event handlers

	private async void GameGameModel_GameOver(object? sender, GameEventArgs e)
	{
		StopTimer();

		if (e.IsWon)
		{
			await DisplayAlert("Game játék",
				"Gratulálok, győztél!" + Environment.NewLine +
				"Összesen " + e.GameStepCount + " lépést tettél meg és " +
				TimeSpan.FromSeconds(e.GameTime).ToString("g") + " ideig játszottál.",
				"OK");
		}
		else
		{
			await DisplayAlert("Game játék", "Sajnálom, vesztettél, lejárt az idő!", "OK");
		}
	}

	#endregion

	#region ViewModel event handlers

	private void GameViewModel_NewGame(object? sender, EventArgs e)
	{
		_GameGameModel.NewGame();

		StartTimer();
	}

	private async void GameViewModel_LoadGame(object? sender, EventArgs e)
	{
		await _storedGameBrowserModel.UpdateAsync();
		await Navigation.PushAsync(new LoadGamePage
		{
			BindingContext = _storedGameBrowserViewModel
		});
	}

	private async void GameViewModel_SaveGame(object? sender, EventArgs e)
	{
		await _storedGameBrowserModel.UpdateAsync();
		await Navigation.PushAsync(new SaveGamePage
		{
			BindingContext = _storedGameBrowserViewModel
		});
	}

	private async void GameViewModel_ExitGame(object? sender, EventArgs e)
	{
		await Navigation.PushAsync(new SettingsPage
		{
			BindingContext = _GameViewModel
		});
	}

	private async void StoredGameBrowserViewModel_GameLoading(object? sender, StoredGameEventArgs e)
	{
		await Navigation.PopAsync();

		try
		{
			await _GameGameModel.LoadGameAsync(e.Name);

			await Navigation.PopAsync();
			await DisplayAlert("Game játék", "Sikeres betöltés.", "OK");

			StartTimer();
		}
		catch
		{
			await DisplayAlert("Game játék", "Sikertelen betöltés.", "OK");
		}
	}

	private async void StoredGameBrowserViewModel_GameSaving(object? sender, StoredGameEventArgs e)
	{
		await Navigation.PopAsync();
		StopTimer();

		try
		{
			await _GameGameModel.SaveGameAsync(e.Name);
			await DisplayAlert("Game játék", "Sikeres mentés.", "OK");
		}
		catch
		{
			await DisplayAlert("Game játék", "Sikertelen mentés.", "OK");
		}
	}

	#endregion
}