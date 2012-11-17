using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedVault.Framework.Model;
using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.Themes;
using Orchard.Users.Models;
using Pharmalto.Ecosystem.Models;
using Pharmalto.Ecosystem.Services;
using Pharmalto.Ecosystem.ViewModels;

namespace Pharmalto.Ecosystem.Controllers
{
    [Themed]
    public class HomeController : BaseController
    {
        private readonly dynamic _shapeFactory;
        private readonly IMembershipService _membershipService;
        private readonly Localizer _t;
        private readonly IEcoMedicineService _medicineService;
        private readonly IOrchardServices _orchardServices;

        public HomeController(IShapeFactory shapeFactory, IAuthenticationService authenticationService,
            IMembershipService membershipService,
            IEcoMedicineService medicineService,
            IEcoUserService ecoUserService,
            IEcoProfileService ecoProfileService,
            IOrchardServices orchardServices) : base(authenticationService, ecoUserService, ecoProfileService) {
            _shapeFactory = shapeFactory;
            _membershipService = membershipService;
            _medicineService = medicineService;
            _orchardServices = orchardServices;
            _t = NullLocalizer.Instance;
        }

        public ActionResult Index() {
            var user = AuthenticationService.GetAuthenticatedUser();
            if (user == null)
                return RedirectToAction("Login");

            IEnumerable<Medicine> medicines = null;
            if (FirstProfile != null) {
                medicines = _medicineService.GetMedicines(m => m.ProfileId == FirstProfile.Id);
            }

            EcoUserPart ecoUser = null;
            if (PharmaltoUser != null) {
                var ecoUserQuery = _orchardServices.ContentManager.Query<EcoUserPart, EcoUserPartRecord>().Where(e => e.UserId == PharmaltoUser.Id);
                ecoUser = ecoUserQuery.List().FirstOrDefault();
            }

            if (medicines == null) {
                medicines = Enumerable.Empty<Medicine>();
            }
            var model = new HomeIndexViewModel {
                Medicines = medicines,
                User = ecoUser
            };
            return View(model);
        }

        public ActionResult Detail(int id) {
            var user = AuthenticationService.GetAuthenticatedUser();
            if (user == null)
                return RedirectToAction("Login");

            var medicine = _medicineService.GetMedicine(id);

            var shape = _shapeFactory.Medicine_Detail(Medicine: medicine);
            return new ShapeResult(this, shape);
        }

        [Themed]
        public ActionResult Register() {
            var user = AuthenticationService.GetAuthenticatedUser();
            if (user != null)
                return RedirectToAction("Index");

            var shape = _shapeFactory.Register();
            return new ShapeResult(this, shape);
        }

        [Themed, HttpPost, ActionName("Register")]
        public ActionResult POSTRegister(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return new ShapeResult(this, _shapeFactory.Register(Register: register));

            var ecoUser = EcoUserService.CreateUser(register.Email, register.Password);

            var user = ecoUser.As<UserPart>();

            AuthenticationService.SignIn(user, true);

            return RedirectToAction("Index");
        }

        [Themed]
        public ActionResult Login()
        {
            var user = AuthenticationService.GetAuthenticatedUser();
            if (user != null)
                return RedirectToAction("Index");

            var shape = _shapeFactory.Login();
            return new ShapeResult(this, shape);
        }

        [Themed, HttpPost, ActionName("Login")]
        public ActionResult POSTLogin(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return new ShapeResult(this, _shapeFactory.Login(Login: login));

            var user = _membershipService.ValidateUser(login.Email, login.Password);

            // If no user was found, add a model error
            if (user == null)
            {
                ModelState.AddModelError("Email", _t("Incorrect username/password combination").ToString());
            }

            // If there are any model errors, redisplay the login form
            if (!ModelState.IsValid)
            {
                var shape = _shapeFactory.Login(Login: login);
                return new ShapeResult(this, shape);
            }

            // Create a forms ticket for the user
            AuthenticationService.SignIn(user, login.CreatePersistentCookie);

            return RedirectToAction("Index");
        }
    }
}