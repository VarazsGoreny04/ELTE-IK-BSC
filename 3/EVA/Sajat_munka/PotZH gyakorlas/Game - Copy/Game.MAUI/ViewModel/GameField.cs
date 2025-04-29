namespace EVA.Game.MAUI.ViewModel;
public class GameField : ViewModelBase
{
    private bool _alive;

    public bool Alive
    {
        get { return _alive; }
        set
        {
            if (_alive != value)
            {
                _alive = value;
                OnPropertyChanged();
            }
        }
    }

    public int X { get; set; }
    public int Y { get; set; }
    public System.Drawing.Point XY { get => new(X, Y); }

    public DelegateCommand? StepCommand { get; set; }
}