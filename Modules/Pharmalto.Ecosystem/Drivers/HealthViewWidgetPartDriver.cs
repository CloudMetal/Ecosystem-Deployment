using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.Drivers
{
    public class HealthViewWidgetPartDriver : ContentPartDriver<HealthViewWidgetPart>
    {
        protected override DriverResult Display(
            HealthViewWidgetPart part, string displayType, dynamic shapeHelper) {

            return ContentShape("Parts_HealthViewWidget", () => shapeHelper.Parts_HealthViewWidget(
                HealthViewWidget: part));
        }

        //GET
        protected override DriverResult Editor(
            HealthViewWidgetPart part, dynamic shapeHelper) {

            return ContentShape("Parts_HealthViewWidget_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/HealthViewWidget",
                    Model: part,
                    Prefix: Prefix));
        }
        //POST
        protected override DriverResult Editor(
            HealthViewWidgetPart part, IUpdateModel updater, dynamic shapeHelper) {

            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}