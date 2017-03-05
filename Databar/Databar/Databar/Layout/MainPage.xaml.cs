
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Databar.Layout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		async void ToZXing(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new BasisUI());

		//361923d... Commit av div endringer + paypage og PayConfirmationPage
		}

		async void ToEditProductPage(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new EditProductPage());
		}

		async void ToAdminLogin(object sender, EventArgs e)
		{
			// Endret til PushAsync for å gi IOS back-button
			await Navigation.PushAsync(new LoginModal());
		//361923d... Commit av div endringer + paypage og PayConfirmationPage
		}

		async void ToPayPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync((new PayPage()));	
		}

		async void ToPayConfirmationPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PayConfirmationPage());
		}
        async void ToCart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingCart());
        }


        //Handle device hardware back button to prevent accidental closing of app
        private bool _canClose = true;
		protected override bool OnBackButtonPressed()
		{
			if (_canClose)
			{
				ShowExitDialog();
			}
			return _canClose;
		}
		// Exit dialog. NOTE: User has to press back-button again to actually close app
		private async void ShowExitDialog()
		{
			var answer = await DisplayAlert("Advarsel!", "Vil du lukke appen?", "Ja", "Nei");
			if (answer)
			{
				_canClose = false;
				OnBackButtonPressed();
			}
		}

	}
}
