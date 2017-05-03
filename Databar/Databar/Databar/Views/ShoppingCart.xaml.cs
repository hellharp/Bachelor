
using System;
using Xamarin.Forms;
using Databar.Models;
using Databar.ViewModels;
using System.Diagnostics;

namespace Databar.Views
{
    public partial class ShoppingCart : ContentPage
    {
        private CartViewModel cartViewModel;
		private string sumstring;


        public ShoppingCart()
        {
            InitializeComponent();

            //Henter CartViewModel
            // cartViewModel = new CartViewModel();
            cartViewModel = Application.Current.Properties["CartViewModel"] as CartViewModel;

            //Setter XAML til å bruke CartViewModel. Denne gjør bruken av {Binding variabel} i XAML mulig.
            BindingContext = cartViewModel;

            CalculatePrice();           
        }



        private void CalculatePrice()
        {
			SumString = cartViewModel.Sum().ToString();
			// SumLabel.Text = number.ToString() + "kr";
			SumLabel.Text = SumString;
			OnPropertyChanged();
        }


        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
				var selection = e.SelectedItem as Product;
                DisplayAlert("Du klikket på ", selection.ProductName, "OK");
                //Fjerner seleksjonen slik at objektet ikke lenger er markert
                ((ListView)sender).SelectedItem = null;
            }
        }

       
        //Starts ZXing from the viewmodel
        async void StartZXing(object sender, EventArgs e)
        {
			bool success = false;
            success = await cartViewModel.StartZXing(sender, e, "(01)12345678901234(10)ABC-321(15)170510");
			CalculatePrice();
			if (!success)
				await DisplayAlert("Invalid product", "This product has not been registered in the database", "Ok");
        }

        private void OnRemoved(object sender, EventArgs e)
        {
            var selectedItem = (MenuItem)sender;
			var selectedProduct = selectedItem.CommandParameter as Product;

            cartViewModel.RemoveProduct(selectedProduct);

			DisplayAlert("Fjernet", $"Du har fjernet {selectedProduct.ProductName} fra handlekurven", "OK");

            OnPropertyChanged();
            CalculatePrice();
        }

		 async void ToPayPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PayPage());
		}

		public String SumString { get { return sumstring+"kr"; } set { sumstring = value; OnPropertyChanged(); } }
    }
}
