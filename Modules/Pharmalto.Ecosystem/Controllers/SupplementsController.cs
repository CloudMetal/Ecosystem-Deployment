using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedVault.Framework.Model.Service;
using Orchard.Mvc;
using Orchard.Security;
using Pharmalto.Ecosystem.Services;

namespace Pharmalto.Ecosystem.Controllers
{
    public class SupplementsController : BaseController {
        private readonly IEcoSupplementService _ecoSupplementService;
        private dynamic _shapeFactory;

        public SupplementsController(IAuthenticationService authenticationService, IEcoUserService ecoUserService, IEcoProfileService ecoProfileService) : base(authenticationService, ecoUserService, ecoProfileService) {}

        public ActionResult Index() {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var user = AuthenticationService.GetAuthenticatedUser();
            if (user == null)
                return RedirectToAction("Login", "Home");

            var medicine = _ecoSupplementService.GetById(id);

            var shape = _shapeFactory.Supplement_Detail(Medicine: medicine);
            return new ShapeResult(this, shape);
        }
    }
}