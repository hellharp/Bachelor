using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Models
{
	/// <summary>
	/// Model for Application Identifier consisting of an AI number and an AI description.
	/// </summary>
	[Table("AI")]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AI
	{
		/// <summary>
		/// Application Identifier.
		/// </summary>
		/// <remarks>
		/// The Databar application is currently meant to support the following AIs:
		/// 01: Global Trade Item Number (GTIN)
		/// 10: Batch or Lot number (BATCH/LOT)
        /// 15: Best before date (BEST BEFORE or SELL BY)
		/// 17: Expiration date (USE BY or EXPIRY)
		/// 21: Serial number (SERIAL)
		/// </remarks>
		[PrimaryKey, MaxLength(4)]
        [JsonProperty(PropertyName = "AInumber")]
        public int AInumber { get; set; }

        /// <summary>
        /// Description of AI.
        /// </summary>
        [MaxLength(100)]
        [JsonProperty(PropertyName = "AIdescription")]
        public string AIdescription { get; set; }
	}
}
