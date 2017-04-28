using Databar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ZXing.Mobile;

namespace Databar.Views.Admin
{
    public partial class AdminMenu : ContentPage
    {
        // Variable used for handling back-button event
        private bool _canClose = true;

        public AdminMenu()
        {
            InitializeComponent();
        }

        async void Logout(object sender, EventArgs e)
        {
            Application.Current.Properties["IsLoggedIn"] = false;
            Application.Current.MainPage = new NavigationPage(new Views.MainPage());
            //await Navigation.PopAsync();
        }

        //Handle device hardware back button to prevent accidental closing of app
        protected override bool OnBackButtonPressed()
        {
            if (_canClose)
            {
                ShowExitDialog();
            }
            return _canClose;
        }
        // Exit dialog. NOTE: User has to press back-button again to actually close app
        private async void ShowExitDialog()
        {
            var answer = await DisplayAlert("Advarsel!", "Vil du lukke appen?", "Ja", "Nei");
            if (answer)
            {
                _canClose = false;
                OnBackButtonPressed();
            }
        }

        async void StartZXing(object sender, EventArgs e)
        {
			Application.Current.Properties["ScannedCode"] = "(1)12345678901234(17)140704(10)1234";
            await Navigation.PushAsync(new EditProductPage());
           
          /*
            var scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan();


            if (result != null)
            {
                Application.Current.Properties["ScannedCode"] = result.Text;

             


                //    await DisplayAlert("Databar skannet", result.ToString(), "OK");
                // Code scanned and saved in Properties["ScannedCode"], send to EditProductPage.
                await Navigation.PushAsync(new EditProductPage());
                // testcommit
            }
            else
            {
                Application.Current.Properties["ScannedCode"] = "";
                // Scanning aborted
                await DisplayAlert("Advarsel", "Skanning av strekkode avbrutt!", "OK");
            }*/


        }

        // Focus on / display the hidden DatePicker when "calendar"-button is pressed
        async void FocusDatePicker(object sender, EventArgs ea)
        {
            Curr_Date_Picker.Focus();
        }

        // Save the chosen date as the "current" date
        async void SetCurrentDate(object sender, EventArgs ea)
        {
            DateTime setCurrentDate = Curr_Date_Picker.Date;
            Application.Current.Properties["CurrentDate"] = setCurrentDate;
        }

        async void TestDB(object sender, EventArgs ea)
        {
            List<AI> ais = new List<AI>();
            List<Product> prods = new List<Product>();
            List<BatchBlock> bs = new List<BatchBlock>();
            //Product p = new Product();
            //p.GTIN = 12345678904321;
            //p.ProductName = "testDBtest";
            //await App.DBManager.SaveProductAsync(p);

            BatchBlock b = new BatchBlock();
            b.BatchNr = "BCA-666";
            b.Blocked = false;

            //var json = JsonConvert.SerializeObject(b);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");



            try
            {
                await App.DBManager.SaveBatchBlockAsync(b);
                ais = await App.DBManager.GetAIsAsync();
                prods = await App.DBManager.GetProductsAsync();
                bs = await App.DBManager.GetBatchBlocksAsync();
                await DisplayAlert("TestDB ai Count (should be 5)", ais.Count.ToString(), "OK");
                await DisplayAlert("TestDB batch Count (should be 3)", bs.Count.ToString(), "OK");
                await DisplayAlert("TestDB prod Count (should be 2)", prods.Count.ToString(), "OK");

                // await DisplayAlert("TestDB batchobject to json test", content.ToString(), "OK");
                //await DisplayAlert("RestURL for AI:", string.Format(Constants.RestUrl, "ai", String.Empty, Constants.JSONoutput), "OK");

                //string tmp = "";
                //foreach (var prod in prods)
                //{
                //    tmp += prod.GTIN.ToString();
                //}
                //if (tmp == "") { tmp = "tom liste"; }
                //await DisplayAlert("TestDB foreach tostring", tmp, "OK");
            }
            catch (Exception e)
            {
                await DisplayAlert("TestDB feil!", e.Message, "OK");
            }
        }
    }
}
