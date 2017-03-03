using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Databar.Layout
{
    public partial class PayPage : ContentPage
    {
        public PayPage()
        {
            InitializeComponent();
        }

		async void ToPayConfirmationPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PayConfirmationPage());
		}
    }
}
