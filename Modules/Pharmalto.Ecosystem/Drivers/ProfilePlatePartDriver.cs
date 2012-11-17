using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.Drivers
{
    public class ProfilePlatePartDriver : ContentPartDriver<ProfilePlatePart>
    {
        protected override string Prefix
        {
            get { return "ProfilePlate"; }
        }

        protected override DriverResult Display(
            ProfilePlatePart part, string displayType, dynamic shapeHelper)
        {
            // attach the current profile and pass in...

            return ContentShape("Parts_ProfilePlate", () => shapeHelper.Parts_ProfilePlate(
                ProfilePlate: part));
        }
    }
}