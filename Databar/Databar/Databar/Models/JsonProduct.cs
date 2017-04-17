using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Models
{
    /// <summary>
    /// Json-wrapper for Product, to send and receive Lists of Product-objects as JSON-arrays. 
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JsonProduct
    {
        /// <summary>
        /// List of type Product, JSON-array-name "products".
        /// </summary>
        [JsonProperty("products")]
        public List<Product> ProductSet { get; set; }

        /// <summary>
        /// Constructor for JsonProduct, instantiates an empty ProductSet.
        /// </summary>
        public JsonProduct()
        {
            ProductSet = new List<Product>();
        }
    }
}
