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
using System.Diagnostics;

namespace Databar.ViewModels
{
    //denne må inheret INotifyPropertyChanged
    public class CartViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TempProd> _cartList;
        private CartServices cartServices;


        //Konstruktøren kaller cartServices og henter cartListen fra den.
        public CartViewModel(CartServices _cartServices)
        {
            if (null == _cartList)
            {
                cartServices = _cartServices;
            }

            CartList = cartServices.getCartList();
        }



        public ObservableCollection<TempProd> CartList
        {
            get { return _cartList; }
            set
            {
                _cartList = value;
                //Refresher user-interface hver gang listen blir endret
                OnPropertyChanged();
            }
        }


        //Disse må implementeres på grunn av INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        //Skal CartServices gjøre dette i stedet for CartViewModel?
        public decimal Sum()
        {
            OnPropertyChanged();
            return cartServices.Sum();
        }

        public async void StartZXing(object sender, EventArgs e)
        {
            //Limit the scan to only read GS1Databar Expanded Stacked
            //Does not work for some reason


            var options = new MobileBarcodeScanningOptions();
            options.PossibleFormats = new List<ZXing.BarcodeFormat>()
            {
                ZXing.BarcodeFormat.RSS_EXPANDED
            };

            var scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan(options);

            AddBarcode();
            OnPropertyChanged();

            //Gjør noe med resultatet
            // AddBarcode(result.ToString());

        }

        public void AddBarcode()
        {
            //Sends the scanned barcode to the Service to be registered in the DB

            cartServices.Add(new TempProd
            {
                ID = 1,
                Name = "Addet etter scan!",
                Discount = 20,
                DiscountType = "%",
                UnitCost = 10.00m
            });
        }

        public void RemoveProduct(TempProd t)
        {
            cartServices.RemoveProduct(t);
            this.OnPropertyChanged();
        }

    }


}

