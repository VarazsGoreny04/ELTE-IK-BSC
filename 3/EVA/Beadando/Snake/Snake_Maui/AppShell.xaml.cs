using ELTE.Snake.Model;
using Snake_Maui.ViewModel;

namespace Snake_Maui;

public partial class AppShell : Shell
{
	#region Fields

	private readonly SnakeGameModel _snakeGameModel;
	private readonly SnakeViewModel _snakeViewModel;

	private readonly IDispatcherTimer _timer;

	#endregion

	#region Application methods

	public AppShell(SnakeGameModel snakeGameModel, SnakeViewModel snakeViewModel)
	{
		InitializeComponent();
		_snakeGameModel = snakeGameModel;
		_snakeViewModel = snakeViewModel;

		_timer = Dispatcher.CreateTimer();
		_timer.Interval = TimeSpan.FromSeconds(0.4);
		_timer.Tick += (_, _) => _snakeGameModel.Step();

		_snakeViewModel.NewGame += NewGame;
		_snakeViewModel.Resume += Resume;
		_snakeViewModel.Pause += Pause;
		_snakeViewModel.Dir += Dir;
		_snakeGameModel.EndGame += GameOver;
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

		StopTimer();

		if (e.IsWon)
			_snakeViewModel.Title = "You won :)";
		else
			_snakeViewModel.Title = "You lost :(";

		_snakeViewModel.IsGameLoaded = false;

		await Navigation.PopAsync();
	}

	#endregion

	#region ViewModel event handlers

	private async void NewGame(object? sender, SnakeUIntEventArgs e)
	{
		try
		{
			FileResult? result = await FilePicker.Default.PickAsync();

			if (result is null || !result.FileName.EndsWith("txt", StringComparison.OrdinalIgnoreCase))
				throw new FieldAccessException();
			
			await _snakeGameModel.NewGame(e.Num, result.FullPath);

			await Navigation.PushAsync(new GamePage { BindingContext = _snakeViewModel });

			_snakeViewModel.GamePhase = GamePhase.Hold;
		}
		catch { }
	}

	private void Dir(object? sender, SnakeUIntEventArgs e)
	{
		if (_snakeViewModel.GamePhase == GamePhase.Hold)
		{
			_snakeViewModel.GamePhase = GamePhase.Start;
			_timer.Start();
		}
		if (_snakeViewModel.GamePhase == GamePhase.Start)
		{
			_snakeGameModel.SetDirection((Dir)e.Num);
		}
	}

	public async void Resume(object? sender, EventArgs e)
	{
		await Navigation.PushAsync(new GamePage { BindingContext = _snakeViewModel });
		_snakeViewModel.GamePhase = GamePhase.Start;
		StartTimer();
	}

	public async void Pause(object? sender, EventArgs e)
	{
		StopTimer();
		_snakeViewModel.GamePhase = GamePhase.Pause;
		_snakeViewModel.Title = "Snake";
		await Navigation.PopAsync();
	}

	#endregion
}