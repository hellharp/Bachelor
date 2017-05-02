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
			return cartServices.Sum();
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

			Debug.WriteLine("I SyncWithDB. Productlist: " + prods.Count.ToString());
		}

		public async Task<Boolean> StartZXing(object sender, EventArgs e)
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

			DecodeBarcode();

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
					cartServices.Add(prods[i]);
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
				GetGTIN(match.Groups[0].Value.ToString(), code.ToString());

				//Increment match to check next AI
				match = match.NextMatch();
			}

		}

		public void GetGTIN(String AI, String Code)
		{
			Debug.WriteLine("Er i GetGtin()");

			if ((AI.Equals("01") || AI.Equals("1")) && !Code.Equals(""))
			{
				_GTIN = Code.ToString();
			}

		}


	}
}
