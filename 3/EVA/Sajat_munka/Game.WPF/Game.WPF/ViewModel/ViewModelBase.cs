using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Game.WPF.ViewModel
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		protected ViewModelBase() { }

		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}