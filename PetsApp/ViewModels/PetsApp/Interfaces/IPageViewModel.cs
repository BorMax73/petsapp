using PetsApp.Persistance;

namespace PetsApp.Interfaces;

public interface IPageViewModel
{
	string Name { get; }
	void Update();
	
	
	void SetContext(DataContext context);
}