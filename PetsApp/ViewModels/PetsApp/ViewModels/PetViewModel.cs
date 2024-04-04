using System.Windows;
using System.Windows.Input;
using PetsApp.Domain;
using PetsApp.Helpers;
using PetsApp.Interfaces;
using PetsApp.Persistance;
using PetsApp.Persistance.Repositories;

namespace PetsApp.ViewModels;

public class PetViewModel : BaseViewModel, IPageViewModel
{
	public string Name { get; } = "Pet";
	private DataContext _dataContex { get; set; }
	private IPetRepository _petRepository { get; set; }
	private ICommand _takeHomeCommand { get; set; }

	public ICommand TakeHomeCommand
	{
		get
		{
			return new RelayCommand(p => TakeHome());
		}
	}
	private ICommand _feedCommand { get; set; }

	public ICommand FeedCommand
	{
		get
		{
			return new RelayCommand(p => Feed());
		
		}
	}
	private void Feed(){
		MessageBox.Show("Для допомоги данній тваринці ви можете відправити кошти за наступним рахунком, або ж привезти корм за адресою: Вул. Левка Мацієвича 23. Банківський рахунок: UA54342342346789932450. Карта приват банку: 5141-4141-3824-3356");
	}
	private void TakeHome()
	{
		MessageBox.Show("Якщо Ви зацікавленні у цій тваринці та хочете забрати її додому. Зателефонуйте за цим номером: 066-783-64-62");
	}
	public Pet Pet { get; set; }
	private int _id;
	public PetViewModel(int Id){
		_id = Id;
		//var pet = _petRepository.GetById(Id);
	}
	public void Update()
	{
		Pet = _petRepository.GetById(_id);
	}

	public void SetContext(DataContext context)
	{
		_dataContex = context;
		_petRepository = new PetRepository(_dataContex);
	}
}