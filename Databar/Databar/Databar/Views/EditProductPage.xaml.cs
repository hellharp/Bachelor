using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databar.Views;
using Databar.ViewModels;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Databar.Models;

namespace Databar.Views
{
    public partial class EditProductPage : ContentPage
    {
        private EditProductPageViewModel EditViewModel;

        public EditProductPage()
        {
            InitializeComponent();
            EditViewModel = new EditProductPageViewModel();

        }

        void FiveDayToggle(object sender, ToggledEventArgs e)
        {
            if (FiveDayRebate_sw.IsToggled == true)
            {
                FiveDayRebateType_label.Text = "%";
            }
            else if(FiveDayRebate_sw.IsToggled == false)
            {
                FiveDayRebateType_label.Text = "Kr";
            }
        }

        void FourDayToggle(object sender, ToggledEventArgs e)
        {
            if (FourDayRebate_sw.IsToggled == true)
            {
                FourDayRebateType_label.Text = "%";
            }
            else if (FourDayRebate_sw.IsToggled == false)
            {
                FourDayRebateType_label.Text = "Kr";
            }
        }
        void ThreeDayToggle(object sender, ToggledEventArgs e)
        {
            if (ThreeDayRebate_sw.IsToggled == true)
            {
                ThreeDayRebateType_label.Text = "%";
            }
            else if (ThreeDayRebate_sw.IsToggled == false)
            {
                ThreeDayRebateType_label.Text = "Kr";
            }
        }
        void TwoDayToggle(object sender, ToggledEventArgs e)
        {
            if (TwoDayRebate_sw.IsToggled == true)
            {
                TwoDayRebateType_label.Text = "%";
            }
            else if (TwoDayRebate_sw.IsToggled == false)
            {
                TwoDayRebateType_label.Text = "Kr";
            }
        }
        void OneDayToggle(object sender, ToggledEventArgs e)
        {
            if (OneDayRebate_sw.IsToggled == true)
            {
                OneDayRebateType_label.Text = "%";
            }
            else if (OneDayRebate_sw.IsToggled == false)
            {
                OneDayRebateType_label.Text = "Kr";
            }
        }
        
        // Shows a confirmation window if the user clickes the delete button
        async void ShowDeleteDialog(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Advarsel!", "Vil du slette det valgte produktet?", "Ja", "Nei");
            Debug.WriteLine("Answer:" + answer);
        }

        async void OnInfoButtonPressed(object sender, EventArgs e)
        {
            var pageItemList = new ObservableCollection<HelpItem>
            {
                new HelpItem
                {
                    NoImageText = "",
                    ImageAndroid = "gs1_ok_circle.png",
                    ImageIOS = "GS1_Symbol_OK_Circle_RGB_20150416.png",
                    Explanation = "Ved å trykke denne knappen vil man lagre produktets verdier."
                },
                new HelpItem
                {
                    NoImageText = "",
                    ImageAndroid = "gs1_remove_circle.png",
                    ImageIOS = "GS1_Symbol_Remove_Circle_RGB_20150416.png",
                    Explanation = "Ved å trykke denne knappen vil man slette produktet fra databasen."
                },
                new HelpItem
                {
                    NoImageText = "Sperret",
                    ImageAndroid = "",
                    ImageIOS = "",
                    Explanation = "Her vil man kunne sperre et produkts batch/lot nr. Alle produkter med tilsvarende batch/lot nr. vil da være stengt for salg"
                },
                new HelpItem
                {
                    NoImageText = "Rabatter",
                    ImageAndroid = "",
                    ImageIOS = "",
                    Explanation = "Her vil man sette de ulike rabattene for de produktet. Slideren på høyre side vil avgjøre om rabatten settes i kroner eller rabatt"
                }
            };

            var infoPage = new InformationPage();
            infoPage.BindingContext = pageItemList;

            await Navigation.PushModalAsync(infoPage, true);
        }
    }
}
