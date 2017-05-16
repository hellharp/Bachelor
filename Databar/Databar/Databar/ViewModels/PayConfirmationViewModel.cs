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
using System.Diagnostics;

namespace Databar.ViewModels
{
	//denne må inheret INotifyPropertyChanged
	public class PayConfirmationViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Product> _cartList;
		private CartViewModel cartViewModel;


		//Konstruktøren kaller cartServices og henter cartListen fra den.
		public PayConfirmationViewModel()
		{
			cartViewModel = App.Current.Properties["CartViewModel"] as CartViewModel;
			var cartServices = cartViewModel.GetCartService();

			CartList = cartServices.GetCartList();
		}



		public ObservableCollection<Product> CartList
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



		//Skal CartServices gjøre dette i stedet for PayConfirmationViewModel?

		public decimal TotalDiscount()
		{
			decimal totaldiscount = 0;

			Debug.WriteLine("I TotalDiscount()");
			Debug.WriteLine("Cartliste count: " + _cartList.Count);


			for (int i = 0; i < _cartList.Count; i++)
			{
				if (_cartList[i] != null)
					totaldiscount += Decimal.Parse(_cartList[i].Price) -_cartList[i].RebatedPrice;
				Debug.WriteLine("Totaldiscount: " + totaldiscount);
			}
			//totaldiscount += ((Int32.Parse(_cartList[i].Price) / 100) * Int32.Parse(_cartList[i].CurrentRebate));



			return totaldiscount;
		}

	}
}

