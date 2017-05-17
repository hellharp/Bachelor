using System;
using Databar.ViewModels;
using Xamarin.Forms;

namespace Databar.Views
{
    /// <summary>
    /// The View for EditProductPage
    /// </summary>
    public partial class EditProductPage : ContentPage
    {
        private EditProductPageViewModel editViewModel;
        private string Page = "EditProductPage";

        /// <summary>
        /// The constructor calls the EditProductPageViewModel
        /// </summary>
        public EditProductPage()
        {
            InitializeComponent();

            editViewModel = new EditProductPageViewModel();

            BindingContext = editViewModel;

            CheckDates();
        }

        /// <summary>
        /// Changes the View to display either % or kr when the switch is toggeled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LastDayToggle(object sender, ToggledEventArgs e)
        {
            if (LastDayRebate_sw.IsToggled == true)
            {
                LastDayRebateType_label.Text = "%";
            }
            else if (LastDayRebate_sw.IsToggled == false)
            {
                LastDayRebateType_label.Text = "Kr";
            }
        }

        /// <summary>
        /// Changes the View to display either % or kr when the switch is toggeled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Changes the View to display either % or kr when the switch is toggeled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Changes the View to display either % or kr when the switch is toggeled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Changes the View to display either % or kr when the switch is toggeled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Shows a confirmation window if the user clicks the delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ShowDeleteDialog(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Advarsel!", "Vil du slette det valgte produktet?", "Ja", "Nei");

            if (answer.Equals(true))
            {
                editViewModel.DeleteProduct();
            }
        }

        /// <summary>
        /// Checks if the ExpirationDatePicker should be visible or not
        /// </summary>
        private void CheckDates()
        {
            if (ExpD_picker.Date.ToString().Equals("ExpD_picker.Date.ToString()"))
                ExpD_picker.IsVisible = false;
            OnPropertyChanged();
        }

        /// <summary>
        /// Calls the InformationPage to display an infoPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnInfoButtonPressed(object sender, EventArgs e)
        {
            var infoPage = new InformationPage(Page);

            await Navigation.PushModalAsync(infoPage, true);
        }

        /// <summary>
        /// Displays an alert and saves the product to the EditViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnSavedButton(object sender, EventArgs e)
        {
            editViewModel.SaveProduct();
            await DisplayAlert("Save", "Klikket save!", "OK");
        }
    }
}
