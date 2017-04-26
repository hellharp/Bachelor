using Databar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databar.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace Databar.ViewModels
{
    //denne må inheret INotifyPropertyChanged
    class EditProductPageViewModel : ContentPage
    {
        private Product _product;
        private String result;

        public EditProductPageViewModel()
        {
            //Hent product med metode fra RestSQL



            //Hard coded string (01)09501101530003(17)140704(10)2929
            result = Application.Current.Properties["ScannedCode"] as String;
            DisplayAlert("Databar skannet", result.ToString(), "OK");


            int nr = 1;



            //Finds the AI number
            String pattern = @"(?<=\().+?(?=\))";
            Match match = Regex.Match(result, pattern);

            while (match.Success)
            {

                //Greps what comes after the AI
                String rest = result.Substring(result.IndexOf(match.Value) + match.Value.Length + 1);

                //Matches everything up to the next "(" aka start of new AI
                Match code = Regex.Match(rest, @"^.*?(?=[(])");

                DisplayAlert("Match nr:" + nr++, "AI: " + match.Groups[0].Value + " Code: " + code.ToString(), "OK");
                match = match.NextMatch();
            }




            String resultString = Regex.Match(result, @"(?<=\().+?(?=\))").Value;
            //  DisplayAlert("Parantes", resultString.ToString(), "OK");

        }

        public Product EditProduct
        {
            get { return _product; }
            set
            {
                _product = value;
            }
        }

        public void GetProduct(Int64 GTIN)
        {
            //_product = DB_Service.GetProduct(GTIN);
        }

        public void SaveProduct()
        {
            //DB_Service.AddProduct(_product);
        }

        public void DeleteProduct()
        {
            //DB_Service.RemoveProduct(_product);
        }
    }
}
