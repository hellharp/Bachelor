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
    /// <summary>
    /// Service which puts the correct elements in the help page
    /// </summary>
    public class HelpServices
    {
        /// <summary>
        /// Method which creates a collection of all the help elements from a given page
        /// </summary>
        /// <param name="page">
        /// Name of the page where the help button were pressed
        /// </param>
        /// <returns>
        /// Returns a ObservableCollection of type HelpItem
        /// </returns>
        public ObservableCollection<HelpItem> getHelpList(string page)
        {
			if (page.ToString().Equals("EditProductPage"))
            { 

 				ObservableCollection<HelpItem> pageItemList = new ObservableCollection<HelpItem>
                {
                    new HelpItem
					{
						ItemText = "Avhuket Sirkel",
                        Explanation = "Ved å trykke denne knappen vil man lagre produktets verdier."
                    },
                    new HelpItem
                    {
                        ItemText = "Søppelbøtte",
                        Explanation = "Ved å trykke denne knappen vil man slette produktet fra databasen."
                    },
                    new HelpItem
                    {
                        ItemText = "Sperret bryter",
                        Explanation = "Her vil man kunne sperre et produkts batch/lot nr. Alle produkter med tilsvarende batch/lot nr. vil da være stengt for salg"
                    },
                    new HelpItem
                    {
                        ItemText = "Rabatter",
                        Explanation = "Her vil man sette de ulike rabattene for de produktet. Slideren på høyre side vil avgjøre om rabatten settes i kroner eller rabatt"
                    }
                };

                return pageItemList;
            }
            else if (page.ToString().Equals("PayPage"))
            {
                ObservableCollection<HelpItem> pageItemList = new ObservableCollection<HelpItem>
                {
                    new HelpItem
                    {
                        ItemText = "Betalingsknapper",
                        Explanation = "Velg hvilken betalingsapp du ønsker å betale med. Da appen er valgt, vil varene i handlekurven bli betalt."
                    },
                    new HelpItem
                    {
                        ItemText = "Handlekurv",
                        Explanation = "Handlekurvknappen til venstre sender deg tilbake til handlekurven uten å betale."
                    },
                    new HelpItem
                    {
                        ItemText = "Meny knapp",
                        Explanation = "Menyknappen sender deg tilbake til hovedmenyen uten å ha betalt. Varene vil forbli i handlekurven."
                    }
                   
                };

                return pageItemList;
            }
            else if (page.ToString().Equals("HomeScreen"))
            {
                ObservableCollection<HelpItem> pageItemList = new ObservableCollection<HelpItem>
                {
                    new HelpItem
                    {
                        ItemText = "Handlekurv",
                        Explanation = "Handlekurvknappen sender deg til handlekurven, hvor man kan skanne varer for å legge de til i listen."
                    },
                    new HelpItem
                    {
                        ItemText = "Meny knapp",
                        Explanation = "Menyknappen sender deg til administrasjonsmenyen. Krever innlogging"
                    }

                };

                return pageItemList;
            }
            else
            {
                var errorList = new ObservableCollection<HelpItem>
                {
                    new HelpItem
                    {
                        ItemText = "ERROR",
                        Explanation = "Something didn't go as planned!"
                    }
                };


                return errorList;
            }
                
        }

    }
}
