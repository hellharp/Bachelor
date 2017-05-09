using System;
using Databar.ViewModels;
using Xamarin.Forms;
using Databar.Services;

namespace Databar.Views
{
    public partial class PayConfirmationPage : ContentPage
	{
		private PayConfirmationViewModel payConfirmationViewModel;
        private CartViewModel cartViewModel;

        public PayConfirmationPage()
		{
			InitializeComponent();

			//Gets PayConfirmationViewModel
			payConfirmationViewModel =  new PayConfirmationViewModel();

			CalculateDiscountPrice();

		}

		//Calculate total discount
		private void CalculateDiscountPrice()
		{
			decimal discountnumber = payConfirmationViewModel.TotalDiscount();
			DiscountAmountLabel.Text = discountnumber.ToString() + ",-";
		}

		async void CloseWindow(object sender, EventArgs e)
		{
            //await Navigation.PushAsync(new Views.MainPage());
            cartViewModel = Application.Current.Properties["CartViewModel"] as CartViewModel;
            cartViewModel.ResetCartlist();
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
	}
}
