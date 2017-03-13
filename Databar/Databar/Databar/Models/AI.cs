using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar_skanner.Models
{
	/// <summary>
	/// Model for Application Identifier consisting of an AI number and an AI description.
	/// </summary>
	[Table("AI")]
	public class AI
	{
		/// <summary>
		/// Application Identifier.
		/// </summary>
		/// <remarks>
		/// Our application currently supports the following AIs:
		/// 01: Global Trade Item Number
		/// 10: Batch or Lot number
		/// 17: Expiration date (YYMMDD)
		/// 21: Serial number
		/// </remarks>
		[PrimaryKey]
		public int AInumber { get; set; }

		/// <summary>
		/// Description of AI.
		/// </summary>
		public string AIdescription { get; set; }
	}
}
