namespace EVA.Game.WPF.ViewModel;
public class GameField : ViewModelBase
{
	private bool _isLocked;
	private string _text = string.Empty;

	public bool IsLocked
	{
		get { return _isLocked; }
		set
		{
			if (_isLocked != value)
			{
				_isLocked = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(IsEnabled));
			}
		}
	}

	public bool IsEnabled
	{
		get { return !IsLocked; }
	}

	public string Text
	{
		get { return _text; }
		set
		{
			if (_text != value)
			{
				_text = value;
				OnPropertyChanged();
			}
		}
	}

	public int X { get; set; }
	public int Y { get; set; }
	public System.Drawing.Point XY { get => new(X, Y); }

	public DelegateCommand? StepCommand { get; set; }
}