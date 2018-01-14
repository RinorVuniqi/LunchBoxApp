using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchBoxApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
		}

	    private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
            ((ListView) sender).SelectedItem = null;
	    }

	    protected override void OnAppearing()
	    {
	        var pageModel = BindingContext as MenuPageModel;
	        pageModel?.SyncOrderedProductsTask();

            base.OnAppearing();
	    }
	}
}