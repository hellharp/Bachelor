﻿using System;
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
            MainPage = new Databar.BasisUI();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
