using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetsApp.Persistance;
using PetsApp.View;
using PetsApp.ViewModels;
using SQLitePCL;
namespace PetsApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private ServiceProvider serviceProvider;
		private Login login;
		private MainWindow mainWindow;

		public App()
		{
			ServiceCollection services = new ServiceCollection();
			
			ConfigureServices(services);
			serviceProvider = services.BuildServiceProvider();
		}
		private void ConfigureServices(ServiceCollection services)
		{
			services.AddDbContext<DataContext>(options =>
			{
				options.UseSqlite("Data Source=pets.db");
			});
			services.AddSingleton<MainWindow>();
			services.AddSingleton<Login>();
			services.AddSingleton<PageSelectorViewModel>();
			;

		}
		private void OnStartup(object sender, StartupEventArgs e)
		{
			Login login = serviceProvider.GetService<Login>();
			login.Closing += Login_Closed;
			login.Show();

			
			
		}
		private void Login_Closed(object sender, EventArgs e)
		{
			// Открыть MainWindow
			mainWindow = serviceProvider.GetService<MainWindow>();
			mainWindow.Show();

			
		}
		private void App_OnExit(object sender, ExitEventArgs e)
		{
			// Запускается при выходе из приложения, но не будет вызвано, если отменим выход при закрытии окна Login.
			// В данном примере этот метод не требуется, но может быть полезен в других случаях.
		}
	}
}
