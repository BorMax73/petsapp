using PetsApp.Interfaces;
using System.Windows.Input;
using PetsApp.Helpers;
using PetsApp.Persistance;

namespace PetsApp.ViewModels;

public class PageSelectorViewModel : BaseViewModel
{
	#region Fields
	private ICommand _changePageCommand;
	
	private IPageViewModel _currentPageViewModel;
	private List<IPageViewModel> _pageViewModels;
	#endregion


	#region Properties/Commands

	public ICommand ChangePageCommand
	{
		get
		{
			if (_changePageCommand == null)
			{
				_changePageCommand = new RelayCommand(
					p => ChangeViewModel((IPageViewModel)p),
					p => p is IPageViewModel);
			}

			return _changePageCommand;
		}
	}

	public void GetSinglePet(int id)
	{
		CurrentPageViewModel = new PetViewModel(id);
		CurrentPageViewModel.SetContext(_dataContex);
		CurrentPageViewModel.Update();
	}
	public List<IPageViewModel> PageViewModels
	{
		get
		{
			if (_pageViewModels == null)
				_pageViewModels = new List<IPageViewModel>();

			return _pageViewModels;
		}
	}

	public IPageViewModel CurrentPageViewModel
	{
		get
		{
			return _currentPageViewModel;
		}
		set
		{
			if (_currentPageViewModel != value)
			{
				_currentPageViewModel = value;
				OnPropertyChanged("CurrentPageViewModel");
			}
		}
	}
	#endregion

	#region methods
	private void ChangeViewModel(IPageViewModel viewModel)
	{
		if (!PageViewModels.Contains(viewModel))
			PageViewModels.Add(viewModel);

		CurrentPageViewModel = PageViewModels
			.FirstOrDefault(vm => vm == viewModel);
	}
	private DataContext _dataContex { get; set; }
	public PageSelectorViewModel(DataContext dbContext)
	{
		_dataContex = dbContext;
		// Add available pages
		PageViewModels.Add(new AllPetsViewModel(this));
		PageViewModels.Add(new DogsViewModel(this));
		PageViewModels.Add(new CatsViewModel(this));
		PageViewModels.Add(new AnotherPetsViewModel(this));
		PageViewModels.Add(new AboutViewModel());
		
	
		foreach (var page in PageViewModels)
		{
			page.SetContext(dbContext);
			page.Update();
		}
		// Set starting page
		CurrentPageViewModel = PageViewModels[0];
	}


	#endregion



}