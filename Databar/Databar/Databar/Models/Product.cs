using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Databar_skanner.Models
{
    [Table("Product")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(14)]
        public long GTIN { get; set; }

        [ForeignKey(typeof(CategoryRebate))]
        public string Category { get; set; }

        public string ProductName { get; set; }

        // Utløpsdato dekker best før/siste forbruksdato
        public DateTime BestBeforeDate { get; set; }
    }
}
