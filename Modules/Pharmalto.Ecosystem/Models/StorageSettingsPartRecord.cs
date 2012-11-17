using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Pharmalto.Ecosystem.Models
{
    public class StorageSettingsPartRecord : ContentPartRecord
    {
        public virtual string AccountName { get; set; }
        public virtual string AccountKey { get; set; }
    }
}