using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Databar_skanner.Models
{
    [Table("KategoriRabatt")]
    public class KategoriRabatt
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [PrimaryKey]
        public string Kategori { get; set; }

        // To dager før utløpsdato
        public double ToDagerRabatt { get; set; }

        // En dag før utløpsdato
        public double EnDagRabatt { get; set; }

        // På utløpsdatoen
        public double SisteDagRabatt { get; set; }
    }
}
