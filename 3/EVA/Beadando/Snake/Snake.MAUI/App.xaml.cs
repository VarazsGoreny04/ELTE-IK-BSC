using ELTE.Snake.Persistence;
using ELTE.Snake.MAUI.Persistence;
using ELTE.Snake.MAUI.ViewModel;
using ELTE.Snake.Model;

namespace ELTE.Snake.MAUI;

public partial class App : Application
{
    /// <summary>
    /// Erre az útvonalra mentjük a félbehagyott játékokat
    /// </summary>
    private const string SuspendedGameSavePath = "SuspendedGame";

    private readonly AppShell _appShell;
    private readonly ISnakeDataAccess _snakeDataAccess;
    private readonly SnakeGameModel _snakeGameModel;
    private readonly IStore _snakeStore;
    private readonly SnakeViewModel _snakeViewModel;

    public App()
    {
		InitializeComponent();

		_snakeStore = new SnakeStore();
		_snakeDataAccess = new SnakeFileDataAccess(FileSystem.AppDataDirectory);

		_snakeGameModel = new SnakeGameModel(_snakeDataAccess);
		_snakeViewModel = new SnakeViewModel(_snakeGameModel);

		_appShell = new AppShell(_snakeStore, _snakeGameModel, _snakeViewModel)
		{
			BindingContext = _snakeViewModel
		};
		MainPage = _appShell;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		Window window = base.CreateWindow(activationState);

		// amikor az alkalmazás fókuszba kerül
		window.Activated += (s, e) =>
		{
			if (!File.Exists(Path.Combine(FileSystem.AppDataDirectory, SuspendedGameSavePath)))
				return;

			Task.Run(async () =>
			{
				// betöltjük a felfüggesztett játékot, amennyiben van
				try
				{
					await _snakeGameModel.NewGame(SuspendedGameSavePath);

					// csak akkor indul az időzítő, ha sikerült betölteni a játékot
					_appShell.StartTimer();
				}
				catch { }
			});
		};

		// amikor az alkalmazás fókuszt veszt
		window.Deactivated += (s, e) =>
		{
			Task.Run(async () =>
			{
				try
				{
					// elmentjük a jelenleg folyó játékot
					_appShell.StopTimer();
					await _snakeGameModel.SaveGameAsync(SuspendedGameSavePath);
				}
				catch { }
			});
		};

		return window;
	}
}