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

namespace Databar.ViewModels
{
    //denne må inheret INotifyPropertyChanged
    public class CartViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TempProd> _cartList;


        //Konstruktøren kaller cartServices og henter cartListen fra den.
        public CartViewModel()
        {
            var cartServices = new CartServices();

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
            decimal sum = 0;

            for (int i = 0; i < _cartList.Count; i++)
            {
                if (_cartList[i].Discount == 0)
                {
                    sum += _cartList[i].UnitCost;
                }
                else
                {
                    sum += (_cartList[i].UnitCost * (_cartList[i].Discount / 100));
                }
            }

            return sum;
        }

        public async void StartZXing(object sender, EventArgs e)
        {
            var scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan();


            //Gjør noe med resultatet
           // AddBarcode(result.ToString());

        }

        public void AddBarcode(String e)
        {
            //Sends the scanned barcode to the Service to be registered in the DB
            //CartServices.Add(e);
        }

    }
}

