using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using PetsApp.Persistance;
using PetsApp.ViewModels;

namespace PetsApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		DataContext context;
		public MainWindow(DataContext dataContext, PageSelectorViewModel selector)
		{
			this.context = dataContext;
			InitializeComponent();
			DataContext = selector;
		}
	}
}