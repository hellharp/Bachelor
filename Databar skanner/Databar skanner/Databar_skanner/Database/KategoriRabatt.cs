using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Databar_skanner.Database
{
    [Table("KategoriRabatt")]
    class KategoriRabatt
    {
        [PrimaryKey]
        public string Kategori { get; set; }

        public double ToDagerRabatt { get; set; }

        public double EnDagRabatt { get; set; }
    }
}
