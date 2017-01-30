using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Databar_skanner.Database
{
    [Table("AI")]
    class AI
    {
        //    AI vi skal støtte:
        //    01 = Global Trade Item Number
        //    10 = Batch or lot number
        //    11 = Production date(YYMMDD)
        //    13 = Packaging date(YYMMDD)
        //    15 = Best before date(YYMMDD)
        //    17 = Expiration date(YYMMDD)

        [PrimaryKey]
        public int AInumber { get; set; }

        public int AIdescription { get; set; }
    }
}
