using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Databar.Views
{
    public partial class PayPage : ContentPage
    {
        public PayPage()
        {
            InitializeComponent();
        }

		async void ToPayConfirmationPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PayConfirmationPage());
		}

		async void ToShoppingCart(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ShoppingCart());
		}

		async void ToMainPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MainPage());
		}

		async void ToPopUp(object sender, EventArgs e)
		{
			await DisplayAlert("Informasjon\n", "Du velger betalingsmetode avhengig av hvilken betalingsapp du ønsker å betale med. " +
			                   "Ved valgt så betales varene i handlekurven.\n\n" +
			                   "Bunnmeny: \n" +
			                   "Handlekurvknappen til venstre sender deg tilbake handlekurven uten å ha betalt.\n\n" +
			                   "Menyknappen i midten sender deg tilbake til hovedmenyen uten å ha betalt.", "Lukk");
		}

	}
}
