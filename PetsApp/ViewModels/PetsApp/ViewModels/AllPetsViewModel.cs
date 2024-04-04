using PetsApp.Domain;
using PetsApp.Helpers;
using PetsApp.Interfaces;
using PetsApp.Persistance.Repositories;
using PetsApp.Persistance;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PetsApp.ViewModels;

public class AllPetsViewModel : BaseViewModel, IPageViewModel
{
	public string Name { get; } = "Усі";
	private DataContext _dataContex { get; set; }
	private IPetRepository _petRepository { get; set; }
	public ObservableCollection<Pet> Pets { get; set; }
	private PageSelectorViewModel _pageSelector { get; set; }
	private ICommand _getByIdCommand;
	public AllPetsViewModel(PageSelectorViewModel pageSelector)
	{
		_pageSelector = pageSelector;
		Pets = new ObservableCollection<Pet>();
	}

	public ICommand GetByIdCommand
	{
		get
		{
			return new RelayCommand(p => GetById((int)p));
		}
	}
	private void GetById(int id)
	{
		var pet = _petRepository.GetById(id);
		//_pageSelector.ChangePageCommand.Execute(new PetViewModel(1));
		_pageSelector.GetSinglePet(id);
	}

	public void Update()
	{
		Pets.Clear();
		var pets = _petRepository.GetAll();
		Pets = new ObservableCollection<Pet>(pets);

	}


	public void SetContext(DataContext context)
	{
		_dataContex = context;
		_petRepository = new PetRepository(_dataContex);
	}
}