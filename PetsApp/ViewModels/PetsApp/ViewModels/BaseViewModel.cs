using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PetsApp.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
	protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
	{
		if (object.Equals(storage, value)) return false;
		storage = value;
		this.OnPropertyChanged(propertyName);
		return true;
	}
	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		var eventHandler = this.PropertyChanged;
		if (eventHandler != null)
			eventHandler(this, new PropertyChangedEventArgs(propertyName));
	}
}