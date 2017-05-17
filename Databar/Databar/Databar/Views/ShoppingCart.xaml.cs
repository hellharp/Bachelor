using System;
using Xamarin.Forms;
using Databar.Models;
using Databar.ViewModels;

namespace Databar.Views
{
    public partial class ShoppingCart : ContentPage
    {
        private CartViewModel cartViewModel;
        private string sumstring;

        /// <summary>
        /// The Constructor for ShoppingCart. Initializes CartViewModel, sets Binding context and calculates price
        /// </summary>
        public ShoppingCart()
        {
            InitializeComponent();

            cartViewModel = Application.Current.Properties["CartViewModel"] as CartViewModel;

            BindingContext = cartViewModel;

            CalculatePrice();
        }

        /// <summary>
        /// Calls cartViewModel to calculate the total price of the shopping cart
        /// </summary>
        private void CalculatePrice()
        {
            SumString = cartViewModel.Sum().ToString();
            // SumLabel.Text = number.ToString() + "kr";
            SumLabel.Text = SumString;
            cartViewModel.DeleteDateList();
            OnPropertyChanged();
        }

        /// <summary>
        /// Is called when an object in the list gets clicked on and shows information about that object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selection = e.SelectedItem as Product;

                DisplayAlert("Du klikket på ", selection.ProductName, "OK");
                //Remove the selection so that the object is no longer highlighted
                ((ListView)sender).SelectedItem = null;
            }
        }

        /// <summary>
        /// Calls CartViewModel to start ZXing mobile scanner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		async void StartZXing(object sender, EventArgs e)
        {
            string success = "";
            success = await cartViewModel.StartZXing(sender, e);

            CalculatePrice();

            if (success.Equals("userAbort"))
            {
                await DisplayAlert("Avbrutt", "Strekkodelesing ble avbrutt", "Ok");
            }
            else if (success.Equals("isBlocked"))
            {
                await DisplayAlert("Sperret batch/lot nummer", "Dette produktet har blitt sperret", "Ok");
                return;
            }
            else if (success.Equals("notinDB"))
                await DisplayAlert("Ugyldig produkt", "Dette produktet har ikke blitt registrert", "Ok");
            else if (success.Equals("barcodeFail"))
                await DisplayAlert("Feil", "Strekkoden kunne ikke bli lest", "Ok");
            else if (success.Equals("expirDate"))
                await DisplayAlert("Advarsel", "Holdbarhetsdatoen er oversteget", "Ok");
        }

        /// <summary>
        /// Gets called when an object is removed. It calls the CartViewModel to delete the object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnRemoved(object sender, EventArgs e)
        {
            var selectedItem = (MenuItem)sender;
            var selectedProduct = selectedItem.CommandParameter as Product;

            cartViewModel.RemoveProduct(selectedProduct);

            OnPropertyChanged();

            CalculatePrice();
        }

        /// <summary>
        /// Opens the PayPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		async void ToPayPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PayPage());
        }

        /// <summary>
        /// Deletes the whole shopping cart through CartViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private async void OnRemoveIcon(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Advarsel!", "Vil du tømme handlekurven?", "Ja", "Nei");
            if (answer)
            {
                cartViewModel.ResetCartlist();
                CalculatePrice();
            }
            else return;
        }

        /// <summary>
        /// Get or set the total Price to the View
        /// </summary>
        public String SumString { get { return sumstring + "kr"; } set { sumstring = value; OnPropertyChanged(); } }
    }
}
