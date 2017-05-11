using Databar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Databar.Views
{
	public partial class LoginModal : ContentPage
	{
		public LoginModal()
		{
			InitializeComponent();
            //NavigationPage.SetTitleIcon(this, "gs1_shopping_cart.png");
            //this.Icon = "gs1_shopping_cart.png";
		}

		// Handle password entry for admin access
		async void Password_Completed(object sender, EventArgs e)
		{
            var usr = usrEntry.Text;
            var pw = ((Entry)sender).Text; // cast sender to access properties of the Entry

            try
            {
                App.DBManager.SetDBRestManager(new RestService(usr, pw));
                bool auth = await App.DBManager.AuthenticateAdmin();
                if (auth)
                {
                    Application.Current.Properties["IsLoggedIn"] = true;
                    Application.Current.MainPage = new NavigationPage(new Admin.AdminMenu());
                }
                else
                {
                    // Set DBManager to readonly
                    App.DBManager.SetDBRestManager(new RestService());
                    await DisplayAlert("Feil passord", "Feil brukernavn eller passord, prøv igjen", "OK");
                }
            }
            catch (Exception ex)
            {
                App.DBManager.SetDBRestManager(new RestService());
                await DisplayAlert("Feil", "Kontakt sysadmin, feil: " + ex.Message, "OK");
            }
        }

		// Handle Enter-button-press event on login-page
		async void Enter_Button_Pressed(object sender, EventArgs e)
		{
            var usr = usrEntry.Text;
            var pw = pwEntry.Text; // Access entry text

            try
            {
                App.DBManager.SetDBRestManager(new RestService(usr, pw));
                bool auth = await App.DBManager.AuthenticateAdmin();
                if (auth)
                {
                    Application.Current.Properties["IsLoggedIn"] = true;
                    Application.Current.MainPage = new NavigationPage(new Admin.AdminMenu());
                }
                else
                {
                    // Set DBManager to readonly
                    App.DBManager.SetDBRestManager(new RestService());
                    await DisplayAlert("Feil passord", "Feil brukernavn eller passord, prøv igjen", "OK");
                }
            }
            catch (Exception ex)
            {
                //App.DBManager.SetDBRestManager(new RestService());
                await DisplayAlert("Feil", "Kontakt sysadmin, feil: " + ex.Message, "OK");
            }

        }

        async void CloseWindow(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
	}
}
