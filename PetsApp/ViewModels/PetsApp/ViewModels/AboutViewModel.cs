using PetsApp.Interfaces;
using PetsApp.Persistance;

namespace PetsApp.ViewModels;

public class AboutViewModel : BaseViewModel, IPageViewModel
{
	public string Name { get; } = "Про нас";
	public void Update()
	{
		
	}

	public void SetContext(DataContext context)
	{
		
	}
}