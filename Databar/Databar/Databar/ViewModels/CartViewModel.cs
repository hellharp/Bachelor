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
using ZXing.Mobile;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Databar.ViewModels
{
	/// <summary>
	/// ViewModel for the shopping cart
	/// </summary>
	public class CartViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Product> _cartList;
		private CartServices cartServices;
		private List<Product> prods;
		private List<string> dateList;
		private String result, _GTIN;

		/// <summary>
		/// Constructor which calles cartServices and it's getCartList method
		/// </summary>
		/// <param name="_cartServices">
		/// 
		/// </param>
		public CartViewModel(CartServices _cartServices)
		{
			if (null == _cartList)
			{
				cartServices = _cartServices;
			}

			//Should be removed after everything is working
			dateList = new List<string>();

			CartList = cartServices.getCartList();
			SyncWithDB();

		}



		public ObservableCollection<Product> CartList
		{
			get { return _cartList; }
			set
			{
				_cartList = value;
				//Refreshes the user-interface every time the list is changed
				OnPropertyChanged();
			}
		}



		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}




		public decimal Sum()
		{
			OnPropertyChanged();
			//		Debug.WriteLine("I cartviewmodel datelist count: " + dateList.Count);
			return cartServices.Sum(dateList);
		}

		private async void SyncWithDB()
		{
			prods = new List<Product>();

			try
			{
				Debug.WriteLine("Prøver å synce med db");
				prods = await App.DBManager.GetProductsAsync();

			}
			catch (Exception e)
			{
				Debug.WriteLine("TestDB feil! " + e.Message);
			}

			//	Debug.WriteLine("I SyncWithDB. Productlist: " + prods.Count.ToString());
		}

		public async Task<Boolean> StartZXing(object sender, EventArgs e, string tempbarcode)
		{
			//Limit the scan to only read GS1Databar Expanded Stacked
			//Does not work for some reason


			var options = new MobileBarcodeScanningOptions();
			options.PossibleFormats = new List<ZXing.BarcodeFormat>()
			{
				ZXing.BarcodeFormat.RSS_EXPANDED
			};

			//	var scanner = new MobileBarcodeScanner();

			//	var result = await scanner.Scan(options);

			result = "(01)12345678901234(10)ABC-321(15)170502";

			DecodeBarcode(tempbarcode);

			//	AddBarcode(result.ToString());
			OnPropertyChanged();

			return AddBarcode(result.ToString());

			//Gjør noe med resultatet
			// AddBarcode(result.ToString());

		}

		public Boolean AddBarcode(String barcode)
		{
			//Sends the scanned barcode to the Service to be registered in the DB


			result = barcode;
			bool productInDB = false;

			Debug.WriteLine("prods sin count:" + prods.Count.ToString());


			//Checks the list of products in the DB with the barcode that was scanned
			Debug.WriteLine("Rett før loopet");
			Debug.WriteLine("_GTIN:" + _GTIN.ToString());
			for (int i = 0; i < prods.Count; i++)
			{
				Debug.WriteLine("I for loopet addbarcode");
				if (prods[i].GTIN.ToString().Equals(_GTIN.ToString()))
				{
					Debug.WriteLine("I if");
					prods[i].DateList = dateList;
					//SetRebate(prods[i]);
					//cartServices.Add(prods[i]);
					cartServices.Add(SetRebate(prods[i]));
					productInDB = true;
				}
			}

			return productInDB;

		}

		public void RemoveProduct(Product t)
		{
			cartServices.RemoveProduct(t);
			this.OnPropertyChanged();
		}

		private void DecodeBarcode(string barcode)
		{

			Debug.WriteLine("Databar skannet " + barcode.ToString());


			int nr = 1;


			//Finds the AI number
			String pattern = @"(?<=\().+?(?=\))";
			Match match = Regex.Match(barcode, pattern);


			Debug.WriteLine("Start på loop");

			while (match.Success)
			{
				//Should be replaced by making the above regex include the result with parenthese
				StringBuilder ai = new StringBuilder();
				ai.Append(match.Value.ToString());
				ai.Insert(0, '(');
				ai.Insert(ai.Length, ')');


				//Greps what comes after the AI
				String rest = barcode.Substring(barcode.IndexOf(ai.ToString()) + ai.Length);

				//Matches everything up to the next "(" aka start of new AI, or end of string
				Match code = Regex.Match(rest, @"^.*?(?=[(]|\Z)");

				//Write everything to the log
				Debug.WriteLine("Match nr: " + nr++ + "AI: " + match.Groups[0].Value + " Code: " + code.ToString());


				GetGTIN(match.Groups[0].Value.ToString(), code.ToString());

				//Increment match to check next AI
				match = match.NextMatch();
			}

		}

		public void GetGTIN(String AI, String Code)
		{
			Debug.WriteLine("Er i GetGtin()");

			int nr = 1;

			if ((AI.Equals("01") || AI.Equals("1")) && !Code.Equals(""))
			{
				_GTIN = Code.ToString();
			}
			if (AI.Equals("15") || AI.Equals("17"))
			{
				Debug.WriteLine("Skriver til datelist #" + nr++);
				dateList.Add(Code);
				Debug.WriteLine("Så er datelist count: " + dateList.Count);
			}

		}

		private Product SetRebate(Product p)
		{
			string closestExpirationDateString = "";
			DateTime currDate = (DateTime)Application.Current.Properties["CurrentDate"];

			for (int i = 0; i < dateList.Count; i++)
			{
				if (dateList[i] != null)
				{
					closestExpirationDateString = dateList[i];
					break;
				}
			}

			//Find the experation/bestbefore date from the barcode and set it to a DateTime

			StringBuilder date = new StringBuilder(closestExpirationDateString);

			string year = "20" + date[0].ToString() + "" + date[1].ToString();
			string month = date[2].ToString() + "" + date[3].ToString();
			string day = date[4].ToString() + "" + date[5].ToString();

			int year_int = Int32.Parse(year.ToString());
			int month_int = Int32.Parse(month.ToString());
			int day_int = Int32.Parse(day.ToString());

			DateTime closestExpirationDate = new DateTime(year_int, month_int, day_int);

			Debug.WriteLine("currdate: " + currDate.ToString());

			Debug.WriteLine("closesDate: " + closestExpirationDate.ToString());

			TimeSpan difference = closestExpirationDate - currDate;

			Debug.WriteLine("Difference in days: " + difference.Days.ToString());


			//Writes the rebate to the Product object
			if (difference.Days == 1)
			{
				p.CurrentRebate = p.OneDayRebate;
				p.CurrentRebateType = p.One_RebateType;
			}
			else if (difference.Days == 2)
			{
				p.CurrentRebate = p.TwoDaysRebate;
				p.CurrentRebateType = p.Two_RebateType;
			}
			else if (difference.Days == 3)
			{
				p.CurrentRebate = p.ThreeDaysRebate;
				p.CurrentRebateType = p.Three_RebateType;
			}
			else if (difference.Days == 4)
			{
				p.CurrentRebate = p.FourDaysRebate;
				p.CurrentRebateType = p.Four_RebateType;
			}
			else if (difference.Days == 0)
			{
				p.CurrentRebate = p.LastDayRebate;
				p.CurrentRebateType = p.Last_RebateType;
			}


			//set rebated price

			if (p.CurrentRebateType.Equals("fixed"))
			{
				p.RebatedPrice = Decimal.Parse(p.Price) - Int32.Parse(p.CurrentRebate);
			}
			else
			{
				Debug.WriteLine("Skal regne ut pris basert på prosent");
				decimal percentage = Decimal.Parse(p.CurrentRebate);
				Debug.WriteLine("Bruker prosenten: " + percentage);

				decimal total = 0;
				decimal temp = percentage / 100;

				decimal ganger = 1 - (percentage / 100);
				Debug.WriteLine("temp ble: " + temp.ToString());

				total = Decimal.Parse(p.Price) * ganger;

				p.RebatedPrice = total;

				Debug.WriteLine("Total ble: " + total);

			}

			return p;

		}


	}
}
