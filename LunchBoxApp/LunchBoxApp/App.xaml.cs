using FreshMvvm;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;
using LunchBoxApp.Domain.Services.SQLite;
using LunchBoxApp.PageModels;
using Xamarin.Forms;

namespace LunchBoxApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    FreshIOC.Container.Register<IUserService>(new UserService());
		    FreshIOC.Container.Register<ICategoryService>(new CategoryService());
		    FreshIOC.Container.Register<ISubcategoryService>(new SubcategoryService());
		    FreshIOC.Container.Register<IProductService>(new ProductService());
		    FreshIOC.Container.Register<IOrderService>(new OrderService());
		    FreshIOC.Container.Register<IPaymentService>(new PaymentService());
		    FreshIOC.Container.Register<ISoundPlayer>(DependencyService.Get<ISoundPlayer>());

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginPageModel>());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
