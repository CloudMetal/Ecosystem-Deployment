using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Pharmalto.Ecosystem.Models
{
    public class StorageSettingsPart : ContentPart<StorageSettingsPartRecord>
    {
        public string AccountKey {
            get { return Record.AccountKey; }
            set { Record.AccountKey = value; }
        }

        public string AccountName
        {
            get { return Record.AccountName; }
            set { Record.AccountName = value; }
        }
    }
}