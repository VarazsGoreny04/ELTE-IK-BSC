namespace HOK.Gomb.MAUI.ViewModel;
public class GombField : ViewModelBase
{
	private bool _onOff;

	public bool OnOff
	{
		get { return _onOff; }
		set
		{
			_onOff = value;
			OnPropertyChanged(nameof(OnOff));
		}
	}

	public GombField()
	{
		_onOff = false;
	}
}