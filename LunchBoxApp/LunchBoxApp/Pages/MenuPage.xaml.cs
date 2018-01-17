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

	    private ScrollView _scrollView;

	    private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
            ((ListView) sender).SelectedItem = null;
	        _scrollView.ScrollToAsync(0, 1000, true);
        }

	    protected override void OnAppearing()
	    {
	        var pageModel = BindingContext as MenuPageModel;
	        pageModel?.SyncOrderedProductsTask();

            base.OnAppearing();
	    }

	    private void Element_OnChildAdded(object sender, ElementEventArgs e)
	    {
	        _scrollView = ((ScrollView)sender);
        }
	}
}