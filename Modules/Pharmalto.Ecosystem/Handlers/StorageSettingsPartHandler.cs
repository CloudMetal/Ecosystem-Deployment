using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Localization;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.Handlers
{
    public class StorageSettingsPartHandler : ContentHandler
    {
        public StorageSettingsPartHandler(IRepository<StorageSettingsPartRecord> repository) {
            T = NullLocalizer.Instance;

            Filters.Add(new ActivatingFilter<StorageSettingsPart>("Site"));
            Filters.Add(StorageFilter.For(repository));
        }

        public Localizer T { get; set; }

        protected override void GetItemMetadata(GetContentItemMetadataContext context)
        {
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("Storage")));
        }
    }
}