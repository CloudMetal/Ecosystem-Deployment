using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmalto.Ecosystem.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string Upload(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Upload", "Storage", new { area = "Pharmalto.Ecosystem" });
        }
        
    }
}