using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Localization;
using Orchard.UI.Navigation;

namespace Pharmalto.Ecosystem.Navigation
{
    public class EcosystemMenuProvider : IMenuProvider
    {
        public EcosystemMenuProvider() {
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public void GetMenu(Orchard.ContentManagement.IContent menu, NavigationBuilder builder)
        {
            builder.Add(T("Lifestyle"), "2", item => item.Action("Index", "Lifestyle", new { area = "Pharmalto.Ecosystem" }));
            builder.Add(T("Supplements"), "2", item => item.Action("Index", "Supplements", new { area = "Pharmalto.Ecosystem" }));
            //builder.Add(T("My Groups"), "2", item => item.Action("Index", "Groups", new { area = "Pharmalto.Ecosystem" }));
            //builder.Add(T("My Albums"), "2", item => item.Action("Index", "Album", new { area = "Pharmalto.Ecosystem" }));
            //builder.Add(T("My Gallery"), "2", item => item.Action("Index", "Gallery", new { area = "Pharmalto.Ecosystem" }));
            //builder.Add(T("My Health Plan"), "2", item => item.Action("Index", "HealthPlan", new { area = "Pharmalto.Ecosystem" }));
            //builder.Add(T("My Health Tracker"), "2", item => item.Action("Index", "Fitness", new { area = "Pharmalto.Ecosystem" }));
        }
    }
}