using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Pharmalto.Ecosystem.Models
{
    public class EcoProfilePartRecord : ContentPartRecord
    {
        public virtual int ProfileId { get; set; }
    }
}