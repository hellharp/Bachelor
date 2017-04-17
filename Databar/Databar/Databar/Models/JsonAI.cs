using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Models
{
    /// <summary>
    /// Json-wrapper for AI, to send and receive Lists of AI-objects as JSON-arrays. 
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JsonAI
    {
        /// <summary>
        /// List of type AI, JSON-array-name "ais".
        /// </summary>
        [JsonProperty("ais")]
        public List<AI> AISet { get; set; }

        /// <summary>
        /// Constructor for JsonAI, instantiates an empty AISet.
        /// </summary>
        public JsonAI()
        {
            AISet = new List<AI>();
        }
    }
}
