
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
<<<<<<< HEAD
			await Navigation.PushAsync(new BasisUI());
=======
			//await Navigation.PushAsync(new BasisUI());
			await Navigation.PushAsync(new BasisUI()));
>>>>>>> 361923d... Commit av div endringer + paypage og PayConfirmationPage
		}

		async void ToEditProductPage(object sender, EventArgs e)
		{
<<<<<<< HEAD
			await Navigation.PushAsync(new EditProductPage());
		}

		async void ToAdminLogin(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new LoginModal());
=======
			await Navigation.PushAsync(new EditProductPage()));
>>>>>>> 361923d... Commit av div endringer + paypage og PayConfirmationPage
		}

		async void ToPayPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync((new PayPage()));	
		}

		async void ToPayConfirmationPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PayConfirmationPage()));
		}

	}
}
