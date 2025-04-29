using ELTE.Snake.Model;
using System.Collections.ObjectModel;

namespace ELTE.Snake.MAUI.ViewModel;
/// <summary>
/// Tárolt játékkezelő nézetmodellje.
/// </summary>
public class StoredGameBrowserViewModel : ViewModelBase
{
	private readonly StoredGameBrowserModel _model;

	/// <summary>
	/// Betöltés eseménye.
	/// </summary>
	public event EventHandler<StoredGameEventArgs>? GameLoading;

	/// <summary>
	/// Mentés eseménye.
	/// </summary>
	public event EventHandler<StoredGameEventArgs>? GameSaving;

	/// <summary>
	/// Új játék parancsa.
	/// </summary>
	public DelegateCommand NewSaveCommand { get; private set; }

	/// <summary>
	/// Tárolt játékok gyűjteménye.
	/// </summary>
	public ObservableCollection<StoredGameViewModel> StoredGames { get; private set; }

	/// <summary>
	/// Tárolt játékkezelő nézetmodelljének példányosítása.
	/// </summary>
	/// <param name="model">A modell.</param>
	public StoredGameBrowserViewModel(StoredGameBrowserModel model)
	{
		_model = model ?? throw new ArgumentNullException(nameof(model));

		_model.StoreChanged += new EventHandler(Model_StoreChanged);

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
				LoadGameCommand = new DelegateCommand(param => OnGameLoading(param?.ToString() ?? "")),
				SaveGameCommand = new DelegateCommand(param => OnGameSaving(param?.ToString() ?? ""))
			});
		}
	}

	private void Model_StoreChanged(object? sender, EventArgs e)
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