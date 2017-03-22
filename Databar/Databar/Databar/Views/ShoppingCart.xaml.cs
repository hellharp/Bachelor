
using System;
using Xamarin.Forms;
using Databar.Models;
using Databar.ViewModels;

namespace Databar.Views
{
    public partial class ShoppingCart : ContentPage
    {
        private CartViewModel cartViewModel;


        public ShoppingCart()
        {
            InitializeComponent();

            //Henter CartViewModel
            cartViewModel = new CartViewModel();

            //Setter XAML til å bruke CartViewModel. Denne gjør bruken av {Binding variabel} i XAML mulig.
            BindingContext = cartViewModel;

            CalculatePrice();           
        }



        private void CalculatePrice()
        {
            decimal number = cartViewModel.Sum();
            SumLabel.Text = number.ToString() + "kr";
        }


        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selection = e.SelectedItem as TempProd;
                DisplayAlert("Du klikket på ", selection.Name, "OK");
                //Fjerner seleksjonen slik at objektet ikke lenger er markert
                ((ListView)sender).SelectedItem = null;
            }
        }

        private void OnRemoved(object sender, EventArgs e)
        {
            var selectedItem = (MenuItem)sender;
            var selectedProduct = selectedItem.CommandParameter as TempProd;
            DisplayAlert("Fjernet", $"Du har fjernet {selectedProduct.Name} fra handlekurven", "OK");
        }

		async void ToPayPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PayPage());
		}

    }
}
