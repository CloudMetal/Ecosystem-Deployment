using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Security;
using Pharmalto.Ecosystem.Services;

namespace Pharmalto.Ecosystem.Controllers
{
    public class LifestyleController : BaseController
    {
        public LifestyleController(IAuthenticationService authenticationService, IEcoUserService ecoUserService, IEcoProfileService ecoProfileService) : base(authenticationService, ecoUserService, ecoProfileService) {}

        public ActionResult Index() {
            return View();
        }
    }
}