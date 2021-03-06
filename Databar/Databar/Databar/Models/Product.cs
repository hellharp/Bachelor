using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Databar.Models
{
    /// <summary>
    /// Model for Products 
    /// </summary>
    [Table("Product")]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Product
    {
        /// <summary>
        /// Global Trade Identification Number
        /// </summary>
        [PrimaryKey, MaxLength(14)]
        [JsonProperty(PropertyName = "GTIN")]
        public string GTIN { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [MaxLength(100)]
        [JsonProperty(PropertyName = "ProductName")]
        public string ProductName { get; set; }

        /// <summary>
        /// Given discount for four days before expiration or best before date
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(PropertyName = "FourDaysRebate")]
        public string FourDaysRebate { get; set; }

        /// <summary>
        /// Given discount for three days before expiration or best before date
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(PropertyName = "ThreeDaysRebate")]
        public string ThreeDaysRebate { get; set; }

        /// <summary>
        /// Given discount for two days before expiration or best before date
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(PropertyName = "TwoDaysRebate")]
        public string TwoDaysRebate { get; set; }

        /// <summary>
        /// Given discount for the day before expiration or best before date
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(PropertyName = "OneDayRebate")]
        public string OneDayRebate { get; set; }

        /// <summary>
        /// Given discount for the day of the expiration or best before date
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(PropertyName = "LastDayRebate")]
        public string LastDayRebate { get; set; }

        /// <summary>
        /// Method to concatenate name and price into one string
        /// </summary>
        public string ProductNameAndPrice
        {
            get
            {
                return ProductName + "\nOrd. Pris:" + Price;
            }
            set
            {
                ProductNameAndPrice = value;
            }
        }

        /// <summary>
        /// Method to get or set the CurrentRebate
        /// </summary>
        public string CurrentRebate { get; set; }

        /// <summary>
        /// Method to get or set the CurrentRebateType
        /// </summary>
        public string CurrentRebateType { get; set; }

        /// <summary>
        /// Method to concatenate CurrentRebate and CurrentRebateType
        /// </summary>
        public string CurrentRebateAndType { get; set; }

        /// <summary>
        /// Method to get or set items RebatedPrice
        /// </summary>
        public decimal RebatedPrice { get; set; }

        /// <summary>
        /// Variable which determines if the four day discount is calculated trough percentage og a fixed amount
        /// </summary>

        public List<String> DateList { get; set; }

        /// <summary>
        /// Variable which determines if the four day discount is calculated trough percentage og a fixed amount
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(PropertyName = "Four_RebateType")]
        public string Four_RebateType { get; set; }

        /// <summary>
        /// Variable which determines if the three day discount is calculated trough percentage og a fixed amount
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(PropertyName = "Three_RebateType")]
        public string Three_RebateType { get; set; }

        /// <summary>
        /// Variable which determines if the two day discount is calculated trough percentage og a fixed amount
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(PropertyName = "Two_RebateType")]
        public string Two_RebateType { get; set; }

        /// <summary>
        /// Variable which determines if the one day discount is calculated trough percentage og a fixed amount
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(PropertyName = "One_RebateType")]
        public string One_RebateType { get; set; }

        /// <summary>
        /// Variable which determines if the last day discount is calculated trough percentage og a fixed amount
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(PropertyName = "Last_RebateType")]

        /// <summary>
        /// Method to get or set the last day rebate type
        /// </summary>
        public string Last_RebateType { get; set; }

        /// <summary>
        /// Method to get or set today's rebate
        /// </summary>
        public string TodaysRebate { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        [MaxLength(100)]
        [JsonProperty(PropertyName = "Price")]
        public string Price { get; set; }
    }
}
