using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JsonAI
    {

        [JsonProperty("ais")]
        public List<AI> AISet { get; set; }


        public JsonAI()
        {
            AISet = new List<AI>();
        }
    }
}
