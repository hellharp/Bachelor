using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Databar.Models
{
    [Table("Product")]
    public class Product
    {
        //[PrimaryKey, AutoIncrement]
        //public int ID { get; set; }

        [PrimaryKey, MaxLength(14)]
        public long GTIN { get; set; }

        // Produktbeskrivelse
        [MaxLength(100)]
        public string ProductName { get; set; }

        //// Utløpsdato dekker best før/siste forbruksdato
        //public DateTime BestBeforeDate { get; set; }

        // Serienummer
        [MaxLength(20)]
        public string SerialNumber { get; set; }

        // Fire dager før utløpsdato
        [MaxLength(10)]
        public string FourDaysRebate { get; set; }

        // Tre dager før utløpsdato
        [MaxLength(10)]
        public string ThreeDaysRebate { get; set; }

        // To dager før utløpsdato
        [MaxLength(10)]
        public string TwoDaysRebate { get; set; }

        // En dag før utløpsdato
        [MaxLength(10)]
        public string OneDayRebate { get; set; }

        // På utløpsdatoen
        [MaxLength(10)]
        public string LastDayRebate { get; set; }

        // Variabler for å holde rede på om rabatt er i % eller kr.
        // Foreslått konvensjon: "percent" for %-rabatt og "fixed" for fastrabatt.
        [MaxLength(10)]
        public string Four_RebateType { get; set; }
        [MaxLength(10)]
        public string Three_RebateType { get; set; }
        [MaxLength(10)]
        public string Two_RebateType { get; set; }
        [MaxLength(10)]
        public string One_RebateType { get; set; }
        [MaxLength(10)]
        public string Last_RebateType { get; set; }

    }
}
