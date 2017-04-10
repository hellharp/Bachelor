using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Models
{
    public class JsonWrapper
    {
        [JsonProperty("ais")]
        public List<AI> AISet { get; set; }

        [JsonProperty("products")]
        public List<Product> ProductSet { get; set; }

        [JsonProperty("batchblocks")]
        public List<BatchBlock> BatchSet { get; set; }
    }
}
