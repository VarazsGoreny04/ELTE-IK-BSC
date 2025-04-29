namespace Snake_Maui.ViewModel;
public class SnakeField : ViewModelBase
{
	private FieldNames _field;

	public int X { get; set; }
	public int Y { get; set; }

	public FieldNames Field 
	{
		get { return _field; }
		set 
		{
			_field = value;
			OnPropertyChanged(nameof(Field));
		}
	}

	public System.Drawing.Point Point { get => new(X, Y); }

	public SnakeField(int X, int Y, FieldNames Field = FieldNames.Grass)
	{
		this.X = X;
		this.Y = Y;
		this.Field = Field;
	}
}