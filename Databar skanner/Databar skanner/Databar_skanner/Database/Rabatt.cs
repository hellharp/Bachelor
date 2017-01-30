using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar_skanner.Database
{
    class Rabatt
    {
        [PrimaryKey]
        public int Kategori { get; set; }
        public double ToDagerRabatt { get; set; }
        public double EnDagRabatt { get; set; }
    }
}
