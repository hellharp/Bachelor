using Databar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;

namespace Databar.Services
{
    public class HelpServices
    {
		
        public ObservableCollection<HelpItem> getHelpList(string page)
        {
			if (page.ToString().Equals("EditProductPage"))
            {
				Debug.WriteLine("I if");
				FileImageSourceConverter f1 = new FileImageSourceConverter();
				Image s1 = new Image();
				s1.Source = "GS1_Symbol_OK_Circle_RGB_20150416.png";

 				ObservableCollection<HelpItem> pageItemList = new ObservableCollection<HelpItem>
                {
                    new HelpItem
					{
						NoImageText = "",
						ImageAndroid = "",
						ImageIOS = s1,
                        Explanation = "Ved å trykke denne knappen vil man lagre produktets verdier."
                    }
                   /* new HelpItem
                    {
                        NoImageText = "",
                        ImageAndroid = "gs1_remove_circle.png",
                        ImageIOS = "GS1_Symbol_Remove_Circle_RGB_20150416.png",
                        Explanation = "Ved å trykke denne knappen vil man slette produktet fra databasen."
                    },
                    new HelpItem
                    {
                        NoImageText = "Sperret",
                        ImageAndroid = "",
                        ImageIOS = "",
                        Explanation = "Her vil man kunne sperre et produkts batch/lot nr. Alle produkter med tilsvarende batch/lot nr. vil da være stengt for salg"
                    },
                    new HelpItem
                    {
                        NoImageText = "Rabatter",
                        ImageAndroid = "",
                        ImageIOS = "",
                        Explanation = "Her vil man sette de ulike rabattene for de produktet. Slideren på høyre side vil avgjøre om rabatten settes i kroner eller rabatt"
                    }*/
                };

                return pageItemList;
            }
            else
            {
                var errorList = new ObservableCollection<HelpItem>
                {
                    new HelpItem
                    {
                        NoImageText = "ERROR",
						// ImageAndroid = "",
                      //  ImageIOS = "",
                        Explanation = "Something didn't go as planned!"
                    }
                };


                return errorList;
            }
                
        }

    }
}
