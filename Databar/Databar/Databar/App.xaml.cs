﻿
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Databar.Services;

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

            // Global variable for current (possibly overridden) date. Initialize as today.
            App.Current.Properties["CurrentDate"] = DateTime.Today;

            //Velger hvilken xaml som først starter. I dette tilfellet MainPage.xaml
            MainPage = new NavigationPage(new Views.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            // Initialize database
            //DB_Service.Instance.CreateDbIfNotExist();

            // Global variable for Admin-status
            App.Current.Properties["IsLoggedIn"] = false;

            // Global variable for current (possibly overridden) date. Initialize as today.
            App.Current.Properties["CurrentDate"] = DateTime.Today;

            // Global variable for scanned barcode
            App.Current.Properties["ScannedCode"] = "";
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
