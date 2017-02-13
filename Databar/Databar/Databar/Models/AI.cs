using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar_skanner.Models
{
    [Table("AI")]
    public class AI
    {
        //    AI vi skal støtte:
        //    01 = Global Trade Item Number
        //    10 = Batch or lot number
        //    11 = Production date(YYMMDD)
        //    17 = Expiration date(YYMMDD)
        //    21 = Serial nr.

        [PrimaryKey]
        public int AInumber { get; set; }

        public string AIdescription { get; set; }
    }
}
