using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin;

namespace Databar.Models
{
    /// <summary>
    /// Model for each element in a view that might need explanation
    /// </summary>
    public class HelpItem
    {
        /// <summary>
        /// String which points to which element that needs explanation if there is no image
        /// </summary>
        public string ItemText { get; set; }
        
        /// <summary>
        /// String that explains the chosen element
        /// </summary>
        public string Explanation { get; set; }
    }
}
