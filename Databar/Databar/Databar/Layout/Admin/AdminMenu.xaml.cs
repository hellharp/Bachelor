using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Databar.Layout.Admin
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
			App.Current.Properties["IsLoggedIn"] = false;
			App.Current.MainPage = new NavigationPage(new Layout.MainPage());
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
	}
}
