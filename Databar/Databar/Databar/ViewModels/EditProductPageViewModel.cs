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
						twodayrebate_entry, onedayrebate_entry, lastdayrebate_entry, producttext_entry;

		private DateTime _BBD, _ExpD;
		private Boolean blocked_sw, lastdayrebate_sw, fourdayrebate_sw, threedayrebate_sw, twodayrebate_sw, onedayrebate_sw
		, _BBD_pickerActive, _ExpD_pickerActive;

		private List<Product> productList;

		private List<BatchBlock> batchlotList;


		public EditProductPageViewModel()
		{
			//Hent product med metode fra RestSQL

			result = Application.Current.Properties["ScannedCode"] as String;
			BBD_pickerActive = false;
			Expd_pickerActive = false;

			SyncWithDB();

		}

		private async void SyncWithDB()
		{
			productList = new List<Product>();
			batchlotList = new List<BatchBlock>();
			try
			{
				Debug.WriteLine("Prøver å synce med db");
				productList = await App.DBManager.GetProductsAsync();
				batchlotList = await App.DBManager.GetBatchBlocksAsync();
			}
			catch (Exception e)
			{
				Debug.WriteLine("TestDB feil! " + e.Message);
			}

			Debug.WriteLine("I SyncWithDB. Productlist: " + productList.Count.ToString() + " Batch: " + batchlotList.Count.ToString());

			if (result != null || !result.Equals(""))
				DecodeBarcode();

		}


		private Product GetProduct(String GTIN)
		{

			if (productList != null)
				Debug.WriteLine("produktliste er ikke null");


			//Debug.WriteLine("Finnes produktlist: " + productList.Count());



			for (int i = 0; i < productList.Count; i++)
			{
				if (productList[i].GTIN.Equals(GTIN.ToString()))
					return productList[i];
			}

			//Returns a new product instead of returning null
			Product nullProduct = new Product();
			nullProduct.GTIN = GTIN;

			return nullProduct;
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


		public void SetDate(String ai, String code)
		{
			

			StringBuilder date = new StringBuilder(code);

			String year = "20" + date[0].ToString() + "" + date[1].ToString();
			String month = date[2].ToString() + "" + date[3].ToString();
			String day = date[4].ToString() + "" + date[5].ToString();

			int year_int = Int32.Parse(year.ToString());
			int month_int = Int32.Parse(month.ToString());
			int day_int = Int32.Parse(day.ToString());

			DateTime dateTime = new DateTime(year_int, month_int, day_int);

			if (ai.Equals("15"))
			{
				BBD_picker = dateTime;
				BBD_pickerActive = true;
			
			}

			else
			{
				ExpD_picker = dateTime;
				Expd_pickerActive = true;

			}

		}


		public void WriteAItoGUI(String AI, String Code)
		{

			if ((AI.Equals("01") || AI.Equals("1")) && !Code.Equals(""))
			{
				GTIN_entry = Code.ToString();
				SetProductInfo(GetProduct(Code));
			}

			else if (AI.Equals("10") && !Code.Equals(""))
			{
				BatchLot_entry = Code.ToString();
				CheckBatchLotBlock(Code);
			}
			else if (AI.Equals("15") || AI.Equals("17"))
			{
				SetDate(AI, Code);
			}



		}

		//Sends the Product's information to the view
		private void SetProductInfo(Product p)
		{
			Gross_entry = p.Price;
			ProductText_entry = p.ProductName;
			FourDayRebate_entry = p.FourDaysRebate;
			ThreeDayRebate_entry = p.ThreeDaysRebate;
			TwoDayRebate_entry = p.TwoDaysRebate;
			OneDayRebate_entry = p.OneDayRebate;
			LastDayRebate_entry = p.LastDayRebate;


			if (p.FourDaysRebate != null)
			{

				FourDayRebate_sw = p.Four_RebateType.Equals("percent");
				ThreeDayRebate_sw = p.Three_RebateType.Equals("percent");
				TwoDayRebate_sw = p.Two_RebateType.Equals("percent");
				OneDayRebate_sw = p.One_RebateType.Equals("percent");
				LastDayRebate_sw = p.Last_RebateType.Equals("percent");
			}

		}

		//Checks whether the BatchLot is blocked or not. Sets it to false if it is not found
		private void CheckBatchLotBlock(String Code)
		{
			for (int i = 0; i < batchlotList.Count; i++)
			{
				if (batchlotList[i].BatchNr.Equals(Code.ToString()))
				{
					Blocked_sw = batchlotList[i].Blocked;
					return;
				}
			}
			Blocked_sw = false;
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

		public void SaveProduct()
		{
			Product p = new Product();

			p.GTIN = GTIN_entry;
			p.ProductName = ProductText_entry;
			p.FourDaysRebate = FourDayRebate_entry;
			p.ThreeDaysRebate = ThreeDayRebate_entry;
			p.TwoDaysRebate = TwoDayRebate_entry;
			p.OneDayRebate = OneDayRebate_entry;
			p.LastDayRebate = LastDayRebate_entry;
			p.Price = Gross_entry;


			//Set rebate type

			if (FourDayRebate_sw == true)
				p.Four_RebateType = "percent";
			else
				p.Four_RebateType = "fixed";

			if (ThreeDayRebate_sw == true)
				p.Three_RebateType = "percent";
			else
				p.Three_RebateType = "fixed";

			if (TwoDayRebate_sw == true)
				p.Two_RebateType = "percent";
			else
				p.Two_RebateType = "fixed";

			if (OneDayRebate_sw == true)
				p.One_RebateType = "percent";
			else
				p.One_RebateType = "fixed";

			if (LastDayRebate_sw == true)
				p.Last_RebateType = "percent";
			else
				p.Last_RebateType = "fixed";

			//Save the product to the DB
			App.DBManager.SaveProductAsync(p, true);

		}

		public void DeleteProduct()
		{
			Product p = new Product();

			p.GTIN = GTIN_entry;

			Debug.WriteLine("Starter delete");
			Debug.WriteLine("sjekker GTIN: " + p.GTIN.ToString());
			App.DBManager.DeleteProductAsync(p);
		}



		public String GTIN_entry { get { return gtin; } set { gtin = value; OnPropertyChanged(); } }

		public String ProductText_entry { get { return producttext_entry; } set { producttext_entry = value; OnPropertyChanged(); } }

		public String BatchLot_entry { get { return batchlotentry; } set { batchlotentry = value; OnPropertyChanged(); } }

		public Boolean BBD_pickerActive { get { return _BBD_pickerActive; } set { _BBD_pickerActive = value; OnPropertyChanged(); } } 

		public Boolean Expd_pickerActive { get { return _ExpD_pickerActive; } set { _ExpD_pickerActive = value; OnPropertyChanged(); } }

		public DateTime BBD_picker { get { return _BBD; } set { _BBD = value; OnPropertyChanged(); } }

		public DateTime ExpD_picker { get { return _ExpD; } set { _ExpD = value; OnPropertyChanged(); } }
		
		public String Serial_entry { get { return serial_entry; } set { serial_entry = value; OnPropertyChanged(); } }

		public String Gross_entry { get { return gross_entry; } set { gross_entry = value; OnPropertyChanged(); } }

		public String FiveDayRebate_entry { get { return fivedayrebate_entry; } set { fivedayrebate_entry = value; OnPropertyChanged(); } }

		public String FourDayRebate_entry { get { return fourdayrebate_entry; } set { fourdayrebate_entry = value; OnPropertyChanged(); } }

		public String ThreeDayRebate_entry { get { return threedayrebate_entry; } set { threedayrebate_entry = value; OnPropertyChanged(); } }

		public String TwoDayRebate_entry { get { return twodayrebate_entry; } set { twodayrebate_entry = value; OnPropertyChanged(); } }

		public String OneDayRebate_entry { get { return onedayrebate_entry; } set { onedayrebate_entry = value; OnPropertyChanged(); } }

		public String LastDayRebate_entry { get { return lastdayrebate_entry; } set { lastdayrebate_entry = value; OnPropertyChanged(); } }

		public Boolean Blocked_sw { get { return blocked_sw; } set { blocked_sw = value; OnPropertyChanged(); } }

		public Boolean LastDayRebate_sw { get { return lastdayrebate_sw; } set { lastdayrebate_sw = value; OnPropertyChanged(); } }

		public Boolean FourDayRebate_sw { get { return fourdayrebate_sw; } set { fourdayrebate_sw = value; OnPropertyChanged(); } }

		public Boolean ThreeDayRebate_sw { get { return threedayrebate_sw; } set { threedayrebate_sw = value; OnPropertyChanged(); } }

		public Boolean TwoDayRebate_sw { get { return twodayrebate_sw; } set { twodayrebate_sw = value; OnPropertyChanged(); } }

		public Boolean OneDayRebate_sw { get { return onedayrebate_sw; } set { onedayrebate_sw = value; OnPropertyChanged(); } }

	}
}
