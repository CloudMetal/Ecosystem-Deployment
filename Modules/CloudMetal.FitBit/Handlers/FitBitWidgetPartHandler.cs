using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudMetal.FitBit.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace CloudMetal.FitBit.Handlers
{
    public class FitBitWidgetPartHandler : ContentHandler
    {
        public FitBitWidgetPartHandler(IRepository<FitBitWidgetPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}