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
        private EditProductPageViewModel editViewModel;
        private string Page = "EditProductPage";

        public EditProductPage()
        {
            InitializeComponent();

			editViewModel = new EditProductPageViewModel();

			BindingContext = editViewModel;

			//Is this delay needed?
			Task.Delay(10000);
			CheckDates();
              

			Debug.WriteLine("EXPDatepicker sin toString :" + ExpD_picker.Date.ToString());

        }


        void LastDayToggle(object sender, ToggledEventArgs e)
        {
			if (LastDayRebate_sw.IsToggled == true)
            {
				LastDayRebateType_label.Text = "%";
				ExpD_picker.IsVisible = false;
				SisteForbruksdato.IsVisible = false;
            }
            else if(LastDayRebate_sw.IsToggled == false)
            {
                LastDayRebateType_label.Text = "Kr";
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
			Debug.WriteLine("Answer:" + answer.ToString());
			if (answer.Equals(true))
			{
				Debug.WriteLine("sender til delete");
				editViewModel.DeleteProduct();
			}
        }

		private void CheckDates()
		{

			if (ExpD_picker.Date.ToString().Equals("ExpD_picker.Date.ToString()"))
				ExpD_picker.IsVisible = false;
			OnPropertyChanged();
		}


        async void OnInfoButtonPressed(object sender, EventArgs e)
        {
            var infoPage = new InformationPage(Page);

            await Navigation.PushAsync(infoPage, true);
        }

		async void OnSavedButton(object sender, EventArgs e)
		{
			editViewModel.SaveProduct();
			await DisplayAlert("Save", "Klikket save!", "OK");
		}
    }


}
