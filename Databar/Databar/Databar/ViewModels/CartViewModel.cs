using Databar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Databar.Services;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ZXing.Mobile;
using Xamarin.Forms;
using System.Text.RegularExpressions;

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

            CartList = cartServices.GetCartList();
            SyncWithDB();
        }

        /// <summary>
        /// Resets the cart list
        /// </summary>
        public void ResetCartlist()
        {
            cartServices.ResetCartlist();
            CartList = cartServices.ResetCartlist();
        }

        /// <summary>
        /// Method to set or get  the cart list
        /// </summary>
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

        /// <summary>
        /// Returns the cartService
        /// </summary>
        /// <returns>cartService</returns>
        public CartServices GetCartService()
        {
            return cartServices;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Calles the sum function from cartServices and returns it
        /// </summary>
        /// <returns>Returns a decimal sum of the cart list</returns>
        public decimal Sum()
        {
            OnPropertyChanged();

            return cartServices.Sum(dateList);
        }

        public void DeleteDateList()
        {
            dateList = new List<string>();
        }

        private async void SyncWithDB()
        {
            prods = new List<Product>();
            batchlist = new List<BatchBlock>();

            try
            {
                prods = await App.DBManager.GetProductsAsync();
                batchlist = await App.DBManager.GetBatchBlocksAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("TestDB feil! " + e.Message);
            }

        }

        /// <summary>
        /// Starts the barcode scanner opensource project ZXing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Returns the scanned barcode</returns>
        public async Task<String> StartZXing(object sender, EventArgs e)
        {
            SyncWithDB();

            //Limit the scan to only read GS1Databar Expanded Stacked
            var options = new MobileBarcodeScanningOptions()
            {
                PossibleFormats = new List<ZXing.BarcodeFormat>()
            {
                ZXing.BarcodeFormat.RSS_EXPANDED
            },
                TryHarder = true,
                AutoRotate = false
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


            Application.Current.Properties["ScannedCode"] = result2;

            DecodeBarcode(result2.Text);

            OnPropertyChanged();

            return AddBarcode(result2.Text);
        }

        /// <summary>
        /// Takes a barcode and first checks if it the GTIN exists in the database, returns if it does not.
        /// Secondly checks if the GTIN has a batch/lot block on it, returns if it is blocked.
        /// Valid barcodes get sent to the cartService to be added to the cart list
        /// </summary>
        /// <param name="barcode">ZXing scan result</param>
        /// <returns>A string that explains if the barcode was added or invalid for any reason</returns>
        public String AddBarcode(String barcode)
        {
            result = barcode;

            bool isBlocked = false;

            String addResult = "";



            //Checks the list of products in the DB with the barcode that was scanned
            for (int i = 0; i < prods.Count; i++)
            {
                if (prods[i].GTIN.ToString().Equals(_GTIN.ToString()))
                {
                    //Temporary fix to check date, should not be used, inefficient. Should write checkdate method instead
                    Product temp = SetRebate(prods[i]);

                    for (int p = 0; p < batchlist.Count; p++)
                    {
                        if (batchlist[p].BatchNr.Equals(batchlot) && !batchlist[p].Blocked)
                        {
                            prods[i].DateList = dateList;

                            addResult = "inDB";

                            if (!isAI17)
                            {
                                cartServices.Add(SetRebate(prods[i]));
                                return addResult;
                            }
                            else if (isAI17 && (difference.Days < 0))
                            {
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

            if (isBlocked)
                return "isBlocked";
            else
                return addResult;
        }

        /// <summary>
        /// Calls the cart service to remove a product
        /// </summary>
        /// <param name="t">Input an instance of Product</param>
        public void RemoveProduct(Product t)
        {
            cartServices.RemoveProduct(t);
            this.OnPropertyChanged();
        }

        /// <summary>
        /// Decodes the barcode into AI number + following string, and sends it to GetGTIN
        /// </summary>
        /// <param name="barcode">Input whole barcode</param>
        private void DecodeBarcode(string barcode)
        {
            //Finds the AI number
            String pattern = @"(?<=\().+?(?=\))";
            Match match = Regex.Match(barcode, pattern);

            while (match.Success)
            {
                //Can be replaced by making the above regex include the result with parenthese
                StringBuilder ai = new StringBuilder();
                ai.Append(match.Value.ToString());
                ai.Insert(0, '(');
                ai.Insert(ai.Length, ')');

                //Greps what comes after the AI
                String rest = barcode.Substring(barcode.IndexOf(ai.ToString()) + ai.Length);

                //Matches everything up to the next "(" aka start of new AI, or end of string
                Match code = Regex.Match(rest, @"^.*?(?=[(]|\Z)");

                GetGTIN(match.Groups[0].Value.ToString(), code.ToString());

                //Increment match to check next AI
                match = match.NextMatch();
            }

        }

        /// <summary>
        ///Gets GTIN and bestbefore or expiration date and batch/lot from the input string
        /// </summary>
        /// <param name="AI">DecodeBarcode AI number</param>
        /// <param name="Code">The following string after the AI number</param>
        public void GetGTIN(String AI, String Code)
        {
            isAI17 = false;

            //(01) = GTIN
            if ((AI.Equals("01") || AI.Equals("1")) && !Code.Equals(""))
            {
                _GTIN = Code;
            }
            // (15) = Best before, (17) = Expiration Date
            else if (AI.Equals("15") || AI.Equals("17"))
            {
                dateList.Add(Code);

                if (AI.Equals("17"))
                    isAI17 = true;
            }
            // (10) = Batch/lot number
            else if (AI.Equals("10") && !Code.Equals(""))
            {
                batchlot = Code;
            }
        }

        /// <summary>
        /// Takes a Product p and sets "today's" rebate and rebatetype (kr/%)
        /// </summary>
        /// <param name="p">An instance of Product</param>
        /// <returns>Returns an instance of Product with the correct Rebate and RebateType</returns>
        private Product SetRebate(Product p)
        {
            string closestExpirationDateString = "";
            DateTime currDate = (DateTime)Application.Current.Properties["CurrentDate"];
            difference = new TimeSpan();

            //Traverses the dateList to return the closest expiration date
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

            difference = closestExpirationDate - currDate;

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
                decimal percentage = Decimal.Parse(p.CurrentRebate);

                decimal total = 0;
                decimal temp = percentage / 100;

                decimal ganger = 1 - (percentage / 100);

                total = Decimal.Parse(p.Price) * ganger;

                p.RebatedPrice = total;
            }

            return p;
        }
    }
}
