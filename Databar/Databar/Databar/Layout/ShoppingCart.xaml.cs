using Databar.Data;
using System;
using Xamarin.Forms;

namespace Databar.Layout
{
    public partial class ShoppingCart : ContentPage
    {
        public ShoppingCart()
        {
            InitializeComponent();
            listView.ItemsSource = CartData.ProductList;
            decimal number = CartData.Sum();

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
    }
}
