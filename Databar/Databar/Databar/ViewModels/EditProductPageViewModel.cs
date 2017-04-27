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
using System.Diagnostics;

namespace Databar.ViewModels
{
	//denne må inheret INotifyPropertyChanged
	public class EditProductPageViewModel : INotifyPropertyChanged
	{
		private Product _product;
		private String result, gtin;



		public EditProductPageViewModel()
		{
			//Hent product med metode fra RestSQL



			//Hard coded string (01)09501101530003(17)140704(10)2929
			result = Application.Current.Properties["ScannedCode"] as String;
			//    DisplayAlert("Databar skannet", result.ToString(), "OK");


			int nr = 1;

			//GTIN_entry = "Satt fra modelen";


			//Finds the AI number
			String pattern = @"(?<=\().+?(?=\))";
			Match match = Regex.Match(result, pattern);


			Debug.WriteLine("Start på loop");

			while (match.Success)
			{

				//Greps what comes after the AI
				String rest = result.Substring(result.IndexOf(match.Value) + match.Value.Length + 1);

				//Matches everything up to the next "(" aka start of new AI
				Match code = Regex.Match(rest, @"^.*?(?=[(])");

				//Write everything to the log
				Debug.WriteLine("Match nr:" + nr++ + "AI: " + match.Groups[0].Value + " Code: " + code.ToString());

				//Increment match to check next AI
				match = match.NextMatch();


			}
			OnPropertyChanged();
			this.OnPropertyChanged();

			GetGTIN = "hei";



			String resultString = Regex.Match(result, @"(?<=\().+?(?=\))").Value;
			//  DisplayAlert("Parantes", resultString.ToString(), "OK");

		}

		public String GetGTIN
		{
			get { return gtin; }
			set
			{
				gtin = value;
				//Refresher user-interface hver gang listen blir endret
				OnPropertyChanged();
			}
		}


		public void WriteAItoGUI(String s)
		{
			if (s.Equals("01") || s.Equals("1"))
			{

			}



		}

		//Disse må implementeres på grunn av INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
