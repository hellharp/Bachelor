using System;
using Xamarin.Forms;
using ZXing.Mobile;
using Databar.ViewModels;
using Databar.Services;

namespace Databar.Views.Admin
{
    /// <summary>
    /// The View for the AdminMenu
    /// </summary>
    public partial class AdminMenu : ContentPage
    {
        // Variable used for handling back-button event
        private bool _canClose = true;
        private CartViewModel cartViewModel;

        /// <summary>
        /// Constructor for AdminMenu. Sets the current date and cartViewModel
        /// </summary>
        public AdminMenu()
        {
            InitializeComponent();

            // Set the date on the datepicker to "CurrentDate" to avoid resetting to the actual date
            DateTime currDate = (DateTime)Application.Current.Properties["CurrentDate"];
            Curr_Date_Picker.Date = currDate;

            // Reset shopping cart
            cartViewModel = Application.Current.Properties["CartViewModel"] as CartViewModel;
            cartViewModel.ResetCartlist();
        }

        /// <summary>
        /// Sends the user out of the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Logout(object sender, EventArgs e)
        {
            Application.Current.Properties["IsLoggedIn"] = false;

            App.DBManager.SetDBRestManager(new RestService());

            Application.Current.MainPage = new NavigationPage(new Views.MainPage());
        }

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
        /// Starts the ZXing mobile scanner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void StartZXing(object sender, EventArgs e)
        {
            var options = new MobileBarcodeScanningOptions()
            {
                TryHarder = true,
                AutoRotate = false
            };
            var scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan(options);

            if (result != null)
            {
                Application.Current.Properties["ScannedCode"] = result.Text;

                await Navigation.PushAsync(new EditProductPage());
            }
            else
            {
                Application.Current.Properties["ScannedCode"] = "";
                // Scanning aborted
                await DisplayAlert("Advarsel", "Skanning av strekkode avbrutt!", "OK");
            }
        }

        /// <summary>
        /// Focus on / display the hidden DatePicker when "calendar"-button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void FocusDatePicker(object sender, EventArgs ea)
        {
            Curr_Date_Picker.Focus();
        }

        /// <summary>
        /// Save the chosen date as the "current" date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void SetCurrentDate(object sender, EventArgs ea)
        {
            DateTime setCurrentDate = Curr_Date_Picker.Date;
            Application.Current.Properties["CurrentDate"] = setCurrentDate;
        }
    }
}
