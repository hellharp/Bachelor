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
		private List<BatchBlock> batchlist;
		private List<string> dateList;
		private String result, _GTIN, batchlot;
		private Boolean isAI17;
		private TimeSpan difference;

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

		public void ResetCartlist()
		{
			cartServices.ResetCartlist();
			CartList = cartServices.ResetCartlist();
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

		public CartServices GetCartService()
		{
			return cartServices;
		}



		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}



		public decimal Sum()
		{
			OnPropertyChanged();
			Debug.WriteLine("I cartviewmodel datelist count: " + dateList.Count);

			return cartServices.Sum(dateList);
		}

		public void SlettDateList()
		{
			dateList = new List<string>();
		}

		private async void SyncWithDB()
		{
			prods = new List<Product>();
			batchlist = new List<BatchBlock>();

			try
			{
				Debug.WriteLine("Prøver å synce med db");
				prods = await App.DBManager.GetProductsAsync();
				batchlist = await App.DBManager.GetBatchBlocksAsync();

			}
			catch (Exception e)
			{
				Debug.WriteLine("TestDB feil! " + e.Message);
			}

		}

		public async Task<String> StartZXing(object sender, EventArgs e)
		{
			//Limit the scan to only read GS1Databar Expanded Stacked
			//Does not work for some reason
			SyncWithDB();

		/*	var options = new MobileBarcodeScanningOptions();
			options.PossibleFormats = new List<ZXing.BarcodeFormat>()
			{
				ZXing.BarcodeFormat.RSS_EXPANDED
			};

			var scanner = new MobileBarcodeScanner();

			var result2 = await scanner.Scan(options);

			
            if (result2 == null)
            {
                return "userAbort";
            }
            else if (result2.ToString().Length < 16)
            {
                return "barcodeFail";
            }

    */
            Application.Current.Properties["ScannedCode"] = "(01)07048840000036(10)ABC321(15)170517";

			DecodeBarcode("(01)07048840000036(10)ABC321(15)170517");

			OnPropertyChanged();

            return AddBarcode("(01)07048840000036(10)ABC321(15)170517");
         


        }

		public String AddBarcode(String barcode)
		{

			result = barcode;

			bool isBlocked = false;

			String addResult = "";



			Debug.WriteLine("prods sin count:" + prods.Count.ToString());


			//Checks the list of products in the DB with the barcode that was scanned
			Debug.WriteLine("Rett før loopet");
			Debug.WriteLine("_GTIN:" + _GTIN.ToString());
			for (int i = 0; i < prods.Count; i++)
			{
				Debug.WriteLine("I for loopet addbarcode");
				if (prods[i].GTIN.ToString().Equals(_GTIN.ToString()))
				{
					//Temporary fix to check date, should not be used, inefficient. Should write checkdate method instead
					Product temp = SetRebate(prods[i]);

					for (int p = 0; p < batchlist.Count; p++)
					{
						
						if (batchlist[p].BatchNr.Equals(batchlot) && !batchlist[p].Blocked)
						{
							Debug.WriteLine("I if");
							prods[i].DateList = dateList;

						

							Debug.WriteLine("JEGERHER!!!!!");
							addResult = "inDB";
							Debug.WriteLine("Returnerer productInDb øverst: " + addResult);

							if (!isAI17)
							{
								cartServices.Add(SetRebate(prods[i]));
								return addResult;
							}

							else if (isAI17 && (difference.Days < 0))
							{
						

								Debug.WriteLine("Diff holdbar: " + difference.Days.ToString());
					
									return "expirDate";
					
							}
							else
							{
								cartServices.Add(SetRebate(prods[i]));
								return addResult;
							}
								
						}
						else
						{
							addResult = "isBlocked";
							isBlocked = true;
						
						}
						

					}
	

				}
				else 
					addResult = "notinDB";
			}

			//Sjekk datoen her!

			Debug.WriteLine("Returnerer productInDb: " + addResult);

			if (isBlocked)
				return "isBlocked";
			else 
				return addResult;

		}

		public void RemoveProduct(Product t)
		{
			cartServices.RemoveProduct(t);
			this.OnPropertyChanged();
		}

		private void DecodeBarcode(string barcode)
		{
			//dateList = new List<string>();

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
			isAI17 = false;

			int nr = 1;

			if ((AI.Equals("01") || AI.Equals("1")) && !Code.Equals(""))
			{
				_GTIN = Code;
			}
			else if (AI.Equals("15") || AI.Equals("17"))
			{
				Debug.WriteLine("Skriver til datelist #" + nr++);
				dateList.Add(Code);
				Debug.WriteLine("Så er datelist count: " + dateList.Count);
				if (AI.Equals("17"))
					isAI17 = true;
			}
			else if (AI.Equals("10") && !Code.Equals(""))
			{
				batchlot = Code;
			}

		}

		private Product SetRebate(Product p)
		{
			string closestExpirationDateString = "";
			DateTime currDate = (DateTime)Application.Current.Properties["CurrentDate"];
			difference = new TimeSpan();

			for (int i = 0; i < dateList.Count; i++)
			{
				if (dateList[i] != null)
				{
					closestExpirationDateString = dateList[i];
					Debug.WriteLine("Closest er: " + dateList[i].ToString());
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

			difference = closestExpirationDate - currDate;

			Debug.WriteLine("Difference in days: " + difference.Days.ToString());

			if (difference.Days < 0)
			{
			}


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
			else if (difference.Days > 4)
			{
				p.CurrentRebate = "0";
				p.CurrentRebateType = "kr";
			}
			else if (difference.Days < 0)
			{
				p.CurrentRebate = "100";
				p.CurrentRebateType = "percent";
			}



			//set rebated price

			if (p.CurrentRebateType.Equals("kr"))
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

			//nylig

			Debug.WriteLine("Det returnerte produktet har info. Rabpris: " + p.RebatedPrice + " CurrentRebate: " + p.CurrentRebate
							+ " Currentrebatetype: " + p.CurrentRebateType);


			return p;

		}


	}
}
