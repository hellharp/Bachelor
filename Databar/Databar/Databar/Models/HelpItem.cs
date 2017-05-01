using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin;

namespace Databar.Models
{
    public class HelpItem
    {
        public string NoImageText { get; set; }
		public string ImageAndroid { get; set; }
		public Image ImageIOS { get; set; }
        public string Explanation { get; set; }

    }
}
