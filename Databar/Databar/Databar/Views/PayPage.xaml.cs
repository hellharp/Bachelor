using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Databar.Views
{
    public partial class PayPage : ContentPage
    {
        public PayPage()
        {
            InitializeComponent();
        }

		async void ToPayConfirmationPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PayConfirmationPage());
		}

		async void ToShoppingCart(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ShoppingCart());
		}
    }
}
