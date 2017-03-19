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
        public string ProductName { get; set; }

        //// Utløpsdato dekker best før/siste forbruksdato
        //public DateTime BestBeforeDate { get; set; }

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

        // Variabler for å holde rede på om rabatt er i % eller kr.
        // Foreslått konvensjon: "percent" for %-rabatt og "fixed" for fastrabatt.

        public string Four_RebateType { get; set; }
        public string Three_RebateType { get; set; }
        public string Two_RebateType { get; set; }
        public string One_RebateType { get; set; }
        public string Last_RebateType { get; set; }

    }
}
