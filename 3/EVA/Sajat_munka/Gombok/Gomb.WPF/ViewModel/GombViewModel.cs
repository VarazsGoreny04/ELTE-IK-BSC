using HOK.Gomb.Model;

namespace HOK.Gomb.WPF.ViewModel;
public class GombViewModel : ViewModelBase
{
	private readonly GombGameModel _model;

	public EventHandler? SaveGame;
	public EventHandler? LoadGame;

	public DelegateCommand SwitchLight1 { get; private set; }
	public DelegateCommand SwitchLight2 { get; private set; }
	public DelegateCommand SaveCommand { get; private set; }
	public DelegateCommand LoadCommand { get; private set; }

	public GombField Light1Field { get; private set; }
	public GombField Light2Field { get; private set; }


	public GombViewModel(GombGameModel model)
	{
		_model = model;

		SwitchLight1 = new DelegateCommand(param => OnLight1Changed());
		SwitchLight2 = new DelegateCommand(param => OnLight12Changed());
		SaveCommand = new DelegateCommand(param => OnSaveGame());
		LoadCommand = new DelegateCommand(param => OnLoadGame());

		Light1Field = new GombField();
		Light2Field = new GombField();
	}

	private void OnLight1Changed()
	{
		_model.Button1();
	}

	private void OnLight12Changed()
	{
		_model.Button12();
	}

	private void OnSaveGame()
	{
		SaveGame?.Invoke(this, EventArgs.Empty);
	}

	private void OnLoadGame()
	{
		LoadGame?.Invoke(this, EventArgs.Empty);
	}
}