using Databar.ViewModels;
using System;
using Xamarin.Forms;

namespace Databar.Views
{
    /// <summary>
    /// The InformationPage View
    /// </summary>
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationPage : ContentPage
    {
        private InformationPageViewModel InfoViewModel;
        private string location;

        /// <summary>
        /// Calls the InfoViewModel to set it as a BindingContext
        /// </summary>
        /// <param name="location">The page at which the function was called</param>
        public InformationPage(string location)
        {
            InitializeComponent();

            InfoViewModel = new InformationPageViewModel(location);

            BindingContext = InfoViewModel;
        }

        /// <summary>
        /// Exits the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}