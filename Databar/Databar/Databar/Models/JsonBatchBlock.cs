using Newtonsoft.Json;
using System.Collections.Generic;

namespace Databar.Models
{
    /// <summary>
    /// Json-wrapper for BatchBlock, to send and receive Lists of BatchBlock-objects as JSON-arrays. 
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JsonBatchBlock
    {
        /// <summary>
        /// List of type BatchBlock, JSON-array-name "batchblocks".
        /// </summary>
        [JsonProperty("batchblocks")]
        public List<BatchBlock> BatchSet { get; set; }

        /// <summary>
        /// Constructor for JsonBatchBlock, instantiates an empty BatchSet.
        /// </summary>
        public JsonBatchBlock()
        {
            BatchSet = new List<BatchBlock>();
        }
    }
}
