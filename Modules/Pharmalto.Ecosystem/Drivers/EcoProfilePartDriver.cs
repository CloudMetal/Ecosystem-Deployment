using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.Drivers
{
    public class EcoProfilePartDriver : ContentPartDriver<EcoProfilePart>
    {
        protected override DriverResult Display(
            EcoProfilePart part, string displayType, dynamic shapeHelper)
        {

            return ContentShape("Parts_EcoProfile", () => shapeHelper.Parts_EcoProfile(
                EcoProfile: part));
        }

        //GET
        protected override DriverResult Editor(
            EcoProfilePart part, dynamic shapeHelper)
        {

            return ContentShape("Parts_EcoProfile_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/EcoProfile",
                    Model: part,
                    Prefix: Prefix));
        }
        //POST
        protected override DriverResult Editor(
            EcoProfilePart part, IUpdateModel updater, dynamic shapeHelper)
        {

            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}