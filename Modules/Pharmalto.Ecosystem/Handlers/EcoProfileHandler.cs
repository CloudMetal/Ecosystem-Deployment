using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.Handlers
{
    public class EcoProfileHandler : ContentHandler
    {
        public EcoProfileHandler(IRepository<EcoProfilePartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}