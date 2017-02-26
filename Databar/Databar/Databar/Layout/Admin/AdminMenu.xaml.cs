using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Databar.Layout.Admin
{
	public partial class AdminMenu : ContentPage
	{
		public AdminMenu()
		{
			InitializeComponent();
		}

		async void Logout(object sender, EventArgs e)
		{
			App.Current.Properties["IsLoggedIn"] = false;
			App.Current.MainPage = new NavigationPage(new Layout.MainPage());
			//await Navigation.PopAsync();
		}
	}
}
