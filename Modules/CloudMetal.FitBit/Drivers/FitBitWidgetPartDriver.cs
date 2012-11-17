using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudMetal.FitBit.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace CloudMetal.FitBit.Drivers
{
    public class FitBitWidgetPartDriver : ContentPartDriver<FitBitWidgetPart> {

        protected override DriverResult Display(
            FitBitWidgetPart part, string displayType, dynamic shapeHelper)
        {

            return ContentShape("Parts_FitBitWidget", () => shapeHelper.Parts_FitBitWidget(
                HealthViewWidget: part));
        }

        //GET
        protected override DriverResult Editor(
            FitBitWidgetPart part, dynamic shapeHelper)
        {

            return ContentShape("Parts_FitBitWidget_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/FitBitWidget",
                    Model: part,
                    Prefix: Prefix));
        }
        //POST
        protected override DriverResult Editor(
            FitBitWidgetPart part, IUpdateModel updater, dynamic shapeHelper)
        {

            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}