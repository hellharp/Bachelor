using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Databar.Layout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		async void ToZXing(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new BasisUI());
		}

		async void ToEditProductPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new EditProductPage());
		}

		async void ToAdminLogin(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new LoginModal());
		}
	}
}
