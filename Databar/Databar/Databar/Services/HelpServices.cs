using Databar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Services
{
    public class HelpServices
    {
        public ObservableCollection<HelpItem> getHelpList(string page)
        {
            if (page.Equals("EditProductPage"))
            {
                var pageItemList = new ObservableCollection<HelpItem>
                {
                    new HelpItem
                    {
                        NoImageText = "",
                        ImageAndroid = "gs1_ok_circle.png",
                        ImageIOS = "GS1_Symbol_OK_Circle_RGB_20150416.png",
                        Explanation = "Ved å trykke denne knappen vil man lagre produktets verdier."
                    },
                    new HelpItem
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
                    }
                };

                return pageItemList;
            }
            else
                return null;
        }

    }
}
