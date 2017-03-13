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
    class EditProductPageViewModel 
    {
        private Product _product;

        public EditProductPageViewModel()
        {
       //Hent product med metode fra RestSQL
        }

        public Product EditProduct
        {
            get { return _product; }
            set
            {
                _product = value;
            }
        }

        public void GetProduct(Int64 GTIN)
        {
            //_product = DB_Service.GetProduct(GTIN);
        }

        public void SaveProduct()
        {
            //DB_Service.AddProduct(_product);
        }

        public void DeleteProduct()
        {
            //DB_Service.RemoveProduct(_product);
        }
    }
}
