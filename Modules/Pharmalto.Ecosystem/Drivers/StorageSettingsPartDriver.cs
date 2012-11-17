using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.Drivers
{
    public class StorageSettingsPartDriver : ContentPartDriver<StorageSettingsPart>
    {
        private const string TemplateName = "Parts/StorageSettings";

        public StorageSettingsPartDriver() {
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        protected override string Prefix { get { return "StorageSettings"; } }

        protected override DriverResult Editor(StorageSettingsPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_StorageSettings_Edit",
                    () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix))
                    .OnGroup("storage");
        }

        protected override DriverResult Editor(StorageSettingsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            return ContentShape("Parts_StorageSettings_Edit", () =>
            {
                updater.TryUpdateModel(part, Prefix, null, null);
                return shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix);
            })
                .OnGroup("storage");
        }
    }

    
}