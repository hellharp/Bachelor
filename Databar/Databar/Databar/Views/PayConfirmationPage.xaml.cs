using System;
using Databar.ViewModels;
using Xamarin.Forms;

namespace Databar.Views
{
    /// <summary>
    /// The View for the PayConfirmationPage
    /// </summary>
    public partial class PayConfirmationPage : ContentPage
	{
		private PayConfirmationViewModel payConfirmationViewModel;
        private CartViewModel cartViewModel;

        /// <summary>
        /// Initializes the PayConfirmationViewModel and calculates the total discounted price
        /// </summary>
        public PayConfirmationPage()
		{
			InitializeComponent();

			//Gets PayConfirmationViewModel
			payConfirmationViewModel =  new PayConfirmationViewModel();

			CalculateDiscountPrice();
		}

        /// <summary>
        /// Calculate total discount
        /// </summary>
        private void CalculateDiscountPrice()
		{
			decimal discountnumber = payConfirmationViewModel.TotalDiscount();
			DiscountAmountLabel.Text = discountnumber.ToString() + ",-";
		}

        /// <summary>
        /// Closes View and clears the cart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		void CloseWindow(object sender, EventArgs e)
		{
            cartViewModel = Application.Current.Properties["CartViewModel"] as CartViewModel;
            cartViewModel.ResetCartlist();
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
	}
}
