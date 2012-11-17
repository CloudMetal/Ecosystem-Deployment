using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Pharmalto.Ecosystem.Models
{
    public class HealthViewWidgetPart : ContentPart<HealthViewWidgetPartRecord>
    {
        public string Mode {
            get { return Record.Mode;  }
            set { Record.Mode = value; }
        }
    }
}