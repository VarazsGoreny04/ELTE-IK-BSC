using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EVA.Game.MAUI.ViewModel;
public abstract class ViewModelBase : INotifyPropertyChanged
{
	protected ViewModelBase() { }

	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}