using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace CloudMetal.FitBit.Models
{
    public class OAuthSettingsPart : ContentPart<OAuthSettingsRecord>
    {
        public string ClientId {
            get { return Record.ClientId; }
            set { Record.ClientId = value; }
        }

        public string ClientSecret {
            get { return Record.ClientSecret; }
            set { Record.ClientSecret = value; }
        }
    }
}