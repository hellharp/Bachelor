﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Databar_skanner.Models
{
    [Table("Produkt")]
    public class Produkt
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(14)]
        public long GTIN { get; set; }

        [ForeignKey(typeof(KategoriRabatt))]
        public string Kategori { get; set; }

        public string Produktnavn { get; set; }

        // Utløpsdato dekker best før/siste forbruksdato
        public DateTime UtlopsDato { get; set; }
    }
}
