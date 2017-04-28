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
		private String result, gtin, batchlotentry, serial_entry, gross_entry, fivedayrebate_entry, fourdayrebate_entry, threedayrebate_entry, 
						twodayrebate_entry, onedayrebate_entry;

		private DateTime _BBD, _ExpD;
		private Boolean blocked_sw, fivedayrebate_sw, fourdayrebate_sw, threedayrebate_sw, twodayrebate_sw, onedayrebate_sw;



		public EditProductPageViewModel()
		{
			//Hent product med metode fra RestSQL

			result = Application.Current.Properties["ScannedCode"] as String;
				
			if (result == null || !result.Equals(""))
				DecodeBarcode();

		}

		//Decodes the barcode and sends it to WriteAItoGUI
		private void DecodeBarcode()
		{

			Debug.WriteLine("Databar skannet " + result.ToString());


			int nr = 1;


			//Finds the AI number
			String pattern = @"(?<=\().+?(?=\))";
			Match match = Regex.Match(result, pattern);


			Debug.WriteLine("Start på loop");

			while (match.Success)
			{
				//Should be replaced by making the above regex include the result with parenthese
				StringBuilder ai = new StringBuilder();
				ai.Append(match.Value.ToString());
				ai.Insert(0, '(');
				ai.Insert(ai.Length, ')');


				//Greps what comes after the AI
				String rest = result.Substring(result.IndexOf(ai.ToString()) + ai.Length);

				//Matches everything up to the next "(" aka start of new AI, or end of string
				Match code = Regex.Match(rest, @"^.*?(?=[(]|\Z)");

				//Write everything to the log
				Debug.WriteLine("Match nr: " + nr++ + "AI: " + match.Groups[0].Value + " Code: " + code.ToString());

				//Write code to editProductPage
				WriteAItoGUI(match.Groups[0].Value.ToString(), code.ToString());

				//Increment match to check next AI
				match = match.NextMatch();
			}
		}


		public String GTIN_entry { get { return gtin; } set { gtin = value; OnPropertyChanged(); } }

		public String BatchLot_entry { get { return batchlotentry; } set { batchlotentry = value; OnPropertyChanged(); } }

		public DateTime BBD { get { return _BBD; } set { _BBD = value; OnPropertyChanged(); } }

		public DateTime ExpD { get { return _ExpD; } set { _ExpD = value; OnPropertyChanged(); } }

		public String Serial_entry { get { return serial_entry; } set { serial_entry = value; OnPropertyChanged(); } }

		public String Gross_entry { get { return gross_entry; } set { gross_entry = value; OnPropertyChanged(); } }

		public String FiveDayRebate_entry { get { return fivedayrebate_entry; } set { fivedayrebate_entry = value; OnPropertyChanged(); } }

		public String FourDayRebate_entry { get { return fourdayrebate_entry; } set { fourdayrebate_entry = value; OnPropertyChanged(); } }

		public String ThreeDayRebate_entry { get { return threedayrebate_entry; } set { threedayrebate_entry = value; OnPropertyChanged(); } }

		public String TwoDayRebate_entry { get { return twodayrebate_entry; } set { twodayrebate_entry = value; OnPropertyChanged(); } }

		public String OneDayRebate_entry { get { return onedayrebate_entry; } set { onedayrebate_entry = value; OnPropertyChanged(); } }



		public Boolean Blocked_sw { get { return blocked_sw; } set { blocked_sw = value; OnPropertyChanged(); } }

		public Boolean FiveDayRebate_sw { get { return fivedayrebate_sw; } set { fivedayrebate_sw = value; OnPropertyChanged(); } }

		public Boolean FourDayRebate_sw { get { return fourdayrebate_sw; } set { fourdayrebate_sw = value; OnPropertyChanged(); } }

		public Boolean ThreeDayRebate_sw { get { return threedayrebate_sw; } set { threedayrebate_sw = value; OnPropertyChanged(); } }

		public Boolean TwoDayRebate_sw { get { return twodayrebate_sw; } set { twodayrebate_sw = value; OnPropertyChanged(); } }

		public Boolean OneDayRebate_sw { get { return onedayrebate_sw; } set { onedayrebate_sw = value; OnPropertyChanged(); } }



		public void WriteAItoGUI(String AI, String Code)
		{

			if ((AI.Equals("01") || AI.Equals("1")) && !Code.Equals(""))
			{
				GTIN_entry = Code.ToString();
			}

			else if (AI.Equals("10") && !Code.Equals(""))
			{
				BatchLot_entry = Code.ToString();
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
