using ELTE.Snake.MAUI.ViewModel;
using ELTE.Snake.Model;
using ELTE.Snake.Persistence;

namespace ELTE.Snake.MAUI;

public partial class AppShell : Shell
{
	#region Fields

	private readonly SnakeGameModel _snakeGameModel;
	private readonly SnakeViewModel _snakeViewModel;

	private readonly IDispatcherTimer _timer;

	private readonly IStore _store;
	private readonly StoredGameBrowserModel _storedGameBrowserModel;
	private readonly StoredGameBrowserViewModel _storedGameBrowserViewModel;

	#endregion

	#region Application methods

	public AppShell(IStore snakeStore, SnakeGameModel snakeGameModel, SnakeViewModel snakeViewModel)
	{
		InitializeComponent();

		_store = snakeStore;
		_snakeGameModel = snakeGameModel;
		_snakeViewModel = snakeViewModel;

		_timer = Dispatcher.CreateTimer();
		_timer.Interval = TimeSpan.FromSeconds(0.4);
		_timer.Tick += (_, _) => _snakeGameModel.Step();

		_snakeViewModel.NewGame += NewGame;
		_snakeViewModel.Resume += Resume;
		_snakeViewModel.Pause += Pause;
		_snakeGameModel.EndGame += GameOver;

		// a játékmentések kezelésének összeállítása
		_storedGameBrowserModel = new StoredGameBrowserModel(_store);
		_storedGameBrowserViewModel = new StoredGameBrowserViewModel(_storedGameBrowserModel);
		_storedGameBrowserViewModel.GameLoading += StoredGameBrowserViewModel_GameLoading;
	}

	#endregion

	#region Internal methods

	internal void StartTimer() => _timer.Start();
	internal void StopTimer() => _timer.Stop();

	#endregion

	#region Model event handlers

	private async void GameOver(object? sender, SnakeEventArgs e)
	{
		_snakeViewModel.ScoreAdvanced(e);

		if (e.EmptyField)
			return;

		_timer.Stop();

		if (e.IsWon)
			_snakeViewModel.Title = "You won :)";
		else
			_snakeViewModel.Title = "You lost :(";

		_snakeViewModel.IsGameLoaded = false;

		await Navigation.PopAsync();
	}

	#endregion

	#region ViewModel event handlers

	private async void NewGame(object? sender, EventArgs e)
	{
		try
		{
			FileResult? result = await FilePicker.Default.PickAsync();

			if (result is null || !result.FileName.EndsWith("txt", StringComparison.OrdinalIgnoreCase))
				throw new FieldAccessException();
			else
				await _snakeGameModel.NewGame(result.FullPath);
		}
		catch { }
	}

	private void Resume(object? sender, EventArgs e)
	{
		StartTimer();
	}

	private void Pause(object? sender, EventArgs e)
	{
		StopTimer();
	}

	private async void StoredGameBrowserViewModel_GameLoading(object? sender, StoredGameEventArgs e)
	{
		await Navigation.PopAsync();

		try
		{
			await _snakeGameModel.NewGame(e.Name);

			await Navigation.PopAsync();
			await DisplayAlert("Snake", "The game has been loaded successfully.", "OK");

			StartTimer();
		}
		catch
		{
			await DisplayAlert("Snake", "A problem occurred during the loading.", "OK");
		}
	}

	#endregion
}