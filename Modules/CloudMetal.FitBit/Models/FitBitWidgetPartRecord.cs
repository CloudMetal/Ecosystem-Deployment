using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace CloudMetal.FitBit.Models
{
    public class FitBitWidgetPartRecord : ContentPartRecord
    {
        public virtual DateTime ActivitiesDate { get; set; }
    }
}