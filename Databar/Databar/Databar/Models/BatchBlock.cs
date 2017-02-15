using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Models
{
    // Model for å lagre blokkerte batch/lotnumre
    // Blokkert for salg hvis Blocked == true, ikke blokkert hvis false eller hvis BatchNr ikke fins i tabellen.

    [Table("BatchBlock")]
    public class BatchBlock
    {
        // String for å håndtere bindestreker o.l.
        [PrimaryKey]
        public string BatchNr { get; set; }

        // SQLite does not have a separate Boolean storage class.
        // Instead, Boolean values are stored as integers 0 (false) and 1 (true).
        public Boolean Blocked { get; set; }
    }
}
