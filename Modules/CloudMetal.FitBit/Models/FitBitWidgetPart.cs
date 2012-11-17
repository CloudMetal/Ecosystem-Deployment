using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace CloudMetal.FitBit.Models
{
    public class FitBitWidgetPart : ContentPart<FitBitWidgetPartRecord> {
        public DateTime ActivitiesDate {
            get { return Record.ActivitiesDate; }
            set { Record.ActivitiesDate = value; }
        }
    }
}