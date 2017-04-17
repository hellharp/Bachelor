using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JsonWrapper
    {
        
        [JsonProperty("ais")]
        public List<AI> AISet { get; set; }

        [JsonProperty("products")]
        public List<Product> ProductSet { get; set; }

        [JsonProperty("batchblocks")]
        public List<BatchBlock> BatchSet { get; set; }

        public JsonWrapper()
        {
            AISet = new List<AI>();
            BatchSet = new List<BatchBlock>();
            ProductSet = new List<Product>();
        }

        public JsonWrapper(String property_type = "")
        {
            if (property_type == "ais")
            {
                AISet = new List<AI>();
            }
            else if (property_type == "batchblocks")
            {
                BatchSet = new List<BatchBlock>();
            }
            else if (property_type == "products")
            {
                ProductSet = new List<Product>();
            }
            else
            {
                throw new Exception("feil i Jswonwrapper");
            }
        }
    }
}
