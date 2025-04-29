using EVA.Game.Persistence;
using EVA.Game.Model;
using EVA.Game.MAUI.Persistence;
using EVA.Game.MAUI.ViewModel;

namespace EVA.Game.MAUI;
public partial class App : Application
{
	private const string SuspendedGameSavePath = "SuspendedGame";

	private readonly AppShell _appShell;
	private readonly IGameDataAccess _GameDataAccess;
	private readonly GameGameModel _GameGameModel;
	private readonly IStore _GameStore;
	private readonly GameViewModel _GameViewModel;

	public App()
	{
		InitializeComponent();

		_GameStore = new GameStore();
		_GameDataAccess = new GameFileDataAccess(FileSystem.AppDataDirectory);

		_GameGameModel = new GameGameModel(_GameDataAccess);
		_GameViewModel = new GameViewModel(_GameGameModel);

		_appShell = new AppShell(_GameStore, _GameGameModel, _GameViewModel)
		{
			BindingContext = _GameViewModel
		};
		MainPage = _appShell;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		Window window = base.CreateWindow(activationState);

		window.Created += (s, e) =>
		{
			_GameGameModel.NewGame();
			_appShell.StartTimer();
		};

		window.Activated += (s, e) =>
		{
			if (!File.Exists(Path.Combine(FileSystem.AppDataDirectory, SuspendedGameSavePath)))
				return;

			Task.Run(async () =>
			{
				try
				{
					await _GameGameModel.LoadGameAsync(SuspendedGameSavePath);
					_appShell.StartTimer();
				}
				catch { }
			});
		};

		window.Deactivated += (s, e) =>
		{
			Task.Run(async () =>
			{
				try
				{
					_appShell.StopTimer();
					await _GameGameModel.SaveGameAsync(SuspendedGameSavePath);
				}
				catch { }
			});
		};

		return window;
	}
}