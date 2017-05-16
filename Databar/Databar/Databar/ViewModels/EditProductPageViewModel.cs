using Databar.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
        private string result, gtin, batchlotentry, serial_entry, gross_entry, fivedayrebate_entry, fourdayrebate_entry, threedayrebate_entry,
                        twodayrebate_entry, onedayrebate_entry, lastdayrebate_entry, producttext_entry;

        private DateTime _BBD, _ExpD;
        private bool blocked_sw, lastdayrebate_sw, fourdayrebate_sw, threedayrebate_sw, twodayrebate_sw, onedayrebate_sw
        , _BBD_pickerActive, _ExpD_pickerActive;

        private List<Product> productList;

        private List<string> dateList;

        private List<BatchBlock> batchlotList;

        private bool IsAI17 { get; set; }
        private bool NewProduct { get; set; }
        private bool NewBatch { get; set; }
        public string GTIN_entry { get => gtin; set { gtin = value; OnPropertyChanged(); } }
        public string ProductText_entry { get => producttext_entry; set { producttext_entry = value; OnPropertyChanged(); } }
        public string BatchLot_entry { get => batchlotentry; set { batchlotentry = value; OnPropertyChanged(); } }
        public bool BBD_pickerActive { get => _BBD_pickerActive; set { _BBD_pickerActive = value; OnPropertyChanged(); } }
        public bool Expd_pickerActive { get => _ExpD_pickerActive; set { _ExpD_pickerActive = value; OnPropertyChanged(); } }
        public DateTime BBD_picker { get => _BBD; set { _BBD = value; OnPropertyChanged(); } }
        public DateTime ExpD_picker { get => _ExpD; set { _ExpD = value; OnPropertyChanged(); } }
        public string Serial_entry { get => serial_entry; set { serial_entry = value; OnPropertyChanged(); } }
        public string Gross_entry { get => gross_entry; set { gross_entry = value; OnPropertyChanged(); } }
        public string FiveDayRebate_entry { get => fivedayrebate_entry; set { fivedayrebate_entry = value; OnPropertyChanged(); } }
        public string FourDayRebate_entry { get => fourdayrebate_entry; set { fourdayrebate_entry = value; OnPropertyChanged(); } }
        public string ThreeDayRebate_entry { get => threedayrebate_entry; set { threedayrebate_entry = value; OnPropertyChanged(); } }
        public string TwoDayRebate_entry { get => twodayrebate_entry; set { twodayrebate_entry = value; OnPropertyChanged(); } }
        public string OneDayRebate_entry { get => onedayrebate_entry; set { onedayrebate_entry = value; OnPropertyChanged(); } }
        public string LastDayRebate_entry { get => lastdayrebate_entry; set { lastdayrebate_entry = value; OnPropertyChanged(); } }
        public bool Blocked_sw { get => blocked_sw; set { blocked_sw = value; OnPropertyChanged(); } }
        public bool LastDayRebate_sw { get => lastdayrebate_sw; set { lastdayrebate_sw = value; OnPropertyChanged(); } }
        public bool FourDayRebate_sw { get => fourdayrebate_sw; set { fourdayrebate_sw = value; OnPropertyChanged(); } }
        public bool ThreeDayRebate_sw { get => threedayrebate_sw; set { threedayrebate_sw = value; OnPropertyChanged(); } }
        public bool TwoDayRebate_sw { get => twodayrebate_sw; set { twodayrebate_sw = value; OnPropertyChanged(); } }
        public bool OneDayRebate_sw { get => onedayrebate_sw; set { onedayrebate_sw = value; OnPropertyChanged(); } }

        /// <summary>
        /// The ViewModel for EditProductPage
        /// </summary>
        public EditProductPageViewModel()
        {
            result = Application.Current.Properties["ScannedCode"] as String;
            BBD_pickerActive = false;
            Expd_pickerActive = false;

            SyncWithDB();
        }

        /// <summary>
        /// Connects with the DBManager to synchronize with the database
        /// </summary>
        private async void SyncWithDB()
        {
            productList = new List<Product>();
            batchlotList = new List<BatchBlock>();

            try
            {
                productList = await App.DBManager.GetProductsAsync();
                batchlotList = await App.DBManager.GetBatchBlocksAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("DB connection failed: " + e.Message);
            }

            if (result != null || !result.Equals(""))
                DecodeBarcode();
        }

        /// <summary>
        /// Takes the GTIN and returns the corresponding Product
        /// </summary>
        /// <param name="GTIN">GTIN for the product that you want returned</param>
        /// <returns></returns>
        private Product GetProduct(string GTIN)
        {
            if (productList != null)
                Debug.WriteLine("productList successfully recieved from DB");

            NewProduct = true;

            for (int i = 0; i < productList.Count; i++)
            {
                if (productList[i].GTIN.Equals(GTIN))
                {
                    NewProduct = false;
                    return productList[i];
                }
            }

            //Returns a new product instead of returning null
            Product nullProduct = new Product();
            nullProduct.GTIN = GTIN;

            return nullProduct;
        }




        /// <summary>
        /// Decodes the barcode and sends the result to the View
        /// </summary>
        private void DecodeBarcode()
        {
            //Finds the AI number
            string pattern = @"(?<=\().+?(?=\))";
            Match match = Regex.Match(result, pattern);

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

                //Write code to editProductPage
                WriteAItoGUI(match.Groups[0].Value.ToString(), code.ToString());

                //Increment match to check next AI
                match = match.NextMatch();
            }
        }

        /// <summary>
        /// Reads the date from the barcode and sets it to the View
        /// </summary>
        /// <param name="ai">Either (15) or (17)</param>
        /// <param name="code">The following string after the AI</param>
        public void SetDate(string ai, string code)
        {
            dateList = new List<string>();

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

                dateList.Add(code);
            }
            else
            {
                ExpD_picker = dateTime;

                Expd_pickerActive = true;

                dateList.Add(code);
            }
        }

        /// <summary>
        /// Takes AI and the following string and writes the result to the View
        /// </summary>
        /// <param name="AI">(01), (10), (15), (17), or (21)</param>
        /// <param name="Code">The following string after the AI</param>
        public void WriteAItoGUI(string AI, string Code)
        {
            IsAI17 = false;

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
                if (AI.Equals("17"))
                    IsAI17 = true;
            }
            else if (AI.Equals("21"))
                Serial_entry = Code.ToString();
        }

        /// <summary>
        /// Takes a Product p and writes the objects information to the View
        /// </summary>
        /// <param name="p">An instance of Product</param>
        private void SetProductInfo(Product p)
        {
            Gross_entry = p.Price;
            ProductText_entry = p.ProductName;
            FourDayRebate_entry = p.FourDaysRebate;
            ThreeDayRebate_entry = p.ThreeDaysRebate;
            TwoDayRebate_entry = p.TwoDaysRebate;
            OneDayRebate_entry = p.OneDayRebate;
            LastDayRebate_entry = p.LastDayRebate;

            //If this is null, then the rest are also null
            if (p.Four_RebateType != null)
            {
                FourDayRebate_sw = p.Four_RebateType.Equals("percent");
                ThreeDayRebate_sw = p.Three_RebateType.Equals("percent");
                TwoDayRebate_sw = p.Two_RebateType.Equals("percent");
                OneDayRebate_sw = p.One_RebateType.Equals("percent");
                LastDayRebate_sw = p.Last_RebateType.Equals("percent");
            }
            else
            {
                FourDayRebate_sw = false;
                ThreeDayRebate_sw = false;
                TwoDayRebate_sw = false;
                OneDayRebate_sw = false;
                LastDayRebate_sw = false;
            }
        }

        /// <summary>
        /// Checks whether the Batch/lot is blocked or not. Sets it to false if it is not found
        /// </summary>
        /// <param name="Code">The Batch/lot string</param>
        private void CheckBatchLotBlock(string Code)
        {
            for (int i = 0; i < batchlotList.Count; i++)
            {
                if (batchlotList[i].BatchNr.Equals(Code))
                {
                    Blocked_sw = batchlotList[i].Blocked;
                    NewBatch = false;
                    return;
                }
            }
            Blocked_sw = false;
            NewBatch = true;
        }

        //Has to be implemented because of INotifyPropertyChanged
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

        /// <summary>
        /// Saves Batch/lot to the DB
        /// </summary>
        private void SaveBatchlot()
        {
            BatchBlock b = new BatchBlock();
            b.BatchNr = BatchLot_entry;
            b.Blocked = blocked_sw;

            App.DBManager.SaveBatchBlockAsync(b, NewBatch);
        }

        /// <summary>
        /// Reads the information from the View and saves the Product to the DB
        /// </summary>
        public void SaveProduct()
        {
            Product p = new Product();

            //Skip checking these, as they are mandatory
            p.GTIN = GTIN_entry;
            p.ProductName = ProductText_entry;

            if (!Gross_entry.Equals(""))
                p.Price = Gross_entry;
            else p.Price = "0";

            //Checks for any fields not filled out and sets them to 0
            if (FourDayRebate_entry == null || FourDayRebate_entry.Equals(""))
                p.FourDaysRebate = "0";
            else p.FourDaysRebate = FourDayRebate_entry;

            if (ThreeDayRebate_entry == null || ThreeDayRebate_entry.Equals(""))
                p.ThreeDaysRebate = "0";
            else p.ThreeDaysRebate = ThreeDayRebate_entry;

            if (TwoDayRebate_entry == null || TwoDayRebate_entry.Equals(""))
                p.TwoDaysRebate = "0";
            else p.TwoDaysRebate = TwoDayRebate_entry;

            if (OneDayRebate_entry == null || OneDayRebate_entry.Equals(""))
                p.OneDayRebate = "0";
            else p.OneDayRebate = OneDayRebate_entry;

            if (LastDayRebate_entry == null || LastDayRebate_entry.Equals(""))
                p.LastDayRebate = "0";
            else p.LastDayRebate = LastDayRebate_entry;

            //Set rebate type
            if (FourDayRebate_sw == true)
                p.Four_RebateType = "percent";
            else
                p.Four_RebateType = "kr";

            if (ThreeDayRebate_sw == true)
                p.Three_RebateType = "percent";
            else
                p.Three_RebateType = "kr";

            if (TwoDayRebate_sw == true)
                p.Two_RebateType = "percent";
            else
                p.Two_RebateType = "kr";

            if (OneDayRebate_sw == true)
                p.One_RebateType = "percent";
            else
                p.One_RebateType = "kr";

            if (LastDayRebate_sw == true)
                p.Last_RebateType = "percent";
            else
                p.Last_RebateType = "kr";

            //Save the product to the DB
            App.DBManager.SaveProductAsync(p, NewProduct);
            SaveBatchlot();

            ResetView();
        }

        /// <summary>
        /// Reads the GTIN from the view and deletes the corresponding product from the DB
        /// </summary>
        public void DeleteProduct()
        {
            Product p = new Product();

            p.GTIN = GTIN_entry;

            App.DBManager.DeleteProductAsync(p);

            ResetView();
        }

        /// <summary>
        /// Clears the EditProductPage view
        /// </summary>
        public void ResetView()
        {
            GTIN_entry = "";
            ProductText_entry = "";
            BatchLot_entry = "";

            Serial_entry = "";
            Gross_entry = "";
            FiveDayRebate_entry = "";
            FourDayRebate_entry = "";
            ThreeDayRebate_entry = "";
            TwoDayRebate_entry = "";
            OneDayRebate_entry = "";
            LastDayRebate_entry = "";

            FourDayRebate_sw = false;
            ThreeDayRebate_sw = false;
            TwoDayRebate_sw = false;
            OneDayRebate_sw = false;
            LastDayRebate_sw = false;
        }
    }
}
