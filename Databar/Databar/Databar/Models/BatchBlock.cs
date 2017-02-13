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
    public class BatchBlock
    {
        // String for å håndtere bindestreker o.l.
        [PrimaryKey]
        public string BatchNr { get; set; }

        public Boolean Blocked { get; set; }
    }
}
