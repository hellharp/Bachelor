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

namespace Databar.ViewModels
{
	//denne må inheret INotifyPropertyChanged
	public class PayConfirmationViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Product> _cartList;


		//Konstruktøren kaller cartServices og henter cartListen fra den.
		public PayConfirmationViewModel()
		{
			var cartServices = new CartServices();

			CartList = cartServices.getCartList();
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

			/*for (int i = 0; i < _cartList.Count; i++)
			{
				if (_cartList[i].Discount == 0)
				{
					totaldiscount += 0;
				}
				else
				{
					totaldiscount += ((_cartList[i].UnitCost / 100) * _cartList[i].Discount);
				}
			}*/

			return totaldiscount;
		}

	}
}

