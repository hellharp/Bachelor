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

            //Velger hvilken xaml som først starter. I dette tilfellet BasisUI.xaml
            MainPage = new Layout.EditProductPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            DB_Service.Instance.CreateDbIfNotExist();
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
