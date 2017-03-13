using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace DatabarRESTService.Models
{
    [Table("Product")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(14)]
        public long GTIN { get; set; }

        // Produktbeskrivelse
        public string ProductName { get; set; }

        // Utløpsdato dekker best før/siste forbruksdato
        public DateTime BestBeforeDate { get; set; }

        // Serienummer
        public string SerialNumber { get; set; }

        // Fire dager før utløpsdato
        public double FourDaysRebate { get; set; }

        // Tre dager før utløpsdato
        public double ThreeDaysRebate { get; set; }

        // To dager før utløpsdato
        public double TwoDaysRebate { get; set; }

        // En dag før utløpsdato
        public double OneDayRebate { get; set; }

        // På utløpsdatoen
        public double LastDayRebate { get; set; }
    }
}
