using HOK.Gomb.Persistence;
using HOK.Gomb.Model;
using HOK.Gomb.MAUI.Persistence;
using HOK.Gomb.MAUI.ViewModel;

namespace HOK.Gomb.MAUI;
public partial class App : Application
{
	private const string SUSPENDEDGAMESAVEPATH = "SuspendedGame";

	private readonly AppShell _appShell;
	private readonly IGombDataAccess _GombDataAccess;
	private readonly GombGameModel _GombGameModel;
	private readonly IStore _GombStore;
	private readonly GombViewModel _GombViewModel;

	public App()
	{
		InitializeComponent();

		_GombStore = new GombStore();
		_GombDataAccess = new GombFileDataAccess(FileSystem.AppDataDirectory);

		_GombGameModel = new GombGameModel(_GombDataAccess);
		_GombViewModel = new GombViewModel(_GombGameModel);

		_appShell = new AppShell(_GombStore, _GombGameModel, _GombViewModel)
		{
			BindingContext = _GombViewModel
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
					await _GombGameModel.LoadGameAsync(SUSPENDEDGAMESAVEPATH);
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
					await _GombGameModel.SaveGameAsync(SUSPENDEDGAMESAVEPATH);
				}
				catch { }
			});
		};

		window.Destroying += (s, e) =>
		{
			Task.Run(async () =>
			{
				await _GombGameModel.SaveGameAsync(SUSPENDEDGAMESAVEPATH);
			});
		};

		return window;
	}
}