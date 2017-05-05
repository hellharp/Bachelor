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
		/*	private async void SyncWithDB()
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

			}*/

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


		public ObservableCollection<Product> ResetCartlist()
		{
			list = new ObservableCollection<Product>();
			return list;
		}

		/// <summary>
		/// Method to get the price for all items in the shopping cart
		/// </summary>
		/// <returns>
		/// Returns a decimal value
		/// </returns>

		public decimal Sum(List<string> dateList)
		{
			decimal sum = 0;
			
			DateTime currDate = (DateTime)Application.Current.Properties["CurrentDate"];
			string output = "";

			//	Debug.WriteLine("!!!!!!!!!!!!!!!!!prods count er: " + list[0].ProductName.ToString());


			for (int i = 0; i < dateList.Count; i++)
			{
				if (dateList[i] != null)
					output = output + dateList[i].ToString() + " ";
			}




			Debug.WriteLine("Teller sum i CartService");
				Debug.WriteLine("Skal ta summen av antall produkter: " + list.Count);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != null)
				{
					Debug.WriteLine("I if for å telle opp sum");
					Debug.WriteLine("Rebated price: " + list[i].RebatedPrice);
					sum += list[i].RebatedPrice;
					Debug.WriteLine("Sum er: " + sum);
				}
			}

			return sum;
		}

	}
}
