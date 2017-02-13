using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Mobile;

using Xamarin.Forms;
using System.Diagnostics;

namespace Databar
{
	public partial class BasisUI : ContentPage
	{


		public BasisUI()
		{
			InitializeComponent();

			imageView.Source = Device.OnPlatform(
				iOS: ImageSource.FromFile("Icon-76.png"), //Ligger i Databar.iOS/Resources
				Android: ImageSource.FromFile("icon.png"), //Ligger i Databar.Droid/Resources/drawable
				WinPhone: null);
			   
		}   

		async void StartZXing(object sender, EventArgs e)
		{
			var scanner = new MobileBarcodeScanner();

			var result = await scanner.Scan();


			if (result != null)
				resultLabel.Text = result.Text;
			else
				resultLabel.Text = "Scan canceled";

		}
	}
}
