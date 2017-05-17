using System;
using Xamarin.Forms;

namespace Databar.Views
{
    public partial class PayPage : ContentPage
    {
        private string Page = "PayPage";

        /// <summary>
        /// The PayPage View 
        /// </summary>
        public PayPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Starts the PayConfirmationPage View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ToPayConfirmationPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PayConfirmationPage());
        }

        /// <summary>
        /// Starts the ShoppingCart View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ToShoppingCart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingCart());
        }

        /// <summary>
        /// Starts the MainPage View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        /// <summary>
        /// Starts a popup with explanations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ToPopUp(object sender, EventArgs e)
        {
            await DisplayAlert("Informasjon\n", "Du velger betalingsmetode avhengig av hvilken betalingsapp du ønsker å betale med. " +
                               "Ved valgt så betales varene i handlekurven.\n\n" +
                               "Bunnmeny: \n" +
                               "Handlekurvknappen til venstre sender deg tilbake handlekurven uten å ha betalt.\n\n" +
                               "Menyknappen i midten sender deg tilbake til hovedmenyen uten å ha betalt.", "Lukk");
        }

        /// <summary>
        /// Starts the InformationPage View
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
