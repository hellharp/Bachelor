using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JsonProduct
    {

        [JsonProperty("products")]
        public List<Product> ProductSet { get; set; }


        public JsonProduct()
        {
            ProductSet = new List<Product>();
        }
    }
}
