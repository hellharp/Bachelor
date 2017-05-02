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
	/// Model for saving blocked batchnumbers
    /// If Blocked == True the batchnumber will be blocked for sale
    /// Default is False
	/// </summary>
    [Table("BatchBlock")]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BatchBlock
    {
        // String to handle non-letter characters 
        [PrimaryKey, MaxLength(20)]
        [JsonProperty(PropertyName = "BatchNr")]
        public string BatchNr { get; set; }

        // SQLite does not have a separate Boolean storage class.
        // Instead, Boolean values are stored as integers 0 (false) and 1 (true).
        [JsonProperty(PropertyName = "Blocked")]
        public Boolean Blocked { get; set; }

    }
}
