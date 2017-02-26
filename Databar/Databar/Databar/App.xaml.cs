using Databar.Data;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Databar
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			// "Global" variable to keep track of admin-login status
			var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;

			//Velger hvilken xaml som først starter. I dette tilfellet MainPage.xaml
			
			MainPage = new NavigationPage(new Layout.MainPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
			DB_Service.Instance.CreateDbIfNotExist();
			App.Current.Properties["IsLoggedIn"] = false;
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
