using Databar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Product> GetCartList()
        {
            return list;
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


            for (int i = 0; i < dateList.Count; i++)
            {
                if (dateList[i] != null)
                    output = output + dateList[i].ToString() + " ";
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    sum += list[i].RebatedPrice;
                }
            }

            return sum;
        }

    }
}
