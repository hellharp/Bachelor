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

        private Label label;
        public BasisUI()
        {
            InitializeComponent();
       
        }

        async void StartZXing(object sender, EventArgs e)
        {
            var scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null)
            {
                Debug.WriteLine("Scanned Barcode: " + result.Text);

            }

        }
    }
}
