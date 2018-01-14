using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchBoxApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        var pageModel = BindingContext as LoginPageModel;
	        pageModel?.ClearOrderedProducts();

            base.OnAppearing();
	    }
	}
}