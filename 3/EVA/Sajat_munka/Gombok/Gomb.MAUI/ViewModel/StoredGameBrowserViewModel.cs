using HOK.Gomb.Model;
using System.Collections.ObjectModel;

namespace HOK.Gomb.MAUI.ViewModel;
public class StoredGameBrowserViewModel : ViewModelBase
{
	private readonly StoredGameBrowserModel _model;

	public event EventHandler<StoredGameEventArgs>? GameLoading;
	public event EventHandler<StoredGameEventArgs>? GameSaving;

	public DelegateCommand NewSaveCommand { get; private set; }

	public ObservableCollection<StoredGameViewModel> StoredGames { get; private set; }

	public StoredGameBrowserViewModel(StoredGameBrowserModel model)
	{
		_model = model ?? throw new ArgumentNullException(nameof(model));

		_model.StoreChanged += new EventHandler(StoreChanged);

		NewSaveCommand = new DelegateCommand(param =>
		{
			string? fileName = Path.GetFileNameWithoutExtension(param?.ToString()?.Trim());
			if (!string.IsNullOrEmpty(fileName))
			{
				fileName += ".txt";
				OnGameSaving(fileName);
			}
		});
		StoredGames = new ObservableCollection<StoredGameViewModel>();

		UpdateStoredGames();
	}

	private void UpdateStoredGames()
	{
		StoredGames.Clear();

		foreach (StoredGameModel item in _model.StoredGames)
		{
			StoredGames.Add(new StoredGameViewModel
			{
				Name = item.Name,
				Modified = item.Modified,
				LoadGameCommand = new DelegateCommand(param => OnGameLoading(param?.ToString() ?? "")),
				SaveGameCommand = new DelegateCommand(param => OnGameSaving(param?.ToString() ?? ""))
			});
		}
	}

	private void StoreChanged(object? sender, EventArgs e)
	{
		UpdateStoredGames();
	}

	private void OnGameLoading(string name)
	{
		GameLoading?.Invoke(this, new StoredGameEventArgs { Name = name });
	}

	private void OnGameSaving(string name)
	{
		GameSaving?.Invoke(this, new StoredGameEventArgs { Name = name });
	}
}