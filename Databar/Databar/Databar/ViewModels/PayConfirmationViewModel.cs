using Databar.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Databar.ViewModels
{
    /// <summary>
    /// The PayConfirmationViewModel binds the PayConfirmationPage together with the CartService to calculate money saved
    /// </summary>
    public class PayConfirmationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _cartList;
        private CartViewModel cartViewModel;

        /// <summary>
        /// The constructor calls the CartService and gets cartList
        /// </summary>
        public PayConfirmationViewModel()
        {
            cartViewModel = App.Current.Properties["CartViewModel"] as CartViewModel;
            var cartServices = cartViewModel.GetCartService();

            CartList = cartServices.GetCartList();
        }

        /// <summary>
        /// Method to get and set the CartList
        /// </summary>
        public ObservableCollection<Product> CartList
        {
            get { return _cartList; }
            set
            {
                _cartList = value;
                //Refreshes the View everytime the cartList is changed
                OnPropertyChanged();
            }
        }

        //Must be implemented because of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Traverses the cartList and calculates the total discount
        /// </summary>
        /// <returns>Total discount of the cartList</returns>
        public decimal TotalDiscount()
        {
            decimal totaldiscount = 0;

            for (int i = 0; i < _cartList.Count; i++)
            {
                if (_cartList[i] != null)
                    totaldiscount += Decimal.Parse(_cartList[i].Price) - _cartList[i].RebatedPrice;
            }

            return totaldiscount;
        }
    }
}

