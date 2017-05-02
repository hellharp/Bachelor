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

		
        /// <summary>
        /// Get method for items in the shopping cart
        /// </summary>
        /// <returns>
        /// Returns ObservableCollection of type Product
        /// </returns>
		public ObservableCollection<Product> getCartList()
		{
			return list;
		}

        /// <summary>
        /// Method for synchronizing the shoppingcart with the database
        /// </summary>
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

        /// <summary>
        /// Method to add a Product to the shopping cart
        /// </summary>
        /// <param name="e">
        /// Adds the product with the variable name equal to e
        /// </param>
		public void Add(Product e)
		{
			list.Add(e);
		}

        /// <summary>
        /// Method to remove a Product from the shopping cart
        /// </summary>
        /// <param name="t">
        /// Removes the product with the variable name equal to t
        /// </param>
		public void RemoveProduct(Product t)
		{
			list.Remove(t);
		}

        /// <summary>
        /// Method to get the price for all items in the shopping cart
        /// </summary>
        /// <returns>
        /// Returns a decimal value
        /// </returns>
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
