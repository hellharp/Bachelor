﻿using System;
using Databar.Models;
using Databar.ViewModels;
using Xamarin.Forms;


namespace Databar.Views
{
	public partial class PayConfirmationPage : ContentPage
	{
		private PayConfirmationViewModel payConfirmationViewModel;

		public PayConfirmationPage()
		{
			InitializeComponent();

			//Gets PayConfirmationViewModel
			payConfirmationViewModel = new PayConfirmationViewModel();

			CalculateDiscountPrice();

		}

		//Calculate total discount
		private void CalculateDiscountPrice()
		{
			decimal discountnumber = payConfirmationViewModel.DiscountSum();
			DiscountSumLabel.Text = discountnumber.ToString() + ",-";
		}

		async void CloseWindow(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Views.MainPage());
		}
	}
}
