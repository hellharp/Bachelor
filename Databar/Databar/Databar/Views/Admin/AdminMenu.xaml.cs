using Databar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ZXing.Mobile;

namespace Databar.Views.Admin
{
	public partial class AdminMenu : ContentPage
	{
		// Variable used for handling back-button event
		private bool _canClose = true;

		public AdminMenu()
		{
			InitializeComponent();
		}

		async void Logout(object sender, EventArgs e)
		{
            Application.Current.Properties["IsLoggedIn"] = false;
            Application.Current.MainPage = new NavigationPage(new Views.MainPage());
			//await Navigation.PopAsync();
		}

		//Handle device hardware back button to prevent accidental closing of app
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

		async void StartZXing(object sender, EventArgs e)
		{
			var scanner = new MobileBarcodeScanner();

			var result = await scanner.Scan();


			if (result != null)
			{
                Application.Current.Properties["ScannedCode"] = result;
                await DisplayAlert("Databar skannet", result.ToString(), "OK");
                // Code scanned and saved in Properties["ScannedCode"], send to EditProductPage.
                //await Navigation.PushAsync(new EditProductPage());
                // testcommit
            }
			else
			{
                Application.Current.Properties["ScannedCode"] = "";
				// Scanning aborted
				await DisplayAlert("Advarsel", "Skanning av strekkode avbrutt!", "OK");
			}


        }

		// Focus on / display the hidden DatePicker when "calendar"-button is pressed
		async void FocusDatePicker(object sender, EventArgs ea)
		{
			Curr_Date_Picker.Focus();
		}

		// Save the chosen date as the "current" date
		async void SetCurrentDate(object sender, EventArgs ea)
		{
			DateTime setCurrentDate = Curr_Date_Picker.Date;
            Application.Current.Properties["CurrentDate"] = setCurrentDate;
		}

        async void TestDB(object sender, EventArgs ea)
        {
            List<AI> ais = new List<AI>();
            List<Product> prods = new List<Product>();
            try
            {
                ais = await App.DBManager.GetAIsAsync();
                prods = await App.DBManager.GetProductsAsync();
                await DisplayAlert("TestDB airesultat", ais.Count.ToString(), "OK");
                await DisplayAlert("RestURL:", string.Format(Constants.RestUrl, "ai", String.Empty, Constants.JSONoutput), "OK");
                await DisplayAlert("TestDB productresultat", prods.Count.ToString(), "OK");
                await DisplayAlert("RestURL:", string.Format(Constants.RestUrl, "product", String.Empty, Constants.JSONoutput), "OK");
                // FEIL: HER BLIR DET 0
            }
            catch (Exception e)
            {
                await DisplayAlert("TestDB feil!", e.Message, "OK");
            }
        }
	}
}
