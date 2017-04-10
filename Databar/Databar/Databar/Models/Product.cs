using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
using Newtonsoft.Json;

namespace Databar.Models
{
    [Table("Product")]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Product
    {
        [PrimaryKey, MaxLength(14)]
        [JsonProperty(PropertyName = "GTIN")]
        public long GTIN { get; set; }

        // Produktbeskrivelse
        [MaxLength(100)]
        [JsonProperty(PropertyName = "ProductName")]
        public string ProductName { get; set; }

        // Price
        [MaxLength(100)]
        [JsonProperty(PropertyName = "Price")]
        public double Price { get; set; }

        // Fire dager før utløpsdato
        [MaxLength(10)]
        [JsonProperty(PropertyName = "FourDaysRebate")]
        public string FourDaysRebate { get; set; }

        // Tre dager før utløpsdato
        [MaxLength(10)]
        [JsonProperty(PropertyName = "ThreeDaysRebate")]
        public string ThreeDaysRebate { get; set; }

        // To dager før utløpsdato
        [MaxLength(10)]
        [JsonProperty(PropertyName = "TwoDaysRebate")]
        public string TwoDaysRebate { get; set; }

        // En dag før utløpsdato
        [MaxLength(10)]
        [JsonProperty(PropertyName = "OneDayRebate")]
        public string OneDayRebate { get; set; }

        // På utløpsdatoen
        [MaxLength(10)]
        [JsonProperty(PropertyName = "LastDayRebate")]
        public string LastDayRebate { get; set; }

        // Variabler for å holde rede på om rabatt er i % eller kr.
        // Foreslått konvensjon: "percent" for %-rabatt og "fixed" for fastrabatt.
        [MaxLength(10)]
        [JsonProperty(PropertyName = "Four_RebateType")]
        public string Four_RebateType { get; set; }
        [MaxLength(10)]
        [JsonProperty(PropertyName = "Three_RebateType")]
        public string Three_RebateType { get; set; }
        [MaxLength(10)]
        [JsonProperty(PropertyName = "Two_RebateType")]
        public string Two_RebateType { get; set; }
        [MaxLength(10)]
        [JsonProperty(PropertyName = "One_RebateType")]
        public string One_RebateType { get; set; }
        [MaxLength(10)]
        [JsonProperty(PropertyName = "Last_RebateType")]
        public string Last_RebateType { get; set; }

    }
}
