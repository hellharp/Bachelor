using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Databar_skanner.Models
{
    [Table("CategoryRebate")]
    public class CategoryRebate
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [PrimaryKey]
        public string Category { get; set; }

        // To dager før utløpsdato
        public double TwoDaysRebate { get; set; }

        // En dag før utløpsdato
        public double OneDayRebate { get; set; }

        // På utløpsdatoen
        public double LastDayRebate { get; set; }
    }
}
