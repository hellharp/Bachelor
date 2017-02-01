using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar
{
    public class ZXingTest
    {
        public async void test()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null)
            {
                Debug.WriteLine("Scanned Barcode: " + result.Text);
            }
        }
    };
}
