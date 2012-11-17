using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace CloudMetal.FitBit.Models
{
    public class OAuthSettingsRecord : ContentPartRecord
    {
        public virtual string ClientId { get; set; }
        public virtual string ClientSecret { get; set; }
    }
}