
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using Databar.ViewModels;
using Databar.Models;
using ZXing.Mobile;

namespace Databar.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			DateTime currDate = (DateTime)Application.Current.Properties["CurrentDate"];
			currentDate.Text = currDate.ToString("d", new CultureInfo("nb-NO"));
            //NavigationPage.SetBackButtonTitle(this, "TEST");
            //NavigationPage.SetTitleIcon(this, "gs1_shopping_cart.png");
            //this.Icon = "icon.png";
            //this.Title = "TEST"
		}

		//protected override void OnAppearing()
		//{
		//	DateTime currDate = (DateTime)App.Current.Properties["CurrentDate"];
		//	currentDate.Text = currDate.ToString("d", new CultureInfo("nb-NO"));
		//}

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

		async void StartZXing(object sender, EventArgs e)
		{
			var scanner = new MobileBarcodeScanner();

			var result = await scanner.Scan();


			if (result != null)
			{
				Application.Current.Properties["ScannedCode"] = result;
				await DisplayAlert("Databar skannet", result.ToString(), "OK");
				// Code scanned and added to shoppingcart.
				//await Navigation.PushAsync(new ShoppingCart());
			}
			else
			{
				Application.Current.Properties["ScannedCode"] = "";
				// Scanning aborted
				await DisplayAlert("Advarsel", "Skanning av strekkode avbrutt!", "OK");
			}
		}

		async void ToPopUp(object sender, EventArgs e)
		{
			await DisplayAlert("Informasjon\n", "Bunnmeny: \n" +
			                   "Strekkodeknappen til venstre starter strekkodeskanneren. " +
			                   "Skannede varer havner i handlekurven.\n\n" +
			                   "Menyknappen i midten sender deg administrasjonsmenyen (krever passord).\n", "Lukk");
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

