using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Databar.Layout
{
	public partial class LoginModal : ContentPage
	{
		public LoginModal()
		{
			InitializeComponent();
		}

		// Handle password entry for admin access
		async void Password_Completed(object sender, EventArgs e)
		{
			var pw = ((Entry)sender).Text; // cast sender to access properties of the Entry
			if (pw == "test")
			{
				App.Current.Properties["IsLoggedIn"] = true;
				App.Current.MainPage = new NavigationPage(new Admin.AdminMenu());
				//await Navigation.PushAsync(new Admin.AdminMenu());
				//await Navigation.PopToRootAsync();
				//await Navigation.PopModalAsync();
			}
			else
			{
				await DisplayAlert("Feil passord", "Feil adminpassord (passord: test)", "OK");
			}
		}
	}
}
