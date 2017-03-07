using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;


namespace Databar.Views
{
	public partial class PayConfirmationPage : ContentPage
	{
		public PayConfirmationPage()
		{
			InitializeComponent();
		}

		async void CloseWindow(object sender, EventArgs e)
		{
			App.Current.MainPage = new NavigationPage(new Views.MainPage());
		}
	}
}
