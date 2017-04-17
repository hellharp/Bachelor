using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JsonBatchBlock
    {

        [JsonProperty("batchblocks")]
        public List<BatchBlock> BatchSet { get; set; }


        public JsonBatchBlock()
        {
            BatchSet = new List<BatchBlock>();
        }
    }
}
