using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.Handlers
{
    public class HealthViewWidgetPartHandler : ContentHandler
    {
        public HealthViewWidgetPartHandler(IRepository<HealthViewWidgetPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}