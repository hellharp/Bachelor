using System;
using System.Globalization;
using Xamarin.Forms;

namespace Databar.Views
{
    public partial class MainPage : ContentPage
    {
        private string Page = "HomeScreen";

        /// <summary>
        /// Constructor for MainPage. Sets the current date
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            DateTime currDate = (DateTime)Application.Current.Properties["CurrentDate"];
            currentDate.Text = currDate.ToString("d", new CultureInfo("nb-NO"));
        }

        /// <summary>
        /// Starts the AdminMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ToAdminLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginModal());
        }

        /// <summary>
        /// Starts the ShoppingCart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ToCart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingCart());
        }

        /// <summary>
        /// Displays a popup with information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ToPopUp(object sender, EventArgs e)
        {
            await DisplayAlert("Informasjon\n", "Bunnmeny: \n" +
                               "Handlekurven til venstre starter strekkodeskanneren. " +
                               "Skannede varer havner i handlekurven.\n\n" +
                               "Menyknappen i midten sender deg administrasjonsmenyen (krever passord).\n", "Lukk");
        }


        private bool _canClose = true;

        /// <summary>
        /// Handle device hardware back button to prevent accidental closing of app
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            if (_canClose)
            {
                ShowExitDialog();
            }
            return _canClose;
        }

        /// <summary>
        /// Exit dialog. NOTE: User has to press back-button again to actually close app
        /// </summary>
        private async void ShowExitDialog()
        {
            var answer = await DisplayAlert("Advarsel!", "Vil du lukke appen?", "Ja", "Nei");
            if (answer)
            {
                _canClose = false;
                OnBackButtonPressed();
            }
        }

        /// <summary>
        /// Calls the InformationPage to display an infoPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnInfoButtonPressed(object sender, EventArgs e)
        {
            var infoPage = new InformationPage(Page);

            await Navigation.PushModalAsync(infoPage, true);
        }
    }
}

