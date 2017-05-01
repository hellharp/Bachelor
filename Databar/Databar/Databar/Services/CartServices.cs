using Databar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Databar.Services
{
	public class CartServices : ContentPage
	{
		ObservableCollection<Product> list = new ObservableCollection<Product>();
		List<Product> prods = new List<Product>();

		//denne skal hente fra sql
		public ObservableCollection<Product> getCartList()
		{
			//var list = new ObservableCollection<TempProd>
			return list;
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

		public void Add(Product e)
		{
			list.Add(e);
		}

		public void RemoveProduct(Product t)
		{
			list.Remove(t);
		}

		public decimal Sum()
		{
			decimal sum = 0;
			DateTime currDate = (DateTime)Application.Current.Properties["CurrentDate"];





	/*		for (int i = 0; i < list.Count; i++)
			{
				Debug.WriteLine("HEI");
				Debug.WriteLine(list.Count);

				if (list[i].Discount == 0)
				{
					Debug.WriteLine("INN EN");
					sum += list[i].UnitCost;
				}
				else
				{
					Debug.WriteLine("INN TO");
					// sum += (list[i].UnitCost * (list[i].Discount / 100));
					sum += (list[i].UnitCost);
				}
			}
			Debug.WriteLine("HEI");
			Debug.WriteLine(sum.ToString());*/
			return sum;
		}

	}
}
