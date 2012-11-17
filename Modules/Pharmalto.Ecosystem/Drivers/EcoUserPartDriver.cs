using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.Drivers
{
    public class EcoUserPartDriver : ContentPartDriver<EcoUserPart> {
        protected override string Prefix
        {
            get { return "EcoUser"; }
        }

        protected override DriverResult Editor(EcoUserPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_EcoUser_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/EcoUser", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(EcoUserPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}