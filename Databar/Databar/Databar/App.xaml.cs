
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Databar.Services;
using Databar.Models;
using Databar.ViewModels;

using Xamarin.Forms;

namespace Databar
{
    public partial class App : Application
    {
        public static DBRestManager DBManager { get; private set; }
        public static CartViewModel _CartViewModel { get; set; }
        //public static CartServices _CartServices { get; set; }
        public App()
        {
            InitializeComponent();

            // "Global" variable to keep track of admin-login status
            var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;

            // Global variable for current (possibly overridden) date. Initialize as today.
            Current.Properties["CurrentDate"] = DateTime.Today;
			decimal i = 0;
			Current.Properties["Cartsum"] = i; 

            // Initialize DBRestManager
            DBManager = new DBRestManager(new RestService());


            //Velger hvilken xaml som først starter. I dette tilfellet MainPage.xaml
            MainPage = new NavigationPage(new Views.MainPage());


            //Inistialiserer objektene som trengs for å håndtere handlekurven
            _CartViewModel = new CartViewModel(new CartServices());


        }
     

        protected override void OnStart()
        {
            base.OnStart();

            // Handle when your app starts

            // Initialize database
            //DB_Service.Instance.CreateDbIfNotExist();

            // Global variable for Admin-status
            Current.Properties["IsLoggedIn"] = false;

            // Global variable for current (possibly overridden) date. Initialize as today.
            Current.Properties["CurrentDate"] = DateTime.Today;

            // Global variable for scanned barcode
            Current.Properties["ScannedCode"] = "";

            //Globak state for cart
            Application.Current.Properties["CartViewModel"] = _CartViewModel;
            
        }
       

        protected override void OnSleep()
        {
            base.OnSleep();
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            base.OnResume();
            // Handle when your app resumes
        }
    }
}
