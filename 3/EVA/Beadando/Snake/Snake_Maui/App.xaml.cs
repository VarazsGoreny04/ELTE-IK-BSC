using ELTE.Snake.Persistence;
using ELTE.Snake.Model;
using Snake_Maui.ViewModel;

namespace Snake_Maui;
public partial class App : Application
{
	private const string SUSPENDEDGAMESAVEPATH = "SuspendedGame";

	private readonly AppShell _appShell;
	private readonly ISnakeDataAccess _snakeDataAccess;
	private readonly SnakeGameModel _snakeGameModel;
	private readonly SnakeViewModel _snakeViewModel;

	public App()
	{
		InitializeComponent();

		_snakeDataAccess = new SnakeFileDataAccess(FileSystem.AppDataDirectory);

		_snakeGameModel = new SnakeGameModel(_snakeDataAccess);
		_snakeViewModel = new SnakeViewModel(_snakeGameModel);

		_appShell = new AppShell(_snakeGameModel, _snakeViewModel)
		{
			BindingContext = _snakeViewModel
		};
		MainPage = _appShell;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		Window window = base.CreateWindow(activationState);


		window.Activated += (s, e) =>
		{
			if (!File.Exists(Path.Combine(FileSystem.AppDataDirectory, SUSPENDEDGAMESAVEPATH)))
				return;

			Task.Run(async () =>
			{
				try
				{
					await _snakeGameModel.NewGame(SUSPENDEDGAMESAVEPATH);
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
					await _snakeGameModel.SaveGameAsync(SUSPENDEDGAMESAVEPATH);
				}
				catch { }
			});
		};

		window.Destroying += (s, e) =>
		{
			Task.Run(async () =>
			{
				await _snakeGameModel.SaveGameAsync(SUSPENDEDGAMESAVEPATH);
			});
		};

		return window;
	}
}