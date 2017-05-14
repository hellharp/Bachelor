
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
			cartViewModel.SlettDateList();
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
			string success = "";
            //	success = await cartViewModel.StartZXing(sender, e); //"(01)12345678901234(10)ABC-321(15)170510");
            success = "(01)07048840000036(10)ABC321(15)170517";

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

		private void OnRemoved(object sender, EventArgs e)
		{
			var selectedItem = (MenuItem)sender;
			var selectedProduct = selectedItem.CommandParameter as Product;

			cartViewModel.RemoveProduct(selectedProduct);

			OnPropertyChanged();
			CalculatePrice();
		}

		async void ToPayPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PayPage());
		}

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


		public String SumString { get { return sumstring + "kr"; } set { sumstring = value; OnPropertyChanged(); } }
	}
}
