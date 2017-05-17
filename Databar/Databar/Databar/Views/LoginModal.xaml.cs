using Databar.Services;
using System;
using Xamarin.Forms;

namespace Databar.Views
{
	public partial class LoginModal : ContentPage
	{
        /// <summary>
        /// Constructor for the LoginModal
        /// </summary>
		public LoginModal()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Handles password entry for admin access
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handle Enter-button-press event on login-page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CloseWindow(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
	}
}
