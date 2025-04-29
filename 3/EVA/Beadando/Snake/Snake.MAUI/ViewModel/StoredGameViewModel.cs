namespace ELTE.Snake.MAUI.ViewModel;
public class StoredGameViewModel : ViewModelBase
{
	private string _name = string.Empty;
	private DateTime _modified;

	public string Name
	{
		get { return _name; }
		set
		{
			if (_name != value)
			{
				_name = value;
				OnPropertyChanged();
			}
		}
	}

	/// <summary>
	/// Módosítás idejének lekérdezése.
	/// </summary>
	public DateTime Modified
	{
		get { return _modified; }
		set
		{
			if (_modified != value)
			{
				_modified = value;
				OnPropertyChanged();
			}
		}
	}

	public DelegateCommand? LoadGameCommand { get; set; }
	public DelegateCommand? SaveGameCommand { get; set; }
}