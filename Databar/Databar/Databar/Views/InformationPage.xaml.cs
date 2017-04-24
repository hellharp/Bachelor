using Databar.Models;
using Databar.Services;
using Databar.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Databar.Views
{

    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationPage : ContentPage
    {
        private InformationPageViewModel InfoViewModel;

        public InformationPage(string page)
        {

            InitializeComponent();

            //Henter InfoPageViewModel
            InfoViewModel = new InformationPageViewModel(page);

            //Setter XAML til å bruke InformationPageViewModel.
            BindingContext = InfoViewModel;
        }

        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}