using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedVault.Framework.Model;
using Orchard.ContentManagement;

namespace Pharmalto.Ecosystem.Models
{
    public class EcoProfilePart : ContentPart<EcoProfilePartRecord>
    {
        public int ProfileId {
            get { return Record.ProfileId; }
            set { Record.ProfileId = value; }
        }

        public Profile Profile { get; set; }
    }
}