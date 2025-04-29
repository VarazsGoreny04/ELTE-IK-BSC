using System.Drawing;

namespace Game.WPF.ViewModel
{
	public class GameField : ViewModelBase
	{
		private Team _color;

		public int X { get; set; }
		public int Y { get; set; }

		public Team Color
		{
			get { return _color; }
			set 
			{
				_color = value;
				OnPropertyChanged(nameof(Color));
			}
		}

		public Point Point { get { return new(X, Y); } }

		public DelegateCommand? StepCommand { get; set; }

		public GameField(int X, int Y, Team color = Team.None)
		{
			this.X = X;
			this.Y = Y;
			Color = color;
		}
	}
}